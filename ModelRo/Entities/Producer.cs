using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRo.Entities
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name {  get; set; }

        #region Parameter Constructor
        public Producer(int id, string name) 
        {
            Id = id;
            Name = name;
        }
        #endregion
    }
}
