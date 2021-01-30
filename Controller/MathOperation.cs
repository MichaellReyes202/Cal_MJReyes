using CalculatorMJR.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorMJR.Controller
{
    class MathOperation
    {
        
        protected double term1;
        protected double term2;
        protected string operato;

        public MathOperation()
        {
            term1 = 0d;
            term2 = 0d;
            operato = "";
        }
        public void setTerm1(Double t1)
        {
            term1 = t1;
        }
        public void setTerm1(String t1)
        {
            term1 = Convert.ToDouble(t1);
        }
        public Double getTerm1()
        {
            return term1;
        }
        public String getTerm1ToString()
        {
            return Math.getNumberToString(term1);
        }
        public void setTerm2(Double t2)
        {
            term2 = t2;
        }
        public void setTerm2(String t2)
        {
            term2 = Double.Parse(t2);
        }
        public Double getTerm2()
        {
            return term2;
        }
        public String getTerm2ToString()
        {
            return Math.getNumberToString(term2);
        }
        public void setOperator(String op)
        {
            operato = op;
        }
        public String getOperator()
        {
            return operato;
        }

        /*
        public double ejecutarOperation(Enum op,double v1,double v2)
        {
            double r = 0;
            switch(op)
            {
                case :
                    {
                        r = v1 + v2;
                    }
                    break;
                case "-":
                    {
                        r = v1 - v2;
                    }
                 break;
                case "*":
                    {
                        r = v1 * v2;
                    }
                    break;
                case "/":
                    {
                        r = v1 / v2;
                    }
                    break;

            }
            return r;
        }
        */

        /*
        public Double resolve()
        {
            Double r;
            switch (operato)
            {
                case "+":
                    r = term1 + term2;
                    break;
                case "-":
                    r = term1 - term2;
                    break;
                case "x":
                    r = term1 * term2;
                    break;
                case "/":
                    r = term1 / term2;
                    break;
                case "n!":              /// term1.intValue()
                    r = Math.getFactorial(Convert.ToInt32(term1));
                    break;
                case ".nf.":
                    r = Math.getFibonacci(Convert.ToInt32(term1));
                    break;
                default:
                    r = 0d;
                    break;
            }
            return r;
        }
        */

        /*
        public String resolveToString()
        {
            Double r;
            String sr;
            switch (operato)
            {
                case "+":
                    r = term1 + term2;
                    sr = Math.getNumberToString(r);
                    break;
                case "-":
                    r = term1 - term2;
                    sr = Math.getNumberToString(r);
                    break;
                case "x":
                    r = term1 * term2;
                    sr = Math.getNumberToString(r);
                    break;
                case "/":
                    r = term1 / term2;
                    sr = Math.getNumberToString(r);
                    break;
                case "n!":
                    r = Math.getFactorial(Convert.ToInt32(term1));
                    sr = Math.getNumberToString(r);
                    break;
                case ".nf.":
                    r = Math.getFibonacci(Convert.ToInt32(term1));
                    sr = Math.getNumberToString(r);
                    break;
                case "n/x?":                        // Convert.ToInt32(term1));
                    sr = Math.isPrimeNumber(Convert.ToInt32(term1)) ? "Es primo" : "No es primo";
                    break;
                case "0112..":
                    sr = Math.getFibonacciSeries(Convert.ToInt32(term1));
                    break;
                default:
                    r = 0d;
                    sr = Math.getNumberToString(r);
                    break;
            }
            return sr;
        }
        */


        /*
        public String toString()
        {
            String r;
            switch (operato)
            {
                case "n!":
                    {
                        r = "fact(" + Convert.ToString(Convert.ToInt32(term1))+")";
                    }
                    break;
                case ".nf.":
                    {
                        r = "fib(" + Convert.ToString(Convert.ToInt32(term1)) + ")";
                    }
                    break;
                case "n/x?":
                    {
                        r = "isPrime(" + Convert.ToString(Convert.ToInt32(term1)) + ")";
                    }
                    break;
                default:
                    r = Math.getNumberToString(term1) + operato + Math.getNumberToString(term2) + "=";
                    break;
            }
            return r;
        }
        */
    }
}
