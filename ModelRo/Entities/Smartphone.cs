using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRo.Entities
{
    public class Smartphone
    {

        public int Id { get; set; }
        public string Model { get; set; }
        public int Units { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ProducerId { get; set; }

        #region Parameter Constructor
        public Smartphone(int id, string model, int units, double price, DateTime releaseDate, int prodId)
        {
            Id = id;
            Model = model;
            Units = units;
            Price = price;
            ReleaseDate = releaseDate;
            ProducerId = prodId;
        }
        #endregion

        #region Explicit Cast Operator
        public static explicit operator int (Smartphone smartphone)
        {
            int AvUnits = smartphone.Units;
            return AvUnits;
        }
        #endregion
    }
}
