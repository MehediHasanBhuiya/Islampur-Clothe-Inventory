using IslampurClotheEnventory.Data.interfaces;
using IslampurClotheEnventory.Data.Models;
using IslampurClotheEnventory.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IslampurClotheEnventory.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IBasicServices _services;

        public ProductsController(IBasicServices services)
        {
            _services = services;
        }
        TosterResultViewModel result = new TosterResultViewModel();

        // GET: Products
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Any()
        {
            return Json(_services.GetAllProduct());
        }



        // POST: Products/Create
        [HttpPost]
        public IActionResult Create([FromBody][Bind("ProductId,ProductName,ProductQuentity,ProductPurchesPrice,ProductSalePrice")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product != null)
                    {
                        _services.SetProduct(product);
                        result.IsSuccess = true;
                        result.Message = "Product create successfully !";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "Product not created !";
                    }

                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return Json(result);
        }



        // POST: Products/Edit/5
        [HttpPost]
        public IActionResult Edit([FromBody] [Bind("ProductId,ProductName,ProductQuentity,ProductPurchesPrice,ProductSalePrice")] Product product)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    if (product!=null)
                    {
                        _services.UpdateProduct(product);
                        result.IsSuccess = true;
                        result.Message = "Product update successfully !";
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "Product not updated !";
                    }
                    
                }
                catch (Exception ex)
                {
                    result.IsSuccess = false;
                    result.Message = ex.Message;
                }

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromBody] int? id)
        {
            try
            {
                if (id != null)
                {
                    _services.DeleteProduct(id.Value);
                    result.IsSuccess = true;
                    result.Message = "Product delete successfully !";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Product not deleted !";
                }

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return Json(result);
        }

    }
}
