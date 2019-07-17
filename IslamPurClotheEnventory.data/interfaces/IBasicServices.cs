using IslampurClotheEnventory.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IslampurClotheEnventory.Data.interfaces
{
    public interface IBasicServices
    {
        void DeleteProduct(int id);

        void EditCustomer(Customer customer);
        void EditProduct(Product product);

        void SetPurchesInfo(PurchesInfo purchesInfo);
        void SetSale(Sale sale);
        Task SetCustomer(Customer customer);
        void SetProduct(Product product);

        IEnumerable<Sale> GetAllSale();
        IEnumerable<Product> GetAllProduct();
        IEnumerable<Product> ProductSearch(string name, string id);
        IEnumerable<Customer> CustomerSearch(string name);
        IEnumerable<PurchesInfo> GetAllPurches();
        IEnumerable<Sale> BestSale(DateTime date);

        void GetSaleById(int id);
        Product GetProductById(int id);
        
        Customer GetCustomerById(int id);

        Task<Customer> GetCustomerByName(string name);
        Product GetProductByName(string name);

        void UpdateProduct(Product product);
        void UpdateProductQuentityForSale(int productId,int saleQuentity);
        void UpdateProductForPurches(Product product);
        Sale SaleAccount();
        PurchesInfo PurchesAccount();

    }
}
