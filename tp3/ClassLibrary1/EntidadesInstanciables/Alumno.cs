using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;




namespace EntidadesInstanciables
{


    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta
        {
            Deudor, AlDia, MesPrueba
        }

        EEstadoCuenta _estadoCuenta;
        EntidadesInstanciables.Gimnasio.EClases _claseQueToma;

     /*   public EClase ClaseQueToma{
            get
            {
                return this._claseQueToma;
            }
        }*/ //esto es irrelevante porq en el operador == ya esta

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EntidadesInstanciables.Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {

            this._claseQueToma = claseQueToma;
            this.ID = id;

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EntidadesInstanciables.Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {

            this._estadoCuenta = estadoCuenta;

        }
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + " Toma la clase: " + this._claseQueToma.ToString() + ", estado de cuenta: " + this._estadoCuenta.ToString();
        }

        protected override string ParticiparEnClase()
        {

            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();


        }

        public static bool operator ==(Alumno a1, EntidadesInstanciables.Gimnasio.EClases c1)
        {
            if (a1._claseQueToma == c1 && a1._estadoCuenta != EEstadoCuenta.Deudor) return true;
            else return false;
        }
        public static bool operator !=(Alumno a1, EntidadesInstanciables.Gimnasio.EClases c1)
        {
            if (a1._claseQueToma != c1) return true;
            else return false;
        }
    }
}
