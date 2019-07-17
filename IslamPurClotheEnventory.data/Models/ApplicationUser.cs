using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IslampurClotheEnventory.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ShopName { get; set; }
        public string  Address { get; set; }
    }
}
