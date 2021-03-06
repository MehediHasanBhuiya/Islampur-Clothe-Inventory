﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IslampurClotheEnventory.Data.Models
{
    public class PurchesInfo
    {
        [Key]
        public int PurchesId { get; set; }
        public string PurchesPersonName { get; set; }
        public string PurchesPersonPhoneNumber { get; set; }
        public string PurchesPersonEmail { get; set; }
        public DateTime PurchesDate { get; set; }
        public double PurchesPrice { get; set; }
        public double PurchesOnCash { get; set; }
        public double PurchesOnDebt { get; set; }
        public int PurchesQuentity { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }


        public Product Product { get; set; }
        public ApplicationUser User { get; set; }


    }
}
