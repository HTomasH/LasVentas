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


//--------------------------------------------------------------------------------------------------------------------------------------------
//  ATENCION :  Para cambiar el primer formulario que por defecto queramos que se pinte al entrar en la aplicacion se cambia de esta forma
//              Hay que ir al fichero Program.cs del proyecto principal(LasVentas)   y  cambiar la linea    Application.Run(new FrmFamilias());
//
//              (por defecto siempre apunta al  Form1)
//------------------------------------------------------------------------------------------------------------------------------------------


namespace CapaPresentacion
{
    public partial class FrmArticulos : Form
    {


        //->Variables para saber si estamos dando altas o no.  es como el que yo utilizaba de  lAltas 
        private bool IsNuevo = false;
        private bool IsEditar = false;


        //-----------------------------------------------------------------------------------------------------------------------------
        //-->PARA LA LUPA DE FAMILIAS  ya que envia parametros de un formulario a otro 
        //-----------------------------------------------------------------------------------------------------------------------------

        // Variable  
        private static FrmArticulos _InstaArti; 
        
        //   Método   para saber si ya tengo una instancia creada o no, si no la tengo la creo, si existiera pues vale la devolvemos. 
        public static FrmArticulos GetInstaArti()
        {
            if (_InstaArti == null)
            {
                //Instancia al formulario,  que tambien es una clase por eso se puede instanciar.
                _InstaArti = new FrmArticulos();
            }
            return _InstaArti;
        }


        // Metodo( que es procedimiento es VOID no retorna nada)  para enviar los valores recibidos a la caja de texto 
        public void setFamilia  (string idCodFam , string cNombreFamilia)
        {
            this.txtIdCodFam.Text = idCodFam;
            this.txtNombreFamilia.Text = cNombreFamilia;                       
        }
        //-->FIN CODIGO PARA LUPA  FAMILIAS 
        //-----------------------------------------------------------------------------------------------------------------------------






        //Constructor --------------------------------------
        public FrmArticulos()
        {
            InitializeComponent();  //Este inicializa los componentes del formulario

            //->Este será el mensaje a mostrar el TOOLTIP al tener el foco en el campo (Caja de texto-TextBox  txtNombre)
            this.ttMensaje.SetToolTip(this.txtcDetalle, "Indique el Nombre del Artículo");



            //Si tuviera un Combo llamaria a esta funcion que tengo abajo deshabilitad
            //para rellenalor     (Video : 14  Minuto : 10 )

            // --->        private void LlenarComboPresentacion()

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
                this.txtidCodArti.Text = string.Empty;
                this.txtcDetalle.Text = string.Empty;
                this.txtIdCodFam.Text = string.Empty;
                this.txtidTipoIva.Text = string.Empty;
                this.txtNombreFamilia.Text = string.Empty;
                this.txtcCodigoBar.Text = string.Empty;
                this.txtnPvP.Text = string.Empty;
                this.txtnStock.Text = string.Empty;
                this.txtPorcenIva.Text = string.Empty;



                //-->Si tubiera una imagen, para dejarla vacia haria esto  (Video :  14  Minuto :  05 )
                //   this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;       
            }


            // Habilitar o NO los controles del formulario        
            //-> Si  valor  llega con valor TRUE pues le indicamos el contrario con ! 
            //   esto es porque la propiedad es  ReadOnly                                 
            private void Habilitar(bool valor)
            {

                this.txtidCodArti.ReadOnly = true; // !valor;  //Es un valor Identity  lo 'capo del todo'
                this.txtidCodArti.Enabled = false; // !valor;  //Es un valor Identity  lo 'capo del todo'
                //cambiarle el color a esto cuando este deshabilitado 
                                
                this.txtcDetalle.ReadOnly = !valor;
                this.txtIdCodFam.ReadOnly = !valor;
                this.txtidTipoIva.ReadOnly = !valor;            
                this.txtnPvP.ReadOnly = !valor;
                this.txtnStock.ReadOnly = !valor;
                this.txtPorcenIva.ReadOnly = true; // !valor;
                this.txtcCodigoBar.ReadOnly = !valor;

                this.txtIdCodFam.ReadOnly = valor;
                this.txtNombreFamilia.ReadOnly = true; //!valor;
                this.btnLupaFami.Enabled = valor;


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
                //Vamos a llamar  a la clase  NArticulos a su metodo Mostrar  (CAPA NEGOCIO)
                //
                //El metodo mostar lo que hace es  llamar al metodo Mostrar de la clase   DArticulos()     (CAPA DATOS)
                //
                //EL Metodo Mostrar de la capa datos  lo que hace es llamar al procedimiento almacenado que creamos 
                // el  "spMostrar_articulo";  que es el que finalmente  captura la información en la base de datos 

                //ESCALADO :
                //CAPA PRESENTACION  llama a   CAPA NEGOCIO   que llama   a CAPA DATOS    que conecta con  BB.DD
                this.dataListado.DataSource =  NArticulo.Mostrar();


                this.OcultarColumnas();

                //-->Pintamos el total de registros : OjO el count es  int  tenemos que convertirlo a String 
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            }


            //-->Método BuscarNombre
            //-----------------------------------------------------------------------------------------------
            private void BuscarNombre()
            {

                //Hace lo mismo que el procedimiento Mostrar pero la diferencia es que aquí si le estamos enviado 
                //un valor :   BuscarNombre(this.txtBuscar.Text)     obviamente el nombre que queremos buscar.
                this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
                this.OcultarColumnas();
                lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            }

        //-->Metodo que carga el formulario 
        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;    //Es un alta así que este valor a true   
            this.IsEditar = false;  //Este a False

            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtcDetalle.Focus();   //Foco a la caja de texto del nombre 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try   //Control de errores   bien....
            {

                //-->VALIDACION DE CAMPOS. NOTA en el curso de C# ví que esto se puede hacer en las propiedades GET/SET
                //----------------------------------------------------------------------------------------------------
                string rpta = "";
                //Controles que deben de tener valores obligatoriamente -- Si está vacía y como es un campo obligatorio,  pues hay que meterlo
                if (this.txtcDetalle.Text == string.Empty   ||  this.txtIdCodFam.Text == string.Empty  ||  this.txtidTipoIva.Text == string.Empty )  
                {
                                                            
                    //--> MENSAJES A MOSTRAR SI LOS CAMPOS OBLIGATORIOS ESTUVIERAN VACIOS  -  Este metodo lo tengo en este mismo módulo
                    MensajeError("Faltan por indicar  datos, serán remarcados");
                    //--Vamos a indicar el mensaje a mostrar cuando salga el error.
                    errorIcono.SetError(txtcDetalle, "Indique un Nombre");
                    errorIcono.SetError(txtIdCodFam, "Indique un código de Familia");
                    errorIcono.SetError(txtidTipoIva, "Indique un código de IVA");

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
                        rpta =  NArticulo.Insertar( this.txtcDetalle.Text.Trim().ToUpper() , Convert.ToInt32(this.txtIdCodFam.Text) ,
                                                    Convert.ToInt32(this.txtnStock.Text), Convert.ToInt32(this.txtidTipoIva.Text) ,  Convert.ToDecimal(this.txtnPvP.Text) , 
                                                    this.txtcCodigoBar.Text  );




                        /*                                                
                            @idCodArti int  output,    --OjO que es identity   (autogenerado)   de tipo salida
                            @cDetalle varchar(100),
                            @idCodFam int,
                            @nStock  decimal(18,6),
                            @idTipoIva smallint,
                            @nPvP decimal(18,6),
                            @cCodigoBar varchar(50)
                         */


                    }
                    else    //Es una modificacion  
                    {
                        //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores 
                        ///rpta = NFamilias.Editar(Convert.ToInt32(this.txtIdFamilias.Text), this.txtNombre.Text.Trim().ToUpper());
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtidCodArti.Text ),
                                                this.txtcDetalle.Text.Trim().ToUpper(), 
                                                Convert.ToInt32(this.txtIdCodFam.Text), 
                                                Convert.ToDecimal(this.txtnStock.Text), 
                                                Convert.ToInt16(this.txtidTipoIva.Text), 
                                                Convert.ToDecimal(this.txtnPvP.Text), 
                                                this.txtcCodigoBar.Text);                        
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidCodArti.Text.Equals(""))
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
        }


        //Si tuviera un Combo así es como lo rellenaria    (Video : 14  Minuto : 10 )
        /*
                private void LlenarComboPresentacion()
                {
                    cbIdpresentacion.DataSource = NPresentacion.Mostrar();
                    cbIdpresentacion.ValueMember = "idpresentacion";
                    cbIdpresentacion.DisplayMember = "nombre";
                }

         *  */



        //Este es el evento se genera haciendo doble click  sobre el Grid  
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

        // OJO  RECORDAR  :  Este es el evento del doble click del Grid  que se crea desde la ventana de propiedades del objeto, del Grid
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            //-->Hacer el Convert  los valores que llegan del Grid llegan como Object 
            //   el   CurrentRow.Cells  captura lo que tiene la celda actual

                       
            //->Le he indicado todos los campos para que me lleve todos los valores a la solapa del detalle 

            this.txtidCodArti.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCodArti"].Value);
            this.txtcDetalle.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cDetalle"].Value);            
            this.txtIdCodFam.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCodFam"].Value);
            this.txtnPvP.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nPvP"].Value);
            this.txtnStock.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nStock"].Value);
            this.txtidTipoIva.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idTipoIva"].Value);
            this.txtcCodigoBar.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cCodigoBar"].Value);


            //->Recuperacion de imagenes en VIDEO 15  minuto 04:00 aprox)


            //-------->  TRATAMIENTO INFORMACION LUPA   <-------------------------------------------------------------------------------------------

            //Esto es para capturar el valor de lupa 
            this.txtIdCodFam.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCodFam"].Value);

            
                    //CAGATOR  :  el profe no busca los valores de otras tablas cuando son lupas, con el diseño que tiene se apaña ya que utiliza 
                    //            los nombres y no los codigos.
                    //RESOLUCION :   Escalo la información llamo a la capa negocios esta llama a la capa datos para mirar en la BB.DD(tabla)                         
                    this.dataListado.DataSource = NFamilias.Mostrar();
                    this.txtNombreFamilia.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cNombreFamilia"].Value);
                    
                //Vuelvo a colocar el foco en  los Artículos que sino se queda apuntando a las Familias 
                    this.dataListado.DataSource = NArticulo.Mostrar();

                    //-> Para que pinte la  Solapa/folder/TabPage  1   que imagino es la del detalle, la del grid debe ser la 0
                    this.tabControl1.SelectedIndex = 1;
            //----------------------------------------------------------------------------------------------------------------------------------

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
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

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

        //Este es el evento clic de la lupa de las Familias 
        private void btnLupaFami_Click(object sender, EventArgs e)
        {
            //Vamos a instanciar una variable con el tipo del formulario auxiliar y lo mostraremos 

            frmVistaFamilia_Articulo form = new frmVistaFamilia_Articulo();
            form.ShowDialog();
            
        }




    }
    }
