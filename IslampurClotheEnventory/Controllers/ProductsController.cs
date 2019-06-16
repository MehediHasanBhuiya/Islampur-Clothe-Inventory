 using IslampurClotheEnventory.Data.interfaces;
using IslampurClotheEnventory.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace IslampurClotheEnventory.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IBasicServices _services;

        public ProductsController(IBasicServices services)
        {
            _services = services;
        }

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
            if (ModelState.IsValid)
            {
                _services.SetProduct(product);

            }
            return new EmptyResult();
        }

        

        // POST: Products/Edit/5
        [HttpPost]
        public IActionResult Edit([FromBody] [Bind("ProductId,ProductName,ProductQuentity,ProductPurchesPrice,ProductSalePrice")] Product product)
        {


            if (ModelState.IsValid)
            {
                _services.UpdateProduct(product);
            }
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromBody] int id)
        {
            _services.DeleteProduct(id);
            return new EmptyResult();
        }

    }
}
