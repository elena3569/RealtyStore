using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using realtyStore.Models;

namespace realtyStore.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        RealtyContext db = new RealtyContext();
        [HttpGet]
        public ActionResult Index()
        {
            //ViewBag.Realties = db.Realties;
            ViewBag.Cities = db.Cities;
            return View();

        }
        [HttpPost]
        public ActionResult Index(SearchParams param, string status)
        {
            IList<Realty> realties = db.Realties.Where(r => r.Status == status).ToList();
            
            if(param.RealtyType != null)
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

            if (param.NumberRooms != null)
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

            ViewBag.Cities = db.Cities;
            ViewBag.Realties = realties;
            return View();
                    
        }
        
        public ActionResult Flat(int? id)
        {
            Realty realty = db.Realties.FirstOrDefault(r => r.Id == id);
            Owner owner = db.Owners.FirstOrDefault(r => r.Id == realty.OwnerId);
            ViewBag.Realty = realty;
            ViewBag.City = db.Cities.FirstOrDefault(c => c.Id == realty.CityId).Name;
            ViewBag.Phone = owner.Phone;
            ViewBag.Name = owner.FirstName;
            return View();
        }

                
        [HttpGet]
        public ActionResult Announcement()
        {
            ViewBag.Owners = db.Owners;
            ViewBag.Cities = db.Cities;
            ViewBag.Realties = db.Realties;
            return View();
        }
        [HttpPost]
        public ActionResult Announcement(Owner owner)
        {
            var findOwner = db.Owners.FirstOrDefault(a => a.Patronymic == owner.Patronymic && a.LastName == owner.LastName && a.FirstName == owner.FirstName || a.Phone == owner.Phone);
            if (findOwner == null)
            {
                db.Owners.Add(owner);
                db.SaveChanges();
            }
            var id = db.Owners.FirstOrDefault(a => a.Patronymic == owner.Patronymic && a.LastName == owner.LastName && a.FirstName == owner.FirstName || a.Phone == owner.Phone).Id;
            
            return RedirectToAction("FormNewRealty", "Home", new { OwnerId = id });
        }


        [HttpGet]
        public ActionResult FormNewRealty(int? OwnerId)
        {
            ViewBag.OwnerId = OwnerId;
            ViewBag.Cities = db.Cities;
            return View();
        }
        [HttpPost]
        public ActionResult FormNewRealty(Realty realty)
        {
            db.Realties.Add(realty);
            db.SaveChanges();
            return RedirectToAction("Flat", "Home", new { id = realty.Id });
        }


        protected ActionResult (Realty realty)
        {
            return PartialView(realty);

        }
        
    }
}