using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Raw_Vidly_App.Models
{
    public class RawVidlyDbContext : IdentityDbContext<ApplicationUser>
    {
        public RawVidlyDbContext() : base("RawVidlyDbContext")
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genere> Generes { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Request> Requests { get; set; }

        public static RawVidlyDbContext Create()
        {
            return new RawVidlyDbContext();
        }
    }
}