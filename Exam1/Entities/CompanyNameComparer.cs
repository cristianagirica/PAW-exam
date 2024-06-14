using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Entities
{
    public class CompanyNameComparer : IComparer<Registration>
    {
        public int Compare(Registration x, Registration y)
        {
            return x.CompanyName.CompareTo(y.CompanyName);
        }
    }
}
