using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace InventoryManagement
{
    public partial class frmLogin : Form
    {
        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString);

        public frmLogin()
        {
            InitializeComponent();
        }
        string conString;
        private void frmLogin_Load(object sender, EventArgs e)
        {

            this.Size = new System.Drawing.Size(465, 202);
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int height = resolution.Size.Height;
            int width = resolution.Size.Width;
            int x = (width - 490) / 2;
            int y = (height - 205) / 2;
            this.Location = new Point(x, y);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.InitialDelay = 1000;
            toolTip1.ShowAlways = true;
            


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
            if (this.Size == new System.Drawing.Size(465, 202))
            {

                this.Size = new System.Drawing.Size(682, 202);
                groupBox2.Visible = true;
                panel2.Visible = false;
                txtServer.Focus();

            }
            else
            {
                this.Size = new System.Drawing.Size(465, 202);
                txtUsername.Focus();
            }

            
                
                string myConnection = ConfigurationManager.ConnectionStrings["Key"].ConnectionString;
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(myConnection);

                txtServer.Text = builder.Server;
                txtPort.Text = builder.Port.ToString();
                txtRoot.Text = builder.UserID;
                txtDBPassword.Text = builder.Password;
                txtDatabase.Text = builder.Database;

            }
            catch(Exception ex)
            {
                Clipboard.SetText(ex.Message);
                MessageBox.Show("Cannot load Connection file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "")
                {
                    lblMessage.Text = "Enter Username";

                }
                else if (txtPassword.Text == "")
                {

                    lblMessage.Text = "Enter Password";
                }
                else
                {
                    MySqlCommand command = new MySqlCommand(@"SELECT
                                                            users.username
                                                            FROM `users`
                                                            WHERE
                                                            users.username = @username", connection);

                    command.Parameters.AddWithValue("@username",txtUsername.Text);

                    connection.Open();

                    var username = command.ExecuteScalar();

                    connection.Close();

                    if (username != null)
                    {
                        MySqlCommand command2 = new MySqlCommand(@"SELECT
                                                                    users.`password`
                                                                    FROM
                                                                    users
                                                                    WHERE
                                                                    users.username = @username", connection);


                        command2.Parameters.AddWithValue("@username", txtUsername.Text);
                        connection.Open();
                        string password = command2.ExecuteScalar().ToString();

                        if (password == txtPassword.Text)
                        {
                             frmMain mn = new frmMain();
                            //mn.Username = username.ToString();
                            mn.Show();

                            this.Hide();
                            
                        }
                        else
                        {
                            lblMessage.Text = "Password Incorrect"; 
                        }


                        connection.Close();
                        
                    }
                    else
                    {
                        lblMessage.Text = "Username Incorrect"; 

                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {

                connection.Close();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string server = "Localhost";
            string userId = "root";
            string password = "123";
            string port = "3308";
            string DB = "stock";

            if (!String.IsNullOrEmpty(txtServer.Text))
                server = txtServer.Text;
            if (!String.IsNullOrEmpty(txtRoot.Text))
                userId = txtRoot.Text;
            if (!String.IsNullOrEmpty(txtDBPassword.Text))
                password = txtDBPassword.Text;
            if (!String.IsNullOrEmpty(txtPort.Text))
                port = txtPort.Text;
            if (!String.IsNullOrEmpty(txtDatabase.Text))
                DB = txtDatabase.Text;

            
            conString = "server=" + server + ";User Id=" + userId + ";password=" + password + ";port=" + port + ";database=" + DB + ";Pooling=false;Connection Lifetime=0;connection timeout=10000; default command timeout=1000;";
            groupBox2.Visible = false;
            panel2.Visible = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirmCode.Text == "qb123")
            {
                changeValue("Key", conString);
                MessageBox.Show("Connection String Changed", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter correct code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtConfirmCode.Text = "";
            panel2.Visible = false;

            this.Size = new System.Drawing.Size(465, 202);
            txtUsername.Focus();
        }

        private void changeValue(String KeyName, String KeyValue)
        {

            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


            //// Update the setting            
            config.ConnectionStrings.ConnectionStrings[KeyName].ConnectionString = KeyValue;

            
            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section.
            ConfigurationManager.RefreshSection("connectionStrings");


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
