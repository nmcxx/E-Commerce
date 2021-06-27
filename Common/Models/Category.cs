using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
