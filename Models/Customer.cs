using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Raw_Vidly_App.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Min18yearsRequired]
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        [ForeignKey("MembershipType")]
        public int MembershipId { get; set; }
        public MembershipType MembershipType { get; set; }
        [ForeignKey("Movies")]
        public int MoviesId { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        //[ForeignKey("Requests")]
        //public int RequestId { get; set; }
        //public List<Request> Requests { get; set; }
    }
}