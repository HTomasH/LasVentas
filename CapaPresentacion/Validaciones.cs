using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;   //Añadadido


namespace CapaPresentacion
{
    public class Validaciones
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


        
   

        

    }
}
