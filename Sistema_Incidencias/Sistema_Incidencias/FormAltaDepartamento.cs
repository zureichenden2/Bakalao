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
using Common.Cache;

namespace Sistema_Incidencias
{
    public partial class FormAltaDepartamento : Form
    {
        public FormAltaDepartamento()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormDepartamentos departamentos = new FormDepartamentos();
            departamentos.Show();
            this.Close();
        }

        private void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {
            string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            string nombre = "";
        
            nombre = textBox1.Text;
         

            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "INSERT INTO Departamento (nombre) " +
                    "VALUES (@nombre)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show("Departamento Insertado!");

                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDepartamentos departamentos = new FormDepartamentos();
            departamentos.Show();
            this.Close();
        }

      
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            string nombre = "";

            nombre = textBox1.Text;


            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "INSERT INTO Departamento (nombre) " +
                    "VALUES (@nombre)";
                if (nombre == "")
                {
                    MessageBox.Show("Favor de insertar nombre del departamento.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (BuscarNombre(nombre))
                    {
                        MessageBox.Show("Departamento ya registrado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@nombre", nombre);

                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                            else
                                MessageBox.Show("¡Departamento Insertado!","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limpiar();

                        }
                    }
                }
            
            }
        }

        public bool BuscarNombre(string nombre)
        {
            bool nombreEncontrado = false;
           string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Imposible conectar con los datos");

                foreach (SqlError err in ex.Errors)
                {
                    MessageBox.Show(err.Message);
                }
                return true;

            }
            SqlDataReader lector = null;

            string strComando = "  select nombre from departamento where nombre ='" + nombre + "'";

            SqlCommand cmd = new SqlCommand(strComando, conn);

            lector = cmd.ExecuteReader();

            if (lector.HasRows)
            {
                nombreEncontrado = true;
            }

            conn.Close();
            return nombreEncontrado;
        }
        public void limpiar()
        {

            textBox1.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}