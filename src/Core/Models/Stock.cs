using System.Collections.Generic;

namespace Core.Models
{
    public class Stock
    {
        public Stock()
        {
            Options = new List<Option>();
        }
        public string Symbol { get; set; }
        public double Price { get; set; }

        public List<Option> Options { get; set; }
    }
}