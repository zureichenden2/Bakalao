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
    public partial class FormDepartamentos : Form
    {
        public FormDepartamentos()
        {
            InitializeComponent();
        }

        private void FormDepartamentos_Load(object sender, EventArgs e)
        {
            var select = "Select departamento.id as 'Código de Departamento', departamento.nombre as 'Nombre de Departamento', persona.id as 'Código de Personal', persona.nombre  +' '+  persona.apellidoPaterno as 'Nombre de Jefe de Departamento' " +
            "From persona Inner Join cargo_persona On cargo_persona.fk_persona = persona.id Inner Join departamento ON cargo_persona.fk_departamento = departamento.id order by departamento.id DESC";
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            DepartamentosSinJefe();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAltaDepartamento alta = new FormAltaDepartamento();
            alta.StartPosition = FormStartPosition.CenterScreen;
            alta.ShowDialog();
            alta.ShowInTaskbar = true;
            this.Hide();

        }

        public void DepartamentosSinJefe()
        {
            var select = "SELECT * FROM departamento t1 WHERE NOT EXISTS(select departamento.id as 'Código de Departamento', departamento.nombre as 'Nombre de Departamento', persona.id as 'Código de Personal', persona.nombre + ' ' + persona.apellidoPaterno as 'Nombre de Jefe de Departamento' From persona " +
            "Inner Join cargo_persona On cargo_persona.fk_persona = persona.id Inner Join departamento ON cargo_persona.fk_departamento = departamento.id where cargo_persona.fk_departamento = t1.id )";
           
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }


    }
}
