using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Raw_Vidly_App.Models;

namespace Raw_Vidly_App.Controllers
{
	public class MembershipTypeController : Controller
	{
		private RawVidlyDbContext _context;

		public MembershipTypeController()
		{
			_context = new RawVidlyDbContext();
		}

		protected override void Dispose(bool disposing)
		{
		   _context.Dispose();
		}

		//
		// GET: /MembershipType/
        [HttpGet]
		public ActionResult AddmemberType()
        {
            ViewBag.MembershipType = _context.MembershipTypes;
			return View();
		}
        [HttpPost]
        public ActionResult AddmemberType(MembershipType membershipType)
        {
            _context.MembershipTypes.Add(membershipType);
            _context.SaveChanges();
            return RedirectToAction("AddmemberType");
        }

        public ActionResult Delete(int id)
        {
            MembershipType membershipType = _context.MembershipTypes.Find(id);
            _context.MembershipTypes.Remove(membershipType);
            _context.SaveChanges();


            return RedirectToAction("AddmemberType");
        }
	}
}