using System;

namespace Core.Models
{
    public class Option
    {
        public Stock Stock { get; init; }
        public double StrikePrice { get; init; }
        public DateOnly ExpirationDate { get; init; }
        public int OpenInterest { get; init; }       
        public decimal Delta { get; init; } 
        public decimal Theta { get; init; } 
        public decimal Gamma { get; init; } 
        public decimal Premium { get; set; }
        

    }
}