using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Car : BaseEntity
    {
        [Required]
        public string Color { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public int MakeId { get; set; }
        public Make MakeNavigation { get; set; }
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Radio RadioNavigation { get; set; }

        public IEnumerable<Driver> Drivers { get; set;} = new List<Driver>();
    }
}