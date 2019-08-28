using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Raw_Vidly_App.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime AddDate { get; set; }
        public int Stock { get; set; }
        [ForeignKey("Genere")]
        public int GenereId { get; set; }
        public Genere Genere { get; set; }
        [ForeignKey("Customers")]
        public int CustomersId { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        //[ForeignKey("Requests")]
        //public int RequestId { get; set; }
        //public Request Requests { get; set; }

    }
}