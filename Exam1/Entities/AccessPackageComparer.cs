using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Entities
{
    public class AccessPackageComparer : IComparer<Registration>
    {
        private readonly Dictionary<string, int> dict;
        private readonly List<AccessPackage> List;

        public AccessPackageComparer(List<AccessPackage> list)
        {
            List = list;
            dict = new Dictionary<string, int>
            {
                { "Platinum", 1 },
                { "Gold", 2 },
                { "Silver", 3 }
            };
        }



        public int Compare(Registration x, Registration y)
        {
            string xAccessPackageName = List.First(p => p.Id == x.AccessPackageId).Name;
            string yAccessPackageName = List.First(p => p.Id ==  y.AccessPackageId).Name;

            int xOrder = dict.ContainsKey(xAccessPackageName) ? dict[xAccessPackageName] : 0;
            int yOrder = dict.ContainsKey(yAccessPackageName) ? dict[yAccessPackageName] : 0;

            return xOrder.CompareTo(yOrder);
            
        }
    }
}
