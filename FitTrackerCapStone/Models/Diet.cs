using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitTrackerCapStone.Models
{
    public class Diet
    {
        [Key]
        public int DietId { get; set; }

        public List<Meal> Meals { get; set; }
    }
}
