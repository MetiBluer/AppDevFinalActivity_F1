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
using MySql.Data.MySqlClient;
using MySql.Data;


namespace _046_tolentino_agustin_F1
{
    public partial class frmEmployee : Form
    {
        string strConn = "server=localhost; database=db_tolentino_agustin; uid=root; pwd=uslt; port = 3306; ";
        MySqlConnection conn;
        
        public frmEmployee()

        {
            InitializeComponent();
        }

        private void dgvDisp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            disp();
            load();
        }
        private void disp()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM EMPLOYEE ";
            conn = new MySqlConnection(strConn);
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            conn.Close();
            dgvDisp.DataSource = dt;
            dgvDisp.Columns["empID"].Visible = false;
            dgvDisp.Columns["deptID"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(txtSex.Text) ||
                 string.IsNullOrWhiteSpace(txtMarital.Text) || string.IsNullOrWhiteSpace(cboDepartment.Text))
            {
                MessageBox.Show("All fields are required!", "ERROR");
            }
            else 
            {
               string query = "" +
               "INSERT INTO EMPLOYEE(emp_name,emp_age,emp_sex,marital_status,deptid) " +
               "VALUES ('" + txtName.Text + "'," + txtAge.Text + ",'" + txtSex.Text + "','" + txtMarital.Text + "'," + cboDepartment.Text + ");";
                conn = new MySqlConnection(strConn);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Employee successfully added!", "SUCCESS");
                disp();
                clear();
            }

           

        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clear() 
        {
            txtName.Clear();
            txtAge.Clear();
            txtSex.Clear();
            txtMarital.Clear();
            cboDepartment.SelectedIndex = 0;         
        }

        private void load() 
        {
            using (MySqlConnection conn = new MySqlConnection(strConn)) 
            {
                conn.Open();

                string deptIDQuery = "select deptID from department";
                using (MySqlCommand deptIDcmd = new MySqlCommand(deptIDQuery, conn)) 
                {
                    using (MySqlDataReader reader = deptIDcmd.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            cboDepartment.Items.Add(reader["deptID"].ToString());
                        }
                    }

                }
                conn.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query = "select e.emp_name as name, e.emp_sex as Sex, d.deptname Department " +
               " from employee e " +
               " inner join department d " +
               " on e.deptID = d.deptID " +
               " where empID = " + txtEmpID.Text + "";
            conn = new MySqlConnection(strConn);
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);
            conn.Close();
            dgvDisp.DataSource = dt;                   
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace( txtAge.Text)
                || string.IsNullOrWhiteSpace(lblSex.Text) || string.IsNullOrWhiteSpace(lblMarital.Text)
                || string.IsNullOrWhiteSpace(cboDepartment.Text) || string.IsNullOrWhiteSpace(txtEmpID.Text))
            {
                MessageBox.Show("All fields are required!");s
            }
            else
            {
                int empID = int.Parse(dgvDisp.SelectedCells[0].Value.ToString());


                string query = "UPDATE EMPLOYEE SET emp_name = '" +txtName.Text + "', emp_age = "+txtAge.Text+ ", " +
                    "emp_sex='"+txtSex.Text+ "', marital_status='"+txtMarital.Text+"' WHERE empID = " + empID + " ";
                conn = new MySqlConnection(strConn);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Employee successfully updated!");
                disp();
            }

        }

        private void dgvDisp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmpID.Text = dgvDisp.SelectedCells[0].Value.ToString();
            txtName.Text = dgvDisp.SelectedCells[1].Value.ToString();
            txtAge.Text = dgvDisp.SelectedCells[2].Value.ToString();
            txtSex.Text = dgvDisp.SelectedCells[3].Value.ToString();
            txtMarital.Text = dgvDisp.SelectedCells[4].Value.ToString();
            cboDepartment.Text = dgvDisp.SelectedCells[5].Value.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmpID.Text))
            {
                MessageBox.Show("Employee ID is required!");
            }
            else
            {            
                string query = "DELETE FROM EMPLOYEE WHERE empID=" + txtEmpID.Text + " ";
                conn = new MySqlConnection(strConn);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Employee successfully deleted!");
                disp();
            }
        }
    }
    
}
