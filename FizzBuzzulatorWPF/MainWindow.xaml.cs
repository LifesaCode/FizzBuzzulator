using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace FizzBuzzulatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FizzBuzzer fizzbuzzer = new FizzBuzzer(); 
            Binding binding = new Binding("Fizz");
            binding.Source = fizzbuzzer;
            BindingOperations.SetBinding(fizzBox, TextBox.TextProperty, binding);

            Binding binding2 = new Binding("Buzz");
            binding2.Source = fizzbuzzer;
            BindingOperations.SetBinding(buzzBox, TextBox.TextProperty, binding2);

        }
        FizzBuzzer fizzbuzzer = new FizzBuzzer();
        private double operand1 = Double.NaN;
        private double operand2 = Double.NaN;
        private string operation = "";
        private double answer = Double.NaN;
        
        private void Number_Click(object sender, RoutedEventArgs e)
        {
                displayBox.AppendText((sender as System.Windows.Controls.Button).Content.ToString());
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            operand1 = Convert.ToDouble(displayBox.Text);
            operation = (sender as System.Windows.Controls.Button).Content.ToString();
            displayBox.Clear();
        }

        private void GetSolution_Click(Object sender, RoutedEventArgs e)
        {
            operand2 = Convert.ToDouble(displayBox.Text);

            switch (operation)
            {
                case "+":
                    answer = operand1 + operand2;
                    break;
                case "-":
                    answer = operand1 - operand2;
                    break;
                case "*":
                    answer = operand1 * operand2;
                    break;
                case "/":
                    if (operand2.Equals(0))
                    {
                        Console.WriteLine("Cannot divide by zero");
                        answer = Double.NaN;
                    }
                    else
                        answer = operand1 / operand2;         //+ (operand1 % operand2)
                    break;
                default:
                    answer = Double.NaN;
                    break;
            }
            string buzzer = fizzbuzzer.FizzBuzz(answer);
            if (!buzzer.Equals(""))
            {
                Task task = updateTextBox(buzzer);
            }
            else
            {
                displayBox.Text = answer.ToString();
            }
        }

        private async Task updateTextBox(string buzzer)
        {
            displayBox.Text = buzzer;
            await Task.Delay(2000);
            displayBox.Text = answer.ToString();
        }

        private void fizzBox_LostFocus(object sender, RoutedEventArgs e)
        {
            fizzbuzzer.Fizz = Convert.ToDouble((sender as TextBox).Text);
        }

        private void buzzBox_LostFocus(object sender, RoutedEventArgs e)
        {
            fizzbuzzer.Buzz = Convert.ToDouble((sender as TextBox).Text);
        }
    }

    public class FizzBuzzer : INotifyPropertyChanged
    {
        private double fizz = 3;
        public double Fizz { get { return fizz; } set { fizz = value; OnPropertyChanged("Fizz"); } }
        private double buzz = 5;
        public double Buzz { get { return buzz; } set { buzz = value; OnPropertyChanged("Buzz"); } }

        public FizzBuzzer() { }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public string FizzBuzz(double answer)
        {
            if ((answer % fizz == 0) && (answer % buzz == 0))
            {
                return "FizzBuzz!";
            }
            else if (answer % fizz == 0)
            {
                return "Fizz!";
            }
            else if (answer % buzz == 0)
            {
                return "Buzz!";
            }
            else return "";
        }

    }
}
