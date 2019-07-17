using System.Collections.Generic;

namespace IslampurClotheEnventory.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string UserId { get; set; }

        public ICollection<Sale> Sales { get; set; }
        public ApplicationUser User { get; set; }
    }
}