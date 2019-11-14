using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-->Usings para poder trabajar con el tipo Datos  y enviar información a SQLServerr
using System.Data;
using System.Data.SqlClient;

//--- nuevo cambio 



namespace CapaDatos
{
    class DFamilias
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
        //   Se hace coocandose sobre la variable y le damos al botón derecho - Opcion Refactorizar - Encapsular Campo 

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

        //-->Constructor  SIN PARAMETROS 
        public DFamilias()
        {
        }

        //---------------------------------------------------------------------------------
        // CODIFICACION    Campos         :  Con guión bajo  _                _idCodFam;    
        //                 Propiedades    :  Con Mayúscula la primera         IdCodFam
        //                 Parametros     :  Con minúscula la priemera        idCodFam
        //---------------------------------------------------------------------------------

        //-->Constructor  CON PARAMETROS 
        // Vamos a indicar los parametros con  minúsculas 
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

        //--METODO  ALTAS 

        //En los parametros que vamos a recibir uno del tipo clase DFamilias  para recibirlo como un objeto
        //esta forma de hacer creo que es por evitar indicar todos los campos de la tabla, que en este caso
        //son pocos pero si fueran muchos seria un coñazo,  al tener instanciada la clase Familias seguro que 
        //luego voy a poder indicar los campos que yo quiera...
        public string Insertar(DFamilias Familias)
        {



            string rpta = "";                             //-->  rpta  -  Variable para saber el valor de retorno
            SqlConnection SqlCon = new SqlConnection();   //-->  SqlCon - Variable de tipo  Conexión SQL
            try  //--->Control de Errores                    
            {

                SqlCon.ConnectionString = Conexion.Cn;   //--> Le digo a  ConnectionString  cual es nuestra conexión  que la tengo en la clase Conexión y en la variable  Cn
                SqlCon.Open();   //--> Abrimos la conexión 


                SqlCommand SqlCmd = new SqlCommand();          //-->   SqlCmd  -  Variable de la clase SqlCommand para poder utilizar los comandos de SQL 
                SqlCmd.Connection = SqlCon;                    //-->   Le pasamos la conexión.
                SqlCmd.CommandText = "spInsertar_familia";   //-->   Le decimos el nombre del Procedimiento a ejecutar 
                SqlCmd.CommandType = CommandType.StoredProcedure;  //-> Le decimos que el tipo de comando es un PRC


                //-->Descripción del campo   idCodFam   de la tabla Familias   
                //-----------------------------------------------------------------------------------
                SqlParameter ParIdCodFam = new SqlParameter();   //->   Esto es para "parametrizar", poder enviar parametros en consultas                 
                ParIdCodFam.ParameterName = "@idCodFam";                //->Nombre del parametro, este es el mismo que tengo puesto en el PRC
                ParIdCodFam.SqlDbType = SqlDbType.Int;              //->Tipo del campo
                ParIdCodFam.Direction = ParameterDirection.Output;  //->Este campo es Identity por lo tanto indicar que es de salida Output                
                SqlCmd.Parameters.Add(ParIdCodFam);             //->Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 


                //-->Descripción del campo   cNombreFamilia   de la tabla Familias   
                //-----------------------------------------------------------------------------------

                SqlParameter ParNombreFamilia = new SqlParameter();   //-->Variable de tipo parametros.
                ParNombreFamilia.ParameterName = "@cNombreFamilia";          //-->Nombre del paramentro como está en el PRC
                ParNombreFamilia.SqlDbType = SqlDbType.VarChar;          //-->Tipo del campo.
                ParNombreFamilia.Size = 50;                         //->Longuitud del campo 
                ParNombreFamilia.Value = Familias.CNombreFamilia;    //->Aquí sí, le enviamos el valor este si es un campo de entrada total 
                SqlCmd.Parameters.Add(ParNombreFamilia);              //->Acción que tiene que llevar a cabo,  AÑADIR en este caso con los parametros contenidos en ParNombre 



                //--> Ahora Ejecutamos nuestro comando (tipo  TERNARIO),
                //    Controlamos el éxito de la operación con el valor retornado en la variable  rpta

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;   //-->Mostramos el mensaje.
            }
            finally      //--> el  finally  se ejecuta siempre tanto si hay error como si no lo hay, así que cerramos la conexión que ya sabemos como mucha memoria.
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        /*
        public string Editar(DFamilias Familias)
        {

        }


        public string Eliminar(DFamilias Familias)
        {

        }


        //-> OjO   de tipo DateTable 
        public DataTable Mostrar()
        {

        }

        //-> Metodo para buscar SOLO el nombre de las familias, lo mismo en vez de recibir el campo en cuestion indicamos toda la Clase
        public DataTable BuscarNombre(DFamilias Familias)
        {

        }

    */


    }
}
