using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Make: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    }
}
