using System;
using IslampurClotheEnventory.Data;
using IslampurClotheEnventory.Data.interfaces;
using IslampurClotheEnventory.Data.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace IslampurClotheEnventory.Services
{
    public class BasicServices : IBasicServices
    {
        private readonly IslampurDbContext _context;

        public BasicServices(IslampurDbContext context)
        {
            _context = context;
        }
        public void GetAllSale()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            return (_context.Customers.Find(id)); 
        }

        public Product GetProductById(int id)
        {
            return (_context.Products.Find(id));
        }

        public void GetSaleById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer IsCustomerNameExists(string name)
        {
            Customer a = (from c in _context.Customers
                where c.CustomerName == name
                select c).FirstOrDefault();
            return (a);
        }

        public void SetCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void SetPurchesInfo(PurchesInfo purchesInfo)
        {
            throw new NotImplementedException();
        }

        public void SetSale(Sale sale)
        {
            _context.Add(sale);
            _context.SaveChanges();
        }
    }
}
