using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
