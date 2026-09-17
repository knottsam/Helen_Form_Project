using System;
using System.Windows.Forms;

namespace Helen_Form_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 gpsForm = new Form1();
            gpsForm.FormClosed += (s, args) => this.Close();
            gpsForm.Show();
            this.Hide();
        }
    }
}
