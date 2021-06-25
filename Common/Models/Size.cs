using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Size
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
    }
}
