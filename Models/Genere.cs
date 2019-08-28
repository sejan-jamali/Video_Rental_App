using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Raw_Vidly_App.Models
{
    public class Genere
    {
        public int GenereId { get; set; }
        public string GenereName { get; set; }
        public List<Movie> Movie { get; set; }
    }
}