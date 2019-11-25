using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion;   //-> Para comunicarse con la capa 


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

            //-> Linea por defecto para indicar el formulario de arranque de la aplicacion  :    Application.Run(new Form1());
            Application.Run(new FrmFamilias());
        }
    }
}
