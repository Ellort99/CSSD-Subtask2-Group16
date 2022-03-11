using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSSD_Subtask2_Group16.Models;

namespace CSSD_Subtask2_Group16.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginUserModel user)
        {
            TollAppContext db = new TollAppContext();
            foreach(Admin a in db.Admins)
            {
                if(a.Email.Equals(user.Email) && a.Password.Equals(user.Password))
                {
                    return RedirectToAction("AdminMenu", "TollApp", a);
                }
            }
            foreach(User u in db.Users)
            {
                if(u.Email.Equals(user.Email) && u.Password.Equals(user.Password))
                {
                    return RedirectToAction("UserTransactions", "TollApp", u);
                }
            }
            ViewBag.NotValidUser = user;
            return View();
        }

        public ActionResult Register([Bind(Include ="AutoId,Username,Password,Firstname,Lastname,Address,BankId")] User user)
        {
            TollAppContext db = new TollAppContext();
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                return LogIn();
            }
            return View(user);
        }
    }
}