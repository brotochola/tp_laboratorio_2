using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public  sealed class Instructor:PersonaGimnasio
    {

        Queue<EntidadesInstanciables.Gimnasio.EClases> _clasesDelDia;
        static Random _random;

        public Queue<EntidadesInstanciables.Gimnasio.EClases> ClasesDelDia
        {
            get
            {
                return this._clasesDelDia;
            }
        }


        void _randomClases()
        {
            int cantEnumEClases = Enum.GetNames(typeof(EntidadesInstanciables.Gimnasio.EClases)).Length;
            int rnd = new Random().Next(cantEnumEClases);
           //paso el enum a un array
            Array A = Enum.GetValues(typeof(EntidadesInstanciables.Gimnasio.EClases));
            //y saco el valor segun el random, castedo al enum
            EntidadesInstanciables.Gimnasio.EClases V = (EntidadesInstanciables.Gimnasio.EClases)A.GetValue(new Random().Next(cantEnumEClases));
                 
            this._clasesDelDia.Enqueue(V);

                          
            //agrego otro
            EntidadesInstanciables.Gimnasio.EClases V2 = (EntidadesInstanciables.Gimnasio.EClases)A.GetValue(new Random().Next(cantEnumEClases));

            this._clasesDelDia.Enqueue(V2);
      
            
        }

       /*  public  Instructor()
        {
            _random = new Random();
             //que onda esto?
             //posta no esta explicado en las consignas
        }*/

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nac):base(id, nombre, apellido, dni, nac)
        {
            this.ID = id;
            this._clasesDelDia = new Queue<EntidadesInstanciables.Gimnasio.EClases>();
            this._randomClases();

        }

        protected override string MostrarDatos()
        {
           return base.MostrarDatos();
        }


        protected override string ParticiparEnClase()
        {
            string a= "CLASES DEL DÍA ";
            for (int i = 0; i < this._clasesDelDia.Count(); i++)
            {
                a += this._clasesDelDia.Dequeue().ToString() + ", ";
            }
                return  a;
        }

        public override string ToString()
        {
            return this.MostrarDatos();

        }

        public static bool operator ==(Instructor i1, EntidadesInstanciables.Gimnasio.EClases c1)
        {
            if(i1._clasesDelDia.Contains(c1)) return true;
            else return false;
        }
        public static bool operator !=(Instructor a1, EntidadesInstanciables.Gimnasio.EClases c1)
        {
            return !(a1 == c1);
        }
    }
}
