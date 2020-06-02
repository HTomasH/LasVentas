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
using CapaDatos;   //Tengo que utilizar objetos de esta capa para el Dvalidator de los campos



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


        //-->Mostrar Mensaje de Confirmación de la operación, del tipo  Información 
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

            //->Valor por defecto a pintar en el campo
            this.txtnPorcIva.Text = "0,00";
            this.txtnPorReq.Text = "0,00";
        }


        // Habilitar o NO los controles del formulario        
        //-> Si  valor  llega con valor TRUE pues le indicamos el contrario con ! 
        //   esto es porque la propiedad es  ReadOnly                                 
        private void Habilitar(bool valor)
        {

            this.txtidTipoIva.ReadOnly = true;  //Es un valor Identity  lo 'capo del todo'
            this.txtidTipoIva.Enabled = false;

            
            if (this.IsNuevo) 
            {
                this.txtcDetIva.Enabled = true;
                this.txtnPorcIva.Enabled = true;
                this.txtnPorReq.Enabled = true;
            }
            else if( this.IsEditar )
            {
                this.txtcDetIva.Enabled = true;
                this.txtnPorcIva.Enabled = true;
                this.txtnPorReq.Enabled = true;
            }





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


        

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //-->VALIDACION DE CAMPOS. NOTA en el curso de C# ví que esto se puede hacer en las propiedades GET/SET
            //----------------------------------------------------------------------------------------------------
            string rpta = "";


            try   //Control de errores   bien....
            {

                ////--  VALIDACION DE CAMPOS  NOTA : en el curso de C# ví que esto se puede hacer en las propiedades GET/SET
                ////----------------------------------------------------------------------------------------------------

                if (this.txtcDetIva.Text == string.Empty)   //Si está vacía y como es un campo obligatorio,  pues hay que meterlo
                {
                    //-->Este metodo lo tengo en este mismo módulo
                    MensajeError("Faltan por indicar  datos, serán remarcados");
                    //--Vamos a indicar el mensaje a mostrar cuando salga el error.
                    errorIcono.SetError(txtcDetIva, "Indique un Nombre");
                }
                else  //El textBox llega con valor,  
                {
                    if (this.IsNuevo)  //Es un alta ??
                    {
                        //VAMOS A UTILIZAR PUNTO DECIMAL 
                       
                    //-->Vamos a llamar al Metodo Insertar de la CapaNegocio enviandole los valores para insertar en la bb.dd                    
                    rpta = NImpuestos.Insertar(this.txtcDetIva.Text.Trim().ToUpper(), Convert.ToDecimal(this.txtnPorcIva.Text), Convert.ToDecimal(this.txtnPorReq.Text));                    
                    }
                else    //Es una modificacion   PARECE QUE ESTA MODIFICANDO TODOS !!!
                {
                    //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores 
                    //rpta = NFamilias.Editar(Convert.ToInt32(this.txtIdFamilias.Text), this.txtNombre.Text.Trim().ToUpper());
                    //rpta = NImpuestos.Editar(this.txtcDetIva.Text.Trim().ToUpper(), Convert.ToDecimal(this.txtnPorcIva.Text), Convert.ToDecimal(this.txtnPorReq.Text));
                }

                //--> Ahora vamos a ver si la operación tuvo éxito o no, el "OK" que estamos poniendo aquí es el que está
                //    indicado en la CAPADATOS en los metodos
                //    Insertar y Editar de esta forma: rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                //Por eso pongo OK sino pondría lo que tuviera puesto...                                                                   
                if (rpta.Equals("OK")) //Comparando cadenas con  :  Equals()      
                {
                    if (this.IsNuevo)
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");
                    }
                    else
                    {
                        this.MensajeOk("Se Actualizó de forma correcta el registro");
                    }
                }
                else  //Si no han tenido éxito la inserción o modificacion ERROR
                {
                    //-->Vamos a enviar al error el valor de rpta que va a ser lo que tengo puesto en la CAPADATOS
                    this.MensajeError(rpta);
                }

                //-->Borra la pelotilla del error si estuviera
                errorIcono.Clear();

                //->Una vez insertado el registro dejamos las variables como estaban.
                this.IsNuevo = false;
                this.IsEditar = false;

                this.Botones();
                this.Limpiar();
                this.Mostrar();


            }
        }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }


}

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            this.IsNuevo = true;    //Es un alta así que este valor a true   
            this.IsEditar = false;  //Este a False

            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtcDetIva.Focus();   //Foco a la caja de texto del nombre 
        }

        private void txtnPorcIva_KeyPress(object sender, KeyPressEventArgs e)
        {
               DValidator.NumerosDecimales(e);
               DValidator.ValiEnter(e);
           
        }

        private void txtnPorReq_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.NumerosDecimales(e);
            DValidator.ValiEnter(e);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Borra la pelotilla del error 
            errorIcono.Clear();

            this.IsNuevo = false;
            this.IsEditar = false;

            this.Botones();
            this.Limpiar();
            this.Habilitar(false);

            //->OjO  con esto.... porqué  dejarlo en blanco???
            this.txtidTipoIva.Text = string.Empty;
        }

        //Check Box de la eliminacion 
        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {                
        
            if (chkEliminar.Checked)   //Si el check está marcado entonces mostramos la columna 0  del  Grid, la de bajas 
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                //Variable de tipo  DialogResult   entiendo que sire para capturar datos de preguntas al usuario
                DialogResult Opcion;

                //Tipo de mensaje que va a mostrar al usuario los botones  SI  o No 
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


                if (Opcion == DialogResult.OK) //Si es que SI,  que ok
                {
                    string Codigo;
                    string Rpta = "";

                    //->Bucle para recorrerse todo el GRID y mira que esta marcado para borrarlo.....este sistema no vale para muchos registros
                    //  si cada vez que va a borrar se tiene que recorrer todo el GRID menuda mierder
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))  //Pregunta por el valor de la columna cero del GRID 
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value); //Trinca el valor de la columna 1 es decir el IdFamilia

                            //Envia el codigo al metodo ELIMINAR de la CapaNegocio de de Familias, OjO conviertiendo a Int  que es como 
                            //es el tipo de campo en la tabla Familias 
                            Rpta = NImpuestos.Eliminar(Convert.ToInt32(Codigo));

                            //Utiliza  EQUALS  para comparar cadenas de texto en vez de hacerlo a machete :  if  Rpta  == "OK"
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    //-->Volver a pintar el GRID con los cambios  y dejar el Check de eliminación deshabilitado 
                    chkEliminar.Checked = false;
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        //Este Evento se genera haciendo doble click  sobre el Grid 
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //Si el indice de la columna es el de la columna Eliminar
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {

                //Declaramos la variable  ChkEliminar   del tipo  DataGridViewCheckBoxCell  
                //nos traeremos los valores (OjO haciendo conversion al tipo DataGridViewCheckBoxCell)   de donde esta marcando el usuario para eliminar  
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];

                //Estamos indicando el valor si esta marcado o no el checkbox en la columna elimnar del GRID y lo convertimos a True o False 
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidTipoIva.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }


        //-----------------------------------------------------------------------------------------------------------------
        //     Este evento es el que vamos a utilizar para llevar la info del Grid al formulario de detalle 
        //
        // OJO  RECORDAR  :  Este es el evento del doble click del Grid  que se crea desde la ventana de propiedades 
        //                   del objeto, del Grid
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //-->Hacer el Convert  los valores que llegan del Grid llegan como Object 
            //   el   CurrentRow.Cells  captura lo que tiene la celda actual


            //->Le he indicado todos los campos para que me lleve todos los valores a la solapa del detalle          
            this.txtidTipoIva.Text =  Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoIva"].Value);
            this.txtcDetIva.Text =  Convert.ToString(this.dataListado.CurrentRow.Cells["cDetIva"].Value);
            this.txtnPorcIva.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nPorcIva"].Value);
            this.txtnPorReq.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nPorReq"].Value);

            //-> Para que pinte la  Solapa/folder/TabPage  1   que imagino es la del detalle, la del grid debe ser la 0
            this.tabControl1.SelectedIndex = 1;

            /// this.IsEditar

            //->Recuperacion de imagenes en VIDEO 15  minuto 04:00 aprox)
        }
    }
}
