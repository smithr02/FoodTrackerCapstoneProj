using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitTrackerCapStone.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string UserName { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("Diet")]
        public int DietId { get; set; }
        public Diet Diet {get; set;}
    }
}
