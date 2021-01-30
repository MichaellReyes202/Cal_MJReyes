using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorMJR.Controller
{
    class Math
    {
        public static double getFibonacci(int n)
        {
            double s = 1, u = 1, p;
            int i;
            switch (n)
            {
                case 0:
                    s = 0;
                    break;
                case 1:
                case 2:
                    s = 1;
                    break;
                default:
                    for (i = 3; i <= n; i++)
                    {
                        p = u;
                        u = s;
                        s = s + p;
                    }
                    break;
            }
            return s;
        }

        //Devuelve la serie Fibonacci hasta el número n
        public static String getFibonacciSeries(int n)
        {
            double s = 1, u = 1, p;
            string series = "";
            int i;
            switch (n)
            {
                case 0:
                    series = "0";
                    break;
                case 1:
                    series = "0, 1";
                    break;
                case 2:
                    series = "0, 1, 1";
                    break;
                default:
                    series = "0, 1, 1";
                    for (i = 3; i <= n; i++)
                    {
                        p = u;
                        u = s;
                        s = s + p;
                        series += ", " + Convert.ToString(s);
                    }
                    break;
            }
            return series;
        }

        //Devuel el factorial de un entero positivo
        public static double getFactorial(int n)
        {
            int i;
            double f = 1;
            if (n > 1)
            {
                for (i = 2; i <= n; i++)
                {
                    f *= i;
                }
            }   
            return f;
        }

        //número primo es un número natural mayor que 1 que tiene únicamente dos divisores 
        public static bool isPrimeNumber(int n)
        {
            int c = 0, i = 1;
            if (n > 2)
            {
                while ((i <= n) && (c < 3))
                {
                    if ((n % i) == 0)
                        c++;
                    i++;
                }
            }
                
            return !(c > 2);
        }
        public static bool isNumeric(String s)
        {
            bool isMatch = Regex.IsMatch(s, "[-+]?\\d*\\.?\\d+");
            return s != null && isMatch;
        }
        public static String getNumberToString(Double number)
        {

            return Convert.ToString(number);
            
            /*            
            BigDecimal d = new BigDecimal(number);
            long a = d.longValue();
            BigDecimal b = d.remainder(BigDecimal.ONE);
            if (b == BigDecimal.ZERO)
            {
                return String.valueOf(a);
            }
            else
            {
                return String.valueOf(number);
            }
            */
        }
    }
}
