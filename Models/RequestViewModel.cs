using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raw_Vidly_App.Models
{
    public class RequestViewModel
    {
        public int CustomersId { get; set; }
        public int MoviesId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Movie> Movies { get; set; }

    }
}