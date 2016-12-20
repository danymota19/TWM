using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TWM.Logic;

namespace TWM.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
           /* Login LoginClass = new Login();
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            else
            {
                LoginClass.validatePassword("ddd");
                MessageBox.Show("Login Successful!");*/
                this.Hide();
                frmMain fm = new frmMain();
                fm.Show();
           // }
        }
    }
}
