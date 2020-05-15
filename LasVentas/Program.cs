using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion;   //-> Para comunicarse con la capa 




/*  =================================>>>>>       HOJA DE RUTA         <<<<========================================================  
        
        -   ESTOY UTILIZANDO EL Framework 4.5.1   se ve en las Properties de cada Capa
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

        -   EN EL VIDEO  https://www.youtube.com/watch?v=W5OWHxKuLew   MUESTRA DOS FORMAS DE VER LA INFORMACION, UNA SOBRE UN 
            GRID Y OTRO QUE CREA UN FORMULARIO  CON OPCIONES DE MENU INCORPORADAS,  MOLA, PERO NO HAY CONTROL ES TODO AUTOMATICO.





        --->> UNA VEZ ACABE CON ESTAS VARIANTES DE LOS ACCESOS TENGO QUE VER EL MANTENIMIENTO DE INGRESOS, ES BASTANTE "TOCHO"



    */



namespace LasVentas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //-> Linea por defecto para indicar el formulario de arranque de la aplicacion  :    

            //--> PRUEBA 1    INICIO
            // Application.Run(new Form1());

            //--> PRUEBA 2    FAMILIAS 
            // Application.Run(new FrmFamilias());

            /*
            //--> PRUEBA 3    ARTICULOS 
                  Para ejecutar los Articulos se hace de esta forma, llamando a la instancia y como hemos dejado en el FrmArticulos
                  si ya tengo una instancia la utilizo, si no la tengo la creo.
                 
                  NOTA : No entiendo bien la utilidad de tener o no una instacia creada.
                         Creo que se debe al tener lupas (lupa) 
                         que abren otros formularios (No Modales No tienen ni  X  ni  Minimizado ni Maximizado )

                  Application.Run(FrmArticulos.GetInstaArti());
            */

            //--> PRUEBA 4   PROVEEDORES
            //Application.Run(new FrmProveedor());

            //--> PRUEBA 5   CIENTES
            //Application.Run(new  frmCliente());

            //--> PRUEBA 6   TRABAJADORES
            //Application.Run(new FrmTrabajador());

            //--> PRUEBA 7   YA CON EL MENU 
            // Ojo para que salga maximizada este formulario lo haremos en las propiedades del mismo en WindowsState
            //Application.Run(new frmPrincipal());

            //--> PRUEBA 8   CON EL CONTROL DE ACCESO 
            // Ojo para que salga maximizada este formulario lo haremos en las propiedades del mismo en WindowsState
            Application.Run(new frmLogin());


        }
    }
}



/*
*****************************************************************************************
*    EQUIVALENCIA TIPOS ENTRE  SQL    Y   .NET 
*
*****************************************************************************************


SQL Server data type          CLR data type (SQL Server)    CLR data type (.NET Framework)  
------------------------      --------------------------    ------------------------------
varbinary                     SqlBytes, SqlBinary           Byte[]  
binary                        SqlBytes, SqlBinary           Byte[]  
varbinary(1), binary(1)       SqlBytes, SqlBinary           byte, Byte[] 
image                         None                          None

varchar                       None                          None
char                          None                          None
nvarchar(1), nchar(1)         SqlChars, SqlString           Char, String, Char[]     
nvarchar                      SqlChars, SqlString           String, Char[] 
nchar                         SqlChars, SqlString           String, Char[] 
text                          None                          None
ntext                         None                          None

uniqueidentifier              SqlGuid                       Guid 
rowversion                    None                          Byte[]  
bit                           SqlBoolean                    Boolean 
tinyint                       SqlByte                       Byte 
smallint                      SqlInt16                      Int16  
int                           SqlInt32                      Int32  
bigint                        SqlInt64                      Int64 

smallmoney                    SqlMoney                      Decimal  
money                         SqlMoney                      Decimal  
numeric                       SqlDecimal                    Decimal  
decimal                       SqlDecimal                    Decimal  
real                          SqlSingle                     Single  
float                         SqlDouble                     Double  

smalldatetime                 SqlDateTime                   DateTime  
datetime                      SqlDateTime                   DateTime 

sql_variant                   None                          Object  
User-defined type(UDT)        None                          user-defined type     
table                         None                          None 
cursor                        None                          None
timestamp                     None                          None 
xml                           SqlXml                        None

*/
