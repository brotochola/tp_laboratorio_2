using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Archivos;


namespace Archivos
{
   public  class Texto : iArchivos<string>
    {
       public bool Guardar(string archivo, string datos)
       {
           bool rta = false;
           try
           {
               using (StreamWriter txt = new StreamWriter(archivo))
               {

                   txt.WriteLine(datos);
               }
               rta = true;
           }
           catch (Exception e)
           {
               throw new ArchivosException(e);
           }

           return rta;
       }
   



       public bool Leer(string archivo, out string datos)
       {

           bool rta = false;
           try
           {
               using (StreamReader txt = new StreamReader(archivo))
               {
                   datos = txt.ReadToEnd();
               }
               rta = true;
           }
           catch (Exception e)
           {
               throw new ArchivosException(e);
           }

           return rta;

       }
    }
}
