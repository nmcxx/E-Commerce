﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Color
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
    }
}
