using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;
using Common.Cache;

namespace Sistema_Incidencias
{

    public partial class FormTimbrarIncidencias : Form
    {
        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
        string Variabletitulo = "";
        string Variabledescripcion = "";
        int VariableTipoIncidencia = 0;
        int VariablePersona = 0;
        string VariablePrioridad = "";
        DateTime VariableFechaLevantamiento = DateTime.Now;
        int VariableEstado = 0;
        string VariableCalificacion = "0";
        int VariableTipoElementoTI = 0;

        int DatagriedtipoElemento = 0;
        int DatagriedVariableidElemento = 0;
        string DatagriedVariableNombreTipoElemento = "";
        int departamento = UserLoginCache.departamento;
        int idIncidencia = 0;



        public FormTimbrarIncidencias()
        {
            InitializeComponent();
        }

        private void FormTimbrarIncidencias_Load(object sender, EventArgs e)
        {
            DataTable dt = ObtenerTipoIncidencia();
            comboBox3.DataSource = dt;
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "nombre";

            var select = "Select elementoTI.id, tipos_elementoTI.nombre, elementoTI.marca, elementoTI.modelo, elementoTI.Descripcion From elementoTI " + 
                        "Inner Join elementoTI_departamento On elementoTI_departamento.fk_elementoTI = elementoTI.id " +
                        "Inner Join departamento On departamento.id = elementoTI_departamento.fk_departamento " +
                        "Inner Join persona_elementoTI on persona_elementoTI.fk_elementoTI = elementoTI.id " +
                        "Inner Join tipos_elementoTI on tipos_elementoTI.id = elementoTI.tipo " +
                        "Inner Join persona on persona.id = persona_elementoTI.fk_persona where persona.id = " + UserLoginCache.id;

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;

        }

    
        private void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {
            Variabletitulo = textBox2.Text;
            Variabledescripcion = textBox1.Text;
            VariableTipoIncidencia = Convert.ToInt32(comboBox3.SelectedValue.ToString());
            VariablePersona = UserLoginCache.id;
            VariablePrioridad = "Alta";
            VariableFechaLevantamiento = DateTime.Now;
            VariableEstado = 1; //Abierta
            VariableCalificacion = "0";

            //Para el insert into incidencia_Detalle
            VariableTipoElementoTI = Convert.ToInt32(textBox5.Text);
            DatagriedVariableidElemento = Convert.ToInt32(textBox4.Text);
         

          




            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "INSERT INTO incidencia(titulo,descripcion,tipo,persona,prioridad,fechaLevantamiento,estado,calificacion) " +
                    "VALUES (@titulo,@descripcion,@tipo,@persona,@prioridad,@fechaLevantamiento,@estado,@calificacion )";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@titulo", Variabletitulo);
                    command.Parameters.AddWithValue("@descripcion", Variabledescripcion);
                    command.Parameters.AddWithValue("@tipo", VariableTipoIncidencia);
                    command.Parameters.AddWithValue("@persona", VariablePersona);
                    command.Parameters.AddWithValue("@prioridad", VariablePrioridad);
                    command.Parameters.AddWithValue("@fechaLevantamiento", VariableFechaLevantamiento);
                    command.Parameters.AddWithValue("@estado", VariableEstado);
                    command.Parameters.AddWithValue("@calificacion", VariableCalificacion);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show(("Incidencia timbrada"), "Incidencia abierta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                string comando = "select max(id) as id from incidencia";
                SqlCommand cmd = new SqlCommand(comando, connection);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idIncidencia = Convert.ToInt32(dr.GetInt32(0));
                }

                dr.Close();

                query = "Insert into incidencia_detalle (fk_incidencia,elementoTI,tipo_elementoTI,departamento,tecnico,fechaInicio,fechaTerminacion,tiempoAtender, tiempo_estimado_Solucion, tiempoSolucionReal) " +
                    "VALUES (@fk_incidencia,@elementoTI,@tipo_elementoTI,@departamento,@tecnico,@fechaInicio,@fechaTerminacion,@tiempoAtender, @tiempo_estimado_Solucion, @tiempoSolucionReal)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fk_incidencia", idIncidencia);
                    command.Parameters.AddWithValue("@elementoTI", DatagriedVariableidElemento);
                    command.Parameters.AddWithValue("@tipo_elementoTI", VariableTipoElementoTI);
                    command.Parameters.AddWithValue("@departamento", departamento);
                    command.Parameters.AddWithValue("@tecnico", DBNull.Value);
                    command.Parameters.AddWithValue("@fechaInicio", DBNull.Value);
                    command.Parameters.AddWithValue("@fechaTerminacion", DBNull.Value);
                    command.Parameters.AddWithValue("@tiempoAtender", DBNull.Value);
                    command.Parameters.AddWithValue("@tiempo_estimado_Solucion", DBNull.Value);
                    command.Parameters.AddWithValue("tiempoSolucionReal", DBNull.Value);

                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show(("Detalle incidencia agregada"), "Detalles añadidos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            DatagriedVariableidElemento = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DatagriedVariableNombreTipoElemento = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            

            DatagriedtipoElemento = 0;
            if (DatagriedVariableNombreTipoElemento.Contains("Computadora"))
            {
                DatagriedtipoElemento = 1;
                textBox5.Text = DatagriedtipoElemento.ToString();
            }
            else if (DatagriedVariableNombreTipoElemento.Contains("Servidor"))
            {
                DatagriedtipoElemento = 2;
                textBox5.Text = DatagriedtipoElemento.ToString();

            }

            else if (DatagriedVariableNombreTipoElemento.Contains("Laptop"))
            {
                DatagriedtipoElemento = 3;
                textBox5.Text = DatagriedtipoElemento.ToString();

            }

            else if (DatagriedVariableNombreTipoElemento.Contains("Proyector"))
            {
                DatagriedtipoElemento = 4;
                textBox5.Text = DatagriedtipoElemento.ToString();

            }

            else if (DatagriedVariableNombreTipoElemento.Contains("Mouse"))
            {
                DatagriedtipoElemento = 5;
                textBox5.Text = DatagriedtipoElemento.ToString();

            }

            else if (DatagriedVariableNombreTipoElemento.Contains("Teclado"))
            {
                DatagriedtipoElemento = 6;
                textBox5.Text = DatagriedtipoElemento.ToString();

            }

            else if (DatagriedVariableNombreTipoElemento.Contains("Access"))
            {
                DatagriedtipoElemento = 7;
                textBox5.Text = DatagriedtipoElemento.ToString();

            }

        }

        public DataTable ObtenerTipoIncidencia()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "select * from tipos_incidencia";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }




    }
}
