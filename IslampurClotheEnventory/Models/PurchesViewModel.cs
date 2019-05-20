using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IslampurClotheEnventory.Models
{
    public class PurchesViewModel
    {
        public Guid id { get; set; }
        public string PurchesPersonName { get; set; }
        public string PurchesPersonPhoneNumber { get; set; }
        public string PurchesPersonEmail { get; set; }
        public DateTime PurchesDate { get; set; }
        public double PurchesPrice { get; set; }
        public double PurchesOnCash { get; set; }
        public double PurchesOnDebt { get; set; }
        public string ProductName { get; set; }
        public int ProductQuentity { get; set; }
        public double ProductPurchesPrice { get; set; }
        public double ProductSalePrice { get; set; }
        public bool IsStoed { get; set; }
    }
}
