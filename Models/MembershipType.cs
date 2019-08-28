using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Raw_Vidly_App.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string MembershipName { get; set; }
        public List<Customer> Customers { get; set; }
        
    }
}