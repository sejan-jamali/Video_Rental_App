using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raw_Vidly_App.Models;

namespace Raw_Vidly_App.Controllers
{
	public class CustomerController : Controller
	{
		private RawVidlyDbContext _context;

		public CustomerController()
		{
			_context = new RawVidlyDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//
		// GET: /Customer/
		public ActionResult ListofCustomer()
		{
			List<Customer> customer = _context.Customers.Include(c => c.MembershipType).ToList();
			ViewBag.Customer = customer;
			return View();
		}

		public ActionResult Details(int id)
		{
			Customer customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.CustomerId == id);
			//customer.
			ViewBag.Customer = customer;
			ViewBag.MembershipId = _context.MembershipTypes;

			return View(customer);
			
		}
		[HttpGet]
		public ActionResult AddCustomer()
		{
			ViewBag.MembershipId = new SelectList(_context.MembershipTypes, "Id", "MembershipName");
			return View();
		}
		[HttpPost]
		
		public ActionResult AddCustomer([Bind(Include = "CustomerId,CustomerName,Email,BirthDate,MembershipId")]Customer customer)
		{
			//ViewBag.MembershipId = new SelectList(_context.MembershipTypes, "Id", "MembershipName");
			
			if (ModelState.IsValid)
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();


				return RedirectToAction("ListofCustomer");
			}
			ViewBag.MembershipId = new SelectList(_context.MembershipTypes, "Id", "MembershipName", customer.MembershipId);
			return View(customer);
		}
		[HttpGet]
		public ActionResult Edit(int? id)
		{
			Customer customer = _context.Customers.Find(id);
			ViewBag.MembershipId = new SelectList(_context.MembershipTypes,"Id","MembershipName",customer.MembershipId);
			return View(customer);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CustomerId,CustomerName,Email,BirthDate,MembershipId")]Customer customer)
		{
			//Customer customerr = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.CustomerId == id);

			if (ModelState.IsValid)
			{
				_context.Entry(customer).State = EntityState.Modified;
				_context.SaveChanges();
				return RedirectToAction("ListofCustomer");

			}
			ViewBag.MembershipId = new SelectList(_context.MembershipTypes, "Id", "MembershipName", customer.MembershipId);

			return View(customer);
		}
	   
		//public Customer GetCustomer(int id)
		//{
		//    Customer customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
		//    return customer;
		//}
		
		public ActionResult Delete(int? id)
		{
			Customer customer = _context.Customers.Find(id);
			return View(customer);
		}
		[HttpPost]
		public ActionResult Delete(int id)
		{
			Customer customer = _context.Customers.Find(id);
			_context.Customers.Remove(customer);
			_context.SaveChanges();
			return RedirectToAction("ListofCustomer");
		}
        public ActionResult MovieID(int id)
        {
            Customer customer = new Customer();
            customer.MoviesId = id;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return View("");
        }

        //private List<Customer> GetallCustomer()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer(){CustomerId = 1, CustomerName = "Ruhul", BirthDate = DateTime.MinValue, Email = "ruhul@gmail.com"},
        //        new Customer(){CustomerId = 1, CustomerName = "Kuddus", BirthDate = DateTime.MinValue, Email = "Kuddus@gmail.com"},
        //        new Customer(){CustomerId = 1, CustomerName = "Nayem", BirthDate = DateTime.MinValue, Email = "Nayem@gmail.com"}
        //    };
        //} 
    }
}