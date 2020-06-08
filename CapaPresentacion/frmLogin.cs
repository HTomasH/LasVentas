using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();


            //  ME CARGE EL CONTROL DEL RELOJ, es un TIMER que se coloca en la parte externa del formulario  

            //Para pintar la hora en la etiqueta 
            //lblHora.Text = DateTime.Now.ToString(); 


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        //  ME CARGE EL CONTROL DEL RELOJ    es un TIMER que se coloca en la parte externa del formulario  
        //--------------------------------------------------------------------------------------------

        //-->El control del reloj, este evento  TICK se ejecuta en el intervalo de tiempo que hubieramos indicado
        //   en el control, en este caso cada 1000  milisegundos  lo que es lo mismo   1 segundo 
        //private void timer1_Tick(object sender, EventArgs e)
        //{

        //    lblHora.Text = DateTime.Now.ToString();
        //}




        //Boton de salida
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //--> Boton de entrada 
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //->Tenemos que enviar los datos que indique el usuario a ver si son validos 
            //  Por lo cual  vamos a crear un objeto de tipo  Datable  para enviar los datos a la capa de negocio al metodo login
            DataTable Datos = CapaNegocio.NTrabajador.Login( this.txtUsuario.Text, this.txtPassword.Text );

            if (Datos.Rows.Count == 0)  //Si rows (columnas, es decir registros es igual a cero 
            { 
                MessageBox.Show("No tiene acceso a este super sistema", "Primer sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Si existe, crearemos un objeto del formulario principal 
                frmPrincipal frm = new frmPrincipal();

                //->Estamos enviando esta información al formulario principal 
                //                            [registro][campo]        
                frm.IdTrabajador = Datos.Rows[0][0].ToString(); //Hay que convertir, lo que llega de DataTable es tipo Objeto
                frm.Apellidos = Datos.Rows[0][1].ToString(); //Hay que convertir, lo que llega de DataTable es tipo Objeto
                frm.Nombre = Datos.Rows[0][2].ToString(); //Hay que convertir, lo que llega de DataTable es tipo Objeto
                frm.Acceso = Datos.Rows[0][3].ToString(); //Hay que convertir, lo que llega de DataTable es tipo Objeto

                frm.Show();  //Mostramos el formulario principal 
                this.Hide(); //Ocultamos el formulario de entrada al sistema 
                

            }


        }
    }
}
