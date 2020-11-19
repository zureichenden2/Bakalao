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
    public partial class FormIncidenciasJefeTaller : Form
    {
        int incidenciaID = 0;

        public FormIncidenciasJefeTaller()
        {
            InitializeComponent();
        }

        private void FormIncidenciasJefeTaller_Load(object sender, EventArgs e)
        {
            dgvIncidencias.CellClick += dgvIncidencias_CellClick;
            llenarTabla();
        }

        private void dgvIncidencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            incidenciaID = Convert.ToInt32(dgvIncidencias.CurrentRow.Cells[0].Value.ToString());

            if (e.ColumnIndex == dgvIncidencias.Columns["aceptar"].Index)
            {
                incidenciaID = Convert.ToInt32(dgvIncidencias.CurrentRow.Cells[0].Value.ToString());

                var connetionString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
                var sql = "UPDATE incidencia SET estado = 2 where incidencia.id = @id";// repeat for all variables
               
                    using (var connection = new SqlConnection(connetionString))
                    {
                        using (var command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.Add("@id", incidenciaID);
                          
                            connection.Open();
                            int result = command.ExecuteNonQuery();

                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                        else
                        {
                            MessageBox.Show("Incidencia aceptada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                
            }
            else if (e.ColumnIndex == dgvIncidencias.Columns["rechazar"].Index)
            {
                incidenciaID = Convert.ToInt32(dgvIncidencias.CurrentRow.Cells[0].Value.ToString());

                var connetionString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
                var sql = "UPDATE incidencia SET estado = 3 where incidencia.id = @id";// repeat for all variables

                using (var connection = new SqlConnection(connetionString))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@id", incidenciaID);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                        else
                        {
                            MessageBox.Show("Incidencia rechazada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }

            else if (e.ColumnIndex == dgvIncidencias.Columns["detalles"].Index)
            {
                FormIncidenciaDetalle detalles = new FormIncidenciaDetalle();
                detalles.Show();
            }

        }

        public void llenarTabla()
        {
            var select = "select i.titulo, i.descripcion, i.prioridad, p.nombre  +' '+ p.apellidoPaterno as 'Jefe Departamento', ti.nombre as Tipo  from incidencia i" +
               " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id";


            if (UserLoginCache.Cargo == "Jefe de Taller de Hardware")
            {
                select = "select i.id, i.titulo, i.descripcion, i.prioridad, p.nombre  +' '+ p.apellidoPaterno as 'Jefe Departamento', ti.nombre as Tipo  from incidencia i" +
               " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id where ti.nombre = 'Hardware' and i.estado =1";
            }

            else if(UserLoginCache.Cargo == "Jefe de Taller de Software")
            {
                select = "select i.id, i.titulo, i.descripcion, i.prioridad, p.nombre  +' '+ p.apellidoPaterno as 'Jefe Departamento', ti.nombre as Tipo  from incidencia i" +
                " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id where ti.nombre = 'Software' and i.estado =1";
            }

            else if (UserLoginCache.Cargo == "Jefe de Taller de Redes")
            {
                select = "select i.id, i.titulo, i.descripcion, i.prioridad, p.nombre  +' '+ p.apellidoPaterno as 'Jefe Departamento', ti.nombre as Tipo  from incidencia i" +
                " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id where ti.nombre = 'Redes' and i.estado =1";
            }



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

            
            DataGridViewButtonColumn VerDetallesButtonColumn = new DataGridViewButtonColumn();
            VerDetallesButtonColumn.Name = "detalles";
            VerDetallesButtonColumn.Text = "Detalles";
            VerDetallesButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex2 = dgvIncidencias.ColumnCount;
            if (dgvIncidencias.Columns["detalles"] == null)
            {
                dgvIncidencias.Columns.Insert(columnIndex2, VerDetallesButtonColumn);
            }
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormMenuJefeTaller menu = new FormMenuJefeTaller();
            menu.Show();
            this.Close();
        }

        private void dgvIncidencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
