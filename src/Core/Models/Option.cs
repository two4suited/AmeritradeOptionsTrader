using System;

namespace Core.Models
{
    public class Option
    {       
        public string Symbol { get; set; }
        public string Id {get;set;}
        public double StrikePrice { get; init; }
        public DateTime ExpirationDate { get; init; }        
        public int OpenInterest { get; init; }       
        public double Delta { get; init; } 
        public double Theta { get; init; } 
        public double Gamma { get; init; } 
        public double Vega { get; init; } 
        public double Premium { get; set; }
        public int Volume { get; set; }
        public double ImpliedVolume { get; set; }
        public OptionType OptionType {get;set;}

    }
}