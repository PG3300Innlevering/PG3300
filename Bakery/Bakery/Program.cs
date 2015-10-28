using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ParameterizedThreadStart threadStart = Customer.GrabCookie;
            new Thread(threadStart).Start(new Customer("Fred"));
            new Thread(threadStart).Start(new Customer("Ted"));
            new Thread(threadStart).Start(new Customer("Greg"));
            Thread bake = new Thread(new ThreadStart(CookieGenerator.Start));
        }
    }
}
