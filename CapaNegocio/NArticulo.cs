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
    public class NArticulo
    {

        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idTrabajador    
        //                 Propiedades    :  Con Mayúscula la primera         IdTrabajador
        //                 Parametros     :  Con minúscula la primera         idTrabajador
        //---------------------------------------------------------------------------------

        //Son FUNCIONES,  están devolviendo un valor 

        

        //----FUNCION INSERTAR    este va a llamar al metodo insertar de la clase DArticulos de la capa Datos

        
        public static string Insertar(string cDetalle, int idCodFam, decimal nStock, int idTipoIva, decimal nPvP, string cCodigoBar)
        {
            DArticulos  Obj = new DArticulos();        //Instanciamos la clase

            //idCodArti   EN ALTAS NO LO TRATO, ES IDENTITY  
            Obj.CDetalle = cDetalle;    //Enviamos el valor del parametro recibido a la Propiedad.         
            Obj.IdCodFam = idCodFam;
            Obj.NStock = nStock;
            Obj.IdTipoIva = idTipoIva;
            Obj.NPvP = nPvP;
            Obj.CCodigoBar = cCodigoBar;
                                            
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Insertar de la clase DArticulos
            return Obj.Insertar(Obj);
        }


        //----FUNCION  EDITAR/MODIFICAR   este va a llamar al metodo editar de la clase DArticulos de la capa Datos
        //
        public static string Editar(int idCodArti, string cDetalle, int idCodFam, decimal nStock, int idTipoIva, decimal nPvP, string cCodigoBar)
        {            
            DArticulos Obj = new DArticulos();        //Instanciamos la clase
            
            Obj.IdCodArti = idCodArti;  //EN MODIFICACIONES  SI LO VOY A TRATAR, NECESITO SABER EL CODIGO QUE VOY A BUSCAR EN EL PRC 
            Obj.CDetalle = cDetalle;    //Enviamos el valor del parametro recibido a la Propiedad.         
            Obj.IdCodFam = idCodFam;
            Obj.NStock = nStock;
            Obj.IdTipoIva = idTipoIva;
            Obj.NPvP = nPvP;
            Obj.CCodigoBar = cCodigoBar;




            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Editar de la clase DArticulos
            return Obj.Editar(Obj);
        }

        //----FUNCION ELIMINAR   que llama al método Eliminar de la clase DArticulos de la capa Datos        
        public static string Eliminar(int idCodArti)
        {
            DArticulos Obj = new DArticulos();        //Instanciamos la clase
            Obj.IdCodArti = idCodArti;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Eliminar de la clase DArticulos
            return Obj.Eliminar(Obj);
        }


        //----FUNCION  MOSTRAR/CONSULTAR  que llama al método Mostrar de la clase DArticulos   de la CapaDatos
        public static DataTable Mostrar()
        {
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Mostrar de la clase DArticulos
            return new DArticulos().Mostrar();
        }


        //----FUNCION  BUSCARNOMBRE que llama al método BuscarNombre  de la clase DArticulos   de la CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulos Obj = new DArticulos();
            Obj.CTextoBuscar = textobuscar;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DArticulos
            return Obj.BuscarNombre(Obj);
        }


    }
}
