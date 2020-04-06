using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;   //Esto no termino de verlo, si tengo la referencia a la CapaNegocio además hay que hacer el usign
                     //Por lo que veo son necesarias las dos acciones,  primero indicar la Referencia y luego el using


namespace CapaPresentacion
{
    public partial class frmCliente : Form      // Es una PARTIAL CLASS  curso:  Se dividen pero al compilar es una sola !!!
    {

        //->Variables para saber si estamos dando altas o no.  es como el que yo utilizaba de  lAltas 
        private bool IsNuevo = false;
        private bool IsEditar = false;


        //->Constructor sin  parametros 
        public frmCliente()
        {
            InitializeComponent();  //Se inicializan todos los componentes del formulario

            //->MENSAJES TOOLTIP EN LAS CAJAS DE TEXTO 
            this.ttMensaje.SetToolTip(this.txtNombre, "Indique el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtNumeroDocu, "Indique el número del Documento");
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


        //-->Limpiar  las  cajas de texto (textBox del formulario)
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;            
            this.txtDirCli.Text = string.Empty;            
            this.txtPoblacion.Text = string.Empty;
            this.txtCodPostal.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtNumeroDocu.Text = string.Empty;
            this.dtFechaNac.Text = string.Empty;            
            this.txtPerson.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
            this.txtCuenta.Text = string.Empty;

     
            //-->Si tubiera una imagen, para dejarla vacia haria esto  (Video :  14  Minuto :  05 )
            //   this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;       

        }


        // Habilitar o NO los controles del formulario        
        //-> Si  valor  llega con valor TRUE pues le indicamos el contrario con ! 
        //   esto es porque la propiedad es  ReadOnly                                 
        private void Habilitar(bool valor)
        {

            this.txtIdCliente.ReadOnly = true; // !valor;  //Es un valor Identity  lo 'capo del todo'
            this.txtIdCliente.Enabled = false; // !valor;  //Es un valor Identity  lo 'capo del todo'
                                               //cambiarle el color a esto cuando este deshabilitado 
            this.txtNombre.ReadOnly = !valor;
            this.txtDirCli.ReadOnly = !valor;
            this.txtPoblacion.ReadOnly = !valor;
            this.txtCodPostal.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtNumeroDocu.ReadOnly = !valor;
            
            //this.dtFechaNac .ReadOnly = !valor;  Este es la fecha, a ver como se habilita o no 
            this.dtFechaNac.Enabled = valor;

            this.txtPerson.ReadOnly = !valor;
            this.txtDescuento.ReadOnly = !valor;
            this.txtCuenta.ReadOnly = !valor;

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


        //-->Método para ocultar columnas en el Grid de Articulos
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;   //Esta se corresponde con la Columna para dar de baja 
                                                           // this.dataListado.Columns[1].Visible = false;   //idCodArti
                                                           // this.dataListado.Columns[3].Visible = false;   //idCodFam
                                                           // this.dataListado.Columns[6].Visible = false;   //idTipoIva 

        }


        //-->Método Mostrar
        //-------------------------------------------------------------------------------------------
        private void Mostrar()
        {

            //ESCALADO : Para pintar la información en el Grid (dataListado.DataSource)  
            //
            //Vamos a llamar  a la clase  NClientes a su metodo Mostrar  (CAPA NEGOCIO)
            //
            //El metodo mostrar lo que hace es  llamar al metodo Mostrar de la clase   DClientes()     (CAPA DATOS)
            //
            //EL Metodo Mostrar de la capa datos  lo que hace es llamar al procedimiento almacenado que creamos 
            // el  "spmostrar_cliente";  que es el que finalmente  captura la información en la base de datos 

            //ESCALADO :
            //CAPA PRESENTACION  llama a   CAPA NEGOCIO   que llama   a CAPA DATOS    que conecta con  BB.DD
            this.dataListado.DataSource = NCliente.Mostrar();


            this.OcultarColumnas();

            //-->Pintamos el total de registros : OjO el count es  int  tenemos que convertirlo a String 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        //-->Método BuscarNombre
        //-----------------------------------------------------------------------------------------------
        private void BuscarRazonSocial()
        {

            //Hace lo mismo que el procedimiento Mostrar pero la diferencia es que aquí si le estamos enviado 
            //un valor :   BuscarNombre(this.txtBuscar.Text)     obviamente el nombre que queremos buscar.

            this.dataListado.DataSource = NCliente.BuscarRazonSocial(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void BuscarDocumento()
        {

            //Hace lo mismo que el procedimiento Mostrar pero la diferencia es que aquí si le estamos enviado 
            //un valor :   BuscarNombre(this.txtBuscar.Text)     obviamente el nombre que queremos buscar.

            this.dataListado.DataSource =  NCliente.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void frmCliente_Load(object sender, EventArgs e)
        {

            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("RAZON SOCIAL"))
            {
                this.BuscarRazonSocial();
            }
            else if (cbBuscar.Text.Equals("DOCUMENTO"))
            {
                this.BuscarDocumento();
            }
        }


        //----- BOTON ELIMINAR  ------------------------------------------------------------------------------
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
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

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
                    //-->Para volver a pintar el GRID con los cambios
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //----  BOTON ELIMINAR ---------------------------------------------------------
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

        //----  BOTON NUEVO ---------------------------------------------------------
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            this.IsNuevo = true;    //Es un alta así que este valor a true   
            this.IsEditar = false;  //Este a False

            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();   //Foco a la caja de texto del nombre 

        }

        //------ BOTON GUARDAR ------------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try   //Control de errores   bien....
            {

                //-->VALIDACION DE CAMPOS. NOTA en el curso de C# ví que esto se puede hacer en las propiedades GET/SET
                //----------------------------------------------------------------------------------------------------
                string rpta = "";

                //Controles que deben de tener valores obligatoriamente -- Si está vacía y como es un campo obligatorio,  pues hay que meterlo

                if (this.txtNombre.Text == string.Empty || this.txtIdCliente.Text == string.Empty || this.txtNumeroDocu.Text == string.Empty)
                {

                    //--> MENSAJES A MOSTRAR SI LOS CAMPOS OBLIGATORIOS ESTUVIERAN VACIOS  -  Este metodo lo tengo en este mismo módulo
                    MensajeError("Faltan por indicar  datos, serán remarcados");
                    //--Vamos a indicar el mensaje a mostrar cuando salga el error.
                    errorIcono.SetError(txtNombre, "Indique un Nombre");
                    errorIcono.SetError(txtNumeroDocu, "Indique un número de documento");

                }
                else  //El textBox llega con valor,  
                {
                    if (this.IsNuevo)  //Es un alta ??
                    {
                        //-->Si tuvieramos que guardar una imagen, lo tratariamos de esta forma     VIDEO 14 minuto  20 aprox:   
                        //----------------------------------------------------------------------                     
                        //   System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        //   this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        //   byte[] imagen = ms.GetBuffer();


                        //-->Vamos a llamar al Metodo Insertar de la CapaNegocio enviandole los valores para insertar en la bb.dd 

                        //rpta = NArticulo.Insertar(this.txtcDetalle.Text.Trim().ToUpper(), Convert.ToInt32(this.txtIdCodFam.Text),
                        //                            Convert.ToInt32(this.txtnStock.Text), Convert.ToInt32(this.txtidTipoIva.Text), Convert.ToDecimal(this.txtnPvP.Text),
                        //                            this.txtcCodigoBar.Text);

                        rpta = NProveedor.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtNumeroDocu.Text);


                    }
                    else    //Es una modificacion  
                    {
                        //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores 


                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdCliente.Text),
                                                 this.txtNombre.Text.Trim().ToUpper(),
                                                 this.txtNumeroDocu.Text);
                    }

                    //-->Ahora vamos a ver si la operación tuvo éxito o no, el "OK" que estamos poniendo aquí es el que está
                    //   indicado  en la CAPADATOS en los metodos 
                    //   Insertar y Editar de esta forma :  rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";  
                    //  Por eso pongo OK sino pondría lo que tuviera puesto...                                                                   
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

                    //Borra la pelotilla del error si estuviera 
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



        //--------- BOTON   EDITAR ----------------------------
        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (!this.txtIdCliente.Text.Equals(""))
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

        //--------- BOTON   CANCELAR ----------------------------
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
            this.txtIdCliente.Text = string.Empty;

        }


        //--------- TRATAMIENTO GRID   REPASAR ESTA FUNCION.....
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //Si el indice de la columna es el de la columna Eliminar
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {

                //Declaramos la variable  ChkEliminar   del tipo  DataGridViewCheckBoxCell  
                //nos traeremos los valores (OjO haciendo conversion al tipo DataGridViewCheckBoxCell) 
                //de donde esta marcando el usuario para eliminar  
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];

                //Estamos indicando el valor si esta marcado o no el checkbox en la columna elimnar del GRID y lo convertimos a True o False 
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }


        //--------- DOBLE CLICK DEL  GRID   MOVIENDO INFORMACION DEL GRID A LOS CAMPOS 
        // OJO  RECORDAR  :  Este es el evento del doble click del Grid  que se crea desde la ventana de propiedades del objeto, del Grid
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {


            //-->Hacer el Convert, 
            //  los valores que llegan del Grid llegan como Object - El  CurrentRow.Cells  captura lo que tiene la celda actual


            //->Le he indicado todos los campos para que me lleve todos los valores a la solapa del detalle 

            //this.txtIdProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idProveedo"].Value);
            //this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cNomPro"].Value);
            //this.txtNumeroDocu.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cNifDni"].Value);

            //AQUIIIIIIIIIIIIIIIIII

            //this.txtIdCliente.ReadOnly = true; // !valor;  //Es un valor Identity  lo 'capo del todo'
            //this.txtIdCliente.Enabled = false; // !valor;  //Es un valor Identity  lo 'capo del todo'
            //                                   //cambiarle el color a esto cuando este deshabilitado 
            //this.txtNombre.ReadOnly = !valor;
            //this.txtDirCli.ReadOnly = !valor;
            //this.txtPoblacion.ReadOnly = !valor;
            //this.txtCodPostal.ReadOnly = !valor;
            //this.txtTelefono.ReadOnly = !valor;
            //this.txtNumeroDocu.ReadOnly = !valor;

            ////this.dtFechaNac .ReadOnly = !valor;  Este es la fecha, a ver como se habilita o no 
            //this.dtFechaNac.Enabled = valor;

            //this.txtPerson.ReadOnly = !valor;
            //this.txtDescuento.ReadOnly = !valor;
            //this.txtCuenta.ReadOnly = !valor;





            //-> Para pintar la solapa 1... veremos como va 
            this.tabControl1.SelectedIndex = 1;


            //->Recuperacion de imagenes en VIDEO 15  minuto 04:00 aprox)

        }




    }
}
