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
    public partial class FormVerElementosTI : Form
    {
        public FormVerElementosTI()
        {
            InitializeComponent();
        }

        private void FormVerElementosTI_Load(object sender, EventArgs e)
        {
            var select = "Select elementoTI.id as 'Código', tipos_elementoTI.nombre as 'Tipo de Elemento', elementoTI.marca as 'Marca', elementoTI.modelo as 'Modelo', elementoTI.Descripcion as 'Descripción', elementoTI.garantia as 'Años de Garantía', elementoTI.fechaCompra as 'Fecha de Compra', departamento.nombre as 'Departamento Asignado', persona.nombre as 'Nombre de Encargado', persona.apellidoPaterno as 'Apellido' "+
           "From elementoTI Inner Join elementoTI_departamento On elementoTI_departamento.fk_elementoTI = elementoTI.id " +
           "Inner Join departamento On departamento.id = elementoTI_departamento.fk_departamento " +
           "Inner Join persona_elementoTI on persona_elementoTI.fk_elementoTI = elementoTI.id " +
          "Inner Join persona on persona.id = persona_elementoTI.fk_persona " +
           "Inner Join tipos_elementoTI on elementoTI.tipo = tipos_elementoTI.id Where tipos_elementoTI.id = elementoTI.tipo";
           
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaElementoTI alta = new AltaElementoTI();
            alta.ShowDialog();
        }

    }
}
