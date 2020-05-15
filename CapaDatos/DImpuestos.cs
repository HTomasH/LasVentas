using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-->Usings para poder trabajar con el tipo Datos  y enviar información a SQLServerr
using System.Data;
using System.Data.SqlClient;


//---->>>    MANTENIMIENTO SIN  PROCEDIMIENTO ALMACENADO,  LO HAGO CON CADENAS   

namespace CapaDatos
{
    public class DImpuestos
    {

        /*
            -   EN ESTA APLICACION SE TRABAJA CON DATATABLE 
            -   CONSIGO MANTENER LAS ESTRUCTURA DE LAS 3 CAPAS.
            -   TAMPOCO SE UTILIZAN LAS FOREING KEY ENTRE TABLAS, EN EL EJEMPLO DEL CURSO DE ACCESO A DATOS 
                SI LAS UTILIZA Y APROVECHA ESAS RELACIONES PARA QUE NO SE PUEDAN BORRAR REGISTROS QUE SE RELACIONEN
                ENTRE ELLAS. 
          

            -   TENGO QUE IMPLEMENTAR EL RESTO DE OPCIONES PARA EL MANTINIMIENTO DE IMPUESTOS



            -   TENDRIA QUE HACER ALGUN MANTENIIENTO CON DATASET  (conjunto de tablas)
            -   EL ESTILO "AUTOMATICO" DEL DATASET MOLA, AHORA TRABAJO PERO EN LA PRUEBA QUE HICE AÑADÍ EL
                DATASET EN LA CapaDatos QUE ES DONDE DEBE DE ESTAR PERO... AL INTENTAR UTILIZARLA EN UN FORMULARIO
                NO CONSEGUIA ACCEDER A ELLA....Y TENIA QUE CREAR UNA NUEVA CONEXIÓN Y ESO SE CARGA EL ESTILO DE LAS CAPAS

           -    SE LE PUEDEN AÑADIR CONDICIONES DE  SELECT WHERE DESDE "DENTRO" UTILIZANDO LA UTILIDADES 



            --->> UNA VEZ ACABE CON ESTAS VARIANTES DE LOS ACCESOS TENGO QUE VER EL MANTENIMIENTO DE INGRESOS, ES BASTANTE "TOCHO"



        */
       


        //-------------------    METODO  CONSULTAR/MOSTRAR -----------------------------------------------------------------

        public DataTable Mostrar()
        {
            //-> OjO   de tipo DataTable 
            DataTable DtResultado = new DataTable("TiposIva");

            //->Variable de tipo Conexion 
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Establecemos lac cadena de conexión.
                SqlCon.ConnectionString = Conexion.Cn;

                /*
                RECORDANDO :  La ejecución de comandos se realiza siempre a través de una conexión abierta,
                              y utilizando un objeto de tipo Command específico del proveedor de datos en uso. 
                              Estos objetos serán descendientes de la clase base abstracta DbCommand, implementada 
                              en el espacio de nombres System.Data.Common.
                
                              Así, como es habitual, el proveedor SqlClient proporcionará acceso a los comandos 
                              a través de su clase SqlCommand;   OleDb,  en cambio, 
                              dispondrá de la clase  OleDbCommand para ello, y así para todos los proveedores....
                */

                //->Variable de tipo Comando para poder utilizar en todas las operaciones 
                SqlCommand SqlCmd = new SqlCommand();

                //->Establecemos la cadena de conexión.
                SqlCmd.Connection = SqlCon;

                //->> Inyeccion de codigo ??  NO, esto mas bien seria hardcode tengo el código puesto a machete 
                //    La inyeccion viene al concatenar datos del usuario(de fuera, externos) con parametros de "dentro" 

                /*
                RECORDANDO : 

                •	CommandType.Text            : indica que CommandText contiene una orden SQL.Es el valor por defecto.

                •	CommandType.TableDirect     : indica que CommandText contiene el nombre de una tabla de la que se recuperarán 
                                                  todas las filas y columnas.

                •	CommandType.StoredProcedure : indica que CommandText contiene el nombre de un procedimiento almacenado.

                ------------------------------------------------------------------------------------------------------------------

                A la hora de ejecutarlo, en función del tipo de resultado que pretendemos obtener, debemos utilizar 
                uno de los siguientes métodos:

                •	ExecuteScalar() retorna un object con el valor de la primera columna de la primera fila 
                                    del conjunto de datos obtenido, ignorando el resto. 
                                    
                                    El tipo concreto dependerá de la consulta realizada y del valor obtenido; 
                                    por ejemplo, en el código anterior era un entero,  (cmd.CommandText = "Select Count(*) from Productos";)
                                    puesto que estábamos realizando un recuento de filas.

                •	ExecuteNonQuery() ejecuta una orden sobre la base de datos, normalmente de actualización de datos, 
                                      retornando el número de filas afectadas, o -1 si hay algún error.


                •	ExecuteReader() ejecuta una consulta, retornando una secuencia de sólo avance y sólo lectura 
                                    con los datos obtenidos. 
                                    
                                    El recorrido de estos datos, como veremos más adelante, se realiza a través 
                                    del objeto DbDataReader propio del data provider en uso.


                NOTA  : El proveedor SqlClient proporciona también el método ExecuteXmlReader(), que permite obtener 
                        un objeto XmlReader directamente desde los datos obtenidos en la consulta, en formato XML.

                */


                             //SqlCmd.CommandText = "spMostrar_familia";  //En este PRC lo que hacemos es selecionar los primeros 200 regitros 
                //--> RECORDANDO : SqlCmd.CommandText   laS ordenes  SQL a ejecutar.
                SqlCmd.CommandText = "select * from " + DtResultado.ToString();
                                //SqlCmd.CommandType = CommandType.StoredProcedure;
                //Estamos indicando que es de tipo Text  aunque es el que tiene por defecto.
                SqlCmd.CommandType = CommandType.Text;


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);                
                SqlDat.Fill(DtResultado);   //Con el Fill estoy rellenado el DataTable  DtResultado 

                

                 // OJO   ¿CUANDO SE CIERRA ESTA CONEXION??
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }



       

    }
}
