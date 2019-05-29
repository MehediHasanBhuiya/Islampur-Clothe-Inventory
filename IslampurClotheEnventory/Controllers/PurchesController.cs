using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IslampurClotheEnventory.Data.interfaces;
using IslampurClotheEnventory.Data.Models;
using IslampurClotheEnventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace IslampurClotheEnventory.Controllers
{
    public class PurchesController : Controller
    {
        private readonly IBasicServices _services;

        public PurchesController(IBasicServices services)
        {
            _services = services;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(PurchesViewModel purches)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductName = purches.ProductName,
                    ProductQuentity = purches.ProductQuentity,
                    ProductPurchesPrice = purches.ProductPurchesPrice,
                    ProductSalePrice = purches.ProductSalePrice,
                    IsStoed = purches.IsStoed,
                };

                if (_services.GetProductByName(purches.ProductName) == null)
                {
                    _services.SetProduct(product);
                }
                else
                {
                    _services.UpdateProductForPurches(product);
                }

                PurchesInfo purchesInfo = new PurchesInfo
                {
                    PurchesPersonName = purches.PurchesPersonName,
                    PurchesPersonPhoneNumber = purches.PurchesPersonPhoneNumber,
                    PurchesPersonEmail = purches.PurchesPersonEmail,
                    PurchesDate = DateTime.Now,
                    PurchesPrice = purches.PurchesPrice,
                    PurchesOnCash = purches.PurchesOnCash,
                    PurchesOnDebt = purches.PurchesOnDebt,
                    
                };
            }

            return View();
        }

    }
}