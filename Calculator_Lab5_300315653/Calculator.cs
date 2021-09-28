using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Lab5_300315653
{
    class Calculator
    {
        public static double sqrt(double value)
        {
            return Math.Sqrt(value);
        }

        public static decimal invert(decimal value)
        {
            return 1 / value;
        }

        public static double add(double value1, double value2)
        {
            return value1 + value2;
        }

        public static double subtract(double value1, double value2)
        {
            return value1 - value2;
        }

        public static double multiply(double value1, double value2)
        {
            return value1 * value2;
        }

        public static decimal divide(decimal value1, decimal value2)
        {
            return value1 / value2;
        }

    }
}
