using Common.Cache;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Incidencias
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            var validLogin = user.LoginUser(textBox1.Text, textBox2.Text);
            if (validLogin == true)
            {
                FormMenuPrincipal mainMenu = new FormMenuPrincipal();
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error de datos");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            var validLogin = user.LoginUser(textBox1.Text, textBox2.Text);
            if (validLogin == true)
            {
                if (UserLoginCache.Cargo.Contains("Jefe de Taller"))
                {
                    FormMenuJefeTaller mainMenuTaller = new FormMenuJefeTaller();
                    mainMenuTaller.Show();

                }

                else if (UserLoginCache.Cargo.Contains("Técnico"))
                {
                    FormMenuTecnico mainMenuTecnico = new FormMenuTecnico();
                    mainMenuTecnico.Show();
                }

                else if (UserLoginCache.Cargo.Contains("Jefe del depto.") || UserLoginCache.Cargo.Contains("Jefa del depto."))
                {
                       FormMenuJefeDepto mainMenuJefeDepto = new FormMenuJefeDepto();
                       mainMenuJefeDepto.Show();
                }

                else if(UserLoginCache.Cargo.Contains("Administrador"))
                {
                    FormMenuPrincipal mainMenu = new FormMenuPrincipal();
                    mainMenu.Show();
                }
             
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error de datos");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }
    }
}
