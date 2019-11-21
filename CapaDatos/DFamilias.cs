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
    public class DFamilias   //Indicar que es publica de lo contrario no podre acceder a ella 
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


        private int _idCodFam;
        private string _cNombreFamilia;

        //->Variable extra para las búsqueda del nombre 
        private string _cTextoBuscar;



        //-->Y ahora para pintar las PROPIEDADES, lo haremos Refactorizando !!   
        //   Se hace colocandose sobre la variable y le damos al botón derecho - Opcion Refactorizar - Encapsular Campo 

        // GETer   Devuelve valores
        // SETer   Recibe valores.

        public int IdCodFam
        {
            get { return _idCodFam; }
            set { _idCodFam = value; }
        }

        public string CNombreFamilia
        {
            get { return _cNombreFamilia; }
            set { _cNombreFamilia = value; }
        }

        public string CTextoBuscar
        {
            get { return _cTextoBuscar; }
            set { _cTextoBuscar = value; }
        }


        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idCodFam;    
        //                 Propiedades    :  Con Mayúscula la primera         IdCodFam
        //                 Parametros     :  Con minúscula la primera         idCodFam
        //---------------------------------------------------------------------------------



        //------------------- CONSTRUCTORES   ----------------------------------------------
        //----------------------------------------------------------------------------------

        //-->Constructor  SIN PARAMETROS 
        //------------------------------
        public DFamilias()
        {
        }
       
        //----------------------------------------------------------------------------------        
        //-->Constructor  CON PARAMETROS (Vamos a indicar los parametros con  minúsculas )
        //----------------------------------------------------------------------------------        

        public DFamilias(int idCodFam, string cNombreFamilia, string cTextoBuscar)
        {
            //Vamos a enviar los datos que  nos llegan en estos parametros  a nuestras propiedades 

            this.CNombreFamilia = cNombreFamilia;
            this.IdCodFam = idCodFam;
            this.CTextoBuscar = cTextoBuscar;
        }


        //----------------------------------------------------------------------------------//
        //         BLOQUE DE METODOS PARA  ALTAS, BAJAS, MODIFICACIONES .....
        //----------------------------------------------------------------------------------//

        //-------------------    METODO  ALTAS  ------------------------------------------------------------------

        //En los parametros que vamos a recibir en este metodo lo hacemos es 
        //instanciar  la clase,  de esta forma nos evitamos tener que estar poniendo campo a campo
        //de los que se tengan que tener en cuenta, en este ejemplo son pocos campos pero si fueramos a tratar tabla
        //donde hubiera muchos campos es un puto coñazo

        public string Insertar(DFamilias Familias)
        {



            string rpta = "";                             //-->  rpta  -  Variable para saber el valor de retorno
            SqlConnection SqlCon = new SqlConnection();   //-->  SqlCon - Variable de tipo  Conexión SQL
            try  //--->Control de Errores                    
            {

                SqlCon.ConnectionString = Conexion.Cn;   //--> Le digo a  ConnectionString  cual es nuestra conexión que tengo en la clase Conexión y en la variable  Cn
                SqlCon.Open();   //--> Abrimos la conexión 


                SqlCommand SqlCmd = new SqlCommand();              //-->  SqlCmd  -  Variable de la clase SqlCommand para poder utilizar los comandos de SQL 
                SqlCmd.Connection = SqlCon;                        //-->  Le pasamos la conexión.
                SqlCmd.CommandText = "spInsertar_familia";         //-->  Le decimos el nombre del Procedimiento a ejecutar 
                SqlCmd.CommandType = CommandType.StoredProcedure;  //-->  Le decimos que el tipo de comando es un PRC


                //-->Descripción del campo   idCodFam   de la tabla Familias   
                //-----------------------------------------------------------------------------------
                SqlParameter ParIdCodFam = new SqlParameter();      //-> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParIdCodFam.ParameterName = "@idCodFam";            //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdCodFam.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdCodFam.Direction = ParameterDirection.Output;  //-> Este campo es Identity por lo tanto indicar que es de salida Output                
                SqlCmd.Parameters.Add(ParIdCodFam);                 //-> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                //-->Descripción del campo   cNombreFamilia   de la tabla Familias   
                //-----------------------------------------------------------------------------------

                SqlParameter ParNombreFamilia = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParNombreFamilia.ParameterName = "@cNombreFamilia";  //--> Nombre del paramentro como está en el PRC
                ParNombreFamilia.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParNombreFamilia.Size = 50;                          //--> Longuitud del campo 
                ParNombreFamilia.Value = Familias.CNombreFamilia;    //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParNombreFamilia);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                //--> Ahora Ejecutamos nuestro comando (tipo  TERNARIO),  es decir estamos llamando al procedimiento almacenado para que se ejecute 
                //    Controlamos el éxito de la operación con el valor retornado en la variable  rpta
                //      if  ( SqlCmd.ExecuteNonQuery()  ==   1 )
                //       { 
                //           rpta = "OK";
                //       }
                //   :   else
                //       { 
                //          rpta "NO se Ingreso el Registro";
                //       }                
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;   //-->Mostramos el mensaje.
            }
            finally      //--> el  finally se ejecuta siempre tanto si hay error como si no lo hay, así que cerramos la conexión que ya sabemos como mucha memoria.
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }


        //-------------------    METODO  MODIFICAR/EDITAR -----------------------------------------------------------------
        public string Editar(DFamilias Familias)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spEditar_familia";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdCodFam = new SqlParameter();
                ParIdCodFam.ParameterName = "@idCodFam";  //Nombre que tengo en el PCR
                ParIdCodFam.SqlDbType = SqlDbType.Int;
                ParIdCodFam.Value = Familias.IdCodFam;    //Toma el valor de la propiedad 
                SqlCmd.Parameters.Add(ParIdCodFam);


                SqlParameter ParNombreFamilia = new SqlParameter();
                ParNombreFamilia.ParameterName = "@cNombreFamilia";   //Nombre que tengo en el PCR
                ParNombreFamilia.SqlDbType = SqlDbType.VarChar;
                ParNombreFamilia.Size = 50;
                ParNombreFamilia.Value = Familias.CNombreFamilia;
                SqlCmd.Parameters.Add(ParNombreFamilia);

                //Ejecutamos nuestro comando, es decir estamos llamando al procedimiento almacenado para que se ejecute 
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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


        //-------------------    METODO  BAJAS/ELIMINAR -----------------------------------------------------------------
        public string Eliminar(DFamilias Familias)
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
                SqlCmd.CommandText = "spEliminar_familia";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdCodFam = new SqlParameter();
                ParIdCodFam.ParameterName = "@idCodFam";
                ParIdCodFam.SqlDbType = SqlDbType.Int;
                ParIdCodFam.Value = Familias.IdCodFam;
                SqlCmd.Parameters.Add(ParIdCodFam);

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



        //-------------------    METODO  CONSULTAR/MOSTRAR -----------------------------------------------------------------
        
        public DataTable Mostrar()
        {
            //-> OjO   de tipo DateTable 
            DataTable DtResultado = new DataTable("Familias");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_familila";  //En este PRC lo que hacemos es selecionar los primeros 200 regitros 
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);    //Con el Fill estoy rellenado  DtResultado  que es un DataTable  de Familias

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }



        //-> metodo para buscar solo el nombre de las familias, lo mismo en vez de recibir el campo en cuestion indicamos toda la clase
        //public DataTable BuscarNombre (DCategoria Categoria)
        public DataTable BuscarNombre( DFamilias Familias)
        {

            DataTable DtResultado = new DataTable("Familias");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscarNombre_familia";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Familias.CTextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }




    }
}
