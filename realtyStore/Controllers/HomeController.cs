using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using realtyStore.Models;
using System.Web.Security;
using System.Security.Principal;

namespace realtyStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        static RealtyContext db = new RealtyContext();

        public ActionResult toogleFavorite(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.LogIn == User.Identity.Name);
            var r = db.Realties.FirstOrDefault(rl => rl.Id == id);
                if (user != null) {
                    var favorites = db.FavoriteRealties.Where(f => f.UserId == user.Id).ToList();
                    if (favorites != null) {
                    var existFR = favorites.FirstOrDefault(fr => fr.RealtyId == id);

                        if (existFR == null)
                        {
                            db.FavoriteRealties.Add( new FavoriteRealties { RealtyId = id, UserId = user.Id });
                            r.isFavorite = true;
                        }
                        else
                        {
                            db.FavoriteRealties.Remove(existFR);
                            r.isFavorite = false;
                        }
                    }
                    else if (favorites == null)
                    {
                        db.FavoriteRealties.Add(new FavoriteRealties { UserId = user.Id, RealtyId = id  });
                        db.Realties.FirstOrDefault(rl => rl.Id == id).isFavorite = true;
                    }
                } else {
                    r.isFavorite = !r.isFavorite;
                }
                    db.SaveChanges();
            return PartialView(new toggleParams { id = r.Id, isFavorite = r.isFavorite });//Redirect(Request.Headers["Referer"].ToString());
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            initialFavorites(db.Realties);
            ViewBag.status = Statuses.RENT_OUT;
            ViewBag.ShowResult = false;
            ViewBag.Cities = db.Cities;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(SearchParams param, string status)
        {
            ViewBag.status = status;
            IList<Realty> realties = db.Realties.Where(r => r.Status == status && r.CityId == param.CityId).ToList();
            if (param.RealtyType != null)
            {
                realties = realties.Where(r => r.Type == param.RealtyType).ToList();
            }

            if (param.MinPrice != null)
            {
                realties = realties.Where(r => r.Price >= param.MinPrice).ToList();
            }

            if (param.MaxPrice != null)
            {
                realties = realties.Where(r => r.Price <= param.MaxPrice).ToList();
            }

            if (param.MinSquare != null)
            {
                realties = realties.Where(r => r.Square >= param.MinSquare).ToList();
            }

            if (param.MaxSquare != null)
            {
                realties = realties.Where(r => r.Square <= param.MaxSquare).ToList();
            }

            if (param.NumberRooms != null && param.RealtyType == Types.HOUSE && param.RealtyType == Types.APARTMENT)
            {
                IEnumerable<Realty> buf = null;
                foreach(string n in param.NumberRooms)
                {
                    if (buf == null)
                    {
                        buf = realties.Where(r => r.NumberRoom == Convert.ToInt16(n)).ToList();
                    } else {
                        buf = buf.Concat(realties.Where(r => r.NumberRoom == Convert.ToInt16(n)).ToList());
                    }
                    if (Convert.ToInt16(n) == 5)
                    {
                        buf = buf.Concat(realties.Where(r => r.NumberRoom >= Convert.ToInt16(n)).ToList());

                    }
                }
                realties = buf.ToList();
            }
            ViewBag.ShowResult = true;
            if (realties == null || realties.Count == 0) {
                ViewBag.TextResult = "Ничего не найдено";
            }

            var user = db.Users.FirstOrDefault(u => u.LogIn == User.Identity.Name);
            ViewBag.Realties = realties;
            ViewBag.Cities = db.Cities;
            return View();
                    
        }
        
        public ActionResult Flat(int? id)
        {
            Realty realty = db.Realties.FirstOrDefault(r => r.Id == id);
            if (realty != null)
            {
                var user = db.Users.FirstOrDefault(u => u.LogIn == User.Identity.Name);
                if ((realty.Status == Statuses.LEASED || realty.Status == Statuses.SOLD) && (!User.Identity.IsAuthenticated || (User.Identity.IsAuthenticated && user.RoleId == 1 && realty.OwnerId != user.Id)))
                {
                    return Redirect($"/flat{id}");
                }
                if (realty.RealtorId != null)
                {
                    myUser realtor = db.Users.FirstOrDefault(r => r.Id == realty.RealtorId);
                    ViewBag.Phone = realtor.Phone;
                    ViewBag.Name = realtor.FirstName + "(риэлтор)";
                } else
                {
                    myUser owner = db.Users.FirstOrDefault(r => r.Id == realty.OwnerId);
                    ViewBag.Phone = owner.Phone;
                    ViewBag.Name = owner.FirstName;
                }
                if (realty.ImgUrl != null)
                {
                    realty.ImgUrl = realty.ImgUrl.Trim();
                    ViewBag.ImgUrl = realty.ImgUrl.Split(' ');
                } 

                ViewBag.City = db.Cities.FirstOrDefault(c => c.Id == realty.CityId).Name;
                return View(realty);
        }
            return Redirect($"/flat{id}");
        }

        public IEnumerable<Realty> initialFavorites(IEnumerable<Realty> realties)
        {
            myUser user = db.Users.FirstOrDefault(u => u.LogIn == User.Identity.Name);
            if (user != null)
            {
                var favorites = db.FavoriteRealties.Where(f => f.UserId == user.Id).ToList();
                List<int> fRId = new List<int> { };

                foreach (var fr in favorites)
                {
                    fRId.Add(fr.RealtyId);
                }
                foreach (var rl in realties)
                {
                    rl.isFavorite = fRId.Exists(id => id == rl.Id);
                }
            }
            db.SaveChanges();
            return realties;
        }

        public ActionResult FavoriteRealties()
        {
            IEnumerable<Realty> realties = db.Realties; 
           
            ViewBag.Realties = initialFavorites(realties).Where(r => r.isFavorite == true).ToList();
            ViewBag.Title = "Избранное";
            return View("Realties");
        }      

        [HttpGet]
        [Authorize]
        public ActionResult FormNewRealty()
        {
            ViewBag.OwnerId = db.Users.FirstOrDefault(u => u.LogIn == User.Identity.Name);
            ViewBag.Cities = db.Cities;
            return View();
        }
        [HttpPost]
        public ActionResult FormNewRealty(Realty realty)
        {
            realty.ImgUrl = "https://thenationalpilot.ng/wp-content/uploads/2017/07/small-add-placeholder.png";
            realty.OwnerId = db.Users.FirstOrDefault(u => u.LogIn == User.Identity.Name).Id;
            db.Realties.Add(realty);
            db.SaveChanges();
            return RedirectToAction("Flat", "Home", new { id = realty.Id });
        }
        public ActionResult AddPhoto(int id)
        {
            myUser user = db.Users.FirstOrDefault(u => u.LogIn == User.Identity.Name);
            Realty realty = db.Realties.FirstOrDefault(r => r.Id == id);
            if (user.Id == realty.OwnerId)
            {
                ViewBag.realtyId = id;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult MyFlats()
        {
            myUser user = db.Users.FirstOrDefault(u => u.LogIn == User.Identity.Name);
            ViewBag.Realties = db.Realties.Where(r => r.OwnerId == user.Id).ToList();
            ViewBag.Title = "Мои объявления";
            return View("Realties");
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] uploads, int? realtyId)
        {
            string path = "";
            if (realtyId != null)
            {
                path = AppDomain.CurrentDomain.BaseDirectory + $"Files\\{realtyId}";
            } else
            {
                path = AppDomain.CurrentDomain.BaseDirectory + $"Files";
            }
            foreach (var file in uploads)
            {
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (file != null)
                    {
                        // получаем имя файла
                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        // сохраняем файл в папку Files/{id} в проекте
                        if (fileName.IndexOf(' ') != -1)
                        {
                            fileName = fileName.Replace(' ', '1');
                        }
                        file.SaveAs(Server.MapPath($"~/Files/{realtyId}/" + fileName));
                        var r = db.Realties.FirstOrDefault(rl => rl.Id == realtyId);
                        if (r.ImgUrl.Split(' ').Length == 1 && r.ImgUrl.Contains("placeholder"))
                        {
                            r.ImgUrl = $"/Files/{realtyId}/{fileName}";
                        } else
                        {
                            r.ImgUrl += $" /Files/{ realtyId}/{fileName}";
                        }

                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                    return Redirect($"/flat{realtyId}");
                }
            }

            return RedirectToAction("Flat", "Home", new { id = realtyId });
        }

        [HttpGet]
        public ActionResult SelectionOfRealtor()
        {
            //ViewBag.Cities = db.Cities;
            return View();
        }
        [HttpPost]
        public ActionResult SelectionOfRealtor(ApplicationToRealtor param)
        {
            db.Apps.Add(param);
            db.SaveChanges();
            return RedirectToAction("answer");
        }
        public ActionResult answer()
        {
            return View();
        }

    }
}