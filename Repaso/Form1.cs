using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso
{
    public partial class Form1 : Form
    {
        public MySqlConnection conexion;
        public Form1()
        {
            InitializeComponent();
            conectarBd();
        }

        private void conectarBd()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            try
            {
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "";
                builder.Database = "repaso";

                conexion = new MySqlConnection(builder.ToString());

              
            }
            catch (Exception e)
            {
                MessageBox.Show("error al conectar a la bd");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand command = null;
            Persona persona = new Persona();
            conexion.Open();
            persona.Nombre = txtNombre.Text;
            persona.Cp = txtCp.Text;

            try
            {
                String consulta = "INSERT INTO repaso.persona(nombre, cp)VALUES(@nombre, @cp)";
                command = new MySqlCommand(consulta, conexion);
                command.Parameters.AddWithValue("@nombre", persona.Nombre);
                command.Parameters.AddWithValue("@cp", persona.Cp);
                command.Prepare();
                
                int respuesta = command.ExecuteNonQuery();
                if (respuesta > 0)
                {
                    MessageBox.Show("se añadió");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("no se añadió");
            }
            finally
            {
                try
                {
                    if (command != null)
                    {
                        conexion.Close();
                    }
                }
                catch (Exception ex) { }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = null;
            conexion.Open();

            String consulta = "select * from persona where nombre=@nombre;";
            cmd = new MySqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Prepare();
            
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            txtCp.Text = reader.GetString(1);

            conexion.Close();
        }
    }
}
