using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    internal class DelegateDemo
    {
        public dataManager UpdateData;
        public int dataValue;
        public void DataAfterUpdate(dataUpdater du)
        {
            du(dataValue);
        }

        public DelegateDemo()
        {
            dataValue = 10;
            UpdateData = new dataManager(GetUpdatedData);
        }
        public static void GetStaticData()
        {
            System.Console.WriteLine("This is Get Static Data Method");
        }

        public void GetInstanceData()
        {
            Console.WriteLine("This is Get Intance Data Method");
        }

        private string GetUpdatedData(int a)
        {
            return "You input data is " + a + " and updated data is " + (a * 5);
        }
    }

    class Test
    {
        public void DataManipulator(int d)
        {
            Console.WriteLine("We hava a new value of d is " + (d / 5.0f +100));
        }
    }
}
