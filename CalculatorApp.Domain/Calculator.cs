using System;

namespace CalculatorApp.Domain
{
    public class Calculator
    {
        public object Add(int a, int b)
        {
            checked{
                return a + b;
            }
        }
    }
}
