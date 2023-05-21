using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;

namespace Evaluation_Manager
{
    public partial class FrmLogin : Form
    {
        public static Teacher LoggedTeacher { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            LoggedTeacher = TeacherRepository.GetTeacher(username);

            if (LoggedTeacher != null && LoggedTeacher.CheckPassword(password))
            {
                FrmStudents frmStudents = new FrmStudents();
                Hide();
                frmStudents.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Wrong credetials!");
            }
        }
    }
}
