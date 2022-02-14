﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }

        // ef core
        public Category Category { get; set; }
        public int? CategoryId { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
