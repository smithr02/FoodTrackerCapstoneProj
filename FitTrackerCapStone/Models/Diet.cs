using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitTrackerCapStone.Models
{
    public class Diet
    {
        [Key]
        public int DietId { get; set; }

        //[ForeignKey("Meals")]
        //public ICollection<int> MealsId { get; set; }
        //public ICollection<Meal> Meals { get; set; }


    }
}
