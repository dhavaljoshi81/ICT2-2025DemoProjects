using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    internal class Employee : IClassDesign<float>
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Name
        {
            get => EmployeeName;
            set => EmployeeName = value;
        }

        public void Display()
        {
            Console.WriteLine("ID: " + EmployeeID + " Name : " + EmployeeName);
        }

        public string GetData()
        {
            return "ID: " + EmployeeID + " Name : " + EmployeeName;
        }

        public string UpdatedValue(int value1, string value2)
        {
            return "Updated value is " + value2 + " is also with " + (value1 * 10);
        }

        public string UpdatedValue(float value1, string value2)
        {
            return "Updated value is " + value2 + " is also with " + (value1 * 10);
        }
    }
}
