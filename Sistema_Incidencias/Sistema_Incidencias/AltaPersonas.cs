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
    public partial class AltaPersonas : Form
    {
        public AltaPersonas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tituloAltaPersonas_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panelContenedorForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AltaPersonas_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void guardarbtn_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        public void Insertar()
        {
            string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            string nombre = "";
            string apellidoPaterno = "";
            string apellidoMaterno = "";
            string usuario = "";
            string contraseña = "";
            string numeroCel = "";
            string direccion = "";

            nombre = nombreTxtb.Text;
            apellidoPaterno = paternoTxtb.Text;
            apellidoMaterno = maternoTxtb.Text;
            usuario = usuarioTxtb.Text;
            contraseña = contrasenaTxtb.Text;
            numeroCel = telefonoTxtb.Text;
            direccion = dirreccionTxtb.Text;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "INSERT INTO Persona (nombre,apellidoPaterno, apellidoMaterno,usuario,contraseña,numeroCelular,direccion) " +
                    "VALUES (@nombre,@apellidoPaterno,@apellidoMaterno, @usuario, @contraseña, @numeroCelular, @direccion)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                    command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@contraseña", contraseña);
                    command.Parameters.AddWithValue("@numeroCelular", numeroCel);
                    command.Parameters.AddWithValue("@direccion", direccion);


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show("Insertado!");

                }
            }
        }

        private void cerrarbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void LoadUserData()
        {
            label3.Text = UserLoginCache.Nombres;
            label4.Text = UserLoginCache.ApellidoPaterno;
        }

        private void PanelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
