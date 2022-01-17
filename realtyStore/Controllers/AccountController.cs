using System.Linq;
using System.Web.Mvc;
using realtyStore.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace realtyStore.Controllers
{
    public class AccountController : Controller
    {
        static RealtyContext db = new RealtyContext();

        public ActionResult LoginForm()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginForm(Login model)
        {
            List<string> answer = new List<string>();
            if (ModelState.IsValid)
            {
                myUser user = null;
                user = db.Users.FirstOrDefault(u => u.LogIn == model.Name && u.Password == model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    var fr = db.Realties.Where(r => r.isFavorite).ToList();
                    if (fr.Capacity > 0 )
                    {
                        foreach(var r in fr) { 
                            if (db.FavoriteRealties.FirstOrDefault(f => f.RealtyId == r.Id && f.UserId == user.Id) == null)
                            {
                                db.FavoriteRealties.Add(new FavoriteRealties { RealtyId = r.Id, UserId = user.Id });
                            }
                        }
                        db.SaveChanges();
                    }
                    if (string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    FormsAuthentication.RedirectFromLoginPage(model.Name, false);
                    return null;
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                    answer.Add("Неверный логин или пароль");
                    return View(answer);
                }
            }

            answer.Add("Что-то пошло не так :(");
            return View(answer);

        }

        public ActionResult RegisterForm()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Cities = db.Cities;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterForm(Register model)
        {
            List<string> answer = new List<string>();
            ViewBag.Cities = db.Cities;
            if (ModelState.IsValid)
            {
                myUser user = null;
                user = db.Users.FirstOrDefault(u => u.LogIn == model.Name);
                
                if (user == null)
                {
                    // создаем нового пользователя
                    db.Users.Add(new myUser { LogIn = model.Name, RoleId = 1, Password = model.Password, LastName = model.LastName, FirstName = model.FirstName, Patronymic = model.Patronymic, Phone = model.Phone, CityId = model.CityId, Address = model.Address });
                    var fr = db.Realties.Where(r => r.isFavorite).ToList();
                    if (fr.Capacity > 0)
                    {
                        foreach (var r in fr)
                        {
                            if (db.FavoriteRealties.FirstOrDefault(f => f.RealtyId == r.Id && f.UserId == user.Id) == null)
                            {
                                db.FavoriteRealties.Add(new FavoriteRealties { RealtyId = r.Id, UserId = user.Id });
                            }
                        }
                    }
                    db.SaveChanges();
                    user = db.Users.Where(u => u.LogIn == model.Name && u.Password == model.Password).FirstOrDefault();
                    
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                    answer.Add("Пользователь с таким логином уже существует");
                    return View(answer);
                }
            }
            if(model.Password.Length <= 6)
            {
                answer.Add("Минимальная длина пароля - 6 символов");
            }
            if (model.Password != model.ConfirmPassword)
            {
                
                answer.Add("Пароли не совпадают");
            }
            return View(answer);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            foreach (var r in db.Realties)
            {
                r.isFavorite = false;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}