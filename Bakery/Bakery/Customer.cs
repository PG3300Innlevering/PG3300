using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Bakery
{
    class Customer
    {
        public string Name {get; private set;}

        public Customer(String name)
        {
            this.Name = name;
        }

        public static void GrabCookie(object obj)
        {
            Customer customer = (Customer)obj;
            CookieGenerator.SellCookieTo(customer);
        }
    }
}
