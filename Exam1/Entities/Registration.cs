using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Entities
{
    [Serializable]
    public class Registration
    {
        public string CompanyName { get; set; }
        public int NoOfPasses { get; set; }
        public int AccessPackageId { get; set; }

        private static List<AccessPackage> AccessPackages;
        //Constructor without parameters for Xml Serialization
        public Registration() { }

        public Registration (string companyName, int noOfPasses, int accessPackageId) : this()
        {
            CompanyName = companyName;
            NoOfPasses = noOfPasses;
            AccessPackageId = accessPackageId;
        }

        public static void SetAccessPackages(List<AccessPackage> accessPackages)
        {
            AccessPackages = accessPackages;
        }

        public static explicit operator double(Registration registration)
        {
            var package = AccessPackages.FirstOrDefault(p => p.Id == registration.AccessPackageId);
            if (package == null)
            {
                return 0.0;
            }
            return package.Price * registration.NoOfPasses;
        }
    }
}
