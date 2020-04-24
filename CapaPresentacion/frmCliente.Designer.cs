namespace CapaPresentacion
{
    partial class frmCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbBuscar = new System.Windows.Forms.ComboBox();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDirCli = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtCuenta = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtPoblacion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTipo_Documento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroDocu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.cbCodPostal = new System.Windows.Forms.ComboBox();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(228, 29);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(540, 73);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(73, 86);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(753, 364);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbBuscar);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkEliminar);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.txtBuscar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(745, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbBuscar
            // 
            this.cbBuscar.FormattingEnabled = true;
            this.cbBuscar.Items.AddRange(new object[] {
            "DOCUMENTO",
            "RAZON SOCIAL"});
            this.cbBuscar.Location = new System.Drawing.Point(24, 36);
            this.cbBuscar.Name = "cbBuscar";
            this.cbBuscar.Size = new System.Drawing.Size(121, 21);
            this.cbBuscar.TabIndex = 8;
            this.cbBuscar.Text = "DOCUMENTO";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            this.dataListado.Location = new System.Drawing.Point(24, 129);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(667, 187);
            this.dataListado.TabIndex = 7;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListado_CellContentClick_1);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(529, 91);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 6;
            // 
            // chkEliminar
            // 
            this.chkEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Location = new System.Drawing.Point(24, 91);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(62, 17);
            this.chkEliminar.TabIndex = 5;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            this.chkEliminar.CheckedChanged += new System.EventHandler(this.chkEliminar_CheckedChanged_1);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(616, 36);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(512, 35);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(407, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(151, 35);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(745, 338);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodPostal);
            this.groupBox1.Controls.Add(this.cbCodPostal);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtDirCli);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtFechaNac);
            this.groupBox1.Controls.Add(this.txtCuenta);
            this.groupBox1.Controls.Add(this.txtDescuento);
            this.groupBox1.Controls.Add(this.txtPerson);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtPoblacion);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbTipo_Documento);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNumeroDocu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clientes";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(333, 149);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(116, 20);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(289, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Correo";
            // 
            // txtDirCli
            // 
            this.txtDirCli.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtDirCli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDirCli.Location = new System.Drawing.Point(316, 91);
            this.txtDirCli.Name = "txtDirCli";
            this.txtDirCli.Size = new System.Drawing.Size(138, 20);
            this.txtDirCli.TabIndex = 3;
            this.txtDirCli.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDirCli_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(258, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Dirección";
            // 
            // dtFechaNac
            // 
            this.dtFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaNac.Location = new System.Drawing.Point(527, 119);
            this.dtFechaNac.Name = "dtFechaNac";
            this.dtFechaNac.Size = new System.Drawing.Size(99, 20);
            this.dtFechaNac.TabIndex = 6;
            this.dtFechaNac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFechaNac_KeyPress);
            // 
            // txtCuenta
            // 
            this.txtCuenta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuenta.Location = new System.Drawing.Point(148, 249);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(100, 20);
            this.txtCuenta.TabIndex = 12;
            this.txtCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuenta_KeyPress);
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Location = new System.Drawing.Point(148, 217);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(100, 20);
            this.txtDescuento.TabIndex = 11;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            this.txtDescuento.Validated += new System.EventHandler(this.txtDescuento_Validated);
            // 
            // txtPerson
            // 
            this.txtPerson.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPerson.Location = new System.Drawing.Point(148, 147);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(100, 20);
            this.txtPerson.TabIndex = 7;
            this.txtPerson.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerson_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Location = new System.Drawing.Point(148, 121);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 5;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtPoblacion
            // 
            this.txtPoblacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtPoblacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPoblacion.Location = new System.Drawing.Point(148, 89);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.Size = new System.Drawing.Size(100, 20);
            this.txtPoblacion.TabIndex = 2;
            this.txtPoblacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPoblacion_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Cta. Contable";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(79, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "% Dcto.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Persona Contacto";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Fecha Nacimiento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Teléfono";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cod.Postal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Población";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(461, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Es un Combo con valores Fijos y como valor por defecto DNI que se indica en la pr" +
    "opidad TEXT";
            // 
            // cbTipo_Documento
            // 
            this.cbTipo_Documento.FormattingEnabled = true;
            this.cbTipo_Documento.Items.AddRange(new object[] {
            "DNI",
            "NIE",
            "PASAPORTE"});
            this.cbTipo_Documento.Location = new System.Drawing.Point(148, 188);
            this.cbTipo_Documento.Name = "cbTipo_Documento";
            this.cbTipo_Documento.Size = new System.Drawing.Size(121, 21);
            this.cbTipo_Documento.TabIndex = 9;
            this.cbTipo_Documento.Text = "DNI";
            this.cbTipo_Documento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTipo_Documento_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Número Documento";
            // 
            // txtNumeroDocu
            // 
            this.txtNumeroDocu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNumeroDocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroDocu.Location = new System.Drawing.Point(401, 192);
            this.txtNumeroDocu.Name = "txtNumeroDocu";
            this.txtNumeroDocu.Size = new System.Drawing.Size(116, 20);
            this.txtNumeroDocu.TabIndex = 10;
            this.txtNumeroDocu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocu_KeyPress);
            this.txtNumeroDocu.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroDocu_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo documento";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(557, 278);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(464, 278);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 15;
            this.btnEditar.Text = "E&ditar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(370, 278);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(275, 278);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click_1);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(148, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(219, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtIdCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCliente.Location = new System.Drawing.Point(148, 30);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(100, 20);
            this.txtIdCliente.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codigo Cliente";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(73, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Clientes";
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // cbCodPostal
            // 
            this.cbCodPostal.FormattingEnabled = true;
            this.cbCodPostal.Location = new System.Drawing.Point(441, 54);
            this.cbCodPostal.Name = "cbCodPostal";
            this.cbCodPostal.Size = new System.Drawing.Size(217, 21);
            this.cbCodPostal.TabIndex = 30;
            this.cbCodPostal.SelectedIndexChanged += new System.EventHandler(this.cbCodPostal_SelectedIndexChanged);
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.txtCodPostal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtCodPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodPostal.CausesValidation = false;
            this.txtCodPostal.Enabled = false;
            this.txtCodPostal.Location = new System.Drawing.Point(604, 28);
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.ReadOnly = true;
            this.txtCodPostal.Size = new System.Drawing.Size(54, 20);
            this.txtCodPostal.TabIndex = 31;
            this.txtCodPostal.Visible = false;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(862, 462);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "frmCliente";
            this.Text = ".:.  Mantenimiento de Clientes  .:.";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbBuscar;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtFechaNac;
        private System.Windows.Forms.TextBox txtCuenta;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtPerson;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtPoblacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTipo_Documento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroDocu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.TextBox txtDirCli;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbCodPostal;
        private System.Windows.Forms.TextBox txtCodPostal;
    }
}