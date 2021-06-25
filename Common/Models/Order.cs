using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderAddressId { get; set; }
        public float Price { get; set; }
        public int OrderStateId { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
