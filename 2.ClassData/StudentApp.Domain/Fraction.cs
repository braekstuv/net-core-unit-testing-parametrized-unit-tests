using System;

namespace StudentApp.Domain
{
    public struct Fraction
    {
        private int _numerator {get;set;}
        private int _denomerator {get;set;}
        public Fraction(int numerator, int denominator){
            _numerator = numerator;
            _denomerator = denominator;
        }

        public decimal GetPercentage(){
            return (decimal) _numerator / _denomerator;
        }
    }
}
