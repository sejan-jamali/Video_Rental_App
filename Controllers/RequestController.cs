using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raw_Vidly_App.Models;

namespace Raw_Vidly_App.Controllers
{
    public class RequestController : Controller
    {
        private RawVidlyDbContext _context;

        public RequestController()
        {
            _context = new RawVidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Request
        public ActionResult ListOfMovie()
        {
            List<Movie> movies = _context.Movie.Include(c => c.Genere).ToList();
            ViewBag.Movies = movies;
            return View();
        }

        public ActionResult RequestMovie(RequestViewModel requestViewModel)
        {
            RequestViewModel request = new RequestViewModel();
            request.Customer.CustomerId = request.CustomersId;
            request.Movie.MovieId = request.MoviesId;
            return View("ListOfMovie");
        }
    }
}