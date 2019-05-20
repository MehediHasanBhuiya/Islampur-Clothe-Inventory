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
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sale/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SaleView sale)
        {
            if (ModelState.IsValid)
            {
                if(_services.GetCustomerByName(sale.CustomerName) == null)
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
                    OnDebt = sale.SalePrice - sale.OnCash,
                    SaleTime = DateTime.Now,
                    CustomerId = _services.GetCustomerByName(sale.CustomerName).CustomerId,
                    ProductId = sale.ProductId,
                    
                };
                _services.SetSale(s);
                _services.UpdateProductQuentityForSale(sale.ProductId, sale.SaleQuentity);


            }
            return View();
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sale/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}