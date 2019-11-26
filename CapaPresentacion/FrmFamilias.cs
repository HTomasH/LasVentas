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
    //partial class --> Es dividir una clase en varios ficheros. El compilador los juntará todos al compliar 
    public partial class FrmFamilias : Form
    {

        //->Variables para saber si estamos dando altas o no.  es como el que yo utilizaba de  lAltas 
        private bool IsNuevo = false;
        private bool IsEditar = false;


        //Constructor 
        public FrmFamilias()
        {
            InitializeComponent(); //Este inicializa los componentes del formulario
            //->Este será el mensaje a mostrar el TOOLTIP al tener el foco en el campo (Caja de texto-TextBox  txtNombre)
            this.ttMensaje.SetToolTip(this.txtNombre, "Indique el Nombre de la Familia");
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
            this.txtIdFamilias.Text = string.Empty;
            this.txtNombre.Text = string.Empty;            
            //this.txtIdFamilias.Text = string.Empty;
        }


        // Habilitar o NO los controles del formulario        
        //-> Si  valor  llega con valor TRUE pues le indicamos el contrario con ! 
        //   esto es porque la propiedad es  ReadOnly                                 
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            
            //this.txtIdFamilias.ReadOnly = !valor;
            this.txtIdFamilias.ReadOnly = true;  //Es un valor Identity  lo 'capo del todo'
            this.txtIdFamilias.Enabled = false;

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


        
        //-->Método Mostrar
        //-------------------------------------------------------------------------------------------
        private void Mostrar()
        {
            
            //ESCALADO : Para pintar la información en el Grid (dataListado.DataSource)  
            //
            //Vamos a llamar  a la clase  NFamilias a su metodo Mostrar  (CAPA NEGOCIO)
            //
            //El metodo mostar lo que hace es  llamar al metodo Mostrar de la clase   DFamilias()     (CAPA DATOS)
            //
            //EL Metodo Mostrar de la capa datos  lo que hace es llamar al procedimiento almacenado que creamos 
            // el  "spMostrar_familila";  que es el que finalmente  captura la información en la base de datos 
            
            //ESCALADO :
            //CAPA PRESENTACION  llama a   CAPA NEGOCIO   que llama   a CAPA DATOS    que conecta con  BB.DD
            this.dataListado.DataSource = NFamilias.Mostrar();


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
            this.dataListado.DataSource = NFamilias.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }




        //-->Este es el EVENTO LOAD del formulario se obtiene haciendo doble click en cualquier parte del formulario donde no haya nada 
        //   obviamente aquí se efectuaran las acciones al iniciar el formulario 
        private void FrmFamilias_Load(object sender, EventArgs e)
        {

            //->Estas coordenadas son para printar el formulario en la esquina superior izquierda
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);  //Cajas de texto  deshabilitadas de inicio 
            this.Botones();



        }
        //-->Evento   Click  del botón buscar que llama al  Metodo  BuscarNombre 
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            this.IsNuevo = true;    //Es un alta así que este valor a true   
            this.IsEditar = false;  //Este a False

            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();   //Foco a la caja de texto del nombre 

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try   //Control de errores   bien....
            {


                //-->VALIDACION DE CAMPOS. NOTA en el curso de C# ví que esto se puede hacer en las propiedades GET/SET
                //----------------------------------------------------------------------------------------------------
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)   //Si está vacía y como es un campo obligatorio,  pues hay que meterlo
                {
                    //-->Este metodo lo tengo en este mismo módulo
                    MensajeError("Faltan por indicar  datos, serán remarcados");
                    //--Vamos a indicar el mensaje a mostrar cuando salga el error.
                    errorIcono.SetError(txtNombre, "Indique un Nombre");
                }
                else  //El textBox llega con valor,  
                {
                    if (this.IsNuevo)  //Es un alta ??
                    {
                        //-->Vamos a llamar al Metodo Insertar de la CapaNegocio enviandole los valores para insertar en la bb.dd
                        rpta = NFamilias.Insertar(this.txtNombre.Text.Trim().ToUpper()  );  //Trim() quitar espacios - ToUpper  todo en mayúsculas 

                    }
                    else    //Es una modificacion   PARECE QUE ESTA MODIFICANDO TODOS !!!
                    {
                        //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores 
                        rpta = NFamilias.Editar(Convert.ToInt32(this.txtIdFamilias.Text), this.txtNombre.Text.Trim().ToUpper());
                            
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

            this.txtIdFamilias.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCodFam"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cNombreFamilia"].Value);
            
            //-> Para que pinte la  Solapa/folder/TabPage  1   que imagino es la del detalle, la del grid debe ser la 0
            this.tabControl1.SelectedIndex = 1;
        }

        //-->EVENTO   CLICK   DEL BOTON EDITAR 
        private void btnEditar_Click(object sender, EventArgs e)
        {

            if ( ! this.txtIdFamilias.Text.Equals(""))
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


        //Este es el EVENTO de cambio de valor en el CHECK de activar la columna de checks de eliminación 
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




        //--> BORRADO de registros 
        // 
        //     MUCHO OJO AL HACER COPY-PASTE DEL OTRO PROGRAMA,  SI NO SE EJECUTA EL EVENTO A LA HORA DE ESTARLO PROGRAMANDO
        //     NO LO REGISTRA EN EL FICHERO  FrmFamilias.Designer.cs  Y POR LO TANTO AUNQUE LO TENGA COPIADO NO VA A FUNCIONAR
        //     SALVO QUE A MANOPLA MODIFIQUE EL CODIGO   para ese ejemplo lo he dejado con  el  1     btnEliminar_Click_1       
        private void btnEliminar_Click_1(object sender, EventArgs e)
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

                    //->Bucle para recorrerse todo el GRID y ver que esta marcado para borrarlo.....este sistema no vale para muchos registros
                    //  si cada vez que va a borrar se tiene que recorrer todo el GRID menuda mierder
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))  //Pregunta por el valor de la columna cero del GRID 
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value); //Trinca el valor de la columna 1 es decir el IdFamilia

                            //Envia el codigo al metodo ELIMINAR dela CapaNegocio de de Familias, OjO conviertiendo a Int  que es como 
                            //es el tipo de campo en la tabla Familias 
                            Rpta = NFamilias.Eliminar(Convert.ToInt32(Codigo));

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


        //BOTON DE IMPRESION 
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            this.MensajeOk("Ha pulsado el botón de imprimir ");
            //Reportes.FrmReporteCategoria frm = new Reportes.FrmReporteCategoria();
            //frm.Texto = txtBuscar.Text;
            //frm.ShowDialog();
        }




    }
}
