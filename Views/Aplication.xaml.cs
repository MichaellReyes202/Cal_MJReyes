using CalculatorMJR.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalculatorMJR.Views
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
    public partial class Aplication : Window
    {
        public Aplication()
        {
            InitializeComponent();
        }

        //********************************* VARIABLES DE INTANCIAS **************************************************

        //private MathOperation mo = new MathOperation();
        bool freeToStart = true;
        
        
        bool openMult = true;
        bool openDiv = true;
        bool openSum = true;
        bool openRes = true;



        double prueba1 = 0;
        double prueba2 = 0;

        double resulPrueba = 0;

        string recolector = "";

        Operacion opp = Operacion.Nodefinida;

        //********************************* OPERACIONES ESPECIALES **************************************************

        public void setMathematicalOperator(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            int n = 0;
            bool d = int.TryParse(screenTextField.Text, out n); ;
            string resultado;
            bool negativo = n < 0 ? true : false;

            if (d)
            {
                switch (bt.ContentStringFormat)
                {
                    case "Factorial":
                        {
                            resultado = Convert.ToString(Controller.Math.getFactorial(n));
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
                            resultado = Convert.ToString(Controller.Math.getFibonacci(n));
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
                            resultado = Controller.Math.isPrimeNumber(n) ? "Es Primo" : "No es Primo";
                            if (negativo)
                            {
                                MessageBox.Show("Valor no valido,Ingresa numero no negativo");
                            }
                            else
                            {
                                screenTextField.Text = resultado;
                            }

                        }
                        break;
                    case "Serie":
                        {
                            resultado = Controller.Math.getFibonacciSeries(n);
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

        // ******************************** BOTONES DE BORRADO ******************************************************

        private void CE_Clear_Click(object sender, RoutedEventArgs e)
        {
            screenTextField.Text = "0";
        }
        private void C_Button_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            String x = getScreenText();
            if (!x.Equals("0") && x.Length >= 1)
            {
                if (x.Length == 1)
                {
                    setTextToScreen("0");
                }
                else
                {
                    setTextToScreen(x.Substring(0, x.Length - 1));
                }
            }

        }
        public void clear()
        {
            freeToStart = false;
            setTextToScreen("0");
            screenLabel.Content = "0";
        }

        // ******************************* NUMERO [0-9] & [.] *******************************************************

        private void printNumber_Click(object sender, RoutedEventArgs e)
        {
            Button rb = (Button)sender;
            if (freeToStart)
            {
                clear();
                setTextToScreen(rb.Name.Replace("N", ""));
            }
            else
            {
                if (!getScreenText().Equals("0"))
                {
                    setTextToScreen(getScreenText() + rb.Name.Replace("N", ""));
                }
                else
                {
                    setTextToScreen(rb.Name.Replace("N", ""));
                }
            }
        }
        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            string x = getScreenText();
            if (x.IndexOf('.') == -1)
            {
                setTextToScreen(x + ".");
            }
        }

        //******************************* OPERADORES MATEMATICOS ****************************************************

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
                            //MessageBox.Show("Entro en el if");
                            bool util = Double.TryParse(screenTextField.Text, out prueba1);                            
                            if(util)
                            {
                                recolector = prueba1 + "/";
                                screenLabel.Content = recolector;
                                screenTextField.Text = "";
                            }
                        }
                        else
                        {
                            
                            //MessageBox.Show("Entro en el else");
                            openDiv = true;
                            bool util = Double.TryParse(screenTextField.Text, out prueba2);
                            if(util)
                            {
                                screenLabel.Content = recolector + prueba2 + "/";
                                resulPrueba = prueba1 / prueba2;
                                screenTextField.Text = Convert.ToString(resulPrueba);
                            }

                        }
                    }
                    break;
                case "Mul":
                    {
                        opp = Operacion.Multiplicacion;
                        if (openMult)
                        {
                            //MessageBox.Show("Entro en el if");
                            openMult = false;
                            bool util = Double.TryParse(screenTextField.Text, out prueba1);
                            if (util)
                            {
                                recolector = prueba1 + "*";
                                screenLabel.Content = recolector;
                                screenTextField.Text = "";
                            }                            
                        }
                        else
                        {
                            openMult = true;
                            //MessageBox.Show("Entro en el else");

                            bool util = Double.TryParse(screenTextField.Text, out prueba2);
                            if (util)
                            {
                                screenLabel.Content = recolector + prueba2 + "*";
                                resulPrueba = prueba1 * prueba2;
                                screenTextField.Text = Convert.ToString(resulPrueba);
                            }
                        }
                    }
                    break;
                case "Res":
                    {
                        opp = Operacion.Resta;
                        if (openRes)
                        {
                            //MessageBox.Show("Entro en el if");
                            openRes = false;
                            bool util = Double.TryParse(screenTextField.Text, out prueba1);
                            if (util)
                            {

                                recolector = prueba1 + "-";
                                screenLabel.Content = recolector;
                                screenTextField.Text = "";
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Entro en el else");
                            openRes = true;
                            bool util = Double.TryParse(screenTextField.Text, out prueba2);
                            if (util)
                            {
                                screenLabel.Content = recolector + prueba2 + "-";
                                resulPrueba = prueba1 - prueba2;
                                screenTextField.Text = Convert.ToString(resulPrueba);
                            }
                        }

                    }
                    break;
                case "Sum":
                    {
                        opp = Operacion.Suma;
                        if (openSum)
                        {
                            //MessageBox.Show("Entro en el if");
                            openSum = false;

                            bool util = Double.TryParse(screenTextField.Text, out prueba1);
                            if (util)
                            {
                                recolector = prueba1 + "+";
                                screenLabel.Content = recolector;
                                screenTextField.Text = "";
                            }  
                        }
                        else
                        {
                            //MessageBox.Show("Entro en el else");
                            openSum = true;
                            bool util = Double.TryParse(screenTextField.Text, out prueba2);
                            if (util)
                            {
                                screenLabel.Content = recolector + prueba2 + "+";
                                resulPrueba = prueba1 + prueba2;
                                screenTextField.Text = Convert.ToString(resulPrueba);
                            }
                        }
                    }
                    break;
            }

        }

        public double ejecutarOperation()
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


        private void equal_Click(object sender, RoutedEventArgs e)
        {
            bool util = Double.TryParse(screenTextField.Text, out prueba2);

            if(util)
            {

                string x = (string)screenLabel.Content;
                if (x.IndexOf('=') == -1)
                {
                    //prueba2 = Convert.ToDouble(screenTextField.Text);
                    screenLabel.Content += prueba2 + "=";
                    double resultado = ejecutarOperation();
                    prueba1 = 0;
                    prueba2 = 0;
                    openMult = openDiv = openSum = openRes = true;
                    screenTextField.Text = Convert.ToString(resultado);

                }
                
            }
            
        }

        public void moreOrLessButton_Click(object sender, RoutedEventArgs e)
        {
            if (!getScreenText().Equals("0"))
            {
                Double number = Convert.ToDouble(getScreenText());
                number = number * -1;
                setTextToScreen(Convert.ToString(number));
            }
        }


        private string getScreenText()
        {
            return screenTextField.Text;
        }
        private void setTextToScreen(String content)
        {
            screenTextField.Text = content;
        }

       
        

        
    }
}
