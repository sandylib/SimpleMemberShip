using SimpleMemberShip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMemberShip.Controllers
{
    public class HomeController : Controller
    {
        private CommisionContext db = new CommisionContext();

       
        public ActionResult Index()
        {

            

            return View();
        }

        [Authorize]
        public ActionResult MyCommissions(SearchVM model)
        {

            int id = 1;

            var commission = db.Commissions.Where(r => r.DealerId == id || (r.CreatedDate>=model.StartDate && r.CreatedDate<=model.EndDate)).ToList();
            if (commission == null)
            {
                return HttpNotFound();
            }

            return View(commission);
        }

        [Authorize(Roles="Admin")]
        public ActionResult Commissions(SearchVM model)
        {

            var comList = new List<Commission>();

            if(model.StartDate !=null && model.EndDate !=null)
            {
                comList = db.Commissions.Where(r=>r.CreatedDate>=model.StartDate && r.CreatedDate<=model.EndDate).ToList();
            }
            
            else
            {
                 comList = db.Commissions.ToList();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListCommisions", model);
            }

            return View(comList);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
