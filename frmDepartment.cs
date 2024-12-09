using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace _046_tolentino_agustin_F1
{
    
    public partial class frmDepartment : Form
    { 

        string strConn = "server=localhost; database=db_tolentino_agustin; uid=root; pwd=uslt; port = 3306; ";
        MySqlConnection conn;
      

        public frmDepartment()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                MessageBox.Show("department name is required!");
            }
            else 
            {
                string query = "INSERT INTO DEPARTMENT(deptName) VALUES('" + txtDeptName.Text + "'); ";
                conn = new MySqlConnection(strConn);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("department successfully added!");
                disp();
            }

            
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            disp();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                MessageBox.Show("All fields are required!");
            }
            else 
            {
                int deptID = int.Parse(dgvDisp.SelectedCells[0].Value.ToString());
                
                string query = "UPDATE DEPARTMENT SET deptName = '" + txtDeptName.Text + "' WHERE deptID = " + deptID + "; ";
                conn = new MySqlConnection(strConn);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("department successfully updated!");
                disp();
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDeptName.Text))
                {
                    MessageBox.Show("department name is required!");
                }
                else
                {
                    string deptname = dgvDisp.SelectedCells[1].Value.ToString();

                    string query = "DELETE FROM DEPARTMENT WHERE deptName='" + deptname + "' ";
                    conn = new MySqlConnection(strConn);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("department successfully deleted!");
                    disp();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant Delete Department because it is connected to an Employee");
            }
           
            
        }

        private void disp()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM DEPARTMENT ";
            conn = new MySqlConnection(strConn);
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            conn.Close();
            dgvDisp.DataSource = dt;

            dgvDisp.Columns["deptID"].Visible = false;
        }

        private void dgvDisp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgvDisp.SelectedCells[0].Value.ToString();
            txtDeptName.Text = dgvDisp.SelectedCells[1].Value.ToString();
        }
    }
}
