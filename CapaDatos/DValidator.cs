using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-->Usings para poder trabajar con el tipo Datos  y enviar información a SQLServerr
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;   //Añadadido en las referencias desde ENSAMBLADOS->FRAMEWORK


namespace CapaDatos
{
    public class DValidator
    {

        
        //Nota :  He visto sobre estas validaciones  :  "ya no funciona en visual 2017 ya que no se crea keypress sino EventArgs"

        //-->Control de pulsación del ENTER para pasar de campo a campo además del tabulador que es el mejor 
        //   además de pasar de campo tambien podriamos indicar una funcionalidad a ejecutar cuando se pulse tal o cual
        //   tecla.    
        public static void ValiEnter(KeyPressEventArgs v)
        {
            if (v.KeyChar == (char)(Keys.Enter))
            {
                v.Handled = false;
                SendKeys.Send("{TAB}");
            }
        }

        //-->Calculo letra para DNI 
        public static char calcularLetra(int n)
        {
            string cadena = "TRWAGMYFPDXBNJZSQVHLCKE";
            return (char)cadena[n % 23];
        }

        //---> Controles de introducción de valores,  Letras, Numeros,  Decimales 
        public static void SoloLetras(KeyPressEventArgs v)
        {
            if (Char.IsLetter(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar)) //Esta permite el Espacio 
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Solo Letras");
            }
        }


        public static void SoloNumeros(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))  //Esta permite el Espacio 
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Solo Números");
            }
        }

        public static void NumerosDecimales(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))   //Esta permite el Espacio 
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (v.KeyChar.ToString().Equals(","))   //Esta permite la coma, pero no la coloca, puede tener tropecientos decimales
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Solo números o números decimales");
            }
        }

        


        //Visual studio dejo este metodo como internal  del estilo normal no iba bien  ¿que era internal? KK               
        public static void RellenoComboPostal(ComboBox cbCodPostal)
        {

            //-->>ESTARE CARGANDOME EL DISEÑO DE LAS TRE CAPAS AL INCLUIR ESTO ASI 
            //    QUIZA PODRIA CREAR UN CLASE DENTRO DE CapaDatos para esto
            //    La conexión :   Cadena  -Verbatim-  con  Arroba por  delante 
            SqlConnection coco = new SqlConnection(@"Data Source=DESKTOP-TMO9LFM\SQLEXPRESS;Initial Catalog=VentasTOMAS; Integrated Security=True");

            //creo que habia una opcion para entrar exclusivamente a una tabla ??

            cbCodPostal.Items.Clear();
            coco.Open();
            SqlCommand cmd = new SqlCommand("select * from CodiPos", coco);
            SqlDataReader dr = cmd.ExecuteReader();

            //-->Bucle de relleno del combo 
            while (dr.Read())
            {
                cbCodPostal.Items.Add(dr[0].ToString() + "-" + dr[1].ToString());

            }
            coco.Close();


            //-->Inserta en la posicion 0 del Combo esta leyenda, en mi caso no es necesario indicarlo
            //   La diferencia entre   Add  e  Insert  es que en Insert puedo decir en que posicion quiero insertalo
            cbCodPostal.Items.Insert(0, "--- Seleccione un item ---");
            cbCodPostal.SelectedIndex = 0;
        }


        //Por que tienen que ser static para que la pueda ver desde el frmCliente??  KK
        public static string[] captar_info(string codipostal)
        {

            //-->>ESTARE CARGANDOME EL DISEÑO DE LAS TRE CAPAS AL INCLUIR ESTO ASI 
            //    QUIZA PODRIA CREAR UN CLASE DENTRO DE CapaDatos para esto
            //    La conexión :   Cadena  -Verbatim-  con  Arroba por  delante 
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TMO9LFM\SQLEXPRESS;Initial Catalog=VentasTOMAS; Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CodiPos where codpostal='" + codipostal + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            //MUEVE LOS VALORES DE LA TABLA AL ARRAY PARA PINTARLOS EN LOS CAMPOS 
            string[] resultado = null;
            while (dr.Read())
            {
                string[] valores =
                {
                    dr[0].ToString(),
                    dr[1].ToString()
                };
                resultado = valores; //IMPORTANTE ESTA LINEA, YA QUE NO PODRIAMOS HACER RETURN DE valores[]  por estar "dentro"  los dejamos en resultado[]
            }
            con.Close();
            return resultado;
        }





    }
}
