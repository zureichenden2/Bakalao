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
    public partial class FormMenuJefeDepto : Form
    {
        public FormMenuJefeDepto()
        {
            InitializeComponent();
        }

        private void FormMenuJefeDepto_Load(object sender, EventArgs e)
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
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            formVerElementosDepartamento elementos = new formVerElementosDepartamento();
            elementos.Show();
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            FormTimbrarIncidencias incidencias = new FormTimbrarIncidencias();
            incidencias.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormEvaluarIncidencias EvaluacionIncidencias = new FormEvaluarIncidencias();
            EvaluacionIncidencias.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
