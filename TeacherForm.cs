using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalResultSystem
    {
    public partial class TeacherForm : Form
        {
        public TeacherForm()
            {
            InitializeComponent();
            }

        private void buttonProcessResult_Click(object sender, EventArgs e)
            {
            this.Hide();
            //ExecutionFrom executionFrom = new ExecutionFrom();
            ExcutionFormDe executionFrom = new ExcutionFormDe();
            executionFrom.Show();
            }

        private void buttonManageStudent_Click(object sender, EventArgs e)
            {
            this.Hide();
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
            }
        }
    }
