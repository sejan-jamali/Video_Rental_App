using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Raw_Vidly_App.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestName { get; set; }
        //[ForeignKey("Customers")]
        //public int CustId { get; set; }
        //public Customer Customers { get; set; }
        //[ForeignKey("Movie")]
        //public int MovieId { get; set; }
        //public List<Movie> Movie { get; set; }

        
    }
}