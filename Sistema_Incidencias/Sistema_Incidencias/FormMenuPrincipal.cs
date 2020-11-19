using Common.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Sistema_Incidencias
{
    public partial class FormMenuPrincipal : Form
    {
        SqlConnection Conexion = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        ArrayList Departamentos = new ArrayList();
        ArrayList CantidadElementos = new ArrayList();

        //Segundo chart
        ArrayList CantidadIncidencias = new ArrayList();
        ArrayList IncidenciasDepartamentos = new ArrayList();




        //Constructor
        public FormMenuPrincipal()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }
        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedorPrincipal.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
       
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //METODOS PARA CERRAR,MAXIMIZAR, MINIMIZAR FORMULARIO------------------------------------------------------
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           
        }

        //METODOS PARA ANIMACION DE MENU SLIDING--
      

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >= 230)
                this.tmExpandirMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width + 5;
            
        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width <= 55)
                this.tmContraerMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width - 5;
        }

        //METODO PARA ABRIR FORM DENTRO DE PANEL-----------------------------------------------------
        private void AbrirFormEnPanel(object formHijo)
        {
            if (this.panelContenedorForm.Controls.Count > 0)
                this.panelContenedorForm.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;            
            this.panelContenedorForm.Controls.Add(fh);
            this.panelContenedorForm.Tag = fh;
            fh.Show();
        }
        //METODO PARA MOSTRAR FORMULARIO DE LOGO Al INICIAR ----------------------------------------------------------
        private void MostrarFormLogo()
        {
            //AbrirFormEnPanel(new FormLogo());
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            MostrarFormLogo();
            LoadUserData();
            GrafCategorias();
            GrafCantidadIncidencias();

        }


        private void GrafCategorias()
        {
            cmd = new SqlCommand("ElementosTIPorDepartamento", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Departamentos.Add(dr.GetString(1));
                CantidadElementos.Add(dr.GetInt32(2));

            }
            chart1.Series[0].Points.DataBindXY(Departamentos, CantidadElementos);
            dr.Close();
            Conexion.Close();
        }

        private void GrafCantidadIncidencias()
        {
            cmd = new SqlCommand("CantidadIncidencias", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IncidenciasDepartamentos.Add(dr.GetString(1));
                CantidadIncidencias.Add(dr.GetInt32(2));
            }
            chart2.Series[0].Points.DataBindXY(IncidenciasDepartamentos, CantidadIncidencias);
            dr.Close();
            Conexion.Close();
        }


        private void LoadUserData()
        {
            label3.Text = UserLoginCache.Nombres;
            label4.Text = UserLoginCache.ApellidoPaterno;
            label5.Text = UserLoginCache.Cargo;
        }
        //METODO PARA MOSTRAR FORMULARIO DE LOGO Al CERRAR OTROS FORM ----------------------------------------------------------
        private void MostrarFormLogoAlCerrarForms(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
        }
        //METODOS PARA ABRIR OTROS FORMULARIOS Y MOSTRAR FORM DE LOGO Al CERRAR ----------------------------------------------------------
        private void BtnListaClientes_Click(object sender, EventArgs e)
        {
            //FormListaClientes fm = new FormListaClientes();
            //fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            //AbrirFormEnPanel(fm);
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            FormVerIncidencias incidencias = new FormVerIncidencias();
            incidencias.Show();
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormListadoUsuarios listadoUsuarios = new FormListadoUsuarios();
            listadoUsuarios.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormVerElementosTI verElementos = new FormVerElementosTI();
            verElementos.Show();
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            //-------CON EFECTO SLIDING
            if (panelMenu.Width == 230)
            {
                this.tmContraerMenu.Start();
            }
            else if (panelMenu.Width == 55)
            {
                this.tmExpandirMenu.Start();
            }

        }

        private void btnMiPerfil_Click(object sender, EventArgs e)
        {

        }

        private void PanelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panelContenedorForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaElementoTI alta = new AltaElementoTI();
            alta.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AltaPersonas alta = new AltaPersonas();
            alta.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AsignarCargo asignar = new AsignarCargo();
            asignar.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Personal per = new Personal();
            per.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Personal verPersonal = new Personal();
            verPersonal.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FormDepartamentos departamentos = new FormDepartamentos();
            departamentos.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //METODO PARA HORA Y FECHA ACTUAL ----------------------------------------------------------
        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Form1());
        }

        

    }
}
