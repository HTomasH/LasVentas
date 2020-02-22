using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;               //Para comunicar con la capa de negocio




namespace CapaPresentacion
{
    public partial class frmVistaFamilia_Articulo : Form
    {
        public frmVistaFamilia_Articulo()
        {
            InitializeComponent();
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


       
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        
        private void frmVistaFamilia_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }


        //->Evento del doubleClic obtenido desde las propiedades del objeto haciendo dobleClic en la propiedad,
        //  este es el que tiene que devolver los valores que estuvieran seleccionados 
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //->Vamos a llamar nuestro metodo que obtiene la instancia 
            FrmArticulos form = FrmArticulos.GetInstaArti();
            
            // Un par de variables para contener los datos 
            string par1, par2;

            //Recordar que la información pillada de las tablas biene como tipo OBJETC por lo cual lo vamos a convertir a String
            par1 =  Convert.ToString(this.dataListado.CurrentRow.Cells["idCodFam"].Value);
            par2 =  Convert.ToString(this.dataListado.CurrentRow.Cells["cNombreFamilia"].Value);
            form.setFamilia(par1, par2);

            //Para cerrar el diagolo una vez hecha la seleccion 
            this.Hide(); 
        }


    }
}
