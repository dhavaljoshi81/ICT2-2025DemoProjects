using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    internal class CallBackDemoFunctionsCollectionCS
    {
        public static string ShowValue(int x, int y)
        {
            Console.WriteLine("Show Value");
            return "Your result value is " + (x + y);
        }

        public static string UpdateValue(int x, int y)
        {
            Console.WriteLine("Update Value");
            return "Your result of " + x + " and " + y + " after update is " + (x * y);
        }
    }
}
