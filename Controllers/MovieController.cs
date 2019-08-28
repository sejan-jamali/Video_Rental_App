using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Raw_Vidly_App.Models;

namespace Raw_Vidly_App.Controllers
{
	public class MovieController : Controller
	{
		private RawVidlyDbContext _context;

		public MovieController()
		{
			_context = new RawVidlyDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//
		// GET: /Movie/
		public ActionResult ListofMovie()
		{
            List<Movie> movie = _context.Movie.Include(c=>c.Genere).ToList();
			ViewBag.Movies = movie;

            if (User.IsInRole(RoleName.Admin))
                return View("ListofMovie");
             
			return View("ListofMovie_Readonly");
		}
		public ActionResult Details(int id)
		{
		    Movie movie = _context.Movie.Include(c => c.Genere).SingleOrDefault(c => c.MovieId==id);

			return View(movie);
		}
		[HttpGet]
        [Authorize(Roles = RoleName.Admin)]
		public ActionResult AddMovie()
		{
			ViewBag.GenereId = new SelectList(_context.Generes, "GenereId", "GenereName");
			return View();
		}
		[HttpPost]
		public ActionResult AddMovie(Movie movie)
		{
			if (ModelState.IsValid)
			{
				_context.Movie.Add(movie);
				_context.SaveChanges();
			}
			ViewBag.GereneId = new SelectList(_context.Generes, "GenereId", "GenereName",movie.GenereId);


			return RedirectToAction("ListofMovie");
		}

        public ActionResult RequestMovie(RequestViewModel request)
        {
            //_context.Customers.Add(request);
            //_context.SaveChanges();

            return View("ListofMovie_Readonly");
        }
        public ActionResult MovieID(int id)
        {
            Movie movie = _context.Movie.Include(c => c.Customers).SingleOrDefault();
            movie.CustomersId = id;
            
            Customer customer = _context.Customers.SingleOrDefault(c => c.CustomerId==id);
            customer.MoviesId = id;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return View("ListofMovie_Readonly");
        }

        public ActionResult CustomerMovieId(int mid,int cid)
        {
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
            //IQueryable<Movie> movie = _context.Movie.Include(c => c.MoviesId==mid).Where(m => m.CustomerId == cid);
            //Movie movie = _context.Movie.Include(c => c.Customers);
            //ViewBag.movies = movie;
            //Customer customer = new Customer();
            //var userID = User.Identity.GetUserId();
            //RequestViewModel requestViewModel = new RequestViewModel();
            //requestViewModel.Customer.CustomerId = Convert.ToInt32(userID);
            //customer.CustomerId = cid;
            //customer.MoviesId = mid;
            //requestViewModel.Customer.MoviesId = mid;
            //_context.Movie.Add(movie);
            _context.SaveChanges();
            return View();
        }

        public ActionResult ListOfRent()
        {
            List<Request> request = _context.Requests.ToList();
            ViewBag.Request = request;
            return View("ListofMovie_Readonly");
        }
    }
}