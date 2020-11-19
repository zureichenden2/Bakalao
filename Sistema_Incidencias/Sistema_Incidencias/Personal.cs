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
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();
        }

        private void tablaPersonalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsignarCargo asignar = new AsignarCargo();
            asignar.Show();
        }

        private void Agregarbtn_Click(object sender, EventArgs e)
        {
            AltaPersonas alta = new AltaPersonas();
            alta.Show();
        }

        private void LoadUserData()
        {
            label3.Text = UserLoginCache.Nombres;
            label4.Text = UserLoginCache.ApellidoPaterno;
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            LoadUserData();

            var select = "Select id as 'Código de Personal', nombre  +' '+ apellidoPaterno+  +' '+ apellidoMaterno as 'Nombre', numeroCelular as 'Número Telefónico', direccion as 'Dirección' From persona";
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            tablaPersonalDGV.DataSource = ds.Tables[0];

            tablaPersonalDGV.Columns[0].Visible = false;
            tablaPersonalDGV.Columns[1].Visible = false;
            tablaPersonalDGV.Columns[2].Visible = false;
            tablaPersonalDGV.Columns[3].Visible = false;
            tablaPersonalDGV.Columns[4].Visible = false;
            tablaPersonalDGV.Columns[5].Visible = false;
            tablaPersonalDGV.Columns[6].Visible = false;
            tablaPersonalDGV.Columns[7].Visible = false;


        }

        private void panelContenedorForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }



    }
}
