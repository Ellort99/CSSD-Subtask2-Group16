using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CSSD_Subtask2_Group16.Models;

namespace CSSD_Subtask2_Group16.Controllers
{
    public class TollAppController : Controller
    {
        public ActionResult AdminMenu(Admin admin)
        {
            return View();
        }

        public ActionResult UserTransactions(User user)
        {
            return View(user);
        }

        public async Task<JsonResult> Check(int id)
        {
            TollAppContext db = new TollAppContext();
            db.Transactions.Where(item => item.TransactionId == id).ToList().Single().Flagged ^= true;
            db.SaveChanges();
            return Json(new { isSuccess = true }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Settle(int id)
        {
            TollAppContext db = new TollAppContext();
            db.Transactions.Where(item => item.TransactionId == id).ToList().Single().Settled = true;
            db.SaveChanges();
            return Json(new { isSuccess = true }, JsonRequestBehavior.AllowGet);
        }
    }
}