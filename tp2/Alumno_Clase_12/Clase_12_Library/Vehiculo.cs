using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
          
        public enum EMarca
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }
        EMarca _marca;
        string _patente;
        ConsoleColor _color;


        public Vehiculo(string patente, EMarca marca, ConsoleColor color)
        {
            this._marca = marca;
            this._patente = patente;
            this._color=color;
        }

        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public virtual short CantidadRuedas { get; set; }

        public string MostrarPublico
        {
            get { return this.Mostrar(); }
            set{}
        }
    

        //protected sealed string Mostrar() //asi venia
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (v1._patente == v2._patente) return true;
            else return false;
        }
        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
