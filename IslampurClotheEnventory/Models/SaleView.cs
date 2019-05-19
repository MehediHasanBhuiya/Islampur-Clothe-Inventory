using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IslampurClotheEnventory.Models
{
    public class SaleView
    {
        public Guid id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int SaleQuentity { get; set; }
        public double SalePrice { get; set; }
        public double OnCash { get; set; }
        public double OnDebt { get; set; }
        public DateTime SaleTime { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
    }
}
