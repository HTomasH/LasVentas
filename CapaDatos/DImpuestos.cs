using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




//-->Usings para poder trabajar con el tipo Datos  y enviar información a SQLServerr
using System.Data;
using System.Data.SqlClient;


//---->>>    MANTENIMIENTO SIN  PROCEDIMIENTO ALMACENADO,  LO HAGO CON CADENAS   

namespace CapaDatos
{
    public class DImpuestos
    {


        /*
          Declaración de los CAMPOS con los que vamos a trabajar
          que son los campos de la tabla Familias.
          
          Vamos a ponerles un guion bajo  por delante para diferenciar los Campos  y  las Propiedades 
        */


        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idCodFam;    
        //                 Propiedades    :  Con Mayúscula la primera         IdCodFam
        //                 Paremetros     :  Con minúscula la priemera        idCodFam
        //---------------------------------------------------------------------------------
        
       

        private int _idTipoIva;
        private string _cDetIva;
        private decimal _nPorcIva;
        private decimal _nPorReq;


        //->Variable extra para las búsqueda del nombre 
        private string _cTextoBuscar;

    

        //-->Y ahora para pintar las PROPIEDADES, lo haremos Refactorizando !!   
        //   Se hace colocandose sobre la variable y le damos al botón derecho - Opcion Refactorizar - Encapsular Campo 

        // GETer   Devuelve valores
        // SETer   Recibe valores.

        public int IdTipoIva
        {
            get { return _idTipoIva;  }
            set { _idTipoIva = value;  }
        }

        public string CDetIva
        {
            get {return _cDetIva; }
            set { _cDetIva = value;}
        }

        public decimal NPorcIva
        {
            get { return _nPorcIva; }
            set { _nPorcIva = value; }
        }

        public decimal NPorReq
        {
            get { return _nPorReq; }
            set { _nPorReq = value; }
        }

        public string CTextoBuscar
        {
            get  { return _cTextoBuscar;  }
            set  { _cTextoBuscar = value; }
        }




        //------------------------------
        //-->Constructor  SIN PARAMETROS 
        //------------------------------
        public DImpuestos()
        {
        }

        //----------------------------------------------------------------------------------        
        //-->Constructor  CON PARAMETROS (Vamos a indicar los parametros con  minúsculas )
        //----------------------------------------------------------------------------------        

        public DImpuestos(int idTipoIva, string cDetIva, decimal nPorcIva, decimal nPorReq, string cTextoBuscar)
        {
            //-->Vamos a enviar los datos que  nos llegan en estos parametros  a nuestras propiedades 
            this.IdTipoIva = idTipoIva;
            this.CDetIva = cDetIva;
            this.NPorcIva = Convert.ToDecimal(nPorcIva);
            this.NPorReq = Convert.ToDecimal(nPorReq);
            this.CTextoBuscar = cTextoBuscar;            
        }




        //-------------------    METODO  ALTAS  ------------------------------------------------------------------

        /*
            En los parametros que vamos a recibir en este método lo hacemos es 
            instanciar  la clase,  de esta forma nos evitamos tener que estar poniendo campo a campo
            de los que se tengan que tener en cuenta, en este ejemplo son pocos campos pero si fueramos a tratar tabla
            donde hubiera muchos campos es un puto coñazo
        */
        public string Insertar(DImpuestos TiposIva)
        {
    
            string rpta = "";                             //-->  rpta  -  Variable para saber el valor de retorno
            SqlConnection SqlCon = new SqlConnection();   //-->  SqlCon - Variable de tipo  Conexión SQL

            try  //--->Control de Errores                    
            {

                //--> Le digo a  ConnectionString  cual es nuestra conexión que tengo en la clase Conexión y en la variable  Cn
                SqlCon.ConnectionString = Conexion.Cn;   
                SqlCon.Open();   //--> Abrimos la conexión 

                SqlCommand SqlCmd = new SqlCommand();  //-->  SqlCmd será la variable de la clase SqlCommand para poder utilizar los comandos de SQL 
                SqlCmd.Connection = SqlCon;            //-->  Le pasamos la conexión.

                //-----------------------CODIGO PARA PROCEDIMIENTOS ALMACENADOS------------------------
                //SqlCmd.CommandText = "spInsertar_familia";         //-->  Le decimos el nombre del Procedimiento a ejecutar 
                //SqlCmd.CommandType = CommandType.StoredProcedure;  //-->  Le decimos que el tipo de comando es un PRC


                //-----------------------CODIGO PARA TEXTO es el tipo  que está  por defecto ------------------------
                /*
                   -  En este caso vamos a utilizar una linea con las instrucciones a ejecutar
                   -  El  $  es interpolación de cadenas, necesario, tengo mucho caracter especial.
                   -  NombreTabla  Values  ( valores a grabar en el mismo orden que tengan los campos en la tabla) 
                   -  Para que no de fallo ya que los campos Identity no se deben de enviar
                      indicaremos el nombre de la tabla y entre paréntesis el nombre de los campos.

                   -  Si los valores de los porcentajes van con la coma decimal da error de conversion de Varchar a Numeric
                      los valores de  NPorcIva y NPorReq son correctos, son númericos, pero la coma no la reconoce bien

                      Utilizando la opción del procedimiento almacenado no da ese problema...
                      los valores que llegan son correctos, son decimal
                
                      Con esta cadena de inserción no había forma, daba error de conversion de VarChar a Decimal ... 
                         SqlCmd.CommandText = $"insert into TiposIva( cDetIva,  nPorcIva,  nPorReq )  values ( '{this.CDetIva}' , {this.NPorcIva}, {this.NPorReq} )";
                                                                      
                */

                //-->INSERT con parametrización, esta si va bien, se indica el tipo de cada campo como en el PRC
                SqlCmd.CommandText = $"insert into TiposIva( cDetIva,  nPorcIva,  nPorReq )  values ( @CDetIva , @NPorcIva, @NPorReq )";
                SqlParameter parcDetIva = SqlCmd.Parameters.Add("@CDetIva", SqlDbType.VarChar);
                SqlParameter parNPorcIva = SqlCmd.Parameters.Add("@NPorcIva", SqlDbType.Decimal);
                SqlParameter parNPorReq = SqlCmd.Parameters.Add("@NPorReq", SqlDbType.Decimal);

                parcDetIva.Value = CDetIva;
                parNPorcIva.Value = NPorcIva;
                parNPorReq.Value = NPorReq;

                //--> ExecuteNonQuery  nos devolverá el número de filas(registros) afectados,                                    
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;   //-->Mostramos el mensaje.
            }
            finally   //--> El finally se ejecuta siempre 
                      //    tanto si hay error como si no lo hay, así que cerramos la conexión que chupa mucha memoria.
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
               

            }
            return rpta;

        }

   

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
                              a través de su clase SqlCommand;   
                              OleDb,  en cambio,  dispondrá de la clase  OleDbCommand para ello, y así para todos los proveedores....
                */

                //->Variable de tipo Comando para poder utilizar en todas las operaciones 
                SqlCommand SqlCmd = new SqlCommand();

                //->Establecemos la cadena de conexión.
                SqlCmd.Connection = SqlCon;

                // NO SE DONDE ABRE LA CONEXION LA VERDAD, EN LOS OTROS BOTONES SI SE ABRE Y SE CIERRA 


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


                //-->Así indicariamos el nombre del PRC a llamar :   SqlCmd.CommandText = "spMostrar_familia";                  

                //-->En este caso vamos a utilizar una linea con las instrucciones a ejecutar
                SqlCmd.CommandText = "select * from " + DtResultado.ToString();
                
                //-->Indicamos el tipo del comando  de PRC o Cadena,  por defecto tiene cadena Text
                //   SqlCmd.CommandType = CommandType.StoredProcedure;                
                SqlCmd.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);                
                //-->Estamos rellenando (FILL )el DataTable  
                SqlDat.Fill(DtResultado);   //Con el Fill estoy rellenado el DataTable  DtResultado 
                                                
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        
          
         //-------------------    METODO  BAJAS/ELIMINAR -----------------------------------------------------------------
        public string Eliminar(DImpuestos TiposIva)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Código
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                                                                         
                
                //-->DELETE con parametrización, esta si va bien, se indica el tipo de cada campo como en el PRC
                SqlCmd.CommandText = $"delete from TiposIva where idTipoIva = @IdTipoIva";
                SqlParameter paridTipoIva = SqlCmd.Parameters.Add("@IdTipoIva", SqlDbType.Int);
                
                paridTipoIva.Value = IdTipoIva;                                
                //Ejecutamos nuestro comando, es decir estamos llamando al procedimiento almacenado para que se ejecute 
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
 
         

        public void nabos()
        {

             MessageBox.Show("LLEGAMOS " , "CAPTION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //El nombre de la clase, se trata de la conexion, no el del Modelo
            //-----------------------------------------------------------------
            //-->En este caso NO funciona ya que la variable no carga la estructura de la tabla

            //JODER JODER JODER  al final lo he conseguido  hay que incluir la cadena de conexion en el App.config de  LasVentas 

            // lo que no se es, para mantener las tres capas... es decir si pongo el Modelo en la Capadatos.. deberé de indicar la conexion en 
            // el App.config  general ???   a ver si funciona 

            // OjO que aqui no se ve el que esta ubicado en LasVentas y viceversa 

            
            // PROBAR  A PONER EN LA CAPADATOS UN MODELO CON  VARIAS TABLAS
            // INDICAR EN EL App.config  principal la cadena de conexión  y a ver si se ve

            //--> EFECTIVAMENTEEEEEEEEE    SE VE EN TODA LA CAPA DATOS, POR LO CUAL EL MODELO SE INDICA EN LA CAPA DATOS CON
            //                             TODAS LAS TABLAS Y EN EL APP.CONFIG GENERAL SE INDICA LA CADENA DE CONEXION


            using (VentasTOMASEntities4 dbx = new VentasTOMASEntities4())
            {
                var lst = dbx.Proveedores;

                foreach (var oModerna in lst)
                {
                    MessageBox.Show("Nombre : " + oModerna.cNomPro, "CAPTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }








    }
}
