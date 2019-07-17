using IslampurClotheEnventory.Data.interfaces;
using IslampurClotheEnventory.Data.Models;
using IslampurClotheEnventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace IslampurClotheEnventory.Controllers
{
    [Authorize]
    public class PurchesController : Controller
    {
        private readonly IBasicServices _services;

        public PurchesController(IBasicServices services)
        {
            _services = services;
        }
        TosterResultViewModel result = new TosterResultViewModel();
        

        public IActionResult Index()
        {
            
            return View();
            
        }

        [HttpPost]
        public JsonResult Search([FromBody] Product product)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Json(_services.ProductSearch(product.ProductName,userId));
        }

        [HttpPost]
        public JsonResult Add([FromBody] PurchesViewModel purches)
        {
            if (ModelState.IsValid)
            {
                try
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
                        ProductId = (_services.GetProductByName(purches.ProductName)).ProductId,
                        PurchesQuentity = purches.ProductQuentity

                    };
                    _services.SetPurchesInfo(purchesInfo);
                    result.IsSuccess = true;
                    result.Message = "Purches successfully complete";
                }
                catch (Exception ex)
                {

                    result.IsSuccess = false;
                    result.Message = ex.Message;
                }

            }

            return Json(result);
        }

        public JsonResult AllPurches()
        {
            return Json(_services.GetAllPurches());
        }

    }
}