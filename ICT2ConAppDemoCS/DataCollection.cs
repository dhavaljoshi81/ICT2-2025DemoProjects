using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    internal class DataCollection <myType>
    {
        private List<myType> myList;

        public DataCollection()
        {
            myList = new List<myType>();
        }

        public void Add(myType data)
        {
            this.myList.Add(data);
        }
        
        public void ShowData()
        {
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
