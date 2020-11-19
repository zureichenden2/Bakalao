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
    public partial class AltaElementoTI : Form
    {

        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
        public AltaElementoTI()
        {
            InitializeComponent();
        }

        private void AltaElementoTI_Load(object sender, EventArgs e)
        {
            LoadUserData();
            DataTable dt = CategoryAll();
            CmbTipoElemento.DataSource = dt;
            CmbTipoElemento.ValueMember = "id";
            CmbTipoElemento.DisplayMember = "nombre";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelContenedorForm_Paint(object sender, PaintEventArgs e)
        {

        }

        public DataTable CategoryAll()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT id, nombre From tipos_ElementoTI";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void PanelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadUserData()
        {
            label10.Text = UserLoginCache.Nombres;
            label9.Text = UserLoginCache.ApellidoPaterno;
        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {
           
        }

        private void tmFechaHora_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void btnAgregarElementoTI_Click(object sender, EventArgs e)
        {
           
            String modelo = "";
            String marca = "";
            String descripcion = "";

            int tipoElemento =Convert.ToInt32(CmbTipoElemento.SelectedValue.ToString());
            modelo = txtModelo.Text;
            marca= txtmarca.Text;
            descripcion = txtDescripcion.Text;
            DateTime fechaCompra = PickerFechaCompra.Value.Date;
            int  garantia =Convert.ToInt32(NumGarantia.Value);

            if(modelo ==""|marca== "" | descripcion==""){
                MessageBox.Show(("Error de datos, campos vacios"), "No se adminten campos vacíos en el alta de elementos de TI",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            else
            {
                string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";



                using (SqlConnection connection = new SqlConnection(connString))
                {
                    String query = "INSERT INTO elementoTI(tipo,marca,modelo,Descripcion,garantia,fechaCompra) " +
                        "VALUES (@tipo,@marca,@modelo,@Descripcion,@garantia,@fechaCompra)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tipo", tipoElemento);
                        command.Parameters.AddWithValue("@modelo", modelo);
                        command.Parameters.AddWithValue("@marca", marca);
                        command.Parameters.AddWithValue("@Descripcion", descripcion);
                        command.Parameters.AddWithValue("@fechaCompra", fechaCompra);
                        command.Parameters.AddWithValue("@garantia", garantia);
                        

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                        else
                            MessageBox.Show(("Alta de elemento correcta"), "Alta de elemento de TI Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }


                
            }

        }
    }
}
