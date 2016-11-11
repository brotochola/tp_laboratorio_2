using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{




    public abstract class Persona
    {
        /*
         * 
         * Clase Persona:
 Abstracta, con los atributos Nombre, Apellido, Nacionalidad y DNI.
 Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y
89999999. Caso contrario, se lanzará la excepción DniInvalidoException.
 Sólo se realizarán las validaciones dentro de las propiedades.
 Validará que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se
cargará.
 ToString retornará los datos de la Persona.
         * 
        */


        string _nombre, _apellido;
        ENacionalidad _nacionalidad;
        int _dni;
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        public string Nombre {
            get{
             return this._nombre;
            }
            set{
                this._nombre = this.ValidarNombreApellido(value);
             }
        }

          public string Apellido {
              get{
                   return this._apellido;
        }
         set{

             this._apellido = this.ValidarNombreApellido(value);
        } }

          public ENacionalidad Nacionalidad {
             get{
             return this._nacionalidad;
            }
            set{
                
                if( Enum.IsDefined(typeof(ENacionalidad),value) ) {
                    this._nacionalidad=value;
                }else{
                    throw new NacionalidadInvalidaException();
                }
                
           } 
         }

        public int DNI {
            get{ return this._dni;}
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public string stringToDNI
        {
            
            set
            {

                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }

       public override string ToString()
            {
 	             return "NOMBRE COMPLETO: "+this.Nombre+" "+this.Apellido+"\n DNI: "+this.DNI.ToString()+"\nNACIONALIDAD: "+this.Nacionalidad.ToString()+"\n";


            }

        public Persona(string nombre, string apellido, ENacionalidad nac)
        {
            //uso las propiedades porq ya validan
            this.DNI = DNI;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nac;
        }

        public Persona(string nombre, string apellido, ENacionalidad nac, int dni):this(nombre, apellido, nac)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, ENacionalidad nac, string dni)
            : this(nombre, apellido, nac)
        {
            this.stringToDNI = dni;
        }

        int ValidarDni(ENacionalidad nac, int dato)
        {
            //si es argentino y el dni tiene sentido..
            if (this._nacionalidad == ENacionalidad.Argentino && dato > 0 && dato < 89999999)
              {
                  return dato;
              }    else {   
                    
                  //  throw new DniInvalidoException();
                  
               }
            return -1; //devuelve -1 si algo salio mal.. aunq en realidad viene la excepcion antes

            
        }
        int ValidarDni(ENacionalidad nac, string dato)
        {
            //si el string es un numero...
            int dniTemp;
            bool ok= int.TryParse(dato, out dniTemp);
            //lo manda al otro metodo
            if (ok)
            {
                return this.ValidarDni(nac, dniTemp);
            }
            else
            {
                throw new DniInvalidoException(); 
            }
            return -1; //devuelve -1 si algo salio mal.. aunq en realidad viene la excepcion antes
        }
        string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$")) return dato;
            else return "";
        }
         
    }
}
