using IslampurClotheEnventory.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace IslampurClotheEnventory.Data.interfaces
{
    public interface IBasicServices
    {
        void SetPurchesInfo(PurchesInfo purchesInfo);
        void SetSale(Sale sale);
        void GetAllSale();
        void GetSaleById(int id);
        void SetCustomer(Customer customer);
        Product GetProductById(int id);
        Customer GetCustomerById(int id);
        Customer IsCustomerNameExists(string name);
        
    }
}
