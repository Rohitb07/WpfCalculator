using System;
using System.Windows;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private string selectedOperator = "";
        private double firstNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string buttonValue = (sender as System.Windows.Controls.Button)?.Content.ToString();

            if ("0123456789".Contains(buttonValue))
            {
                currentInput += buttonValue;
                Display.Text = currentInput;
            }
            else if ("+-*/".Contains(buttonValue))
            {
                if (!string.IsNullOrEmpty(currentInput))
                {
                    firstNumber = double.Parse(currentInput);
                    selectedOperator = buttonValue;
                    currentInput = "";
                }
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && !string.IsNullOrEmpty(selectedOperator))
            {
                double secondNumber = double.Parse(currentInput);
                double calculationResult = 0;

                switch (selectedOperator)
                {
                    case "+":
                        calculationResult = firstNumber + secondNumber;
                        break;
                    case "-":
                        calculationResult = firstNumber - secondNumber;
                        break;
                    case "*":
                        calculationResult = firstNumber * secondNumber;
                        break;
                    case "/":
                        calculationResult = secondNumber != 0 ? firstNumber / secondNumber : 0;
                        break;
                }

                Display.Text = calculationResult.ToString();
                currentInput = calculationResult.ToString();
                selectedOperator = "";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            selectedOperator = "";
            firstNumber = 0;
            Display.Text = "";
        }
    }
}
