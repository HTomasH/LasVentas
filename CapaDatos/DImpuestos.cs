using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-->Usings para poder trabajar con el tipo Datos  y enviar información a SQLServerr
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DImpuestos
    {

        /*
        -   TENGO QUE APROVECHAR LAS CONEXIONES QUE TENGO.
        -   LO DEL AUTOMATICO MOLA MUCHO PERO NO LO VEO CLARO
        -   TENGO QUE ESTABLECER EL ACCESO EN VEZ DE POR PRC VIA DIRECTO 
        
        -   PROBAR CON EL METODO MOSTRAR Y LUEGO VER LOS OTROS 
        -   LO QUE AQUI INDIQUE SERA DESDE DONDE LO LLAMARE DESDE EL FORMULARIO 
        
        */
       


        //-------------------    METODO  CONSULTAR/MOSTRAR -----------------------------------------------------------------

        public DataTable Mostrar()
        {
            //-> OjO   de tipo DateTable 
            DataTable DtResultado = new DataTable("TiposIva");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                //->> inyeccion de codigo NO, esto mas bien seria hardcode tengo el código puesto a machete 

                //SqlCmd.CommandText = "spMostrar_familia";  //En este PRC lo que hacemos es selecionar los primeros 200 regitros 
                SqlCmd.CommandText = "select * from " + DtResultado.ToString();                 
                //SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.CommandType = CommandType.Text;


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);                
                SqlDat.Fill(DtResultado);    //Con el Fill estoy rellenado el DataTable  DtResultado 
                
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }



       

    }
}
