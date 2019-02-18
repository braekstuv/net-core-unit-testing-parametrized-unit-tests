using System;

namespace StudentApp.Domain
{
    public struct Fraction
    {
        private int _numerator {get;set;}
        private int _denomerator {get;set;}
        public Fraction(int numerator, int denominator){
            if(denominator == 0)
                throw new ArgumentException("The denominator of a fraction can never be zero.");
                
            _numerator = numerator;
            _denomerator = denominator;
        }

        public decimal GetPercentage(){
            return (decimal) _numerator / _denomerator;
        }
    }
}
