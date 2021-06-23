using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Discount
    {
        public int ID { get; set; }
        public int Count { get; set; }

        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
    }
}
