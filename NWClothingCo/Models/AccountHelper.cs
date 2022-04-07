using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWClothingCo.Models
{
    public class AccountHelper
    {
        public Customer customer;
        public string page;
        public string role;
        public string firstName;
        public string lastName;

        public AccountHelper(Customer customer, string page, string role, string firstName, string lastName)
        {
            this.customer = customer;
            this.page = page;
            this.role = role;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
