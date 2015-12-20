using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class frmMaterialOrder : Form
    {
        public frmMaterialOrder()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString);

        private void frmMaterialOrder_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            LoadOrderID();
            LoadItems();
        }

        private void LoadItems()
        {
            try
            {
                using (connection)
                {
                    string query = @"SELECT
                                    rawmaterial.materialname,
                                    rawmaterial.materialid
                                    FROM `rawmaterial`
                                    ORDER BY
                                    rawmaterial.materialname ASC
                                    ";

                    MySqlDataAdapter adp = new MySqlDataAdapter(query, connection);
                    DataTable tbl = new DataTable();
                    tbl.Columns.Add("materialname");
                    tbl.Columns.Add("materialid");
                    tbl.Rows.Add("", "");
                    adp.Fill(tbl);

                    item.DataSource = tbl;
                    item.DisplayMember = "materialname";
                    item.ValueMember = "materialid";

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void LoadOrderID()
        {
            try
            {
                using (connection)
                {
                    string query = @"SELECT
                                    Max(materialorderheader.orderid)
                                    FROM `materialorderheader`
                                    ORDER BY
                                    materialorderheader.orderid DESC
                                    ";

                    MySqlCommand command = new MySqlCommand(query,connection);

                    connection.Open();
                    var tmpID = command.ExecuteScalar();

                    double id;
                    Double.TryParse(tmpID.ToString(), out id);
                    id+=1;
                    txtOrderID.Text = id.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        

        private void LoadSuppliers()
        {
            try
            {
                using (connection)
                {
                    string query = @"SELECT
                                suppliers.supplierid,
                                suppliers.suppliername
                                FROM `suppliers`
                                ORDER BY
                                suppliers.suppliername ASC";
                    MySqlDataAdapter adp = new MySqlDataAdapter(query, connection);
                    DataTable tbl = new DataTable();
                    tbl.Columns.Add("supplierid");
                    tbl.Columns.Add("suppliername");
                    tbl.Rows.Add("", "");
                    adp.Fill(tbl);

                    cmbSupplier.DataSource = tbl;
                    cmbSupplier.DisplayMember = "suppliername";
                    cmbSupplier.ValueMember = "supplierid";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
