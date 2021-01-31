
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
    
    public partial class Aplication : Window
    {
        MathController control;
        public string getScreenTextField()
        {
            return screenTextField.Text;
        }
        public void SetScreenTextField(string t)
        {
            screenTextField.Text = t;
            
        }
        public void SetScreenLabel(string t)
        {
            screenLabel.Content = t;
        }
        public string GetscreenLabel()
        {
            return (string)screenLabel.Content;
        }

        public Aplication()
        {
            InitializeComponent();
            setupController();
        }
        private void setupController()
        {
            control = new MathController(this);
            this.CE_Clear.Click += new System.Windows.RoutedEventHandler(control.HanglerButton);
            this.C_Button.Click += new System.Windows.RoutedEventHandler(control.HanglerButton);
            this.backButton.Click += new System.Windows.RoutedEventHandler(control.HanglerButton);
            
            this.Factorial.Click += new System.Windows.RoutedEventHandler(control.setMathematicalOperator);
            this.NFibo.Click += new System.Windows.RoutedEventHandler(control.setMathematicalOperator);
            this.Primo.Click += new System.Windows.RoutedEventHandler(control.setMathematicalOperator);
            this.Serie.Click += new System.Windows.RoutedEventHandler(control.setMathematicalOperator);

            this.N0.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N1.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N2.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N3.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N4.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N5.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N6.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N7.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N8.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);
            this.N9.Click += new System.Windows.RoutedEventHandler(control.printNumber_Click);

            this.ButtonPowerOff.Click += new System.Windows.RoutedEventHandler(control.moreOrLessButton_Click);

            this.Divicion.Click += new System.Windows.RoutedEventHandler(control.SetOperation);
            this.Multiplicacion.Click += new System.Windows.RoutedEventHandler(control.SetOperation);
            this.Resta.Click += new System.Windows.RoutedEventHandler(control.SetOperation);
            this.Suma.Click += new System.Windows.RoutedEventHandler(control.SetOperation);

            this.equal.Click += new System.Windows.RoutedEventHandler(control.equal_Click);

            this.pointButton.Click += new System.Windows.RoutedEventHandler(control.pointButton_Click);
        }
    }
}
