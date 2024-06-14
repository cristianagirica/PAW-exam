using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRo.Entities
{
    public class ReleaseDateComparer : IComparer<Smartphone>
    {
        public int Compare(Smartphone x, Smartphone y)
        {
            if (x == null && y == null) return 0;
            return x.ReleaseDate.CompareTo(y.ReleaseDate);
        }
    }
}
