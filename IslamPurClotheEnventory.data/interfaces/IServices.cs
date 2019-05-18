using IslampurClotheEnventory.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace IslampurClotheEnventory.Data.interfaces
{
    interface IServices
    {
        IActionResult SetPurchesInfo(PurchesInfo purchesInfo);
        IActionResult SetSale(Sale sale);


    }
}
