using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-->OjO   OjO    Tengo añadida en Referencias la referencia a CapaDatos  pero además necesitamos sus clases así que hay que indicar using
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NEntidad
    {


        //----FUNCION INSERTAR    este va a llamar al metodo insertar de la clase DEntidad de la capa Datos
        public static string Insertar(string cNombreEntidad, string cDepartamento)  //, string cTextoBuscar
        {
            // DEntidad Obj = new DEntidad();        //Instanciamos la clase
            // Obj.Nombre = cNombreEntidad;    //Enviamos el valor del parametro recibido a la Propiedad.         
            // Obj.Departamento = cDepartamento;

            DEntidad Obj = new DEntidad();

            Obj.Nombre = cNombreEntidad;
            Obj.Departamento = cDepartamento;


            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Insertar de la clase DEntidad
            return Obj.Insertar(Obj);
        }

        //---FUNCION MOSTRAR (LISTAR)    
        public static List<Entidad> Mostrar()
        {
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Mostrar de la clase DEntidad

            return new DEntidad().Listar();
        }



        ////----FUNCION ELIMINAR   que llama al método Eliminar de la clase DFamilias de la capa Datos        
        public static string Eliminar(int idEntidad)
        {
            DEntidad Obj = new DEntidad();
            Obj.Identifica = idEntidad;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Eliminar de la clase DEntidad
            return Obj.Eliminar(Obj);
        }





        //----FUNCION  EDITAR/MODIFICAR   este va a llamar al metodo editar de la clase DFamilias de la capa Datos

        public static string Editar(int idEntidad, string nombreEntidad, string deparEntidad)
        {
            DEntidad Obj = new DEntidad();
            Obj.Identifica = idEntidad;
            Obj.Nombre = nombreEntidad;
            Obj.Departamento = deparEntidad;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Editar de la clase DEntidad
            return Obj.Editar(Obj);
        }




        ////----FUNCION  BUSCARNOMBRE que llama al método BuscarNombre  de la clase DFamilias   de la CapaDatos
        public static string BuscarNombre(string textobuscar)
        {
            DEntidad Obj = new DEntidad();
            Obj.CTextoBuscar = textobuscar;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DEntidad
            return Obj.BuscarNombre(Obj);
        }


    }
}
