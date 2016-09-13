using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblResultado.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// boton igual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {          
            string operador = "+";
            operador = Calculadora.validarOperador(cmbOperacion.Text);
            MessageBox.Show(operador);
            Numero num1 = new Numero();
            Numero num2 = new Numero();
            num1.setNumero(txtNumero1.Text);
            num2.setNumero(txtNumero2.Text);
            lblResultado.Text = Calculadora.operar(num1, num2, operador);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }

    public class Calculadora{
       
        string _operador;

        public static string validarOperador(string a){
            string op="";
            if (a == "+") { op = "+"; }
            else if (a == "-") { op = "-"; }
            else if (a == "*") { op = "*"; }
            else if (a == "/") { op = "/"; }
            else { op = "+"; }
            return op;
        }

        public string operar(Numero num1, Numero num2, string operador){
          
            double n1 = num1.getNumero();
            double n2 = num2.getNumero();
            double valor=0;
            switch (operador)
            {
                case "+":
                    valor = n1 + n2;
                    break;
                case "-":
                    valor = n1 - n2;
                    break;
                case "/":
                    valor = n1 / n2;
                    break;
                case "*":
                    valor = n1 * n2;
                    break;
            }
            return valor.ToString();
        }

     } //fin clase 

    public class Numero
    {

        double _numero;

        public double getNumero(){
            return this._numero;
        }

        public Numero()
        {

        }

        
        public Numero(double numero)
        {
           

        }
        public void setNumero(string a){
            bool parseOk = Double.TryParse(a, out this._numero);
            MessageBox.Show("el numero " + a + " esta " + parseOk);
        }

        
        public Numero(string numero)
        {

        }

        private static double validarNumero(string numeroString){
            double num=0;
            if (Double.TryParse(numeroString, out num))
            {
                return num;
            }
            else
            {
                return 0;
            }
          
        }
    } //fin calculadora

  
}
