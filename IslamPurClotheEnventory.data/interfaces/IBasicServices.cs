using IslampurClotheEnventory.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IslampurClotheEnventory.Data.interfaces
{
    public interface IBasicServices
    {
        void EditCustomer(Customer customer);

        void SetPurchesInfo(PurchesInfo purchesInfo);
        void SetSale(Sale sale);
        Task SetCustomer(Customer customer);
        void SetProduct(Product product);

        void GetAllSale();
        void GetSaleById(int id);
        Product GetProductById(int id);
        Customer GetCustomerById(int id);

        Customer GetCustomerByName(string name);
        Product GetProductByName(string name);

        void UpdateProductQuentityForSale(int productId,int saleQuentity);
        void UpdateProductForPurches(Product product);


    }
}
