using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    public delegate string GetDataValues();

    internal class MulticastDelegateDemoCS
    {
        public static string DataValue1()
        {
            Console.WriteLine("---> DV1");
            return "This is from Data Value 1.";
        }
        public static string DataValue2()
        {
            Console.WriteLine("---> DV2");
            return "This is from Data Value 2.";
        }

    }
}
