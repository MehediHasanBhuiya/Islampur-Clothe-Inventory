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

            pro.ProductPurchesPrice = product.ProductPurchesPrice;
            pro.ProductSalePrice = product.ProductSalePrice;
            pro.ProductQuentity = product.ProductQuentity + pro.ProductQuentity;
            //_context.Products.Attach(pro);
            //var entry = _context.Entry(pro);
            //entry.Property(p => p.ProductPurchesPrice == Convert.ToDouble(product.ProductPurchesPrice)).IsModified = true;
            //entry.Property(p => p.ProductSalePrice == Convert.ToDouble(product.ProductSalePrice)).IsModified = true;
            //entry.Property(p => p.ProductQuentity == product.ProductQuentity + pro.ProductQuentity).IsModified = true;
            _context.SaveChanges();

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

        public void EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            var product = (from p in _context.Products
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

        public IEnumerable<Product> ProductSearch(string name)
        {
            var product = (from p in _context.Products where p.ProductName.Contains(name) select p).ToList();

            return product;
        }

        public IEnumerable<PurchesInfo> GetAllPurches()
        {
            var purches = (from p in _context.PurchesInfos
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
    }
}
