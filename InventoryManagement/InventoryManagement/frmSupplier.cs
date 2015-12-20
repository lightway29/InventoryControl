using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace InventoryManagement
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDetails();
        }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString);

        private void SaveDetails()
        {
            try
            {
                using (connection)
               {
                   string query = "INSERT INTO suppliers (suppliername,telephone,address) VALUES (@suppliername,@telephone,@address)";

                   MySqlCommand command = new MySqlCommand(query, connection);
                   command.Parameters.AddWithValue("@suppliername",txtName.Text);
                   command.Parameters.AddWithValue("@telephone", txtTel.Text);
                   command.Parameters.AddWithValue("@address", txtAdd.Text);

                   connection.Open();

                   command.ExecuteNonQuery();

                   LoadDetails();
                   Clear();
                   MessageBox.Show("Successfully saved supplier details", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


               }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDetails();
        }

        private void UpdateDetails()
        {
            try
            {
                using (connection)
                {
                    if (lblID.Text != "")
                    {
                        string query = "UPDATE suppliers  SET suppliername=@suppliername,telephone=@telephone,address=@address WHERE supplierid=@id";

                        string id =  lblID.Text.Substring(3);

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@suppliername", txtName.Text);
                        command.Parameters.AddWithValue("@telephone", txtTel.Text);
                        command.Parameters.AddWithValue("@address", txtAdd.Text);
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();

                        command.ExecuteNonQuery();

                        LoadDetails();
                        Clear();
                        MessageBox.Show("Successfully updated supplier details", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No record to update");
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
            DeleteDetails();
        }

        private void DeleteDetails()
        {
            try
            {
                using (connection)
                {
                    if (lblID.Text != "")
                    {
                        string id = lblID.Text.Substring(3);

                        string query = "DELETE FROM suppliers WHERE supplierid=@id";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();

                        command.ExecuteNonQuery();

                        LoadDetails();
                        Clear();
                        MessageBox.Show("Successfully updated supplier details", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void LoadDetails()
        {
            try
            {
                using (connection)
                {
                    string query = @"SELECT
                                    suppliers.supplierid,
                                    suppliers.suppliername,
                                    suppliers.telephone,
                                    suppliers.address
                                    FROM `suppliers`
                                    ORDER BY
                                    suppliers.supplierid ASC,
                                    suppliers.suppliername ASC";

                    MySqlDataAdapter adp = new MySqlDataAdapter(query, connection);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);

                    dataGridView1.Rows.Clear();

                    for (int i = 0; i < tbl.Rows.Count;i++ )
                    {
                        dataGridView1.Rows.Add();

                        dataGridView1.Rows[i].Cells[0].Value = "SUP"+tbl.Rows[i]["supplierid"].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = tbl.Rows[i]["suppliername"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = tbl.Rows[i]["telephone"].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = tbl.Rows[i]["address"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
                {
                }
                else
                {
                    lblID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtTel.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtAdd.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            lblID.Text = "";
            txtName.Clear();
            txtTel.Clear();
            txtAdd.Clear();
        }
    }
}
