using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Bakery
{
    class CookieGenerator
    {
        
        static List<Cookie> Cookies = new List<Cookie>();
        private static object obj = new Object(); 
        
      

        public static void Start()
        {
            System.Timers.Timer time = new System.Timers.Timer(667);
            time.Elapsed += new ElapsedEventHandler(CreateCookie);
            time.Start();
        }

        static void CreateCookie(object o, ElapsedEventArgs e)
        {
            int cookieCount = 0;
            cookieCount++;
                Cookies.Add(new Cookie(cookieCount));
                Console.WriteLine("Bakery made cookie #" + cookieCount);
        }

        public static void SellCookieTo(Customer customer)
        {
            lock (obj)
            {
                if (Cookies.Count > 0)
                {
                    int i = Cookies.Count - 1;
                    Console.WriteLine("\t\t\t" + customer.Name + " received cookie #");
                    Cookies.RemoveAt(i);
                }
            }

        }
    }
}
