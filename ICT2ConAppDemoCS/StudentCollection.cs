using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    internal class StudentCollection
    {
        private Student[] students = new Student[5];

        public Student this[int index]
        {
            get
            { return students[index]; }
            set
            {  students[index] = value; }
        }
        public Student this [string sName] 
        {
            get
            {
                Student response = null;
                for (int i = 0; i < students.Length; i++)
                {
                    if (students[i].name.Equals(sName))
                    {
                        response = students[i];
                        break;
                    }
                }
                return response;
            } 
        }
    }
}
