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


//---->>>    MANTENIMIENTO SIN  PROCEDIMIENTO ALMACENADO,  LO HAGO CON CADENAS   


namespace CapaPresentacion
{

    

    public partial class frmImpuestos : Form
    {

        //->Variables para saber si estamos dando altas o no.  es como el que yo utilizaba de  lAltas 
        private bool IsNuevo = false;
        private bool IsEditar = false;


        public frmImpuestos()
        {
            InitializeComponent();

            //->Este será el mensaje a mostrar el TOOLTIP al tener el foco en el campo (Caja de texto-TextBox  txtNombre)
            this.ttMensaje.SetToolTip(this.txtcDetIva, "Indique el Nombre del impuesto");

        }

        private void frmImpuestos_Load(object sender, EventArgs e)
        {
            
            //->Estas coordenadas son para printar el formulario en la esquina superior izquierda
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);  //Cajas de texto  deshabilitadas de inicio 
            this.Botones();


                        
        }

        private void Limpiar()
        {
            this.txtidTipoIva.Text = string.Empty;
            this.txtcDetIva.Text = string.Empty;
            this.txtnPorcIva.Text = string.Empty;
            this.txtnPorReq.Text = string.Empty;

            
        }


        // Habilitar o NO los controles del formulario        
        //-> Si  valor  llega con valor TRUE pues le indicamos el contrario con ! 
        //   esto es porque la propiedad es  ReadOnly                                 
        private void Habilitar(bool valor)
        {

            this.txtidTipoIva.ReadOnly = true;  //Es un valor Identity  lo 'capo del todo'
            this.txtcDetIva.Enabled = !valor;
            this.txtnPorcIva.Enabled = !valor;
            this.txtnPorReq.Enabled = !valor;

            
        }



        //--Habilitar los botones
        //----------------------------------------------------------------------------------

        //No entiendo que dice este tío en el video parece que lo dice al revés 
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) // el  OR  ||   se obtiene con   Alt + 124
            {
                //Estamos dando altas o modificando 

                this.Habilitar(true);    //Habilitamos las cajas de texto 
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                //Estamos dando bajas o consultando 

                this.Habilitar(false);          //DESHabilitamos las cajas de texto 
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                //this.btnCancelar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }

        }


        //-->Método para ocultar columnas en el Grid de Familias
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;   //Esta se corresponde con la Columna para dar de baja 
            this.dataListado.Columns[1].Visible = false;   //Esta se corresponde con el ID de  la tablas

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


            this.OcultarColumnas();

            //-->Pintamos el total de registros : OjO el count es  int  tenemos que convertirlo a String 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void btnImprimir_Click(object sender, EventArgs e)
        {

            this.MensajeOk("Ha pulsado el botón de imprimir ");
            //Reportes.FrmReporteCategoria frm = new Reportes.FrmReporteCategoria();
            //frm.Texto = txtBuscar.Text;
            //frm.ShowDialog();
        }


        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //-->Mostrar Mensaje de Confirmación de la operación, del tipo  Error  
        //-->Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
