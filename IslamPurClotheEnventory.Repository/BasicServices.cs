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

        public Customer GetCustomerByName(string name)
        {
            Customer customer = (from c in _context.Customers
                          where c.CustomerName == name
                          select c).FirstOrDefault();
            return (customer);
        }

        public Product GetProductByName(string name)
        {
            Product product = (from p in _context.Products
                               where p.ProductName == name
                               select p).FirstOrDefault();
            return (product);
        }

        public async Task SetCustomer(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public void SetProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void SetPurchesInfo(PurchesInfo purchesInfo)
        {
            _context.Add(purchesInfo);
            _context.SaveChanges();
        }

        public void SetSale(Sale sale)
        {
            _context.Add(sale);
            _context.SaveChanges();
        }

        public void UpdateProductForPurches(Product product)
        {
            Product pro = GetProductByName(product.ProductName);

            _context.Products.Attach(product);
            var entry = _context.Entry(product);
            entry.Property(p => p.ProductPurchesPrice == product.ProductPurchesPrice);
            entry.Property(p => p.ProductSalePrice == product.ProductSalePrice);
            entry.Property(p => p.ProductQuentity == product.ProductQuentity + pro.ProductQuentity);

        }

        public void UpdateProductQuentityForSale(int productId, int saleQuentity)
        {
            Product product = _context.Products.Find(productId);
            product.ProductQuentity = product.ProductQuentity - saleQuentity;

            _context.Products.Attach(product);
            var entry = _context.Entry(product);
            entry.Property(p => p.ProductQuentity).IsModified = true;
            _context.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }
    }
}
