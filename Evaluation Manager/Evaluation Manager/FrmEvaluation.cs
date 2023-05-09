using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaluation_Manager.Repositories;

namespace Evaluation_Manager
{
    public partial class FrmEvaluation : Form
    {
        private Student selectedStudent;

        public FrmEvaluation(Student selectedStudent)
        {
            InitializeComponent();
            this.selectedStudent = selectedStudent;
            this.Text = $"{selectedStudent.FirstName} {selectedStudent.LastName}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           //TODO : Save score to database
        }

        private void FrmEvaluation_Load(object sender, EventArgs e)
        {
            PopulateActivities();
        }

        private void PopulateActivities()
        {
            cboActivities.DataSource = ActivityRepository.GetActivities();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            Activity selectedActivity = cboActivities.SelectedItem as Activity;
            txtActivityDescription.Text = selectedActivity.Description;
            TxtMinForGrade.Text = selectedActivity.MinPointsForGrade.ToString();
            txtMinForSignature.Text = selectedActivity.MinPointsForSignature.ToString();
        }
    }
}
