using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMVC5.Models;
using System.Data.Entity.Core.Objects;

namespace SampleMVC5.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult regcus()
        {
            return View();
        }

        [HttpPost]
        public ActionResult regcus(samplemvc5 sm)
        {
            if (ModelState.IsValid)
            {
                data_base d = new data_base();
                ObjectParameter O = new ObjectParameter("cid", 0);

                d.sp_insertmvc5(sm.name, sm.gender, O);
                int cusid = Convert.ToInt32(O.Value);
                ViewBag.l1 = "Your Customer ID is-" + cusid;

            }

            return View();
            
        }

       public ActionResult viewcus()
        {
            data_base d = new data_base();
           var v= d.sp_viewcus5().ToList();
            ViewBag.u1 = v;

            return View();

        }

        public ActionResult delcus(int? id)
        {
            data_base d = new data_base();
            d.sp_deletemvc5(id);
            var v = d.sp_viewcus5().ToList();
            ViewBag.u1 = v;


            return View("viewcus");
        }

        public ActionResult updcus()
        {
            //data_base d = new data_base();
           // d.sp_updatemvc5(s.id,s.name,s.gender);
            return View("regcus");
        }

        [HttpPost]
        public ActionResult updcus(samplemvc5 s)
        {
            data_base d = new data_base();
             d.sp_updatemvc5(s.id,s.name,s.gender);
            var v = d.sp_viewcus5().ToList();
            ViewBag.u1 = v;

            return View("viewcus");
        }
    }
}
