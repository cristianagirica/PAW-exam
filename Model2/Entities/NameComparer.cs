using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2.Entities
{
    public class NameComparer : IComparer<Participant>
    {
        public int Compare(Participant x, Participant y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
