using Common.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Incidencias
{
    public partial class FormTecnicosJefeTaller : Form
    {
        public FormTecnicosJefeTaller()
        {
            InitializeComponent();
        }

        private void FormTecnicosJefeTaller_Load(object sender, EventArgs e)
        {
            lblId.Text = UserLoginCache.departamento.ToString();
            llenarTabla();
        }


        public void llenarTabla()
        {
            var select = " select p.nombre + p.apellidoPaterno as 'Nombre completo', cp.cargo from persona p " +
                "join cargo_persona cp on p.id= cp.fk_persona where cp.cargo = 'Técnico'";

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvTecnicos.DataSource = ds.Tables[0];
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormMenuJefeTaller menu = new FormMenuJefeTaller();
            menu.Show();
            // this.Close();
            this.Hide();
        }


    }
}
