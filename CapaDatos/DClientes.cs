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
    public class DClientes
    {

        // Declaración de los CAMPOS con los que vamos a trabajar que son los campos de la tabla Proveedores.
        // Vamos a ponerles un guion bajo  por delante para diferenciar los Campos  y  las Propiedades 

        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idCodFam;    
        //                 Propiedades    :  Con Mayúscula la primera         IdCodFam
        //                 Parametros     :  Con minúscula la priemera        idCodFam
        //---------------------------------------------------------------------------------

        private int _idCodcli;
        private string _cNomCli;
        private string _cDirCli;
        private string _cPobCli;
        private string _cDniCif;
        private string _cContacto;
        private string _cCtaContable;
        private decimal _nDto;
        private string _cTelefono1;
        private string _cEmail;
        private string _cCodPostal;
        private DateTime _dFechaNaci;

        //->Variable extra para las búsqueda del nombre 
        private string _cTextoBuscar;


        //PROPIEDADES      IMPORTANTE : EN EL CURSO VI QUE EN EL GET/SET SE PUEDEN GESTIONAR LAS VALIDACIONES DE LOS DATOS 
        //                              RECIBIDOS
        public int IdCodcli
        {
            get {  return _idCodcli;   }
            set { _idCodcli = value;   }
        }

        public string CNomCli
        {
            get {   return _cNomCli; }       
            set {   _cNomCli = value; }
        }

        public string CDirCli
        {
            get  { return _cDirCli;   }
            set  { _cDirCli = value;  }
        }

        public string CPobCli
        {
            get  {  return _cPobCli;  }
            set  {  _cPobCli = value; }
        }

        public string CDniCif
        {
            get  { return _cDniCif;  }
            set  {  _cDniCif = value;   }
        }

        public string CContacto
        {
            get {  return _cContacto;  }
            set {  _cContacto = value; }
        }

        public string CCtaContable
        {
            get  {  return _cCtaContable;  }
            set  {  _cCtaContable = value; }
        }

        public decimal NDto
        {
            get { return _nDto; }
            set { _nDto = value; }
        }

        public string CTelefono1
        {
            get { return _cTelefono1;  }
            set { _cTelefono1 = value; }
        }

        public string CEmail
        {
            get  {  return _cEmail;  }
            set  {  _cEmail = value; }
        }

        public string CCodPostal
        {
            get { return _cCodPostal; }
            set { _cCodPostal = value;  }
        }

        public DateTime DFechaNaci
        {
            get { return _dFechaNaci;  }
            set { _dFechaNaci = value;  }
        }

        public string CTextoBuscar
        {
            get { return _cTextoBuscar;  }
            set { _cTextoBuscar = value; }
        }


        //-->Constructor  SIN PARAMETROS 
        //------------------------------
        public DClientes()
        {
        }



        //-->Constructor  CON PARAMETROS (Vamos a indicar los parametros con  minúsculas )  DE LOS CAMPOS QUE NOS VAN A LLEGAR 
        //----------------------------------------------------------------------------------        
        public DClientes(int idCodcli, string cNomCli, string cDirCli, string cPobCli, string cDniCif, 
                         string cContacto, string cCtaContable, decimal nDto, string cTelefono1, string cEmail, 
                         string cCodPostal, DateTime dFechaNaci, string cTextoBuscar)
        {
            //Vamos a dejar en nuestras propiedades la informacion que nos llega 

            this.IdCodcli = idCodcli;
            this.CNomCli = cNomCli;
            this.CDirCli = cDirCli;
            this.CPobCli = cPobCli;
            this.CDniCif = cDniCif;
            this.CContacto = cContacto;
            this.CCtaContable = cCtaContable;
            this.NDto = nDto;
            this.CTelefono1 = cTelefono1;
            this.CEmail = cEmail;
            this.CCodPostal = cCodPostal;
            this.DFechaNaci = dFechaNaci;

            this.CTextoBuscar = cTextoBuscar;
        }


        //----------------------------------------------------------------------------------//
        //         BLOQUE DE METODOS PARA  ALTAS, BAJAS, MODIFICACIONES .....
        //----------------------------------------------------------------------------------//


        //-------------------    METODO  ALTAS  ------------------------------------------------------------------

        public string Insertar(DClientes Clientes)
        {


            string rpta = "";                             //-->  rpta  -  Variable para saber el valor de retorno
            SqlConnection SqlCon = new SqlConnection();   //-->  SqlCon - Variable de tipo  Conexión SQL
            try  //--->Control de Errores                    
            {

                SqlCon.ConnectionString = Conexion.Cn;   //--> Le digo a  ConnectionString  cual es nuestra conexión que tengo en la clase Conexión y en la variable  Cn
                SqlCon.Open();   //--> Abrimos la conexión 


                SqlCommand SqlCmd = new SqlCommand();              //-->  SqlCmd  -  Variable de la clase SqlCommand para poder utilizar los comandos de SQL 
                SqlCmd.Connection = SqlCon;                        //-->  Le pasamos la conexión.
                SqlCmd.CommandText = "spinsertar_cliente";         //-->  Le decimos el nombre del Procedimiento a ejecutar 
                SqlCmd.CommandType = CommandType.StoredProcedure;  //-->  Le decimos que el tipo de comando es un PRC


                //-->Descripción del campo   idCodcli 
                //-----------------------------------------------------------------------------------
                SqlParameter ParIdCliente = new SqlParameter();      //-> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParIdCliente.ParameterName = "@idCodcli";            //-> Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdCliente.SqlDbType = SqlDbType.Int;              //-> Tipo del campo
                ParIdCliente.Direction = ParameterDirection.Output;  //-> Este campo es Identity por lo tanto indicar que es de salida Output                
                SqlCmd.Parameters.Add(ParIdCliente);                 //-> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                
                SqlParameter ParCNomCli = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParCNomCli.ParameterName = "@cNomCli";         //--> Nombre del paramentro como está en el PRC
                ParCNomCli.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParCNomCli.Size = 100;                          //--> Longuitud del campo 
                ParCNomCli.Value = Clientes.CNomCli;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParCNomCli);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

               
                SqlParameter ParcDirCli = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcDirCli.ParameterName = "@cDirCli";         //--> Nombre del paramentro como está en el PRC
                ParcDirCli.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcDirCli.Size = 100;                          //--> Longuitud del campo 
                ParcDirCli.Value = Clientes.CDirCli;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcDirCli);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                

                SqlParameter ParcPobCli = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcPobCli.ParameterName = "@cPobCli";         //--> Nombre del paramentro como está en el PRC
                ParcPobCli.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcPobCli.Size = 100;                          //--> Longuitud del campo 
                ParcPobCli.Value = Clientes.CPobCli;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcPobCli);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                
                SqlParameter ParcDniCif = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcDniCif.ParameterName = "@cDniCif";         //--> Nombre del paramentro como está en el PRC
                ParcDniCif.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcDniCif.Size = 17;                          //--> Longuitud del campo 
                ParcDniCif.Value = Clientes.CDniCif;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcDniCif);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

               

                SqlParameter ParcContacto = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcContacto.ParameterName = "@cContacto";         //--> Nombre del paramentro como está en el PRC
                ParcContacto.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcContacto.Size = 100;                          //--> Longuitud del campo 
                ParcContacto.Value = Clientes.CDniCif;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcContacto);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                

                SqlParameter ParcCtaContable = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcCtaContable.ParameterName = "@cCtaContable";         //--> Nombre del paramentro como está en el PRC
                ParcCtaContable.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.
                ParcCtaContable.Size = 12;                          //--> Longuitud del campo 
                ParcCtaContable.Value = Clientes.CCtaContable;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcCtaContable);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                

                SqlParameter ParnDto = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParnDto.ParameterName = "@nDto";         //--> Nombre del paramentro como está en el PRC
                ParnDto.SqlDbType = SqlDbType.Decimal;      //--> Tipo del campo.                
                ParnDto.Value = Clientes.NDto;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParnDto);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                SqlParameter ParcTele = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcTele.ParameterName = "@cTelefono1";         //--> Nombre del paramentro como está en el PRC
                ParcTele.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.                
                ParcTele.Value = Clientes.CTelefono1;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcTele);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                SqlParameter ParcMail = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcMail.ParameterName = "@cEmail";         //--> Nombre del paramentro como está en el PRC
                ParcMail.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.                
                ParcMail.Value = Clientes.CEmail;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcMail);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                SqlParameter ParcPostal = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcPostal.ParameterName = "@cCodPostal";         //--> Nombre del paramentro como está en el PRC
                ParcPostal.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.                
                ParcPostal.Value = Clientes.CCodPostal;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcPostal);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                SqlParameter PardFecha = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                PardFecha.ParameterName = "@dFechaNaci";         //--> Nombre del paramentro como está en el PRC
                PardFecha.SqlDbType = SqlDbType.Date;      //--> Tipo del campo.                
                PardFecha.Value = Clientes.DFechaNaci;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(PardFecha);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 



                




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


        public string Editar(DClientes Clientes)
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
                SqlCmd.CommandText = "speditar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdCliente = new SqlParameter();    
                ParIdCliente.ParameterName = "@idCodcli";          
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Clientes.IdCodcli;           
                SqlCmd.Parameters.Add(ParIdCliente);


                SqlParameter ParCNomCli = new SqlParameter();  
                ParCNomCli.ParameterName = "@cNomCli";         
                ParCNomCli.SqlDbType = SqlDbType.VarChar;      
                ParCNomCli.Size = 100;                         
                ParCNomCli.Value = Clientes.CNomCli;          
                SqlCmd.Parameters.Add(ParCNomCli);



                SqlParameter ParcDirCli = new SqlParameter();  
                ParcDirCli.ParameterName = "@cDirCli";         
                ParcDirCli.SqlDbType = SqlDbType.VarChar;      
                ParcDirCli.Size = 100;                         
                ParcDirCli.Value = Clientes.CDirCli;          
                SqlCmd.Parameters.Add(ParcDirCli);            



                SqlParameter ParcPobCli = new SqlParameter();  
                ParcPobCli.ParameterName = "@cPobCli";         
                ParcPobCli.SqlDbType = SqlDbType.VarChar;      
                ParcPobCli.Size = 100;                         
                ParcPobCli.Value = Clientes.CPobCli;          
                SqlCmd.Parameters.Add(ParcPobCli);            


                SqlParameter ParcDniCif = new SqlParameter();  
                ParcDniCif.ParameterName = "@cDniCif";         
                ParcDniCif.SqlDbType = SqlDbType.VarChar;      
                ParcDniCif.Size = 17;                          
                ParcDniCif.Value = Clientes.CDniCif;          
                SqlCmd.Parameters.Add(ParcDniCif);            



                SqlParameter ParcContacto = new SqlParameter();  
                ParcContacto.ParameterName = "@cContacto";       
                ParcContacto.SqlDbType = SqlDbType.VarChar;      
                ParcContacto.Size = 100;                         
                ParcContacto.Value = Clientes.CDniCif;          
                SqlCmd.Parameters.Add(ParcContacto);            



                SqlParameter ParcCtaContable = new SqlParameter();  
                ParcCtaContable.ParameterName = "@cCtaContable";    
                ParcCtaContable.SqlDbType = SqlDbType.VarChar;      
                ParcCtaContable.Size = 12;                          
                ParcCtaContable.Value = Clientes.CCtaContable;      
                SqlCmd.Parameters.Add(ParcCtaContable);             



                SqlParameter ParnDto = new SqlParameter();  
                ParnDto.ParameterName = "@nDto";         
                ParnDto.SqlDbType = SqlDbType.Decimal;   
                ParnDto.Value = Clientes.NDto;          
                SqlCmd.Parameters.Add(ParnDto);



                SqlParameter ParcTele = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcTele.ParameterName = "@cTelefono1";         //--> Nombre del paramentro como está en el PRC
                ParcTele.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.                
                ParcTele.Value = Clientes.CTelefono1;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcTele);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                SqlParameter ParcMail = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcMail.ParameterName = "@cEmail";         //--> Nombre del paramentro como está en el PRC
                ParcMail.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.                
                ParcMail.Value = Clientes.CEmail;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcMail);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 

                SqlParameter ParcPostal = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParcPostal.ParameterName = "@cCodPostal";         //--> Nombre del paramentro como está en el PRC
                ParcPostal.SqlDbType = SqlDbType.VarChar;      //--> Tipo del campo.                
                ParcPostal.Value = Clientes.CCodPostal;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(ParcPostal);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                SqlParameter PardFecha = new SqlParameter();  //--> Esto es para "parametrizar", poder enviar parametros en consultas                 
                PardFecha.ParameterName = "@dFechaNaci";         //--> Nombre del paramentro como está en el PRC
                PardFecha.SqlDbType = SqlDbType.Date;      //--> Tipo del campo.                
                PardFecha.Value = Clientes.DFechaNaci;          //--> Aquí sí, le enviamos el valor que tenemos en la Propiedad OjO
                SqlCmd.Parameters.Add(PardFecha);             //--> Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 




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

        public string Eliminar(DClientes Clientes)
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
                SqlCmd.CommandText = "speliminar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCodcli";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Clientes.IdCodcli;
                SqlCmd.Parameters.Add(ParIdCliente);


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
            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_cliente";  //En este PRC lo que hacemos es selecionar los primeros 200 regitros 
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




        public DataTable BuscarRazonSocial(DClientes Clientes)
        {

            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Clientes.CTextoBuscar;
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


        public DataTable BuscarNum_Documento(DClientes Clientes)
        {

            DataTable DtResultado = new DataTable("Clientes");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cliente_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Clientes.CTextoBuscar;
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
