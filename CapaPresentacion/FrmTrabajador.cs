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
    public partial class FrmTrabajador : Form
    {


        //->Variables para saber si estamos dando altas o no.  es como el que yo utilizaba de  lAltas 
        private bool IsNuevo = false;
        private bool IsEditar = false;


        //->Constructor sin  parametros 
        public FrmTrabajador()
        {
            InitializeComponent();  //Se inicializan todos los componentes del formulario

            //->MENSAJES de ayuda TOOLTIP EN LAS CAJAS DE TEXTO 
            this.ttMensaje.SetToolTip(this.txtNombreTraba, "Indique el Nombre del Trabajador");
            this.ttMensaje.SetToolTip(this.txtApellidosTraba, "Indique los apellidos del Trabajador");
            this.ttMensaje.SetToolTip(this.txtcAcceso, "Indique el Usuario/Acceso");
            this.ttMensaje.SetToolTip(this.txtPassword, "Indique el Password");
            this.ttMensaje.SetToolTip(this.cbAcceso, "Indique Perfil de acceso");                        
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
            this.txtNombreTraba.Text = string.Empty;
            this.txtApellidosTraba.Text = string.Empty;
            this.txtcAcceso.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.cbAcceso.Text = string.Empty;
            this.txtUsuariol.Text = string.Empty;

        }


        // Habilitar o NO los controles del formulario        
        //-> Si  valor  llega con valor TRUE pues le indicamos el contrario con ! 
        //   esto es porque la propiedad es  ReadOnly                                 
        private void Habilitar(bool valor)
        {

            this.txtIdTraba.ReadOnly = true; // !valor;  //Es un valor Identity  lo 'capo del todo'
            this.txtIdTraba.Enabled = false; // !valor;  //Es un valor Identity  lo 'capo del todo'
                                             //cambiarle el color a esto cuando este deshabilitado 


          
            this.txtNombreTraba.ReadOnly = !valor;
            this.txtApellidosTraba.ReadOnly = !valor;
            this.txtcAcceso.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
            this.txtUsuariol.ReadOnly = !valor;
            //this.cbAcceso.ReadOnly = !valor;


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
                this.cbAcceso.Enabled = true;   //EL COMBO DE PERFILES
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
                this.cbAcceso.Enabled = false;   //EL COMBO DE PERFILES
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
            this.dataListado.DataSource = NTrabajador.Mostrar();


            this.OcultarColumnas();

            //-->Pintamos el total de registros : OjO el count es  int  tenemos que convertirlo a String 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            this.dataListado.Columns[1].HeaderText = "ID";
            this.dataListado.Columns[2].HeaderText = "Nombre Trabajador";
            this.dataListado.Columns[3].HeaderText = "Apellidos";
            this.dataListado.Columns[4].HeaderText = "Perfil";
            this.dataListado.Columns[5].HeaderText = "Password";
            this.dataListado.Columns[6].HeaderText = "Usuario para Acceso";

        }

        private void BuscarNombreTrabajador()
        {
            //Hace lo mismo que el procedimiento Mostrar pero la diferencia es que aquí si le estamos enviado 
            //un valor :   BuscarNombre(this.txtBuscar.Text)     obviamente el nombre que queremos buscar.

            this.dataListado.DataSource =  NTrabajador.BuscarNombreTrabajador(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        //->Búsqueda Incremental,  
        //  el método  TextChanged lo obtengo haciendo doble click en la caja de texto
        //->Evento   TextChanged, se llama al Metodo buscar nombre 
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombreTrabajador();
        }




        ////----- BOTON ELIMINAR  ------------------------------------------------------------------------------
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
                            Rpta = NTrabajador.Eliminar(Convert.ToInt32(Codigo));

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

        ////----  CHECK  ELIMINAR ---------------------------------------------------------                
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




        ////----  BOTON NUEVO ---------------------------------------------------------                
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;    //Es un alta así que este valor a true   
            this.IsEditar = false;  //Este a False

            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombreTraba.Focus();   //Foco a la caja de texto del nombre 
        }



        ////------ BOTON GUARDAR ------------------------------------------------------------                
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try   //Control de errores   bien....
            {

                //-->VALIDACION DE CAMPOS. NOTA en el curso de C# ví que esto se puede hacer en las propiedades GET/SET
                //----------------------------------------------------------------------------------------------------
                string rpta = "";

                //Controles que deben de tener valores obligatoriamente -- Si está vacía y como es un campo obligatorio,  pues hay que meterlo

                //if (this.txtNombre.Text == string.Empty || this.txtIdCliente.Text == string.Empty || this.txtNumeroDocu.Text == string.Empty)
                if (this.txtNombreTraba.Text == string.Empty || this.txtcAcceso.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    //--> MENSAJES A MOSTRAR SI LOS CAMPOS OBLIGATORIOS ESTUVIERAN VACIOS  -  Este metodo lo tengo en este mismo módulo
                    MensajeError("Faltan por indicar  datos, serán remarcados");

                    errorIcono.SetError(txtNombreTraba, "Indique el Nombre");
                    errorIcono.SetError(txtcAcceso, "Indique el usuario de acceso");
                    errorIcono.SetError(txtPassword, "Indique Contraseña");


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

                        //Convert.ToDecimal(this.txtDescuento.Text),                                                  
                        //Convert.ToString(this.txtCodPostal.Text),
                        //this.dtFechaNac.Value,
                        //this.txtBuscar.Text.Trim().ToUpper());

                        rpta = NTrabajador.Insertar(this.txtNombreTraba.Text.Trim().ToUpper(),
                                                     this.txtApellidosTraba.Text.Trim().ToUpper(),
                                                     this.txtcAcceso.Text.Trim().ToUpper(),
                                                     //La password tal cual como este escrita sin convertir a mayúsculas 
                                                         //this.txtPassword.Text.Trim().ToUpper()
                                                     this.txtPassword.Text.Trim(),
                                                     this.txtUsuariol.Text.Trim().ToUpper()
                                                   //this.txtBuscar.Text.Trim().ToUpper()                        
                                                   );



                    }
                    else    //Es una modificacion  
                    {
                        //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores 



                        rpta = NTrabajador.Editar(Convert.ToInt32(this.txtIdTraba.Text),
                                                   this.txtNombreTraba.Text.Trim().ToUpper(),
                                                   this.txtApellidosTraba.Text.Trim().ToUpper(),
                                                   this.txtcAcceso.Text.Trim().ToUpper(),
                                                   //La password tal cual como este escrita sin convertir a mayúsculas 
                                                   //this.txtPassword.Text.Trim().ToUpper()
                                                   this.txtPassword.Text.Trim(),
                                                   this.txtUsuariol.Text.Trim().ToUpper()
                                                   );


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



        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }




        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (!this.txtIdTraba.Text.Equals(""))
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
            this.txtIdTraba.Text = string.Empty;

        }
        
        //-apaño
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("NOMBRE"))
            {
                this.BuscarNombreTrabajador();
            }
            else if (cbBuscar.Text.Equals("NOMBRE2"))
            {
                this.BuscarNombreTrabajador();
            }
        }


        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            //-->Hacer el Convert : Los valores que llegan del Grid sin tipo Object 
            //                      El  CurrentRow.Cells  captura lo que tiene la celda actual 

            
            this.txtIdTraba.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idTrabajador"].Value);
            this.txtNombreTraba.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cNombreTraba"].Value);
            this.txtApellidosTraba.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cApellidos"].Value);
            this.txtcAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cAcceso"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Password"].Value);
            this.txtUsuariol.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cUsuario"].Value);



            //-> Para pintar la solapa 1... veremos como va 
            this.tabControl1.SelectedIndex = 1;
            //->Recuperacion de imagenes en VIDEO 15  minuto 04:00 aprox)
        }

        
        

        
    }
}
