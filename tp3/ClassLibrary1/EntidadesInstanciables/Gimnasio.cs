using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{

 
    [Serializable]
    //todo esto se va a exportar en el xml:
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Persona))]
    public class Gimnasio
    {
        public enum EClases
        {
            CrossFit, Natacion, Pilates, Yoga
        }

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;


     

        /// <summary>
        /// constructor por default, inicializa las listas
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        public static bool Guardar(Gimnasio g1)
        {

            Archivos.Xml<Gimnasio> guardador = new Archivos.Xml<Gimnasio>();
          //  if (guardador.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Gimansio.Xml", g1)) return true;

           // else return false;
            return true;
        }

        private static string MostrarDatos(Gimnasio g)
        {
            string a = "El gimnasio tiene los siguientes alumnos: ";
            for (int i = 0; i < g._alumnos.Count(); i++)
            {
                a+= g._alumnos[i].ToString();
            }
            a+="\n... los siguientes instructores:";

             for (int i = 0; i < g._instructores.Count(); i++)
            {
                a+= g._instructores[i].ToString();
            }
            a+="\n Y las siguientes jornadas:";
            for (int i = 0; i < g._jornada.Count(); i++)
            {
                a+= g._jornada[i].ToString();
            }
            return a;

        }

        public static bool operator !=(Gimnasio g, Alumno a){
            return !(g == a);
        }
        public static Instructor operator !=(Gimnasio g, EntidadesInstanciables.Gimnasio.EClases c)
        {
            int cualInstructor = -1;
            for (int i = 0; i < g._instructores.Count(); i++)
            {
                if (!g._instructores[i].ClasesDelDia.Contains(c)) cualInstructor = i;
            }

            if (cualInstructor != -1) return g._instructores[cualInstructor];
            else return null; //si todos pueden, retorna null.. no dice nada en las consignas
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            if (!g._instructores.Contains(i)) return true;
            else return false;
        }

     
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (!g._alumnos.Contains(a)) g._alumnos.Add(a); //esto despues lo voy a usar en g+c
            return g;
        }
        public static Gimnasio operator +(Gimnasio g, EClases c)
        {
            if (!Object.Equals(g, null) && !Object.Equals(c, null) && !Object.Equals(g._alumnos, null))
            {


                int cualInstructor = -1;
                Jornada j = new Jornada(c, (g == c));
                //al igualar un gimnasio con una clase, me devuelve un instructor :D

                /*   for (int i = 0; i < g._instructores.Count(); i++)
                   {
                       if (g._instructores[i].ClasesDelDia.Contains(c)) //si elguno de los instructores del gim, da la clase c
                       {
                           cualInstructor =i;
                           j = new Jornada(c, g._instructores[i]);
                           break; //solo un instructor por jornada
                       }
                   }*/


                for (int i = 0; i < g._alumnos.Count(); i++) //se fija que alumnos del gimnasio toman la clase c
                {
                    if (g._alumnos[i] == c)
                    {
                        j += g._alumnos[i]; //los agrega a la jornada, tantos como haya
                    }
                }

                g._jornada.Add(j); //agrega la jornada al gim, solo si
            }
            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (!g._instructores.Contains(i)) g._instructores.Add(i);
            return g;
        }

        public static bool operator ==(Gimnasio g, Alumno a)
        {
            if (g._alumnos.Contains(a)) return true;
            else return false;
        }
        public static Instructor operator ==(Gimnasio g, EClases c)
        {
            for (int i = 0; i < g._instructores.Count(); i++) //recorro los instructores de este gimnadio
            {
                if (g._instructores[i] == c)
                {
                    return g._instructores[i];
                }
            }
            return null;
        }

        public static bool operator ==(Gimnasio g, Instructor i)
        {
            if (g._instructores.Contains(i)) return true;
            else return false;
        }

        /// <summary>
        /// gim[i] devuelve la jornada segun su indice
        /// </summary>
        /// <param name="i">indice de jornada de este gim</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { 
                return this._jornada[i];  
            }
        }
    }
}
