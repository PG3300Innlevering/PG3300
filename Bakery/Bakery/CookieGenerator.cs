using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery
{
    class CookieGenerator : Items
    {
        public static void CookieType()
        {
            Random ct = new Random();
            int type = ct.Next(0, 3);

            switch (type)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }
}
