using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime timeStamp { get; set; }
        public double price { get; set; }
        public string cashierName { get; set; }
        public int beforeQuantity { get; set; }
        public int soldQuantity { get; set; }

        // ef core   
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
