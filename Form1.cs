using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _046_tolentino_agustin_F1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDepartment frmDep = new frmDepartment(); 
            frmDep.ShowDialog();

        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            frmEmployee frmEmp = new frmEmployee();
            frmEmp.ShowDialog();    
        }
    }
}
