using Sistema_Incidencias.Properties;
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
    public partial class FormVerIncidencias : Form
    {
        public FormVerIncidencias()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormVerIncidencias_Load(object sender, EventArgs e)
        {
            var select = "Select * From incidencia";
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.EditarProducto.Width;
                var h = Properties.Resources.EditarProducto.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Resources.EditarProducto, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
         e.RowIndex >= 0)
            {
                senderGrid.Rows[e.RowIndex].ReadOnly = false;
                var btn = (DataGridViewButtonCell)senderGrid.CurrentCell;
                FormIncidenciaDetalle abrir = new FormIncidenciaDetalle();
                abrir.ShowDialog();
            }
        }


    }
}
