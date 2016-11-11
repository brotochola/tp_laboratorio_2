using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntidadesAbstractas
{




    public abstract class PersonaGimnasio:Persona
    {
        int _identificador;
     
        protected virtual string MostrarDatos()
        {
            return this.ID.ToString() + ", "+ ((Persona)this).ToString();
        }
        protected abstract string ParticiparEnClase();
        public  static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2){
            //uso object.equals, porq el equals de esta clase lo tengo overrideado
            if (Object.Equals(pg1, null) ||Object.Equals(pg2, null))  return false; //si son null retorna false
            if (pg1.Equals(pg2)) return true;
            else return false;
        }

        public override bool Equals(object obj)
        {
            if (Object.Equals(this, null) || Object.Equals(obj, null)) return false; //si son null retorna false
            if (
               (
               (this.DNI == ((PersonaGimnasio)obj).DNI) || (this._identificador == ((PersonaGimnasio)obj)._identificador)
               ) && (this.GetType() == obj.GetType())
              )
                return true;
            else return false;
        }
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nac)
            : base(nombre, apellido, nac, dni)
        {
            this._identificador = id;
        }
        public int ID { get { return this._identificador; } set { this._identificador = value; } }
        //sobre el identificador, que segun las consignas debe ser privado, no dice nada sobre como usarlo, asi q hago una propiedades para manipularlo desde la clases hijas de esta
    }
}
