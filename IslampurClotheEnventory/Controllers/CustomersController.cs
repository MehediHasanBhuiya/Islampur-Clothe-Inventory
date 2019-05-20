using IslampurClotheEnventory.Data.interfaces;
using IslampurClotheEnventory.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IslampurClotheEnventory.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IBasicServices _services;

        public CustomersController(IBasicServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }
        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,CustomerAddress,CustomerPhoneNumber,CustomerEmail")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _services.SetCustomer(customer);

            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer =  _services.GetCustomerById(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CustomerId,CustomerName,CustomerAddress,CustomerPhoneNumber,CustomerEmail")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    _services.EditCustomer(customer);
                
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
