using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaDatos;   //Tengo que utilizar objetos de esta capa 
using CapaNegocio; //Tengo que utilizar objetos de esta capa   


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

            //->MENSAJES de ayuda TOOLTIP EN LAS CAJAS DE TEXTO 
            this.ttMensaje.SetToolTip(this.txtNombre, "Indique el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtNumeroDocu, "Indique el número del Documento");
            //etc..  etc.. pondria los mensajes para todos los campos que quiera...

            
        }


        //->Este es el evento de cambio de valor en el ComboBox lo obtengo haciendo dobleClick sobre el control en el formulario
        private void cbCodPostal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCodPostal.SelectedIndex > 0)
            {                
                string[] valores =  DValidator.captar_info(cbCodPostal.Text.Substring(0,5));
                this.txtCodPostal.Text = valores[0];  
                this.txtPoblacion.Text = valores[1];  
            }
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

            //this.txtDescuento.Text = string.Empty;  
            this.txtDescuento.Text = "0,00";


            this.txtCuenta.Text = string.Empty;
            this.txtEmail.Text = string.Empty;


            //-->Cargo el combo de los codigos postales             
            DValidator.RellenoComboPostal(cbCodPostal);
            cbCodPostal.SelectedIndex = 0;  //lo colocamos en la primera posicion con valores 


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

          
            //EN ALTAS LLEGARA COMO TRUE ENTONCES COMO ES SOLO LECTURA EL CONTRARIO ES FALSE, ES DECIR NOOO SOLO LECTURA
            //JODER QUE MIERDA QUE ES ESTO


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
            this.txtEmail.ReadOnly = !valor;
                        
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
                this.cbCodPostal.Enabled = true;   //EL COMBO DE CODIGOS POSTALES
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
                this.cbCodPostal.Enabled = false;   //EL COMBO DE CODIGOS POSTALES
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

            this.dataListado.Columns[1].HeaderText = "ID";
            this.dataListado.Columns[2].HeaderText = "Nombre";
            this.dataListado.Columns[3].HeaderText = "Dirección";
            this.dataListado.Columns[4].HeaderText = "Población";
            this.dataListado.Columns[5].HeaderText = "Teléfono";
            this.dataListado.Columns[6].HeaderText = "DNI/NIF/NIE";
            this.dataListado.Columns[7].HeaderText = "Contacto";
            this.dataListado.Columns[8].HeaderText = "Cta. Contable";
            this.dataListado.Columns[9].HeaderText = "Descuento";
            this.dataListado.Columns[10].HeaderText = "Mail";
            this.dataListado.Columns[11].HeaderText = "Cod. Postal";
            this.dataListado.Columns[12].HeaderText = "Fecha Nacimiento";


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


        //-->PREGUNTAMOS POR EL VALOR DEL COMBO PARA SABER POR QUE CAMPO TENEMOS QUE BUSCAR 
        
        private void btnBuscar_Click_1(object sender, EventArgs e)
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
        private void chkEliminar_CheckedChanged_1(object sender, EventArgs e)
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
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            this.IsNuevo = true;    //Es un alta así que este valor a true   
            this.IsEditar = false;  //Este a False

            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();   //Foco a la caja de texto del nombre 
        }


    
        //------ BOTON GUARDAR ------------------------------------------------------------                
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            try   //Control de errores   bien....
            {

                //-->VALIDACION DE CAMPOS. NOTA en el curso de C# ví que esto se puede hacer en las propiedades GET/SET
                //----------------------------------------------------------------------------------------------------
                string rpta = "";

                //Controles que deben de tener valores obligatoriamente -- Si está vacía y como es un campo obligatorio,  pues hay que meterlo

                //if (this.txtNombre.Text == string.Empty || this.txtIdCliente.Text == string.Empty || this.txtNumeroDocu.Text == string.Empty)
                if (this.txtNombre.Text == string.Empty  || this.txtNumeroDocu.Text == string.Empty)
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
                        //-------------------------------------------------------------------------------------------------------

                        

                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                                                  this.txtDirCli.Text.Trim().ToUpper(),
                                                  this.txtPoblacion.Text.Trim().ToUpper(),
                                                  this.txtNumeroDocu.Text.Trim().ToUpper(),
                                                  this.txtPerson.Text.Trim().ToUpper(),
                                                  this.txtCuenta.Text.Trim().ToUpper(),
                                                  Convert.ToDecimal(this.txtDescuento.Text),
                                                  this.txtTelefono.Text,
                                                  this.txtEmail.Text,
                                                  Convert.ToString(this.txtCodPostal.Text),
                                                  this.dtFechaNac.Value,
                                                  this.txtBuscar.Text.Trim().ToUpper());



                                                      



                    }
                    else    //Es una modificacion  
                    {
                        //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores 



                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdCliente.Text),
                                                 this.txtNombre.Text.Trim().ToUpper(),
                                                 this.txtDirCli.Text.Trim().ToUpper(),
                                                 this.txtPoblacion.Text.Trim().ToUpper(),
                                                 this.txtNumeroDocu.Text.Trim().ToUpper(),
                                                 this.txtPerson.Text.Trim().ToUpper(),
                                                 this.txtCuenta.Text.Trim().ToUpper(),
                                                 Convert.ToDecimal(this.txtDescuento.Text),
                                                 this.txtTelefono.Text,
                                                 this.txtEmail.Text,
                                                 this.txtCodPostal.Text,
                                                 this.dtFechaNac.Value,
                                                 this.txtBuscar.Text.Trim().ToUpper());







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
        
        private void btnEditar_Click_1(object sender, EventArgs e)
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
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



        //--> Este evento ocurre antes de que se actualice el valor de la celda.
        //--> Se genera haciendo doble click  sobre el Grid.  
        //--> UTILIDAD : Saber el valor inicial del check de baja  
        //-----------------------------------------------------------------------------------------------------------------------


        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            //->Preguntamos si el indice de la columna es el de la columna Eliminar
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                //-->Declaramos la variable  ChkEliminar   del tipo  DataGridViewCheckBoxCell  
                //   nos traeremos los valores (OjO haciendo conversion al tipo DataGridViewCheckBoxCell) 
                //   de donde esta marcando el usuario para eliminar  
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];

                //-->Estamos indicando  ChkEliminar.Value  si está marcado o no el checkbox 
                //   en la columna elimnar del GRID y lo convertimos a True o False 
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
            
        //--------- DOBLE CLICK DEL  GRID   MOVIENDO INFORMACION DEL GRID A LOS CAMPOS -----------------------------------------------------
        //RECORDAR  :  Este es el evento del doble click del Grid  que se crea desde la ventana de propiedades del objeto, del Grid.
        // 
        //Aqui lo que estamos indicando es que cuando en el GRID se haga doble click se muestre el registro selecionado
        //en el formulario individual.
        //
        //Para indicar este evento : Nos situamos en el GRID,  CLICK para ver sus propiedades y buscamos 
        //                           el evento(rayo)  DoubleClick  al clicar sobre el mismo nombre y
        //                           selecionar ninguna de la opciones que aparecen en el desplegable 
        //                           ya nos creara el "esqueleto" del procedimiento del  evento
        //--------------------------------------------------------------------------------------------------------------------------------
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //-->Hacer el Convert : Los valores que llegan del Grid sin tipo Object 
            //                      El  CurrentRow.Cells  captura lo que tiene la celda actual  
                              
            this.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCodcli"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cNomCli"].Value);
            this.txtDirCli.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cDirCli"].Value);
            this.txtPoblacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cPobCli"].Value);
            this.txtCodPostal.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cCodPostal"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cTelefono1"].Value);
            this.txtNumeroDocu.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cDniCif"].Value);
            //->OjO este es de fecha, la conversion es diferente
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["dFechaNaci"].Value);
            this.txtPerson.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cContacto"].Value);
            this.txtDescuento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nDto"].Value);
            this.txtCuenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cCtaContable"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cEmail"].Value);

            //-> Para pintar la solapa 1... veremos como va 
            this.tabControl1.SelectedIndex = 1;
            //->Recuperacion de imagenes en VIDEO 15  minuto 04:00 aprox)
        }


        //----------------------------------------------------------------------------------------------------
        //--->                         VALIDACIONES DE  CAMPOS                                     <----------
        //
        //   Para poder utilizar en ENTER para salir de los campos hay que indicarlo en todos ellos
        //----------------------------------------------------------------------------------------------------

        


        //--->  EDICION DE CAMPOS (doble clic desde las propiedades del campo  en KeyPress)
        //------------------------------------------------------------------------------------------
        private void txtCodPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.SoloNumeros(e);
            DValidator.ValiEnter(e);
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.NumerosDecimales(e);
            DValidator.ValiEnter(e);
        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.SoloNumeros(e);
            DValidator.ValiEnter(e);
        }


        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }

        private void txtPoblacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }

        private void txtDirCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }

        private void dtFechaNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }

        private void txtPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }

        private void cbTipo_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }

        private void txtNumeroDocu_KeyPress(object sender, KeyPressEventArgs e)
        {
            DValidator.ValiEnter(e);
        }



        
        
        //----------------------//

        private void txtNumeroDocu_Validating(object sender, CancelEventArgs e)
        {
            int numero;
            char cReciLetra;            
            int index;

            //-> Tratamiendo segun documento, tengo un código donde se trata el cálculo de la letra para 
            //   cada tipo de documento.
            //------------------------------------------------------------------------------------------
            index = cbTipo_Documento.SelectedIndex;

            switch (index)
            {
                case 0:                    
                    numero = Convert.ToInt32(txtNumeroDocu.Text);
                    //cReciLetra = Convert.ToString(Validaciones.calcularLetra(numero));
                    cReciLetra = DValidator.calcularLetra(numero);

                    MessageBox.Show("El resultado es: " + txtNumeroDocu.Text + cReciLetra);
                    txtNumeroDocu.Text = txtNumeroDocu.Text + cReciLetra;
                    break;
                case 1:                   
                    MessageBox.Show("Es NIE" );
                    break;
                case 2:                    
                    MessageBox.Show("Es PASAPORTE");
                    break;
                default:
                    MessageBox.Show("NO ES NINGUNO");
                    break;
            }            
        }

        //->ESTA PROPIEDAD ES CUANDO EL USUARIO CIERRA EL FORMULARIO  
        //  ->>>> No lo voy a utilizar pero esta bien saberlo <<<<<
        //private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Application.Exit();
        //}


        private void txtDescuento_Validated(object sender, EventArgs e)
        {
            //decimal joder;
            //joder = Convert.ToDecimal(txtDescuento.Text);

            MessageBox.Show("Como has dejado esto : " + Convert.ToDecimal(txtDescuento.Text) );
        }



        // QUE DIFERENCIA HAY ENTRE VALIDATING(Antes de Validated)  Y  VALIDATED (Despues de haberse hecho Validating)

        //private void textbox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    if (textbox.text == "")
        //    {
        //        e.Cancel = true;
        //        textbox.Select(0, textBox1.Text.Length);
        //        errorProvider1.SetError(textBox1, "Debe introducir el nombre");
        //    }
        //}

        //private void textBox1_Validated(object sender, System.EventArgs e)
        //{
        //    errorProvider1.SetError(textbox, "");
        //}






        //-----------------------------------------------------------------------------------------------------------------------
        //------- ZONA POR COME_MIERDAS   copie los controles y no hice click sobre ellos antes de meter el código           ---- 
        //-----------------------------------------------------------------------------------------------------------------------
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



                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                                                  this.txtDirCli.Text.Trim().ToUpper(),
                                                  this.txtPoblacion.Text.Trim().ToUpper(),
                                                  this.txtNumeroDocu.Text.Trim().ToUpper(),
                                                  this.txtPerson.Text.Trim().ToUpper(),
                                                  this.txtCuenta.Text.Trim().ToUpper(),
                                                  Convert.ToDecimal(this.txtDescuento.Text),
                                                  this.txtTelefono.Text,
                                                  this.txtEmail.Text,
                                                  this.txtCodPostal.Text,
                                                  this.dtFechaNac.Value,
                                                  this.txtBuscar.Text.Trim().ToUpper());


                    }
                    else    //Es una modificacion  
                    {
                        //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores 



                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdCliente.Text),
                                                 this.txtNombre.Text.Trim().ToUpper(),
                                                 this.txtDirCli.Text.Trim().ToUpper(),
                                                 this.txtPoblacion.Text.Trim().ToUpper(),
                                                 this.txtNumeroDocu.Text.Trim().ToUpper(),
                                                 this.txtPerson.Text.Trim().ToUpper(),
                                                 this.txtCuenta.Text.Trim().ToUpper(),
                                                 Convert.ToDecimal(this.txtDescuento.Text),
                                                 this.txtTelefono.Text,
                                                 this.txtEmail.Text,
                                                 this.txtCodPostal.Text,
                                                 this.dtFechaNac.Value,
                                                 this.txtBuscar.Text.Trim().ToUpper());







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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;    //Es un alta así que este valor a true   
            this.IsEditar = false;  //Este a False

            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();   //Foco a la caja de texto del nombre 
        }


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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //->Preguntamos si el indice de la columna es el de la columna Eliminar
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                //-->Declaramos la variable  ChkEliminar   del tipo  DataGridViewCheckBoxCell  
                //   nos traeremos los valores (OjO haciendo conversion al tipo DataGridViewCheckBoxCell) 
                //   de donde esta marcando el usuario para eliminar  
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];

                //-->Estamos indicando  ChkEliminar.Value  si está marcado o no el checkbox 
                //   en la columna elimnar del GRID y lo convertimos a True o False 
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        

        //---->  EL SISTEMA DEJA NUEVO CODIGO ----------------------------------




    }
}
