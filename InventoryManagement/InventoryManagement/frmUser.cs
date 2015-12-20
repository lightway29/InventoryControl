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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadUsers();

            cmbUserType.Text = "Admin";
        }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString);

        private void LoadUsers()
        {
            try
            {
                using (connection)
                {
                    string query = @"SELECT
                                    users.`name`,
                                    users.username,
                                    users.usertype
                                    FROM `users`
                                    ORDER BY
                                    users.`name` ASC
                                    ";

                    MySqlDataAdapter adp = new MySqlDataAdapter(query,connection);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);

                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < tbl.Rows.Count;i++ )
                    {
                        dataGridView1.Rows.Add();

                        dataGridView1.Rows[i].Cells[0].Value = tbl.Rows[i]["name"].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = tbl.Rows[i]["username"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = tbl.Rows[i]["usertype"].ToString();

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private bool Validation()
        {
            if(txtName.Text=="")
            {
                MessageBox.Show("Enter Name");
                return false;
            }
            else if (txtUsername.Text == "")
            {
                MessageBox.Show("Enter Username");
                return false;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter Password");
                return false;
            }
            else if (txtConfirm.Text == "")
            {
                MessageBox.Show("Enter Confirm Password");
                return false;
            }
            else if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Password doesn't match with confirm password ");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUser();
        }

        private void SaveUser()
        {
            try
            {
                if(Validation())
                {
                using (connection)
                {
                    string query = "INSERT INTO users (name,username,password,usertype) VALUES(@name,@username,@password,@usertype)";
                    MySqlCommand command = new MySqlCommand(query,connection);

                    command.Parameters.AddWithValue("@name",txtName.Text);
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    command.Parameters.AddWithValue("@usertype", cmbUserType.Text);

                    connection.Open();
                    command.ExecuteNonQuery();

                    Clear();
                    LoadUsers();
                    MessageBox.Show("Successfully saved user details","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void UpdateUser()
        {
            try
            {
                if (Validation())
                {
                    using (connection)
                    {
                        if (lblID.Text != "")
                        {
                            string query = "UPDATE users  SET name=@name,username=@username,password=@password,usertype=@usertype WHERE userid=@id";
                            MySqlCommand command = new MySqlCommand(query, connection);

                            command.Parameters.AddWithValue("@name", txtName.Text);
                            command.Parameters.AddWithValue("@username", txtUsername.Text);
                            command.Parameters.AddWithValue("@password", txtPassword.Text);
                            command.Parameters.AddWithValue("@usertype", cmbUserType.Text);
                            command.Parameters.AddWithValue("@id", lblID.Text);

                            connection.Open();
                            command.ExecuteNonQuery();

                            Clear();
                            LoadUsers();
                            MessageBox.Show("Successfully updated user details", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record to update");
                        }
                   }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void DeleteUser()
        {
            try
            {
                using (connection)
                {
                    if (lblID.Text != "")
                    {
                        string query = "DELETE FROM users WHERE userid=@id";
                        MySqlCommand command = new MySqlCommand(query, connection);

                        command.Parameters.AddWithValue("@id", lblID.Text);

                        connection.Open();
                        command.ExecuteNonQuery();

                        Clear();
                        LoadUsers();
                        MessageBox.Show("Successfully deleted user details", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("No record to delete");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Clear()
        {
            lblID.Text = "";
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirm.Clear();
            cmbUserType.Text = "Admin";

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
                {
                }
                else
                {
                    using (connection)
                    {
                        string query = @"SELECT
                                    users.userid,
                                    users.`name`,
                                    users.username,
                                    users.`password`,
                                    users.usertype
                                    FROM `users`
                                    WHERE
                                    users.username = @username";

                        MySqlCommand command = new MySqlCommand(query,connection);
                        command.Parameters.AddWithValue("@username", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                        connection.Open();
                        MySqlDataReader rdr = command.ExecuteReader();

                        if (rdr.Read())
                        {
                            lblID.Text = rdr["userid"].ToString();
                            txtName.Text = rdr["name"].ToString();
                            txtUsername.Text = rdr["username"].ToString();
                            cmbUserType.Text = rdr["usertype"].ToString();
                            txtPassword.Text = rdr["password"].ToString();
                        }

                    }
                }
            }
        }


    }
}
