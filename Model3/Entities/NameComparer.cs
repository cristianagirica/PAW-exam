using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model3.Entities
{
    public class NameComparer : IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            return y.Name.CompareTo(x.Name);
        }
    }
}
