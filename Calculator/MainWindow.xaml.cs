using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private double savedValue;
        private bool newButton;
        private char myOperator;

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string number = btn.Content.ToString();
            if(resultText.Text == "0" || newButton == true)
            {
                resultText.Text = number;
                newButton = false;
            }
            else
            {
                resultText.Text = resultText.Text + number;
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultText.Text = "0";
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            double lastNumber;
            if (double.TryParse(resultText.Text, out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultText.Text = lastNumber.ToString();
            }
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            double lastNumber;
            if(double.TryParse(resultText.Text, out lastNumber))
            {
                lastNumber = lastNumber * 0.01;
                resultText.Text = lastNumber.ToString();
            }
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if(resultText.Text.Contains(".") == false)
            {
                resultText.Text += ".";
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (myOperator == '+')
                resultText.Text = (savedValue + double.Parse(resultText.Text)).ToString();
            else if (myOperator == '-')
                resultText.Text = (savedValue - double.Parse(resultText.Text)).ToString();
            else if (myOperator == '*')
                resultText.Text = (savedValue * double.Parse(resultText.Text)).ToString();
            else if (myOperator == '/')
                resultText.Text = (savedValue / double.Parse(resultText.Text)).ToString();
        }

       
        private void OpBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            savedValue = double.Parse(resultText.Text);
            myOperator = btn.Content.ToString()[0];
            newButton = true;
        }
    }


}

