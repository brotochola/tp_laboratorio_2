using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clase_12_Library
{
    public class Camion:Vehiculo
    {
        public Camion(Clase_12_Library.Vehiculo.EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 8;
            }
        }
        //private override sealed string Mostrar() //asi venia
        protected override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS :"+ this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
