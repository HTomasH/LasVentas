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
    public class DArticulos
    {

        /*
          Declaración de los CAMPOS con los que vamos a trabajar
          que son los campos de la tabla Familias.
          
          Vamos a ponerles un guion bajo  por delante para diferenciar los Campos  y  las Propiedades 
        */


        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idCodFam;    
        //                 Propiedades    :  Con Mayúscula la primera         IdCodFam
        //                 Parametros     :  Con minúscula la primera         idCodFam
        //---------------------------------------------------------------------------------



        private int _idCodArti;
        private string _cDetalle;
        private int _idCodFam;
        private decimal _nStock;
        private int _idTipoIva; //convert.toint16()   Int16    veremos si no da  problemas luego en la tabla es smallint
        private decimal _nPvP;
        private string _cCodigoBar;

        

         //->Variable extra para las búsqueda del nombre 
         private string _cTextoBuscar;

         //No tengo imagen pero seria de este tipo :  byte[]   _Imagen  esto lo vi en el curso del Gallego lo de que son arrays de tipo Byte  



        public int IdCodArti
        {
            get  { return _idCodArti;  }
            set  { _idCodArti = value;  }
        }

        public string CDetalle
        {
            get  { return _cDetalle;  }
            set  { _cDetalle = value;  }
        }

        public int IdCodFam
        {
            get  {  return _idCodFam;  }
            set  { _idCodFam = value;  }
        }

        public decimal NStock
        {
            get   {  return _nStock;  }
            set   {  _nStock = value; }
        }

        public int IdTipoIva
        {
            get  {  return _idTipoIva;   }
            set  {  _idTipoIva = value;  }
        }

        public decimal NPvP
        {
            get  {  return _nPvP; }
            set  {  _nPvP = value; }
        }

        public string CCodigoBar
        {
            get  {  return _cCodigoBar;  }
            set  {  _cCodigoBar = value; }
        }

        public string CTextoBuscar
        {
            get  {  return _cTextoBuscar;   }
            set  {  _cTextoBuscar = value;  }
        }



        //------------------- CONSTRUCTORES   ----------------------------------------------
        //----------------------------------------------------------------------------------

        //-->Constructor  SIN PARAMETROS 
        //------------------------------
        public DArticulos()
        {
        }

                
        public DArticulos(int idCodArti, string cDetalle, int idCodFam, decimal nStock, int idTipoIva, decimal nPvP, string cCodigoBar)
        {

            //->Enviamos a las propiedades la información que nos llege en los parametros

            this.IdCodArti = idCodArti;  //Esa info entra EN LA PROPIEDAD por el  Set
            this.CDetalle = cDetalle;
            this.IdCodFam = idCodFam;
            this.NStock = nStock;
            this.IdTipoIva = idTipoIva;   //convert.toint16()   Int16    veremos si no da  problemas luego en la tabla es smallint
            this.NPvP = nPvP;
            this.CCodigoBar = cCodigoBar;

           

        }


        //--------------------->    AREA DE METODOS    <-----------------------------------------


        //-------------------    METODO  ALTAS  ------------------------------------------------------------------

        //En los parametros que vamos a recibir en este metodo lo hacemos es 
        //instanciar  la clase,  de esta forma nos evitamos tener que estar poniendo campo a campo
        //de los que se tengan que tener en cuenta, en este ejemplo son pocos campos pero si fueramos a tratar tabla
        //donde hubiera muchos campos es un puto coñazo

        public string Insertar(DArticulos  Articulos)
        {

            string rpta = "";                             //-->  rpta  -  Variable para saber el valor de retorno
            SqlConnection SqlCon = new SqlConnection();   //-->  SqlCon - Variable de tipo  Conexión SQL
            try  //--->Control de Errores                    
            {

                SqlCon.ConnectionString = Conexion.Cn;   //--> Le digo a  ConnectionString  cual es nuestra conexión que tengo en la clase Conexión y en la variable  Cn
                SqlCon.Open();   //--> Abrimos la conexión 


                SqlCommand SqlCmd = new SqlCommand();              //-->  SqlCmd  -  Variable de la clase SqlCommand para poder utilizar los comandos de SQL 
                SqlCmd.Connection = SqlCon;                        //-->  Le pasamos la conexión.
                SqlCmd.CommandText = "spInsertar_articulos";         //-->  Le decimos el nombre del Procedimiento a ejecutar 
                SqlCmd.CommandType = CommandType.StoredProcedure;  //-->  Le decimos que el tipo de comando es un PRC


                //-->Descripción del campo   idCodArti   
                //-----------------------------------------------------------------------------------
                SqlParameter ParIdCodArti = new SqlParameter();      //-> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParIdCodArti.ParameterName = "@idCodArti";          //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdCodArti.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdCodArti.Direction = ParameterDirection.Output;  //-> Este campo es Identity por lo tanto indicar que es de salida Output                
                SqlCmd.Parameters.Add(ParIdCodArti);                 //-> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                //-->Descripción del campo   cDetalle     
                //-----------------------------------------------------------------------------------

                SqlParameter ParcDetalle = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcDetalle.ParameterName = "@cDetalle";  //--> Nombre del paramentro como está en el PRC
                ParcDetalle.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcDetalle.Size = 100;                          //--> Longuitud del campo 
                ParcDetalle.Value = Articulos.CDetalle;       //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcDetalle);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                //-->Descripción del campo   idCodFam     
                //-----------------------------------------------------------------------------------

                SqlParameter ParidCodFam = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParidCodFam.ParameterName = "@idCodFam";  //--> Nombre del paramentro como está en el PRC
                ParidCodFam.SqlDbType = SqlDbType.Int;      //--> Tipo del campo.                
                ParidCodFam.Value = Articulos.IdCodFam;       //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParidCodFam);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 



                //-->Descripción del campo  @nStock 
                //-----------------------------------------------------------------------------------

                SqlParameter ParnStock = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParnStock.ParameterName = "@nStock";  //--> Nombre del paramentro como está en el PRC
                ParnStock.SqlDbType = SqlDbType.Decimal;      //--> Tipo del campo.                
                ParnStock.Value = Articulos.NStock;       //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParnStock);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 



                //-->Descripción del campo  @idTipoIva 
                //-----------------------------------------------------------------------------------

                SqlParameter ParidTipoIva = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParidTipoIva.ParameterName = "@idTipoIva";  
                ParidTipoIva.SqlDbType = SqlDbType.SmallInt;     
                ParidTipoIva.Value = Articulos.IdTipoIva;  //convert.toint16()   Int16    veremos si no da  problemas luego en la tabla es smallint
                SqlCmd.Parameters.Add(ParidTipoIva);


                //-->Descripción del campo  @nPvP
                //-----------------------------------------------------------------------------------

                SqlParameter ParnPvP = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParnPvP.ParameterName = "@nPvP";
                ParnPvP.SqlDbType = SqlDbType.Decimal;
                ParnPvP.Value = Articulos.NPvP;
                SqlCmd.Parameters.Add(ParnPvP);


                //-->Descripción del campo   @cCodigoBar     
                //-----------------------------------------------------------------------------------

                SqlParameter ParcCodigoBar = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcCodigoBar.ParameterName = "@cCodigoBar";  //--> Nombre del paramentro como está en el PRC
                ParcCodigoBar.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcCodigoBar.Size = 50;                          //--> Longuitud del campo 
                ParcCodigoBar.Value = Articulos.CCodigoBar;       //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcCodigoBar);



               

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
        public string Editar(DArticulos Articulos)
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
                SqlCmd.CommandText = "spEditar_articulos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                
                SqlParameter ParIdCodArti = new SqlParameter();      //-> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParIdCodArti.ParameterName = "@idCodArti";          //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdCodArti.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdCodArti.Value =  Articulos.IdCodArti;          //Toma el valor de la propiedad 
                SqlCmd.Parameters.Add(ParIdCodArti);



                //-->Descripción del campo   cDetalle     
                //-----------------------------------------------------------------------------------

                SqlParameter ParcDetalle = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcDetalle.ParameterName = "@cDetalle";  //--> Nombre del paramentro como está en el PRC
                ParcDetalle.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcDetalle.Size = 100;                          //--> Longuitud del campo 
                ParcDetalle.Value = Articulos.CDetalle;       //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcDetalle);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                //-->Descripción del campo   idCodFam     
                //-----------------------------------------------------------------------------------

                SqlParameter ParidCodFam = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParidCodFam.ParameterName = "@idCodFam";  //--> Nombre del paramentro como está en el PRC
                ParidCodFam.SqlDbType = SqlDbType.Int;      //--> Tipo del campo.                
                ParidCodFam.Value = Articulos.IdCodFam;       //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParidCodFam);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 



                //-->Descripción del campo  @nStock 
                //-----------------------------------------------------------------------------------

                SqlParameter ParnStock = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParnStock.ParameterName = "@nStock";  //--> Nombre del paramentro como está en el PRC
                ParnStock.SqlDbType = SqlDbType.Decimal;      //--> Tipo del campo.                
                ParnStock.Value = Articulos.NStock;       //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParnStock);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 



                //-->Descripción del campo  @idTipoIva 
                //-----------------------------------------------------------------------------------

                SqlParameter ParidTipoIva = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParidTipoIva.ParameterName = "@idTipoIva";
                ParidTipoIva.SqlDbType = SqlDbType.SmallInt;
                ParidTipoIva.Value = Articulos.IdTipoIva;  //convert.toint16()   Int16    veremos si no da  problemas luego en la tabla es smallint
                SqlCmd.Parameters.Add(ParidTipoIva);


                //-->Descripción del campo  @nPvP
                //-----------------------------------------------------------------------------------

                SqlParameter ParnPvP = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParnPvP.ParameterName = "@nPvP";
                ParnPvP.SqlDbType = SqlDbType.Decimal;
                ParnPvP.Value = Articulos.NPvP;
                SqlCmd.Parameters.Add(ParnPvP);


                //-->Descripción del campo   @cCodigoBar     
                //-----------------------------------------------------------------------------------

                SqlParameter ParcCodigoBar = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcCodigoBar.ParameterName = "@cCodigoBar";  //--> Nombre del paramentro como está en el PRC
                ParcCodigoBar.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcCodigoBar.Size = 50;                          //--> Longuitud del campo 
                ParcCodigoBar.Value = Articulos.CCodigoBar;       //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcCodigoBar);

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
        public string Eliminar(DArticulos Articulos)
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
                SqlCmd.CommandText = "spEliminar_articulos";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdCodArti = new SqlParameter();      //-> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParIdCodArti.ParameterName = "@idCodArti";          //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdCodArti.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdCodArti.Value = Articulos.IdCodArti;          //Toma el valor de la propiedad 
                SqlCmd.Parameters.Add(ParIdCodArti);



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
            DataTable DtResultado = new DataTable("Articulos");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spMostrar_articulos";  //En este PRC lo que hacemos es selecionar los primeros 200 regitros 
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);    //Con el Fill estoy rellenado  DtResultado  que es un DataTable  de Articulos 

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }



        //-> metodo para buscar solo el nombre de las familias, lo mismo en vez de recibir el campo en cuestion indicamos toda la clase
        //public DataTable BuscarNombre (DCategoria Categoria)
        public DataTable BuscarNombre(DArticulos Articulos)
        {

            DataTable DtResultado = new DataTable("Articulos");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spBuscarNombre_articulos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulos.CTextoBuscar;
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
