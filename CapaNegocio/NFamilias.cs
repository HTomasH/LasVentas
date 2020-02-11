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
    public class NFamilias   //OjO Publica
    {

        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idTrabajador;    
        //                 Propiedades    :  Con Mayúscula la primera         IdTrabajador
        //                 Parametros     :  Con minúscula la primera         idTrabajador
        //---------------------------------------------------------------------------------

        //Son FUNCIONES,  están devolviendo un valor 

        //----FUNCION INSERTAR    este va a llamar al metodo insertar de la clase DFamilias de la capa Datos
        public static string Insertar(string cNombreFamilia)
        {
            DFamilias Obj = new DFamilias();        //Instanciamos la clase
            Obj.CNombreFamilia = cNombreFamilia;    //Enviamos el valor del parametro recibido a la Propiedad.         

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Insertar de la clase DFamilias
            return Obj.Insertar(Obj);               
        }


        //----FUNCION  EDITAR/MODIFICAR   este va a llamar al metodo editar de la clase DFamilias de la capa Datos
        //
        public static string Editar(int idCodFam, string cNombreFamilia)
        {
            DFamilias Obj = new DFamilias();
            Obj.IdCodFam = idCodFam;
            Obj.CNombreFamilia = cNombreFamilia;            
            
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Editar de la clase DFamilias
            return Obj.Editar(Obj);
        }

        //----FUNCION ELIMINAR   que llama al método Eliminar de la clase DFamilias de la capa Datos        
        public static string Eliminar(int idCodFam)
        {
            DFamilias Obj = new DFamilias();
            Obj.IdCodFam = idCodFam;
            
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Eliminar de la clase DFamilias
            return Obj.Eliminar(Obj);
        }


        //----FUNCION  MOSTRAR/CONSULTAR  que llama al método Mostrar de la clase DFamilias   de la CapaDatos
        public static DataTable Mostrar()
        {
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Mostrar de la clase DFamilias
            return new DFamilias().Mostrar();
        }


        //----FUNCION  BUSCARNOMBRE que llama al método BuscarNombre  de la clase DFamilias   de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DFamilias Obj = new DFamilias();
            Obj.CTextoBuscar = textobuscar;
            
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DFamilias
            return Obj.BuscarNombre(Obj);
        }



    }
}
