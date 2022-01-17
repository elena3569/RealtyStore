 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using realtyStore.Models;


namespace realtyStore.Controllers
{

    public class RealtorModeController : Controller
    {
        const string imgUrl = "https://thenationalpilot.ng/wp-content/uploads/2017/07/small-add-placeholder.png";
        RealtyContext db = new RealtyContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string action)
        {
            if (action == "showOwners")
            {
                IEnumerable<myUser> owners = new myUser[] { };
                foreach(var r in db.Realties)
                {
                    var owner = db.Users.FirstOrDefault(u => u.Id == r.OwnerId);
                    owner.Address = "г. " + db.Cities.FirstOrDefault(c => c.Id == owner.CityId).Name + ", " + owner.Address;
                    if (owners.FirstOrDefault(b => b.Id == owner.Id) == null)
                    {
                        owners = owners.Prepend(owner);
                    }
                }
                   
                ViewBag.Table = owners.Reverse();


                ViewBag.TableName = "Владельцы";
                ViewBag.Count = owners.ToList().Count;
            }
            else if (action == "showBuyers")
            {
                ViewBag.TableName = "Арендаторы/покупатели";
                IEnumerable<myUser> buyers = new myUser[] { };
                foreach (var l in db.Leased)
                {
                    var buyer = db.Users.FirstOrDefault(u => u.Id == l.BuyerId);
                    buyer.Address = "г. " + db.Cities.FirstOrDefault(c => c.Id == buyer.CityId).Name + ", " + buyer.Address;
                    if (buyers.FirstOrDefault(b => b.Id == buyer.Id) == null)
                    {
                        buyers = buyers.Prepend(buyer);
                    }
                }
                
                foreach (var s in db.Sold)
                {
                    var buyer = db.Users.FirstOrDefault(u => u.Id == s.BuyerId);
                    buyer.Address = "г. " + db.Cities.FirstOrDefault(c => c.Id == buyer.CityId).Name + ", " + buyer.Address;
                    if(buyers.FirstOrDefault(b => b.Id == buyer.Id) == null)
                    {
                        buyers = buyers.Prepend(buyer);
                    }
                }

                ViewBag.Table = buyers.Reverse();

                ViewBag.Count = buyers.ToList().Count;
            }
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "realtor")]
        public ActionResult Dial()
        {
            ViewBag.TableNameSold = "Сделки по продаже";

            ViewBag.TableSold = db.Sold;
            ViewBag.SoldCount = db.Sold.Count();

            foreach (Sold s in ViewBag.TableSold)
            {
                s.Address = "г." + db.Cities.FirstOrDefault(c => c.Id == s.CityId).Name + ", " + s.Address;
            }
            
            
            ViewBag.TableNameLeased = "Сделки по аренде";
            ViewBag.TableLeased = db.Leased;
            ViewBag.LeasedCount = db.Leased.Count();

            foreach (Leased l in ViewBag.TableLeased)
            {
                l.Address = "г." + db.Cities.FirstOrDefault(c => c.Id == l.CityId).Name + ", " + l.Address;
            }
            
            return View();
        }
        [HttpPost]
        [Authorize(Roles="realtor")]
        public ActionResult Dial(string action, string DateCheckout, int? Id)
        {
            if (action == "SaveNewDate")
            {
                db.Leased.FirstOrDefault(l => l.Id == Id).DateCheckOut = DateCheckout;
                db.SaveChanges();
            }
            if (action == "UpdateLeased")
            {
                
                foreach (Leased l in db.Leased)
                {
                    if (l != null)
                    {
                        var d1 = DateTime.Parse(l.DateCheckOut).Date;
                        var d2 = DateTime.Now.Date;
                        int result = DateTime.Compare(d1, d2);
                        if (result < 0)
                        {
                            db.Realties.FirstOrDefault(r => r.Id == l.RealtyId).Status = l.Status;
                            db.Leased.Remove(l);
                        }

                    }
                }
                db.SaveChanges();

            }

            ViewBag.TableNameSold = "Сделки по продаже";

            ViewBag.TableSold = db.Sold;
            ViewBag.SoldCount = db.Sold.Count();

            foreach (Sold s in ViewBag.TableSold)
            {
                s.Address = "г." + db.Cities.FirstOrDefault(c => c.Id == s.CityId).Name + ", " + s.Address;
            }


            ViewBag.TableNameLeased = "Сделки по аренде";
            ViewBag.TableLeased = db.Leased;
            ViewBag.LeasedCount = db.Leased.Count();

            foreach (Leased l in ViewBag.TableLeased)
            {
                l.Address = "г." + db.Cities.FirstOrDefault(c => c.Id == l.CityId).Name + ", " + l.Address;
            }

            return View();
        }


        [HttpGet]
        [Authorize(Roles="realtor")]
        public ActionResult Apps()
        {
            ViewBag.TableName = "Заявки";           
            ViewBag.Table = db.Apps;
            ViewBag.Count = db.Apps.Count();

            foreach (ApplicationToRealtor l in ViewBag.Table)
            {
                l.Address = "г." + db.Cities.FirstOrDefault(c => c.Id == l.CityId).Name + ", " + l.Address;
            }
            return View();
        }

        [Authorize(Roles="realtor")]
        public ActionResult Realtor(int? id)
        {
            myUser realtor = db.Users.FirstOrDefault(r => r.Id == id);
            ViewBag.men = realtor;
            ViewBag.address = db.Cities.FirstOrDefault(c => c.Id == realtor.CityId).Name + ", " + realtor.Address;
            return View();
        }
        [Authorize(Roles="realtor")]
        public ActionResult ShowUser(int? id)
        {
            myUser user = db.Users.FirstOrDefault(b => b.Id == id);
            ViewBag.men = user;
            ViewBag.address = db.Cities.FirstOrDefault(c => c.Id == user.CityId).Name + ", " + user.Address;
            return View();
        }
        [Authorize(Roles="realtor")]
        public ActionResult PlaceApp(int? id)
        {
            ApplicationToRealtor app = db.Apps.FirstOrDefault(a => a.Id == id);
            myUser owner = db.Users.FirstOrDefault(a => a.Patronymic == app.Patronymic 
                                                     && a.LastName == app.LastName 
                                                     && a.FirstName == app.FirstName 
                                                     || a.Phone == app.Phone);
            if (owner == null)
            {
                owner = new myUser { CityId = app.CityId,
                    FirstName = app.FirstName,
                    LastName = app.LastName,
                    Patronymic = app.Patronymic,
                    Passport = app.Passport,
                    Phone = app.Phone,
                    Address = app.Address
                };
                db.Users.Add(owner);
                db.SaveChanges();
            }

            db.Realties.Add(new Realty{ ImgUrl = imgUrl, Type = app.RealtyType, NumberRoom = app.NumberRoom, Address = app.Address, Square = app.Square, Floor = app.Floor, Floors = app.Floors, Status = app.Status, CityId = app.CityId, OwnerId = owner.Id, Price = app.Price, Description = app.Description, RealtorId = 1 });
            db.Apps.Remove(app);
            db.SaveChanges();
            return RedirectToAction("Apps", "RealtorMode");
        }
        [HttpGet]
        [Authorize(Roles="realtor")]
        public ActionResult EditApp(int? id)
        {
            ViewBag.Cities = db.Cities;
            return View(db.Apps.FirstOrDefault(a => a.Id == id));
        }
        [HttpPost]
        [Authorize(Roles="realtor")]
        public ActionResult EditApp(ApplicationToRealtor app)
        {
            ApplicationToRealtor oldApp = db.Apps.FirstOrDefault(a => a.Id == app.Id);
            oldApp.RealtyType = app.RealtyType;
            oldApp.Phone = app.Phone;
            oldApp.Square = app.Square;
            oldApp.LastName = app.LastName;
            oldApp.Status = app.Status;
            oldApp.FirstName = app.FirstName;
            oldApp.Patronymic = app.Patronymic;
            oldApp.Address = app.Address;
            oldApp.Description = app.Description;
            oldApp.Price = app.Price;
            oldApp.CityId = app.CityId;
            oldApp.Floors = app.Floors;
            oldApp.Floor = app.Floor;
            oldApp.NumberRoom = app.NumberRoom;
            db.SaveChanges();
            return RedirectToAction("Apps", "RealtorMode");
        }

        [HttpGet]
        [Authorize(Roles = "realtor")]
        public ActionResult Realties()
        {
            ViewBag.TableName = "Все объявления";
            ViewBag.Table = db.Realties;
            foreach (Realty r in ViewBag.Table)
            {
                r.Address = "г." + db.Cities.FirstOrDefault(c => c.Id == r.CityId).Name + ", " + r.Address;
            }

            ViewBag.Count = db.Realties.Count();
            return View();
        }
        [HttpPost]
        [Authorize(Roles="realtor")]
        public ActionResult Realties(int? Id)
        {
            db.Realties.Remove(db.Realties.FirstOrDefault(r => r.Id == Id));
            db.SaveChanges();
            ViewBag.TableName = "Все объявления";
            ViewBag.Table = db.Realties;
            ViewBag.Count = db.Realties.Count();
            return View();
        }
       
        [HttpGet]
        [Authorize(Roles="realtor")]
        public ActionResult EditRealty(int? id)
        {
            ViewBag.Cities = db.Cities;
            return View(db.Realties.FirstOrDefault(r => r.Id == id));
        }
        [HttpPost]
        [Authorize(Roles="realtor")]
        public ActionResult EditRealty(int Id, string Status, string Description, string date)
        {
            Realty realty = db.Realties.FirstOrDefault(a => a.Id == Id);
            
            realty.Description = Description;

            if(Status == Statuses.LEASED)
            {
                var l = new Leased
                {
                    RealtyId = realty.Id,
                    Status = realty.Status,
                    RealtyType = realty.Type,
                    CityId = realty.CityId,
                    Address = realty.Address,
                    Date = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                    Price = realty.Price,
                    RealtorId = realty.RealtorId,
                    OwnerId = realty.OwnerId,
                    DateCheckOut = date
                };
                db.Leased.Add(l);
                realty.Status = Status;
                db.SaveChanges();
                return RedirectToAction("BuyerForm", "RealtorMode", new { id = l.Id, type ="leased"});

            }
            if (Status == Statuses.SOLD)
            {
                var s = new Sold
                {
                    RealtyType = realty.Type,
                    CityId = realty.CityId,
                    Address = realty.Address,
                    Date = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                    Price = realty.Price,
                    RealtorId = realty.RealtorId,
                    OwnerId = realty.OwnerId,
                };
                db.Sold.Add(s);
                db.Realties.Remove(realty);
                db.SaveChanges();
                return RedirectToAction("BuyerForm", "RealtorMode", new { id = s.Id, type = "sold"});
            }

            db.SaveChanges();
            
            return RedirectToAction("Realties", "RealtorMode");
        }

        [HttpGet]
        [Authorize(Roles="realtor")]
        public ActionResult BuyerForm(int? id, string type)
        {
            ViewBag.Cities = db.Cities;
            ViewBag.Id = id;
            ViewBag.type = type;
            return View();
        }
        [HttpPost]
        [Authorize(Roles="realtor")]
        public ActionResult BuyerForm(int dialId, string type, myUser buyer)
        {
            myUser findBuyer = db.Users.FirstOrDefault(a => a.Patronymic == buyer.Patronymic && a.LastName == buyer.LastName && a.FirstName == buyer.FirstName || a.Phone == buyer.Phone);
            if (findBuyer == null)
            {
                db.Users.Add(buyer);
                db.SaveChanges();
            }
            if (type == "sold")
            {
                db.Sold.FirstOrDefault(s => s.Id == dialId).OwnerId = buyer.Id;
            }
            if (type == "leased")
            {
                db.Leased.FirstOrDefault(l => l.Id == dialId).BuyerId = buyer.Id;
            }
            db.SaveChanges();
            return RedirectToAction("Realties", "RealtorMode");
        }
    }
}