using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ProductDetails
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public int? DiscountID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
