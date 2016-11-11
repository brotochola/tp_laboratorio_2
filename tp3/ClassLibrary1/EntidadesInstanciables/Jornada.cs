using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;


namespace EntidadesInstanciables
{
      [Serializable]
    public  class Jornada
    {
        List<Alumno> _alumnos;
        EntidadesInstanciables.Gimnasio.EClases _clase;
        Instructor _instructor;


        public Jornada this[int i] { get {
            return this;
        } }
          //que onda esto?

        public static bool Guardar(Jornada jornada)
        {

            bool rta = false;
            try { 
                string a=jornada.ToString();
                Archivos.Texto guardador = new Archivos.Texto();

                if (guardador.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt", a))
                {
                    rta = true;
                }
                else
                {
                    rta = false;
                }
            }catch (Exception e)
            {
                throw new ArchivosException(e);
            }
           
            
                return rta;
            

        }

         public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

         public Jornada(EntidadesInstanciables.Gimnasio.EClases clase, Instructor i)
         {
             this._instructor = i;
             this._clase = clase;
         }

         public override string ToString()
         {
             string a= "La Jornada tiene la clase " + this._clase.ToString() + ", el instructor es " + this._instructor.ToString() + ", sus alumnos son: ";
             for (int i = 0; i > this._alumnos.Count(); i++)
             {
                 a += this._alumnos[i].ToString();
             }
             return a;
         }

         public static Jornada operator +(Jornada j1, Alumno a1)
         {
             if (Object.Equals(j1, null) || Object.Equals(a1, null) || Object.Equals(j1._alumnos, null)) return null; //si son null retorna false
          
             if (j1!=a1)
             {
                 j1._alumnos.Add(a1);
                
             }
             return j1;
            
         }

         public static bool operator !=(Jornada j, Alumno a)
         {
             return !(j == a);
         }

         public static bool operator ==(Jornada j, Alumno a)
         {
             bool rta = false;
             if (!Object.Equals(j, null) && !Object.Equals(a, null) && !Object.Equals(j._alumnos, null))
             {

                  /*if (j._alumnos.Contains(a)) return true; //esto estaba elegante, pero no anda
                 else return false;*/

                 foreach (Alumno pibe in j._alumnos)
                 {
                     if (object.Equals(pibe, a))
                     {
                         rta = true;
                     }
                 }
                

             }
             return rta;
         }
    }
}
