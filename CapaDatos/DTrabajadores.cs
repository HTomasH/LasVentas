using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//-->Usings para poder trabajar con el tipo Datos  y enviar información a SQLServerr
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajadores   //Indicar que es publica de lo contrario no podre acceder a ella 
    {
    

        /*
          Declaración de los CAMPOS con los que vamos a trabajar
          que son los campos de la tabla Trabadores.
          
          Vamos a ponerles un guion bajo  por delante para diferenciar los Campos  y  las Propiedades 
        */


        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idTrabajador;    
        //                 Propiedades    :  Con Mayúscula la primera         IdTrabajador
        //                 Parametros     :  Con minúscula la primera         idTrabajador

        //--@idTrabajador int,
        //--@cNombreTraba varchar(20),
        //--@cApellidos varchar(40),
        //--@cAcceso varchar(20),
        //--@Password varchar(20)
        
        //---------------------------------------------------------------------------------


        private int _idTrabajador;
        private string _cNombreTraba;
        private string _cApellidos;
        private string _cAcceso;
        private string _Password;
        private string _cUsuario;
        private string _cPassword;

        //->Variable extra para las búsqueda del nombre 
        private string _cTextoBuscar;


        //-->Y ahora para pintar las PROPIEDADES, lo haremos Refactorizando !!   
        //   Se hace colocandose sobre la variable y le damos al botón derecho - Opcion Refactorizar - Encapsular Campo 

        // GETer   Devuelve valores
        // SETer   Recibe valores.

        public int IdTrabajador
        {
            get { return _idTrabajador; }
            set { _idTrabajador = value; }
        }

        public string CNombreTraba
        {
            get  { return _cNombreTraba;  }
            set  {  _cNombreTraba = value; }
        }

        public string CApellidos
        {
            get {   return _cApellidos;  }
            set {  _cApellidos = value;  }
        }

        public string CAcceso
        {
            get { return _cAcceso;  }
            set { _cAcceso = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }


        public string CUsuario
        {
            get { return _cUsuario; }
            set { _cUsuario = value; }
        }


        public string CPassword 
        {
            get { return _cPassword; }
            set { _cPassword = value; }
        }


        public string CTextoBuscar
        {
            get { return _cTextoBuscar;  }
            set { _cTextoBuscar = value; }
        }


        //------------------- CONSTRUCTORES   ----------------------------------------------
        //----------------------------------------------------------------------------------

        //-->Constructor  SIN PARAMETROS 
        //------------------------------
        public DTrabajadores()
        {
        }


        //----------------------------------------------------------------------------------        
        //-->Constructor  CON PARAMETROS (Vamos a indicar los parametros con  minúsculas )
        //----------------------------------------------------------------------------------        

        public DTrabajadores(int idTrabajador,  string cNombreTraba,  string cApellidos, string  cAcceso, string Password, string cUsuario ,string cTextoBuscar)
        {
            //Vamos a enviar los datos que  nos llegan en estos parametros  a nuestras propiedades 

           
            this.IdTrabajador = idTrabajador;
            this.CNombreTraba = cNombreTraba;
            this.CApellidos = cApellidos;
            this.CAcceso = cAcceso;
            this.Password = Password;
            this.CUsuario = cUsuario;
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

        public string Insertar(DTrabajadores Trabajadores)
        {

            
            string rpta = "";                             //-->  rpta  -  Variable para saber el valor de retorno
            SqlConnection SqlCon = new SqlConnection();   //-->  SqlCon - Variable de tipo  Conexión SQL
            try  //--->Control de Errores                    
            {

                SqlCon.ConnectionString = Conexion.Cn;   //--> Le digo a  ConnectionString  cual es nuestra conexión que tengo en la clase Conexión y en la variable  Cn
                SqlCon.Open();   //--> Abrimos la conexión 


                SqlCommand SqlCmd = new SqlCommand();              //-->  SqlCmd  -  Variable de la clase SqlCommand para poder utilizar los comandos de SQL 
                SqlCmd.Connection = SqlCon;                        //-->  Le pasamos la conexión.
                SqlCmd.CommandText = "spInsertar_trabajador";         //-->  Le decimos el nombre del Procedimiento a ejecutar 
                SqlCmd.CommandType = CommandType.StoredProcedure;  //-->  Le decimos que el tipo de comando es un PRC


                //-->Descripción del campo   IdTrabajador   
                //-----------------------------------------------------------------------------------
                SqlParameter ParIdTrabajador = new SqlParameter();      //-> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParIdTrabajador.ParameterName = "@idTrabajador";        //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdTrabajador.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdTrabajador.Direction = ParameterDirection.Output;  //-> Este campo es Identity en la tabla por lo tanto indicar que es de salida Output                

                SqlCmd.Parameters.Add(ParIdTrabajador);                 //-> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 



                //-->Descripción del campo   cNombreTraba  
                //-----------------------------------------------------------------------------------

                SqlParameter ParNombreTraba = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParNombreTraba.ParameterName = "@cNombreTraba";    //--> Nombre del paramentro como está en el PRC
                ParNombreTraba.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParNombreTraba.Size = 20;                          //--> Longuitud del campo 
                ParNombreTraba.Value = Trabajadores.CNombreTraba;  //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParNombreTraba);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


             
                //-----------------------------------------------------------------------------------

                SqlParameter ParcApellidos = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParcApellidos.ParameterName = "@cApellidos";    //--> Nombre del paramentro como está en el PRC
                ParcApellidos.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcApellidos.Size = 40;                          //--> Longuitud del campo 
                ParcApellidos.Value = Trabajadores.CApellidos;  //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParcApellidos);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                //-----------------------------------------------------------------------------------
                            
                SqlParameter ParccAcceso = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParccAcceso.ParameterName = "@cAcceso";        //--> Nombre del paramentro como está en el PRC
                ParccAcceso.SqlDbType = SqlDbType.VarChar;     //--> Tipo del campo.
                ParccAcceso.Size = 20;                         //--> Longuitud del campo 
                ParccAcceso.Value = Trabajadores.CAcceso;      //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParccAcceso);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                //-----------------------------------------------------------------------------------
                
                SqlParameter ParPassword = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParPassword.ParameterName = "@Password";        //--> Nombre del paramentro como está en el PRC
                ParPassword.SqlDbType = SqlDbType.VarChar;     //--> Tipo del campo.
                ParPassword.Size = 20;                         //--> Longuitud del campo 
                ParPassword.Value = Trabajadores.Password;      //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParPassword);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                //-------------------------------------------------------------------------------------------------

                SqlParameter ParUsuario = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParUsuario.ParameterName = "@cUsuario";        //--> Nombre del paramentro como está en el PRC
                ParUsuario.SqlDbType = SqlDbType.VarChar;     //--> Tipo del campo.
                ParUsuario.Size = 20;                         //--> Longuitud del campo 
                ParUsuario.Value = Trabajadores.CUsuario;      //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParUsuario);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 




                //-----------------------------------------------------------------------------------


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
        public string Editar(DTrabajadores Trabajadores)
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
                SqlCmd.CommandText = "spEditar_trabajador";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                
                SqlParameter ParIdTrabajador = new SqlParameter();          //-> Esto es para "parametrizar", poder enviar parametros en consultas                 
                
                ParIdTrabajador.ParameterName = "@idTrabajador";        //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdTrabajador.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdTrabajador.Value = Trabajadores.IdTrabajador;      //Toma el valor de la propiedad 
                
                SqlCmd.Parameters.Add(ParIdTrabajador);                     //-> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                //---//
                
                SqlParameter ParNombreTraba = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                
                ParNombreTraba.ParameterName = "@cNombreTraba";    //--> Nombre del paramentro como está en el PRC
                ParNombreTraba.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParNombreTraba.Size = 20;                          //--> Longuitud del campo 
                ParNombreTraba.Value = Trabajadores.CNombreTraba;  //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParNombreTraba);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                //---//

                SqlParameter ParcApellidos = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParcApellidos.ParameterName = "@cApellidos";    //--> Nombre del paramentro como está en el PRC
                ParcApellidos.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcApellidos.Size = 40;                          //--> Longuitud del campo 
                ParcApellidos.Value = Trabajadores.CApellidos;  //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParcApellidos);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                //---//

                SqlParameter ParccAcceso = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParccAcceso.ParameterName = "@cAcceso";        //--> Nombre del paramentro como está en el PRC
                ParccAcceso.SqlDbType = SqlDbType.VarChar;     //--> Tipo del campo.
                ParccAcceso.Size = 20;                         //--> Longuitud del campo 
                ParccAcceso.Value = Trabajadores.CAcceso;      //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParccAcceso);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                //---//

                SqlParameter ParPassword = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParPassword.ParameterName = "@Password";        //--> Nombre del paramentro como está en el PRC
                ParPassword.SqlDbType = SqlDbType.VarChar;     //--> Tipo del campo.
                ParPassword.Size = 20;                         //--> Longuitud del campo 
                ParPassword.Value = Trabajadores.Password;      //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParPassword);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                //---//

                SqlParameter ParUsuario = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 

                ParUsuario.ParameterName = "@cUsuario";        //--> Nombre del paramentro como está en el PRC
                ParUsuario.SqlDbType = SqlDbType.VarChar;     //--> Tipo del campo.
                ParUsuario.Size = 20;                         //--> Longuitud del campo 
                ParUsuario.Value = Trabajadores.CUsuario;      //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO

                SqlCmd.Parameters.Add(ParUsuario);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 






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
        public string Eliminar(DTrabajadores Trabajadores)
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
                SqlCmd.CommandText = "spEliminar_trabajador";
                SqlCmd.CommandType = CommandType.StoredProcedure;

        
                SqlParameter ParIdTrabajador = new SqlParameter();          //-> Esto es para "parametrizar", poder enviar parametros en consultas                 
                
                ParIdTrabajador.ParameterName = "@idTrabajador";        //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdTrabajador.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdTrabajador.Value = Trabajadores.IdTrabajador;      //Toma el valor de la propiedad 
                
                SqlCmd.Parameters.Add(ParIdTrabajador);                     //-> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


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
            DataTable DtResultado = new DataTable("Trabajadores");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_trabajador";  //En este PRC lo que hacemos es selecionar los primeros 200 regitros 
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
        public DataTable BuscarNombreTrabajador(DTrabajadores Trabajadores)
        {

            DataTable DtResultado = new DataTable("Trabajadores");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajadores.CTextoBuscar;
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


        //-------------------    METODO  ACCESO Y CONTROL PERFILES -------------------------------------------------------



        public DataTable Login(DTrabajadores Trabajadores)
        {

            DataTable DtResultado = new DataTable("Trabajadores");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario= new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajadores.CUsuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 20;
                ParPassword.Value = Trabajadores.Password;
                SqlCmd.Parameters.Add(ParPassword);



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
