using System;
using System.Collections.Generic;
using System.Text;

namespace IslampurClotheEnventory.Data.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int SaleQuentity { get; set; }
        public double SalePrice { get; set; }
        public double OnCash { get; set; }
        public double OnDebt { get; set; }
        public DateTime SaleTime { get; set; }
        

        public int ProductId { get; set; }
        public Product Products { get; set; }

        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
