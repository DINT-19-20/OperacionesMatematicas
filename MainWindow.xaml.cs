using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace OperacionesMatematicas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Iniciar();

        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            Iniciar();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ActualizaResultado();
        }

        private void OperandoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ActualizaResultado();
        }

        private void ActualizaResultado()
        {
            //Convertimos a decimal los dos operandos. En caso de que no haya nada en los TextBox lo tratamos como un 0
            decimal operando1 = String.IsNullOrEmpty(Operando1TextBox.Text) ? 0 : decimal.Parse(Operando1TextBox.Text);
            decimal operando2 = String.IsNullOrEmpty(Operando2TextBox.Text) ? 0 : decimal.Parse(Operando2TextBox.Text);

            //Comprobamos cuál de los RadioButton está marcado y realizamos la operación correspondiente
            if ((bool)SumaRadioButton.IsChecked)
            {
                ResultadoTextBox.Text = (operando1 + operando2).ToString();
            }
            else if ((bool)RestaRadioButton.IsChecked)
            {
                ResultadoTextBox.Text = (operando1 - operando2).ToString();
            }
            else if ((bool)MultiplicacionRadioButton.IsChecked)
            {
                ResultadoTextBox.Text = (operando1 * operando2).ToString();
            }
            else if ((bool)DivisionRadioButton.IsChecked)
            {
                //En el caso de la división, controlamos que el divisor no sea 0
                if (operando2 != 0)
                {
                    ResultadoTextBox.Text = (operando1 / operando2).ToString();
                }
                else
                {
                    ResultadoTextBox.Text = "Error";
                }
            }
        }

        private void Iniciar()
        {
            //Volvemos a seleccionar la poeración Suma
            SumaRadioButton.IsChecked = true;

            //Ponemos a 0 los cuadros de texto
            Operando1TextBox.Text = "0";
            Operando2TextBox.Text = "0";
        }
    }
}
