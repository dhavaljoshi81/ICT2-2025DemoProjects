using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    public delegate string UpdateMyData<T>(T a,  int b);

    internal class CallbackMethodDemoCs<U>
    {
        public int value1;
        public int value2;
        private UpdateMyData<U> UpdateMyDataMethod;
        public UpdateMyData<U> CallUpdateData { 
            set
            {
                UpdateMyDataMethod = value;
            }
            get
            {
                return UpdateMyDataMethod;
            }
        }

        public void GetResult()
        {
            if (UpdateMyDataMethod != null)
            {
                Console.WriteLine(UpdateMyDataMethod(value1, value2));
            }
            else
                Console.WriteLine("No Result");
        }
    }
}
