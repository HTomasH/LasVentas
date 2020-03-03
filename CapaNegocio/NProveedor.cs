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
    public class NProveedor
    {


        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idTrabajador;    
        //                 Propiedades    :  Con Mayúscula la primera         IdTrabajador
        //                 Parametros     :  Con minúscula la primera         idTrabajador
        //---------------------------------------------------------------------------------

        //Son FUNCIONES,  están devolviendo un valor 


        
        //----FUNCION INSERTAR    este va a llamar al metodo insertar de la clase DProveedor de la capa Datos
        public static string Insertar(string cNomPro,  string cNifDni)
        {
            DProveedor Obj = new DProveedor();        //Instanciamos la clase
            Obj.CNomPro = cNomPro;    //Enviamos el valor del parametro recibido a la Propiedad.         
            Obj.CNifDni = cNifDni;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Insertar de la clase DProveedor
            return Obj.Insertar(Obj);
        }




        //----FUNCION  EDITAR/MODIFICAR   este va a llamar al metodo editar de la clase DProveedor de la capa Datos
        //
        public static string Editar(int idProveedo, string cNomPro, string cNifDni)
        {
            
            DProveedor Obj = new DProveedor();        //Instanciamos la clase
            Obj.IdProveedo = idProveedo;
            Obj.CNomPro = cNomPro;    //Enviamos el valor del parametro recibido a la Propiedad.         
            Obj.CNifDni = cNifDni;


            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Editar de la clase DProveedor
            return Obj.Editar(Obj);
        }



        //----FUNCION ELIMINAR   que llama al método Eliminar de la clase DFamilias de la capa Datos        
        public static string Eliminar(int idProveedo)
        {
            DProveedor Obj = new DProveedor();        //Instanciamos la clase
            Obj.IdProveedo = idProveedo;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Eliminar de la clase DProveedor
            return Obj.Eliminar(Obj);
        }


        //----FUNCION  MOSTRAR/CONSULTAR  que llama al método Mostrar de la clase DProveedor   de la CapaDatos
        public static DataTable Mostrar()
        {
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Mostrar de la clase DProveedor
            return new DProveedor().Mostrar();
        }


        //----FUNCION  BUSCARNOMBRE que llama al método BuscarNombre  de la clase DProveedor   de la CapaDatos
        //public static DataTable BuscarNombre(string textobuscar)
        //{
        //    DFamilias Obj = new DFamilias();
        //    Obj.CTextoBuscar = textobuscar;

        //    //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DProveedor
        //    return Obj.BuscarNombre(Obj);
        //}


        //----FUNCION  BUSCAR RAZON SOCIAL NOMBRE que llama al método BuscarNombre  de la clase DProveedor   de la CapaDatos
        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.CTextoBuscar = textobuscar;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DProveedor
            return Obj.BuscarRazonSocial(Obj);
        }


        public static DataTable BuscarNumeroDocumento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.CTextoBuscar = textobuscar;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DProveedor
            return Obj.BuscarNumeroDocumento(Obj);
        }




    }
}
