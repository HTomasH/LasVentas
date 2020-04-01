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
    public class DProveedor
    {

        /*
          Declaración de los CAMPOS con los que vamos a trabajar
          que son los campos de la tabla Proveedores.
          
          Vamos a ponerles un guion bajo  por delante para diferenciar los Campos  y  las Propiedades 
        */


        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idCodFam;    
        //                 Propiedades    :  Con Mayúscula la primera         IdCodFam
        //                 Parametros     :  Con minúscula la priemera        idCodFam
        //---------------------------------------------------------------------------------

        private int _idProveedo;
        private string _cNomPro;
        private string _cNifDni;

        //->Variable extra para las búsqueda del nombre 
        private string _cTextoBuscar;


        public int IdProveedo
        {
            get {return _idProveedo; }
            set { _idProveedo = value;}
        }

        public string CNomPro
        {
            get {return _cNomPro;}
            set { _cNomPro = value; }
        }

        public string CNifDni
        {
            get { return _cNifDni; }
            set { _cNifDni = value; }
        }

        public string CTextoBuscar
        {
            get { return CTextoBuscar;   }
            set { CTextoBuscar = value;   }
        }


        
        //-->Constructor  SIN PARAMETROS 
        //------------------------------
        public DProveedor()
        {
        }


        
        //-->Constructor  CON PARAMETROS (Vamos a indicar los parametros con  minúsculas )
        //----------------------------------------------------------------------------------        
        public DProveedor(int idProveedo, string cNomPro, string cNifDni, string cTextoBuscar)
        {
            //Vamos a enviar los datos que  nos llegan en estos parametros  a nuestras propiedades 
            this.IdProveedo = idProveedo;
            this.CNomPro = cNomPro;
            this.CNifDni = cNifDni;
            
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

        public string Insertar( DProveedor Proveedor )
        {


            string rpta = "";                             //-->  rpta  -  Variable para saber el valor de retorno
            SqlConnection SqlCon = new SqlConnection();   //-->  SqlCon - Variable de tipo  Conexión SQL
            try  //--->Control de Errores                    
            {

                SqlCon.ConnectionString = Conexion.Cn;   //--> Le digo a  ConnectionString  cual es nuestra conexión que tengo en la clase Conexión y en la variable  Cn
                SqlCon.Open();   //--> Abrimos la conexión 


                SqlCommand SqlCmd = new SqlCommand();              //-->  SqlCmd  -  Variable de la clase SqlCommand para poder utilizar los comandos de SQL 
                SqlCmd.Connection = SqlCon;                        //-->  Le pasamos la conexión.
                SqlCmd.CommandText = "spInsertar_Proveedor";         //-->  Le decimos el nombre del Procedimiento a ejecutar 
                SqlCmd.CommandType = CommandType.StoredProcedure;  //-->  Le decimos que el tipo de comando es un PRC


                //-->Descripción del campo   idProveedo 
                //-----------------------------------------------------------------------------------
                SqlParameter ParIdProveedo = new SqlParameter();      //-> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParIdProveedo.ParameterName = "@idProveedo";          //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdProveedo.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdProveedo.Direction = ParameterDirection.Output;  //-> Este campo es Identity por lo tanto indicar que es de salida Output                
                SqlCmd.Parameters.Add(ParIdProveedo);                 //-> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                //-->Descripción del campo   CNomPro 
                //-----------------------------------------------------------------------------------

                SqlParameter ParCNomPro = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParCNomPro.ParameterName = "@cNomPro";         //--> Nombre del paramentro como está en el PRC
                ParCNomPro.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParCNomPro.Size = 120;                          //--> Longuitud del campo 
                ParCNomPro.Value = Proveedor.CNomPro;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParCNomPro);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                SqlParameter ParCNifDni = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParCNifDni.ParameterName = "@cNifDni";         //--> Nombre del paramentro como está en el PRC
                ParCNifDni.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParCNifDni.Size = 12;                          //--> Longuitud del campo 
                ParCNifDni.Value = Proveedor.CNifDni;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParCNifDni);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 





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
            finally      //--> el  finally se ejecuta siempre tanto si hay error como si no lo hay, así que cerramos la conexión que ya sabemos chupa mucha memoria.
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }


        //-------------------    METODO  MODIFICAR/EDITAR -----------------------------------------------------------------
        public string Editar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "spEditar_Proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdProveedo = new SqlParameter();
                ParIdProveedo.ParameterName = "@idProveedo";  //Nombre que tengo en el PCR
                ParIdProveedo.SqlDbType = SqlDbType.Int;
                ParIdProveedo.Value = Proveedor.IdProveedo;    //Toma el valor de la propiedad 
                SqlCmd.Parameters.Add(ParIdProveedo);

                
                SqlParameter ParCNomPro = new SqlParameter();
                ParCNomPro.ParameterName = "@cNomPro";   //Nombre que tengo en el PCR
                ParCNomPro.SqlDbType = SqlDbType.VarChar;
                ParCNomPro.Size = 120;
                ParCNomPro.Value = Proveedor.CNomPro;
                SqlCmd.Parameters.Add(ParCNomPro);

                SqlParameter ParCNifDni = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParCNifDni.ParameterName = "@cNifDni";         //--> Nombre del paramentro como está en el PRC
                ParCNifDni.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParCNifDni.Size = 12;                          //--> Longuitud del campo 
                ParCNifDni.Value = Proveedor.CNifDni;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParCNifDni);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 



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
        public string Eliminar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "spEliminar_Proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdProveedo = new SqlParameter();
                ParIdProveedo.ParameterName = "@idProveedo";  //Nombre que tengo en el PCR
                ParIdProveedo.SqlDbType = SqlDbType.Int;
                ParIdProveedo.Value = Proveedor.IdProveedo;    //Toma el valor de la propiedad 
                SqlCmd.Parameters.Add(ParIdProveedo);


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
            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_Proveedor";  //En este PRC lo que hacemos es selecionar los primeros 200 regitros 
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


        
        public DataTable BuscarRazonSocial(DProveedor Proveedor)
        {

            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Proveedor_razon_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 120;
                ParTextoBuscar.Value = Proveedor.CTextoBuscar;
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


        public DataTable BuscarNumeroDocumento(DProveedor Proveedor)
        {

            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscar_Proveedor_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 120;
                ParTextoBuscar.Value = Proveedor.CTextoBuscar;
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
