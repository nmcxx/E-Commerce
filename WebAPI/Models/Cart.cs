using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public int ProductDetailsId { get; set; }
        public int Quantity { get; set; }
        public int? OrderId { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
        public virtual Order Order { get; set; }

    }
}
