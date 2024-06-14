using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model3.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        public Product() { }

        public Product(int id, string name, int units, double price, int categoryId)
        {
            Id = id;
            Name = name;
            Units = units;
            Price = price;
            CategoryId = categoryId;
        }

        public static explicit operator double(Product product)
        {
            double totPrice = product.Price * product.Units;
            return totPrice;
        }
    }
}
