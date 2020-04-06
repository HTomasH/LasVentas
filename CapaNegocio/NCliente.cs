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
    public class NCliente
    {



        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idTrabajador;    
        //                 Propiedades    :  Con Mayúscula la primera         IdTrabajador
        //                 Parametros     :  Con minúscula la primera         idTrabajador
        //---------------------------------------------------------------------------------

        //Son FUNCIONES,  están devolviendo un valor 



        //----FUNCION INSERTAR    este va a llamar al metodo insertar de la clase DProveedor de la capa Datos
        //---------------------------------------------------------------------------------------------------
        public static string Insertar(string cNomCli, string cDirCli, string cPobCli, string cDniCif,
                                      string cContacto, string cCtaContable, decimal nDto, string cTelefono1, string cEmail,
                                      string cCodPostal, DateTime dFechaNaci, string cTextoBuscar)
        {
                    
            DClientes  Obj = new DClientes();        //Instanciamos la clase
            
            //Enviamos el valor del parametro recibido a la Propiedad.         
            Obj.CNomCli = cNomCli;
            Obj.CDirCli = cDirCli;
            Obj.CPobCli = cPobCli;
            Obj.CDniCif = cDniCif;
            Obj.CContacto = cContacto;
            Obj.CCtaContable = cCtaContable;            
            Obj.NDto = nDto;
            Obj.CTelefono1 = cTelefono1;
            Obj.CEmail = cEmail;
            Obj.CCodPostal = cCodPostal;
            Obj.DFechaNaci = dFechaNaci;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Insertar de la clase DClientes
            return Obj.Insertar(Obj);
        }




        //----FUNCION  EDITAR/MODIFICAR   este va a llamar al metodo editar de la clase DProveedor de la capa Datos
        //---------------------------------------------------------------------------------------------------------
        //        
         public static string Editar(int idCodcli,  string cNomCli, string cDirCli, string cPobCli, string cDniCif,
                                      string cContacto, string cCtaContable, decimal nDto, string cTelefono1, string cEmail,
                                      string cCodPostal, DateTime dFechaNaci, string cTextoBuscar)

        {

            DClientes Obj = new DClientes();        //Instanciamos la clase


            //Enviamos el valor del parametro recibido a la Propiedad.         
            Obj.IdCodcli = idCodcli;
            Obj.CNomCli = cNomCli;
            Obj.CDirCli = cDirCli;
            Obj.CPobCli = cPobCli;
            Obj.CDniCif = cDniCif;
            Obj.CContacto = cContacto;
            Obj.CCtaContable = cCtaContable;
            Obj.NDto = nDto;
            Obj.CTelefono1 = cTelefono1;
            Obj.CEmail = cEmail;
            Obj.CCodPostal = cCodPostal;
            Obj.DFechaNaci = dFechaNaci;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Editar de la clase DClientes
            return Obj.Editar(Obj);
        }



        //----FUNCION ELIMINAR   que llama al método Eliminar de la clase DClientes de la capa Datos  
        //------------------------------------------------------------------------------------------      
        public static string Eliminar(int IdCodcli)
        {
            DClientes Obj = new DClientes();        //Instanciamos la clase
            Obj.IdCodcli = IdCodcli;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Eliminar de la clase DClientes
            return Obj.Eliminar(Obj);
        }


        //----FUNCION  MOSTRAR/CONSULTAR  que llama al método Mostrar de la clase DClientes   de la CapaDatos
        //-----------------------------------------------------------------------------------------------------
        public static DataTable Mostrar()
        {
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Mostrar de la clase DClientes
            return new  DClientes().Mostrar();
        }


        //----FUNCION  BUSCARNOMBRE que llama al método BuscarNombre  de la clase DClientes   de la CapaDatos
        //public static DataTable BuscarNombre(string textobuscar)
        //{
        //    DFamilias Obj = new DFamilias();
        //    Obj.CTextoBuscar = textobuscar;

        //    //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DClientes
        //    return Obj.BuscarNombre(Obj);
        //}


        //----FUNCION  BUSCAR RAZON SOCIAL NOMBRE que llama al método BuscarNombre  de la clase DProveedor   de la CapaDatos
        //------------------------------------------------------------------------------------------------------------------
        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            DClientes Obj = new DClientes();        //Instanciamos la clase
            Obj.CTextoBuscar = textobuscar;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DProveedor
            return Obj.BuscarRazonSocial(Obj);
        }


        //----FUNCION  BUSCAR #########  que llama al método BuscarNombre  de la clase DProveedor   de la CapaDatos
        //------------------------------------------------------------------------------------------------------------------
        

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DClientes Obj = new DClientes();        //Instanciamos la clase
            Obj.CTextoBuscar = textobuscar;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo BuscarNombre de la clase DProveedor
            return Obj.BuscarNum_Documento(Obj);
        }


    }
}
