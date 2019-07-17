using System;
using IslampurClotheEnventory.Data;
using IslampurClotheEnventory.Data.interfaces;
using IslampurClotheEnventory.Data.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IslampurClotheEnventory.Services
{
    public class BasicServices : IBasicServices
    {
        private readonly IslampurDbContext _context;
        public BasicServices(IslampurDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Sale> GetAllSale()
        {

            var sales = (from s in _context.Sales
                         orderby s.SaleTime descending
                         select new Sale
                         {
                             Customers = new Customer
                             {
                                 CustomerName = s.Customers.CustomerName,
                                 CustomerAddress = s.Customers.CustomerAddress,
                                 CustomerEmail = s.Customers.CustomerEmail,
                                 CustomerPhoneNumber = s.Customers.CustomerPhoneNumber
                             },
                             Products = new Product
                             {
                                 ProductName = s.Products.ProductName
                             },
                             OnCash = s.OnCash,
                             OnDebt = s.OnDebt,
                             SalePrice = s.SalePrice,
                             SaleQuentity = s.SaleQuentity,
                             SaleTime = s.SaleTime
                         }).ToList();
            return sales;
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

        public async Task<Customer> GetCustomerByName(string name)
        {
            Customer customer = await (from c in _context.Customers
                                       where c.CustomerName == name
                                       select c).FirstOrDefaultAsync();
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

            pro.ProductPurchesPrice = product.ProductPurchesPrice;
            pro.ProductSalePrice = product.ProductSalePrice;
            pro.ProductQuentity = product.ProductQuentity + pro.ProductQuentity;

            _context.SaveChanges();

        }

        public void UpdateProductQuentityForSale(int productId, int saleQuentity)
        {
            Product product = _context.Products.Find(productId);
            product.ProductQuentity = product.ProductQuentity - saleQuentity;

            _context.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            var product = (from p in _context.Products
                           orderby p.ProductName ascending
                           select p).ToList();
            return product;
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> ProductSearch(string name, string id)
        {
            var product = (from p in _context.Products where p.ProductName.Contains(name) && p.UserId == id select p).ToList();

            return product;
        }

        public IEnumerable<PurchesInfo> GetAllPurches()
        {
            var purches = (from p in _context.PurchesInfos
                           orderby p.PurchesDate descending
                           select new PurchesInfo
                           {
                               Product = new Product
                               {
                                   ProductId = p.Product.ProductId,
                                   ProductName = p.Product.ProductName,
                                   ProductPurchesPrice = p.Product.ProductPurchesPrice,
                                   IsStoed = p.Product.IsStoed

                               },
                               PurchesPersonName = p.PurchesPersonName,
                               PurchesPersonPhoneNumber = p.PurchesPersonPhoneNumber,
                               PurchesPersonEmail = p.PurchesPersonEmail,
                               PurchesQuentity = p.PurchesQuentity,
                               PurchesPrice = p.PurchesPrice,
                               PurchesOnCash = p.PurchesOnCash,
                               PurchesOnDebt = p.PurchesOnDebt

                           }).ToList();
            var ab = _context.PurchesInfos.Include(p => p.Product);
            return purches;
        }

        public IEnumerable<Customer> CustomerSearch(string name)
        {
            var customer = (from c in _context.Customers where c.CustomerName.Contains(name) select c).ToList();
            return customer;
        }

        public IEnumerable<Sale> BestSale(DateTime date)
        {
            var sale = from s in _context.Sales
                       where date < s.SaleTime
                       group s by s.Products.ProductName into g
                       let winner = (
                       from a in g
                       orderby a.SaleQuentity descending
                       select new Sale
                       {
                           Products = new Product { ProductName = a.Products.ProductName },
                           SaleQuentity = g.Sum(i => i.SaleQuentity)
                       }).FirstOrDefault()

                       select winner;
            return sale;

        }

        public Sale SaleAccount()
        {
            Sale sale = new Sale();

            sale.SalePrice = _context.Sales.Sum(a => a.SalePrice);
            sale.OnCash = _context.Sales.Sum(a => a.OnCash);
            sale.OnDebt = _context.Sales.Sum(a => a.OnDebt);

            return sale;
        }
        public PurchesInfo PurchesAccount()
        {
            PurchesInfo purches = new PurchesInfo();

            purches.PurchesPrice = _context.PurchesInfos.Sum(a => a.PurchesPrice);

            return purches;
        }
    }
}
