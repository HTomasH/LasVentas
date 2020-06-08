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


        public static List<Entidad> Mostrar()
        {
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Mostrar de la clase DFamilias

            return new DEntidad().Listar();
        }





        ////----FUNCION  EDITAR/MODIFICAR   este va a llamar al metodo editar de la clase DFamilias de la capa Datos
        ////
        //public static string Editar(int idCodFam, string cNombreFamilia)
        //{
        //    DFamilias Obj = new DFamilias();
        //    Obj.IdCodFam = idCodFam;
        //    Obj.CNombreFamilia = cNombreFamilia;

        //    //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Editar de la clase DFamilias
        //    return Obj.Editar(Obj);
        //}

        ////----FUNCION ELIMINAR   que llama al método Eliminar de la clase DFamilias de la capa Datos        
        //public static string Eliminar(int idCodFam)
        //{
        //    DFamilias Obj = new DFamilias();
        //    Obj.IdCodFam = idCodFam;

        //    //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Eliminar de la clase DFamilias
        //    return Obj.Eliminar(Obj);
        //}




        ////----FUNCION  BUSCARNOMBRE que llama al método BuscarNombre  de la clase DFamilias   de la CapaDatos
        //public static DataTable BuscarNombre(string textobuscar)
        //{
        //    DFamilias Obj = new DFamilias();
        //    Obj.CTextoBuscar = textobuscar;

        //    //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DFamilias
        //    return Obj.BuscarNombre(Obj);
        //}




    }
}
