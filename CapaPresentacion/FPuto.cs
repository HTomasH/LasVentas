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
using CapaDatos;


namespace CapaPresentacion
{
    public partial class FPuto : Form
    {


        //->Variables para saber si estamos dando altas o no.  es como el que yo utilizaba de  lAltas 
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FPuto()
        {
            InitializeComponent();


            //->Este será el mensaje a mostrar el TOOLTIP al tener el foco en el campo (Caja de texto-TextBox  txtNombre)
            this.ttMensaje.SetToolTip(this.txtNombreEntidad, "Indique el Nombre de la Entidad");

            //->Este será el mensaje a mostrar el TOOLTIP al tener el foco en el campo (Caja de texto-TextBox  txtNombre)
            this.ttMensaje.SetToolTip(this.txtDeparEntidad, "Indique el Departamento de la Entidad");
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
            this.txtIdEntidad.Text = string.Empty;
            this.txtNombreEntidad.Text = string.Empty;
            this.txtDeparEntidad.Text = string.Empty;

        }

        // Habilitar o NO los controles del formulario        
        //-> Si  valor  llega con valor TRUE pues le indicamos el contrario con ! 
        //   esto es porque la propiedad es  ReadOnly                                 
        private void Habilitar(bool valor)
        {
            this.txtNombreEntidad.ReadOnly = !valor;
            this.txtDeparEntidad.ReadOnly = !valor;

            this.txtIdEntidad.ReadOnly = true;  //Es un valor Identity  lo 'capo del todo'
            this.txtIdEntidad.Enabled = false;

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
           // this.dataListado.Columns[1].Visible = false;   //Esta se corresponde con el ID de  la tablas

        }



        private void FPuto_Load(object sender, EventArgs e)
        {
            //->Estas coordenadas son para printar el formulario en la esquina superior izquierda
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);  //Cajas de texto  deshabilitadas de inicio 
            this.Botones();
        }

        //-->Método Mostrar
        //-------------------------------------------------------------------------------------------
        private void Mostrar()
        {

            /*
              Todas las llamadas que se hacen a Negocio y a datos son funciones de tipo DataTable 
              por lo cual eso para ese sistema ya no vale, no es un DataTable lo que retorna
            
                    this.dataListado.DataSource = NEntidad.Mostrar(dataListado);

             Este código no respeta las tres capas, ya que no veo la forma de tener este 
             código en la capa Datos para rellenar el Grid :             

             Se esta utilinado una Coleccion -  lista, esto lo vi en el curso del  Gallego..

             */

            //-->FINALMENTE LO HE CONSEGUIDO JODERRR, SIGO RESPETENADO LAS TRES CAPAS  


            this.dataListado.DataSource = NEntidad.Mostrar();  
            this.OcultarColumnas();  //KAKA


            //-->Pintamos el total de registros : OjO el count es  int  tenemos que convertirlo a String 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }



        //-->Método BuscarNombre
        //-----------------------------------------------------------------------------------------------
        private void BuscarNombre()
        {

            string cRecibe;
            int nRecibe;
                                    
            //Este es el del tipo Datatable
            //this.dataListado.DataSource = NEntidad.BuscarNombre(this.txtBuscar.Text);

            cRecibe = NEntidad.BuscarNombre(this.txtBuscar.Text);
            nRecibe = Convert.ToInt32(cRecibe);
            //-->Lo que no veo bien seria el rendimiento, si hay mucha información esto no es bueno.
            for (int i = 0; i < dataListado.Rows.Count; i++)
            {
                String key = dataListado.Rows[i].Cells["identifica"].Value.ToString();
                if (key.Contains(cRecibe) == true)
                {
                    //->Colocar el DataGrid en la posición que me llega  
                    dataListado.CurrentCell = dataListado.Rows[i].Cells[nRecibe];
                    dataListado.Refresh();
                 }                                                                                           
            }
            
            this.OcultarColumnas(); //KAKA
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }



        //-->botónde buscar 
        //-----------------------------------------------------------------------------------------------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        //->Búsqueda Incremental,  
        //  el método  TextChanged lo obtengo haciendo doble click en la caja de texto
        //->Evento   TextChanged, se llama al Metodo buscar nombre 
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }


        //-->Botón de NUEVO 
        //-----------------------------------------------------------------------------------------------
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            this.IsNuevo = true;    //Es un alta así que este valor a true   
            this.IsEditar = false;  //Este a False

            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombreEntidad.Focus();   //Foco a la caja de texto del nombre 
        }


        //-->Botón de GUARDAR
        //-----------------------------------------------------------------------------------------------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try   //Control de errores   bien....
            {


                //-->VALIDACION DE CAMPOS. NOTA en el curso de C# ví que esto se puede hacer en las propiedades GET/SET
                //----------------------------------------------------------------------------------------------------
                string rpta = "";
                if (this.txtNombreEntidad.Text == string.Empty)   //Si está vacía y como es un campo obligatorio,  pues hay que meterlo
                {
                    //-->Este metodo lo tengo en este mismo módulo
                    MensajeError("Faltan por indicar  datos, serán remarcados");
                    //--Vamos a indicar el mensaje a mostrar cuando salga el error.
                    errorIcono.SetError(txtNombreEntidad, "Indique un Nombre");
                }
                else  //El textBox llega con valor,  
                {
                    if (this.IsNuevo)  //Es un alta ??
                    {
                        //-->Vamos a llamar al Metodo Insertar de la CapaNegocio enviandole los valores para insertar en la bb.dd
                        rpta = NEntidad.Insertar(this.txtNombreEntidad.Text.Trim().ToUpper(), this.txtDeparEntidad.Text.Trim().ToUpper());  //Trim() quitar espacios - ToUpper  todo en mayúsculas 
                    }
                    else    //Es una modificacion   PARECE QUE ESTA MODIFICANDO TODOS !!!
                    {
                        //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores                         
                        rpta = NEntidad.Editar(Convert.ToInt32(this.txtIdEntidad.Text) , this.txtNombreEntidad.Text.Trim().ToUpper(), this.txtDeparEntidad.Text.Trim().ToUpper());
                        
                    }

                    //-->Ahora vamos a ver si la operación tuvo éxito o no, el "OK" que estamos poniendo aquí es el que está
                    //   indicado  en la CAPADATOS en los metodos 
                    //   Insertar y Editar de esta forma :  rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";  
                    //
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


        //--Aqui lo que estamos indicando es que cuando en el GRID se haga doble click se muestre ese registro
        //  en el formulario individual.
        //
        //  Para indicar esta funcionalidad   :   Nos situamos en el GRID,  CLICK para ver sus propiedades y buscamos 
        //                                        el evento(rayo)  DoubleClick   al clicar sobre el mismo nombre y
        //                                        selecionar ninguna de la opciones que aparecen en el desplegable 
        //                                        ya nos creara el "esqueleto" del procedimiento del  evento
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //-->Hacer el Convert  los valores que llegan del Grid llegan como Object 
            //   el   CurrentRow.Cells  captura lo que tiene la celda actual

            this.txtIdEntidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["identifica"].Value);
            this.txtNombreEntidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDeparEntidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["departamento"].Value);

            //-> Para que pinte la  Solapa/folder/TabPage  1   que imagino es la del detalle, la del grid debe ser la 0
            this.tabControl1.SelectedIndex = 1;
        }


        // BOTON DE EDITAR EL REGISTRO -------------------------------------------------------------------- 
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdEntidad.Text.Equals(""))
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


        // BOTON DE CANCELAR -------------------------------------------------------------------- 
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


        // CONTROL DEL CAMBIO DE VALOR EN EL CHECK DE LA COLUMNA DE BORRADO DE RESGISTROS -------------------------------------------- 
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

        //Para el tratamiento individual de cada registro dentro del GRID    haremos  DobleClick  sobre el GRID  y se 
        //nos creará el evento   dataListado_CellContentClick
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


        //----> BOTON DE ELIMINAR ----------------------------------------------------------------------
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                //Variable de tipo  DialogResult  entiendo que sirve para capturar datos de preguntas al usuario
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
                            Codigo = Convert.ToString(row.Cells[1].Value); //Trinca el valor de la columna 1 es decir el Identifica

                            //Envia el codigo al metodo ELIMINAR de la CapaNegocio de Entidad, OjO conviertiendo a Int  que es como 
                            //es el tipo de campo en la tabla Entidad 
                            Rpta =  NEntidad.Eliminar(Convert.ToInt32(Codigo));

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


        //-->Botón de IMPRIMIR 
        //-----------------------------------------------------------------------------------------------
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.MensajeOk("Ha pulsado el botón de imprimir ");
            //Reportes.FrmReporteCategoria frm = new Reportes.FrmReporteCategoria();
            //frm.Texto = txtBuscar.Text;
            //frm.ShowDialog();
        }


        




    }


}

