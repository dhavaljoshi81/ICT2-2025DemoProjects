using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    internal interface IClassDesign
    {
        string Name { get; set; }
        void Display();
        string GetData();
        string UpdatedValue(int value1, string value2);
    }

    internal interface IClassDesign<T>
    {
        string Name { get; set; }
        void Display();
        string GetData();
        string UpdatedValue(T value1, string value2);
    }
}
