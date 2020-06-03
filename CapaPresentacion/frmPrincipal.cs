using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
     



namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;   //Esta variable la puso el sistema

        //->Vamos a declarar unas variables de tipo publico 
        //  para que recibar los valores  del formulario de acceso 

        public string IdTrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";




        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        //--->OPCION MENU :  SALIR 
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //--->OPCION MENU :  Familias 
        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //--> Creamos un objeto frm  instanciandolo del formulario de Familias
            FrmFamilias frm = new FrmFamilias();
            frm.MdiParent = this;     //->Indicado como formulario Padre 
            frm.Show();               //->Mostrarlo                
        }



        //--->OPCION MENU :  Articulos
        //                   En este ya teníamos una instancia por lo de la lupa
        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Lo que tengo en el FrmArticulos es un metodo para saber si ya tengo creada una instancia o no, por lo cual
            //aquí a diferencia de los otros lo que voy hacer es llamar a ese método a ver si tengo creada o la la instancia

            FrmArticulos frm = FrmArticulos.GetInstaArti();
            frm.MdiParent = this;     //->Indicado como formulario Padre 
            frm.Show();               //->Mostrarlo   
        }


        //--->OPCION MENU :  Proveedores 
        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor frm = new  FrmProveedor();
            frm.MdiParent = this;     //->Indicado como formulario Padre 
            frm.Show();
        }

        //--->OPCION MENU :  Clientes 
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;     //->Indicado como formulario Padre 
            frm.Show();
        }

        //--->OPCION MENU :  Trabajadores
        private void accesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajador frm = new FrmTrabajador();
            frm.MdiParent = this;     //->Indicado como formulario Padre 
            frm.Show();

        }

        //--->OPCION MENU :  Impuestos.
        private void impuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmImpuestos frm = new frmImpuestos();
            frm.MdiParent = this;     //->Indicado como formulario Padre 
            frm.Show();
        }


        //ESTO CON UN CASE  VA MAL LIMPIO 


        //--------->CONTROL DE LOS ACCESOS POR PERFILES 
        private void GestionUsuario()
        {
            if(Acceso == "ADMINISTRADOR")
            {
                this.MnuAlmacen.Enabled = true; 
                this.MnuCompras.Enabled = true;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;               
                this.MnuUsuarios.Enabled = true;
                this.MnuVentas.Enabled = true;
                //->los accesos rápidos
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = true;
            }
            else if ( Acceso == "VENDEDOR")
            { 

                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.MnuUsuarios.Enabled = true;
                this.MnuVentas.Enabled = true;
                //->los accesos rápidos
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = true;
            }
            else if (Acceso == "MOZO")
            {

                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.MnuUsuarios.Enabled = true;
                this.MnuVentas.Enabled = false;
                //->los accesos rápidos
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = false;
            }
            else  //es que no tiene acceso ninguno,  ESTO VA MEJOR CON UN CASE....
            {

                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuConsultas.Enabled = false;
                this.MnuHerramientas.Enabled = false;
                this.MnuUsuarios.Enabled = false;
                this.MnuVentas.Enabled = false;
                //->los accesos rápidos
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = false;
            }

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

            
            //--Llamamos al metodo de control de perfies 
            GestionUsuario();


        }



     
    }
}
