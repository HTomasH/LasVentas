using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace CapaPresentacion
{
    public partial class frmImpuestos : Form
    {
        public frmImpuestos()
        {
            InitializeComponent();
        }

        private void frmImpuestos_Load(object sender, EventArgs e)
        {
            //->Estas coordenadas son para printar el formulario en la esquina superior izquierda
            this.Top = 0;
            this.Left = 0;


            this.dataListado.DataSource = NImpuestos.Mostrar();


            //this.OcultarColumnas();

            //-->Pintamos el total de registros : OjO el count es  int  tenemos que convertirlo a String 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void Mostrar()
        {

            //ESCALADO : Para pintar la información en el Grid (dataListado.DataSource)  
            //
            //Vamos a llamar  a la clase  NImpuestos a su metodo Mostrar  (CAPA NEGOCIO)
            //
            //El metodo mostar lo que hace es  llamar al metodo Mostrar de la clase   DImpuestos()     (CAPA DATOS)
            //
            
            //ESCALADO :
            //CAPA PRESENTACION  llama a   CAPA NEGOCIO   que llama   a CAPA DATOS    que conecta con  BB.DD
            this.dataListado.DataSource = NImpuestos.Mostrar();


            //this.OcultarColumnas();

            //-->Pintamos el total de registros : OjO el count es  int  tenemos que convertirlo a String 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


    }
}
