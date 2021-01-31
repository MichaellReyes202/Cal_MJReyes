using CalculatorMJR.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorMJR.Controller
{
    public enum Operacion
    {
        Nodefinida = 0,
        Suma = 1,
        Resta = 2,
        Division = 3,
        Multiplicacion = 4,
        Modulo = 5
    }
    public class MathController
    {
        Aplication frame;
        private bool freeToStart = true;
        private bool openMult = true;
        private bool openDiv = true;
        private bool openSum = true;
        private bool openRes = true;
        private double prueba1 = 0;
        private double prueba2 = 0;
        private double resulPrueba = 0;
        private string recolector = "";

        public MathController(Aplication API)
        {
            this.frame = API;
        }

        public void HanglerButton(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            switch(bt.ContentStringFormat)
            {
                case "CE":
                    {
                        frame.SetScreenTextField("0");
                    }
                break;

                case "C":
                    {
                        clear();
                    }break;
                case "back":
                    {
                        string x = frame.getScreenTextField();
                        if (!x.Equals("0") && x.Length >= 1)
                        {
                            if (x.Length == 1)
                            {
                                frame.SetScreenTextField("0");
                            }
                            else
                            {
                                frame.SetScreenTextField(x.Substring(0, x.Length - 1));
                            }
                        }

                    }
                    break;
            }
        }

        public void setMathematicalOperator(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            int n = 0;
            bool d = int.TryParse(frame.getScreenTextField(), out n);
            string resultado;
            bool negativo = n < 0 ? true : false;

            if (d)
            {
                switch (bt.ContentStringFormat)
                {
                    case "Factorial":
                        {
                            resultado = Convert.ToString(Models.Math.getFactorial(n));
                            if (negativo)
                            {
                                MessageBox.Show("Valor no valido,Ingresa numero no negativo");
                            }
                            else
                            {
                                MessageBox.Show("Factorial (" + Convert.ToString(n) + ") = " + resultado);
                            }
                        }
                        break;
                    case "Fibonasi":
                        {
                            resultado = Convert.ToString(Models.Math.getFibonacci(n));
                            if (negativo)
                            {
                                MessageBox.Show("Valor no valido,Ingresa numero no negativo");
                            }
                            else
                            {
                                MessageBox.Show("Fibo (" + Convert.ToString(n) + ") = " + resultado);
                            }

                        }
                        break;
                    case "Primo":
                        {
                            resultado = Models.Math.isPrimeNumber(n) ? "Es Primo" : "No es Primo";
                            if (negativo)
                            {
                                MessageBox.Show("Valor no valido,Ingresa numero no negativo");
                            }
                            else
                            {
                                frame.SetScreenTextField(resultado);
                                //screenTextField.Text = resultado;
                            }

                        }
                        break;
                    case "Serie":
                        {
                            resultado = Models.Math.getFibonacciSeries(n);
                            if (negativo)
                            {
                                MessageBox.Show("Valor no valido,Ingresa numero no negativo");
                            }
                            else
                            {
                                MessageBox.Show(resultado);
                            }

                        }
                        break;
                }
            }
        }

        public void clear()
        {
            freeToStart = false;
            frame.SetScreenTextField("0");
            frame.SetScreenLabel("0");
        }

        public void printNumber_Click(object sender, RoutedEventArgs e)
        {
            Button rb = (Button)sender;
            if (freeToStart)
            {
                clear();
                frame.SetScreenTextField(rb.ContentStringFormat);
            }
            else
            {  
                if (!frame.getScreenTextField().Equals("0"))
                {
                    frame.SetScreenTextField(frame.getScreenTextField() + rb.ContentStringFormat);
                }
                else
                {
                    frame.SetScreenTextField(rb.ContentStringFormat);
                }
            }
        }

        public void moreOrLessButton_Click(object sender, RoutedEventArgs e)
        {
            if (!frame.getScreenTextField().Equals("0"))
            {
                Double number = Convert.ToDouble(frame.getScreenTextField());
                number = number * -1;
                frame.SetScreenTextField(Convert.ToString(number));
            }
        }


        

        Operacion opp = Operacion.Nodefinida;

        public void SetOperation(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;

            switch (bt.ContentStringFormat)
            {
                case "Div":
                    {
                        opp = Operacion.Division;
                        if (openDiv)
                        {
                            openDiv = false;
                            bool util = Double.TryParse(frame.getScreenTextField(), out prueba1);
                            if (util)
                            {
                                recolector = prueba1 + "/";
                                frame.SetScreenLabel(recolector);
                                frame.SetScreenTextField("");
                            }
                        }
                        else
                        {
                            openDiv = true;
                            bool util = Double.TryParse(frame.getScreenTextField(), out prueba2);
                            if (util)
                            {
                                frame.SetScreenLabel(recolector + prueba2 + "/");
                                resulPrueba = prueba1 / prueba2;
                                frame.SetScreenTextField(Convert.ToString(resulPrueba));
                            }

                        }
                    }
                    break;
                case "Mul":
                    {
                        opp = Operacion.Multiplicacion;
                        if (openMult)
                        {
                            openMult = false;
                            bool util = Double.TryParse(frame.getScreenTextField(), out prueba1);
                            if (util)
                            {
                                recolector = prueba1 + "*";
                                frame.SetScreenLabel(recolector);
                                frame.SetScreenTextField("");
                            }
                        }
                        else
                        {
                            openMult = true;
                            bool util = Double.TryParse(frame.getScreenTextField(), out prueba2);
                            if (util)
                            {
                                frame.SetScreenLabel(recolector + prueba2 + "*");
                                resulPrueba = prueba1 * prueba2;
                                frame.SetScreenTextField(Convert.ToString(resulPrueba));
                            }
                        }
                    }
                    break;
                case "Res":
                    {
                        opp = Operacion.Resta;
                        if (openRes)
                        {
                            openRes = false;
                            bool util = Double.TryParse(frame.getScreenTextField(), out prueba1);
                            if (util)
                            {
                                recolector = prueba1 + "-";
                                frame.SetScreenLabel(recolector);
                                frame.SetScreenTextField("");
                            }
                        }
                        else
                        {
                            openRes = true;
                            bool util = Double.TryParse(frame.getScreenTextField(), out prueba2);
                            if (util)
                            {
                                frame.SetScreenLabel(recolector+prueba2+"-");
                                resulPrueba = prueba1 - prueba2;
                                frame.SetScreenTextField(Convert.ToString(resulPrueba));
                            }
                        }

                    }
                    break;
                case "Sum":
                    {
                        opp = Operacion.Suma;
                        if (openSum)
                        {
                            openSum = false;
                            bool util = Double.TryParse(frame.getScreenTextField(), out prueba1);
                            if (util)
                            {
                                recolector = prueba1 + "+";
                                frame.SetScreenLabel(recolector);
                                frame.SetScreenTextField("");
                            }
                        }
                        else
                        {
                            openSum = true;
                            bool util = Double.TryParse(frame.getScreenTextField(), out prueba2);
                            if (util)
                            {
                                frame.SetScreenLabel(recolector + prueba2 + "+");
                                resulPrueba = prueba1 + prueba2;
                                frame.SetScreenTextField(Convert.ToString(resulPrueba));
                            }
                        }
                    }
                    break;
            }

        }

        private double ejecutarOperation()
        {
            double r = 0;
            switch (opp)
            {
                case Operacion.Suma:
                    {
                        r = prueba1 + prueba2;
                    }
                    break;
                case Operacion.Resta:
                    {
                        r = prueba1 - prueba2;
                    }
                    break;
                case Operacion.Multiplicacion:
                    {
                        r = prueba1 * prueba2;
                    }
                    break;
                case Operacion.Division:
                    {
                        if (prueba2 == 0)
                        {
                            MessageBox.Show("No se puede dividir entre Cero");
                            r = 0;
                        }
                        else
                        {
                            r = prueba1 / prueba2;
                        }

                    }
                    break;

            }
            return r;
        }


        public void equal_Click(object sender, RoutedEventArgs e)
        {
            bool util = Double.TryParse(frame.getScreenTextField(), out prueba2);

            if (util)
            {
                string x = (string)frame.GetscreenLabel();
                if (x.IndexOf('=') == -1)
                {
                    frame.SetScreenLabel(frame.GetscreenLabel() + prueba2 + "=");
                    double resultado = ejecutarOperation();
                    prueba1 = 0;
                    prueba2 = 0;
                    openMult = openDiv = openSum = openRes = true;
                    frame.SetScreenTextField(Convert.ToString(resultado));
                }
            }

        }
        public void pointButton_Click(object sender, RoutedEventArgs e)
        {
            string x = frame.getScreenTextField();
            if (x.IndexOf('.') == -1)
            {
                frame.SetScreenTextField(x + ".");
            }
        }

    }
}
