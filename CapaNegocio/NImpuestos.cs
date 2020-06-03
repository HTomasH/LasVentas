using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-->OjO   OjO    Tengo añadida en Referencias la referencia a CapaDatos  pero además necesitamos sus clases así que hay que indicar using


using CapaDatos;
using System.Data;




//---->>>    MANTENIMIENTO SIN  PROCEDIMIENTO ALMACENADO,  LO HAGO CON CADENAS   

namespace CapaNegocio
{



    public class NImpuestos
    {



      


        public static DataTable Mostrar()
        {
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Mostrar de la clase
            return new DImpuestos().Mostrar();
        }

        //this.txtcDetIva.Text.Trim().ToUpper(),  Convert.ToDecimal(this.txtnPorcIva.Text), Convert.ToDecimal(this.txtnPorReq.Text)

        public static string Insertar(string cDetIva, decimal nPorcIva, decimal nPorReq)
        {
            
            DImpuestos Obj = new DImpuestos();  //Instanciamos la clase 

            //idCodArti   EN ALTAS NO LO TRATO, ES IDENTITY  
            Obj.CDetIva = cDetIva;    //Enviamos el valor del parametro recibido a la Propiedad.         
            Obj.NPorcIva = nPorcIva;
            Obj.NPorReq = nPorReq;
            
            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Insertar de la clase DImpuestos
            return Obj.Insertar(Obj);
        }

        //----FUNCION ELIMINAR   que llama al método Eliminar de la clase DArticulos de la capa Datos        
        public static string Eliminar(int idTipoIva)  
        {
            DImpuestos Obj = new DImpuestos();        //Instanciamos la clase
            Obj.IdTipoIva = idTipoIva;

            //ATENTO :  El valor de retorno,  se lo estamos enviando al metodo Eliminar de la clase DImpuestos
            return Obj.Eliminar(Obj);
        }
    }




}
