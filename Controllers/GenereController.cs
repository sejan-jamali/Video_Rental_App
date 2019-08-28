using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raw_Vidly_App.Models;

namespace Raw_Vidly_App.Controllers
{
	public class GenereController : Controller
	{
		private RawVidlyDbContext _context;

		public GenereController()
		{
			_context = new RawVidlyDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}


		//
		// GET: /Genere/
        [HttpGet]
		public ActionResult AddGenere()
		{
			ViewBag.Generes = _context.Generes;
			return View();
		}
        [HttpPost]
	    public ActionResult AddGenere(Genere genere)
	    {
	        _context.Generes.Add(genere);
	        _context.SaveChanges();
	        return RedirectToAction("AddGenere");
	    }

	    public ActionResult Delete(int id)
	    {
	        Genere genere = _context.Generes.Find(id);
	        _context.Generes.Remove(genere);
	        _context.SaveChanges();
	        return RedirectToAction("AddGenere");
	    }
	}
}