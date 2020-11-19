using Common.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Incidencias
{
    public partial class FormMenuJefeTaller : Form
    {
        public FormMenuJefeTaller()
        {
            InitializeComponent();
        }

        private void FormMenuJefeTaller_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            label3.Text = UserLoginCache.Nombres;
            label4.Text = UserLoginCache.ApellidoPaterno;
            label5.Text = UserLoginCache.Cargo;
        }

        private void tmFechaHora_Tick(object sender, EventArgs e)
        {

        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {

        }

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

        }

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            FormTecnicosJefeTaller tecnicos = new FormTecnicosJefeTaller();
            tecnicos.Show();
        }

        private void btnIncidencia_Click(object sender, EventArgs e)
        {
            FormIncidenciasJefeTaller incidencias = new FormIncidenciasJefeTaller();
            incidencias.Show();
        }


    }
}
