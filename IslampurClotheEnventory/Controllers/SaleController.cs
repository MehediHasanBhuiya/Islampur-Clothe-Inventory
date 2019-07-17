using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IslampurClotheEnventory.Data.interfaces;
using IslampurClotheEnventory.Data.Models;
using IslampurClotheEnventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IslampurClotheEnventory.Controllers
{
    public class SaleController : Controller
    {
        private readonly IBasicServices _services;

        public SaleController(IBasicServices services)
        {
            _services = services;
        }
        TosterResultViewModel result = new TosterResultViewModel();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSale([FromBody] SaleView sale)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_services.GetCustomerByName(sale.CustomerName) == null)
                    {
                        Customer customer = new Customer
                        {
                            CustomerName = sale.CustomerName,
                            CustomerAddress = sale.CustomerAddress,
                            CustomerPhoneNumber = sale.CustomerPhoneNumber,
                            CustomerEmail = sale.CustomerEmail
                        };
                        _services.SetCustomer(customer);
                    }
                    Sale s = new Sale
                    {
                        SaleQuentity = sale.SaleQuentity,
                        SalePrice = sale.SalePrice,
                        OnCash = sale.OnCash,
                        OnDebt = sale.OnDebt,
                        SaleTime = DateTime.Now,
                        CustomerId = _services.GetCustomerByName(sale.CustomerName).Result.CustomerId,
                        ProductId = sale.ProductId
                    };
                    _services.SetSale(s);
                    _services.UpdateProductQuentityForSale(sale.ProductId, sale.SaleQuentity);
                    result.IsSuccess = true;
                    result.Message = "Sale successfully complete";
                }
                catch (Exception ex)
                {

                    result.IsSuccess = false;
                    result.Message = ex.Message;
                }
            }
            return new EmptyResult();
        }

        [HttpPost]
        public JsonResult SearchCusetomer([FromBody] Customer customer)
        {
            return Json(_services.CustomerSearch(customer.CustomerName));
        }


        public JsonResult AllSale()
        {
            return Json(_services.GetAllSale());
        }

        public ActionResult BestSale()
        {
            return View();
        }

        [HttpPost]
        public JsonResult BestSaleData([FromBody] string product)
        {
            if (product == null || product.Equals("empty"))
            {
                var lastWeek = DateTime.Today.AddDays(-7);
                return Json(_services.BestSale(lastWeek));
            }
            else
            {
                DateTime date = DateTime.ParseExact(product, "d", null);
                return Json(_services.BestSale(date));
            }
        }

        public JsonResult RevinueInfo()
        {
            RevinueInfoViewModel revinue = new RevinueInfoViewModel
            {
                TotalSales = _services.SaleAccount().SalePrice,
                TotalOnCash = _services.SaleAccount().OnCash,
                TotalOndebt = _services.SaleAccount().OnDebt,
                TotalPurches = _services.PurchesAccount().PurchesPrice,
                Revinue = _services.SaleAccount().SalePrice - _services.PurchesAccount().PurchesPrice
            };

            return Json(revinue);
        }

    }
}