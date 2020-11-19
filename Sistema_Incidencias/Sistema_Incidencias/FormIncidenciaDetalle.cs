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
    public partial class FormIncidenciaDetalle : Form
    {
        public FormIncidenciaDetalle()
        {
            InitializeComponent();
        }

        private void FormIncidenciaDetalle_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }


        public void llenarTabla()
        {
            var select = "select i.titulo, i.descripcion, i.prioridad, p.nombre  +' '+ p.apellidoPaterno as 'Jefe Departamento', ti.nombre as Tipo  from incidencia i" +
               " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id";


            if (UserLoginCache.Cargo == "Jefe de Taller de Hardware" || UserLoginCache.Cargo == "Técnico en Hardware")
            {
                select = "select *  from incidencia i" +
               " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id where ti.nombre = 'Hardware'";
            }

            else if (UserLoginCache.Cargo == "Jefe de Taller de Software" || UserLoginCache.Cargo == "Técnico en Software")
            {
                select = "select *  from incidencia i" +
               " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id where ti.nombre = 'Software'";
            }

            else if (UserLoginCache.Cargo == "Jefe de Taller de Redes" || UserLoginCache.Cargo == "Técnico en Redes")
            {
                select = "select *  from incidencia i" +
                " join persona p on i.persona = p.id join tipos_incidencia ti on i.tipo = ti.id where ti.nombre = 'Redes'";
            }



            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvIncidencias.DataSource = ds.Tables[0];
        }


    }



}
