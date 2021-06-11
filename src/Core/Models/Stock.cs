using System.Collections.Generic;

namespace Core.Models
{
    public class Stock
    {
        public string Symbol { get; set; }
        public double Price { get; set; }

        public List<Option> Options { get; set; }
    }
}