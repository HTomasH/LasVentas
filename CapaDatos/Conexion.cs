using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CapaDatos
{

    class Conexion
    {

        // Cadena  -Verbatim-  con  Arroba por  delante 
        // para que no den error los caraceres especiales con la barra invertida 

        //Declaramos las cadenas de conexión :
        //----------------------------------

        // CASA :       
        public static string Cn = @"Data Source=DESKTOP-TMO9LFM\SQLEXPRESS;Initial Catalog=VentasTOMAS; Integrated Security=True";

        // TRABAJO :       
        //public static string Cn = @"Data Source=MBO9IBSTHERRERO\SQLEXPRESS;Initial Catalog=VentasTOMAS; Integrated Security=True";

    }

}