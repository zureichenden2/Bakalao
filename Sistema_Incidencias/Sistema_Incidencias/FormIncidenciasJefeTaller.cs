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
    public partial class FormIncidenciasJefeTaller : Form
    {
        public FormIncidenciasJefeTaller()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormMenuJefeTaller menu = new FormMenuJefeTaller();
            menu.Show();
            this.Close();
        }

        private void FormIncidenciasJefeTaller_Load(object sender, EventArgs e)
        {
            dgvIncidencias.CellClick += dgvIncidencias_CellClick;
            llenarTabla();
        }

        private void dgvIncidencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvIncidencias.Columns["aceptar"].Index)
            {
                MessageBox.Show("Incidencia aceptada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (e.ColumnIndex == dgvIncidencias.Columns["rechazar"].Index)
            {
                MessageBox.Show("Incidencia rechazada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dgvIncidencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void llenarTabla()
        {

            var select = "select i.titulo, i.descripcion, i.prioridad, p.nombre  +' '+ p.apellidoPaterno as 'Jefe Departamento', ti.nombre as Tipo  from incidencia i" +
                " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id";

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvIncidencias.DataSource = ds.Tables[0];


            DataGridViewButtonColumn aceptarButtonColumn = new DataGridViewButtonColumn();
            aceptarButtonColumn.Name = "aceptar";
            aceptarButtonColumn.Text = "Aceptar";
            aceptarButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex = dgvIncidencias.ColumnCount;
            if (dgvIncidencias.Columns["aceptar"] == null)
            {
                dgvIncidencias.Columns.Insert(columnIndex, aceptarButtonColumn);
            }

            DataGridViewButtonColumn rechazarButtonColumn = new DataGridViewButtonColumn();
            rechazarButtonColumn.Name = "rechazar";
            rechazarButtonColumn.Text = "Rechazar";
            rechazarButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex1 = dgvIncidencias.ColumnCount;
            if (dgvIncidencias.Columns["rechazar"] == null)
            {
                dgvIncidencias.Columns.Insert(columnIndex1, rechazarButtonColumn);
            }
        }




    }
}
