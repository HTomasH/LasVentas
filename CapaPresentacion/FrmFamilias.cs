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
                this.btnCancelar.Enabled = false;
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
            this.txtNombre.Focus();
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
                    else    //Es una modificacion 
                    {
                        //-->Vamos a llamar al Metodo Editar de la CapaNegocio enviandole los valores 
                        rpta = NFamilias.Editar(Convert.ToInt32(this.txtIdFamilias.Text), this.txtNombre.Text.Trim().ToUpper());
                            
                    }

                    //-->Ahora vamos a ver si la operación tuvo éxito o no, el "OK" que estamos poniendo aquí es el que está
                    //   indicado  en la CAPADATOS en los metodos 
                    //   Insertar y Editar de esta forma :  rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";  
                    //
                    //                                               
                    if (rpta.Equals("OK")) //  Por eso pongo OK sino pondría lo que tuviera puesto...
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
    }
}
