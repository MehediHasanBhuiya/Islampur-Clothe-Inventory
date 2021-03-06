﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IslampurClotheEnventory.Data.Models
{
    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
            PurchesInfos = new HashSet<PurchesInfo>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuentity { get; set; }
        public double ProductPurchesPrice { get; set; }
        public double ProductSalePrice { get; set; }
        public bool IsStoed { get; set; }
        public string UserId { get; set; }


        public ICollection<Sale> Sales { get; set; }
        public ICollection<PurchesInfo> PurchesInfos { get; set; }
        public ApplicationUser User { get; set; }

    }

}
