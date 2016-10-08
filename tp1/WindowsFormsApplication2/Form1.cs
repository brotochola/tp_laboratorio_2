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
            //  MessageBox.Show(operador);
            Numero num1 = new Numero();
            Numero num2 = new Numero();
            num1.setNumero(txtNumero1.Text);
            num2.setNumero(txtNumero2.Text);
            Calculadora cal = new Calculadora();
              lblResultado.Text = cal.operar(num1, num2, operador);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }

    public class Calculadora
    {

        string _operador;
        /// <summary>
        /// le entra un string y devuelve otro, q si o si serà una operacion valida.
        /// si le entra cualquier cosa devuelve "+"
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string validarOperador(string a)
        {
            string op = "";
            if (a == "+") { op = "+"; }
            else if (a == "-") { op = "-"; }
            else if (a == "*") { op = "*"; }
            else if (a == "/") { op = "/"; }
            else { op = "+"; }
            return op;
        }

        /// <summary>
        /// le entran 2 objetos Numero. y hace la operacion
        /// aparentemente c# ya toma en cuanta la division por cero :)
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public string operar(Numero num1, Numero num2, string operador)
        {

            double n1 = num1.getNumero(); //agarro los numeros y los meto en variables double
            double n2 = num2.getNumero();
            double valor = 0; //variable de salida
            switch (operador)
            {
                case "+":
                    valor = n1 + n2;
                    break;
                case "-":
                    valor = n1 - n2;
                    break;
                case "/":

                    valor = n1 / n2; //cuando divido por 0 me pone "infinito", y no se rompe.. con esto me alcanza 
                    break;
                case "*":
                    valor = n1 * n2;
                    break;
            }
            return valor.ToString(); //devuelve un string para poder ponerlo como label.Text
        }

    } //fin clase 

    public class Numero
    {

        private  double _numero; //esta es el atributo de cada objeto de esta clase, donde esta el numero posta

        public double getNumero()
        {
            return this._numero; //como el atributo _numero es privado, necesitamos un mtodo publico para acceder a el
        }

        public Numero()
        {
            this._numero = 0; //por default esta sobrecarga del constructor, pone el numero en 0
        }


        public Numero(double numero)
        {
            this._numero = numero; // si lo q le enra es un double, lo carga de una

        }

        public Numero(string a) //esta sobrecarga del constructor es como setNumero
        {
            this.setNumero(a);
        }
        public void setNumero(string a)
        {


            this._numero = Numero.validarNumero(a);
            //  MessageBox.Show("el numero " + a + " esta " + parseOk);
        }


    

        private static double validarNumero(string numeroString)
        {
            double num = 0;
            if (Double.TryParse(numeroString, out num)) //tryparse da un booleano como resultado, y eso es lo que este if evalua, si se pudo o no parsear como double
            { // "out num" establece q de poder parsearse el numero queda en la variable num
                return num; 
            }
            else
            {
                return 0; //si pusiste cualquiera, saca un 0
            }

        }
    }
}//fin calculadora

  
//fin namespace
