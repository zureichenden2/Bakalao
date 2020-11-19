
namespace Sistema_Incidencias
{
    partial class AltaPersonas
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
            this.tmFechaHora = new System.Windows.Forms.Timer(this.components);
            this.tmExpandirMenu = new System.Windows.Forms.Timer(this.components);
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.PanelBarraTitulo = new System.Windows.Forms.Panel();
            this.tmContraerMenu = new System.Windows.Forms.Timer(this.components);
            this.panelContenedorPrincipal = new System.Windows.Forms.Panel();
            this.panelContenedorForm = new System.Windows.Forms.Panel();
            this.guardarbtn = new System.Windows.Forms.Button();
            this.cerrarbtn = new System.Windows.Forms.Button();
            this.contrasenaTxtb = new System.Windows.Forms.TextBox();
            this.usuarioTxtb = new System.Windows.Forms.TextBox();
            this.dirreccionTxtb = new System.Windows.Forms.TextBox();
            this.telefonoTxtb = new System.Windows.Forms.TextBox();
            this.maternoTxtb = new System.Windows.Forms.TextBox();
            this.paternoTxtb = new System.Windows.Forms.TextBox();
            this.nombreTxtb = new System.Windows.Forms.TextBox();
            this.domicilio = new System.Windows.Forms.Label();
            this.numeroTelefonico = new System.Windows.Forms.Label();
            this.contrasena = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.Label();
            this.apellidoMaterno = new System.Windows.Forms.Label();
            this.apellidoPaterno = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.Label();
            this.tituloAltaPersonas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblHora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.PanelBarraTitulo.SuspendLayout();
            this.panelContenedorPrincipal.SuspendLayout();
            this.panelContenedorForm.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // tmFechaHora
            // 
            this.tmFechaHora.Enabled = true;
            this.tmFechaHora.Tick += new System.EventHandler(this.tmFechaHora_Tick);
            // 
            // tmExpandirMenu
            // 
            this.tmExpandirMenu.Interval = 15;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(9, 9);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(28, 28);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 5;
            this.pictureBox8.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "TECNM";
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.FlatAppearance.BorderSize = 0;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormal.Location = new System.Drawing.Point(856, 0);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(43, 43);
            this.btnNormal.TabIndex = 3;
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Visible = false;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Location = new System.Drawing.Point(810, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(43, 43);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.Location = new System.Drawing.Point(856, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(43, 43);
            this.btnMaximizar.TabIndex = 1;
            this.btnMaximizar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(903, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(39, 39);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // PanelBarraTitulo
            // 
            this.PanelBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.PanelBarraTitulo.Controls.Add(this.pictureBox8);
            this.PanelBarraTitulo.Controls.Add(this.label1);
            this.PanelBarraTitulo.Controls.Add(this.btnNormal);
            this.PanelBarraTitulo.Controls.Add(this.btnMinimizar);
            this.PanelBarraTitulo.Controls.Add(this.btnMaximizar);
            this.PanelBarraTitulo.Controls.Add(this.btnCerrar);
            this.PanelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.PanelBarraTitulo.Name = "PanelBarraTitulo";
            this.PanelBarraTitulo.Size = new System.Drawing.Size(960, 43);
            this.PanelBarraTitulo.TabIndex = 1;
            this.PanelBarraTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBarraTitulo_Paint);
            // 
            // tmContraerMenu
            // 
            this.tmContraerMenu.Interval = 15;
            // 
            // panelContenedorPrincipal
            // 
            this.panelContenedorPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.panelContenedorPrincipal.Controls.Add(this.panelContenedorForm);
            this.panelContenedorPrincipal.Controls.Add(this.panel1);
            this.panelContenedorPrincipal.Controls.Add(this.PanelBarraTitulo);
            this.panelContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedorPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelContenedorPrincipal.Name = "panelContenedorPrincipal";
            this.panelContenedorPrincipal.Size = new System.Drawing.Size(960, 560);
            this.panelContenedorPrincipal.TabIndex = 1;
            // 
            // panelContenedorForm
            // 
            this.panelContenedorForm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelContenedorForm.Controls.Add(this.guardarbtn);
            this.panelContenedorForm.Controls.Add(this.cerrarbtn);
            this.panelContenedorForm.Controls.Add(this.contrasenaTxtb);
            this.panelContenedorForm.Controls.Add(this.usuarioTxtb);
            this.panelContenedorForm.Controls.Add(this.dirreccionTxtb);
            this.panelContenedorForm.Controls.Add(this.telefonoTxtb);
            this.panelContenedorForm.Controls.Add(this.maternoTxtb);
            this.panelContenedorForm.Controls.Add(this.paternoTxtb);
            this.panelContenedorForm.Controls.Add(this.nombreTxtb);
            this.panelContenedorForm.Controls.Add(this.domicilio);
            this.panelContenedorForm.Controls.Add(this.numeroTelefonico);
            this.panelContenedorForm.Controls.Add(this.contrasena);
            this.panelContenedorForm.Controls.Add(this.usuario);
            this.panelContenedorForm.Controls.Add(this.apellidoMaterno);
            this.panelContenedorForm.Controls.Add(this.apellidoPaterno);
            this.panelContenedorForm.Controls.Add(this.nombre);
            this.panelContenedorForm.Controls.Add(this.tituloAltaPersonas);
            this.panelContenedorForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedorForm.Location = new System.Drawing.Point(0, 43);
            this.panelContenedorForm.Name = "panelContenedorForm";
            this.panelContenedorForm.Size = new System.Drawing.Size(960, 417);
            this.panelContenedorForm.TabIndex = 6;
            this.panelContenedorForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedorForm_Paint);
            // 
            // guardarbtn
            // 
            this.guardarbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.guardarbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.guardarbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guardarbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardarbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarbtn.ForeColor = System.Drawing.Color.Navy;
            this.guardarbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guardarbtn.Location = new System.Drawing.Point(224, 320);
            this.guardarbtn.Name = "guardarbtn";
            this.guardarbtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.guardarbtn.Size = new System.Drawing.Size(136, 31);
            this.guardarbtn.TabIndex = 17;
            this.guardarbtn.Text = "Guardar";
            this.guardarbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.guardarbtn.UseVisualStyleBackColor = true;
            this.guardarbtn.Click += new System.EventHandler(this.guardarbtn_Click);
            // 
            // cerrarbtn
            // 
            this.cerrarbtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.cerrarbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.cerrarbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cerrarbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cerrarbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarbtn.ForeColor = System.Drawing.Color.Navy;
            this.cerrarbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cerrarbtn.Location = new System.Drawing.Point(416, 320);
            this.cerrarbtn.Name = "cerrarbtn";
            this.cerrarbtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cerrarbtn.Size = new System.Drawing.Size(129, 31);
            this.cerrarbtn.TabIndex = 14;
            this.cerrarbtn.Text = "Cerrar";
            this.cerrarbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cerrarbtn.UseVisualStyleBackColor = true;
            this.cerrarbtn.Click += new System.EventHandler(this.cerrarbtn_Click);
            // 
            // contrasenaTxtb
            // 
            this.contrasenaTxtb.Location = new System.Drawing.Point(416, 154);
            this.contrasenaTxtb.Margin = new System.Windows.Forms.Padding(2);
            this.contrasenaTxtb.Name = "contrasenaTxtb";
            this.contrasenaTxtb.Size = new System.Drawing.Size(197, 20);
            this.contrasenaTxtb.TabIndex = 14;
            // 
            // usuarioTxtb
            // 
            this.usuarioTxtb.Location = new System.Drawing.Point(455, 116);
            this.usuarioTxtb.Margin = new System.Windows.Forms.Padding(2);
            this.usuarioTxtb.Name = "usuarioTxtb";
            this.usuarioTxtb.Size = new System.Drawing.Size(158, 20);
            this.usuarioTxtb.TabIndex = 13;
            // 
            // dirreccionTxtb
            // 
            this.dirreccionTxtb.Location = new System.Drawing.Point(90, 265);
            this.dirreccionTxtb.Margin = new System.Windows.Forms.Padding(2);
            this.dirreccionTxtb.Name = "dirreccionTxtb";
            this.dirreccionTxtb.Size = new System.Drawing.Size(193, 20);
            this.dirreccionTxtb.TabIndex = 12;
            // 
            // telefonoTxtb
            // 
            this.telefonoTxtb.Location = new System.Drawing.Point(137, 229);
            this.telefonoTxtb.Margin = new System.Windows.Forms.Padding(2);
            this.telefonoTxtb.Name = "telefonoTxtb";
            this.telefonoTxtb.Size = new System.Drawing.Size(146, 20);
            this.telefonoTxtb.TabIndex = 11;
            // 
            // maternoTxtb
            // 
            this.maternoTxtb.Location = new System.Drawing.Point(127, 195);
            this.maternoTxtb.Margin = new System.Windows.Forms.Padding(2);
            this.maternoTxtb.Name = "maternoTxtb";
            this.maternoTxtb.Size = new System.Drawing.Size(158, 20);
            this.maternoTxtb.TabIndex = 10;
            // 
            // paternoTxtb
            // 
            this.paternoTxtb.Location = new System.Drawing.Point(125, 158);
            this.paternoTxtb.Margin = new System.Windows.Forms.Padding(2);
            this.paternoTxtb.Name = "paternoTxtb";
            this.paternoTxtb.Size = new System.Drawing.Size(158, 20);
            this.paternoTxtb.TabIndex = 9;
            // 
            // nombreTxtb
            // 
            this.nombreTxtb.Location = new System.Drawing.Point(86, 120);
            this.nombreTxtb.Margin = new System.Windows.Forms.Padding(2);
            this.nombreTxtb.Name = "nombreTxtb";
            this.nombreTxtb.Size = new System.Drawing.Size(197, 20);
            this.nombreTxtb.TabIndex = 8;
            // 
            // domicilio
            // 
            this.domicilio.AutoSize = true;
            this.domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domicilio.Location = new System.Drawing.Point(34, 269);
            this.domicilio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.domicilio.Name = "domicilio";
            this.domicilio.Size = new System.Drawing.Size(53, 13);
            this.domicilio.TabIndex = 7;
            this.domicilio.Text = "direccion:";
            this.domicilio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.domicilio.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // numeroTelefonico
            // 
            this.numeroTelefonico.AutoSize = true;
            this.numeroTelefonico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroTelefonico.Location = new System.Drawing.Point(34, 232);
            this.numeroTelefonico.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numeroTelefonico.Name = "numeroTelefonico";
            this.numeroTelefonico.Size = new System.Drawing.Size(100, 13);
            this.numeroTelefonico.TabIndex = 6;
            this.numeroTelefonico.Text = "Numero Telefonico:";
            this.numeroTelefonico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contrasena
            // 
            this.contrasena.AutoSize = true;
            this.contrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrasena.Location = new System.Drawing.Point(350, 158);
            this.contrasena.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.contrasena.Name = "contrasena";
            this.contrasena.Size = new System.Drawing.Size(63, 13);
            this.contrasena.TabIndex = 5;
            this.contrasena.Text = "contraseña:";
            this.contrasena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario.Location = new System.Drawing.Point(350, 116);
            this.usuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(101, 13);
            this.usuario.TabIndex = 4;
            this.usuario.Text = "Nombre de Usuario:";
            this.usuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apellidoMaterno
            // 
            this.apellidoMaterno.AutoSize = true;
            this.apellidoMaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellidoMaterno.Location = new System.Drawing.Point(34, 199);
            this.apellidoMaterno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.apellidoMaterno.Name = "apellidoMaterno";
            this.apellidoMaterno.Size = new System.Drawing.Size(89, 13);
            this.apellidoMaterno.TabIndex = 3;
            this.apellidoMaterno.Text = "Apellido Materno:";
            this.apellidoMaterno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // apellidoPaterno
            // 
            this.apellidoPaterno.AutoSize = true;
            this.apellidoPaterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apellidoPaterno.Location = new System.Drawing.Point(34, 158);
            this.apellidoPaterno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.apellidoPaterno.Name = "apellidoPaterno";
            this.apellidoPaterno.Size = new System.Drawing.Size(87, 13);
            this.apellidoPaterno.TabIndex = 2;
            this.apellidoPaterno.Text = "Apellido Paterno:";
            this.apellidoPaterno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.Location = new System.Drawing.Point(34, 120);
            this.nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(47, 13);
            this.nombre.TabIndex = 1;
            this.nombre.Text = "Nombre:";
            this.nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nombre.Click += new System.EventHandler(this.label2_Click);
            // 
            // tituloAltaPersonas
            // 
            this.tituloAltaPersonas.AutoSize = true;
            this.tituloAltaPersonas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloAltaPersonas.Location = new System.Drawing.Point(295, 28);
            this.tituloAltaPersonas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tituloAltaPersonas.Name = "tituloAltaPersonas";
            this.tituloAltaPersonas.Size = new System.Drawing.Size(129, 20);
            this.tituloAltaPersonas.TabIndex = 0;
            this.tituloAltaPersonas.Text = "Alta de personas";
            this.tituloAltaPersonas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tituloAltaPersonas.Click += new System.EventHandler(this.tituloAltaPersonas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbFecha);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.lblHora);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 100);
            this.panel1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(83, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(83, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "León";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(83, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Melissa";
            // 
            // lbFecha
            // 
            this.lbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbFecha.ForeColor = System.Drawing.Color.White;
            this.lbFecha.Location = new System.Drawing.Point(699, 71);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(224, 20);
            this.lbFecha.TabIndex = 4;
            this.lbFecha.Text = "Lunes, 26 de septiembre 2018";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(12, 18);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(65, 65);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 3;
            this.pictureBox7.TabStop = false;
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.LightGray;
            this.lblHora.Location = new System.Drawing.Point(702, 11);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(205, 54);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "21:49:45";
            // 
            // AltaPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Controls.Add(this.panelContenedorPrincipal);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AltaPersonas";
            this.Text = "AltaPersonas";
            this.Load += new System.EventHandler(this.AltaPersonas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.PanelBarraTitulo.ResumeLayout(false);
            this.PanelBarraTitulo.PerformLayout();
            this.panelContenedorPrincipal.ResumeLayout(false);
            this.panelContenedorForm.ResumeLayout(false);
            this.panelContenedorForm.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmFechaHora;
        private System.Windows.Forms.Timer tmExpandirMenu;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel PanelBarraTitulo;
        private System.Windows.Forms.Timer tmContraerMenu;
        private System.Windows.Forms.Panel panelContenedorPrincipal;
        private System.Windows.Forms.Panel panelContenedorForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label tituloAltaPersonas;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.Label apellidoPaterno;
        private System.Windows.Forms.Label domicilio;
        private System.Windows.Forms.Label numeroTelefonico;
        private System.Windows.Forms.Label contrasena;
        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Label apellidoMaterno;
        private System.Windows.Forms.TextBox contrasenaTxtb;
        private System.Windows.Forms.TextBox usuarioTxtb;
        private System.Windows.Forms.TextBox dirreccionTxtb;
        private System.Windows.Forms.TextBox telefonoTxtb;
        private System.Windows.Forms.TextBox maternoTxtb;
        private System.Windows.Forms.TextBox paternoTxtb;
        private System.Windows.Forms.TextBox nombreTxtb;
        private System.Windows.Forms.Button guardarbtn;
        private System.Windows.Forms.Button cerrarbtn;
    }
}