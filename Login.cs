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
    public partial class Login : Form
        {
        DB dbAccess = new DB();
        DataTable TeacherTbl = new DataTable();
        public Login()
            {
            InitializeComponent();
            }

        private void Login_Load(object sender, EventArgs e)
            {
            maskingPassword();
            fillTeacherTbl();
            comboBoxRole.SelectedIndex = 0;
            }
        private void checkBoxPasshow_CheckedChanged(object sender, EventArgs e)
            {
            TextBoxPassword.PasswordChar = checkBoxPasshow.Checked ? '\0' : '*';
            if (checkBoxPasshow.Checked)
                { checkBoxPasshow.ForeColor = Color.BlueViolet; }
            else { checkBoxPasshow.ForeColor = Color.Gray; }
            }
        void maskingPassword()
            {
            TextBoxPassword.PasswordChar = '*';
            }

        private void ButtonLogin_Click(object sender, EventArgs e)
            {
            LoginValidation();
            }

        private void ButtonClear_Click(object sender, EventArgs e)
            {
            TextBoxUsername.Text = "";
            TextBoxPassword.Text = "";
            }

        void EnterTeachersFORM()
            {
            this.Hide();
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.Show();
            }

        void EnterAdminsFORM()
            {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            }

        void fillTeacherTbl()
            {
            string query = "  Select * from Teacher ";
            dbAccess.readDatathroughAdapter(query, TeacherTbl);
            dbAccess.closeConn();
            }

        void refreshTeacherTbl()
            {
            TeacherTbl.Rows.Clear();
            TeacherTbl.Columns.Clear();
            TeacherTbl.Clear();
            }


        void LoginValidation()
            {
            string username = TextBoxUsername.Text.Trim();
            string password = TextBoxPassword.Text.Trim();
            string role = comboBoxRole.Text.Trim();

            if (username == "" || password == "") MessageBox.Show("Fields can not be Empty!");
            else
                {
                refreshTeacherTbl();
                string query = "  Select * from Teacher Where Teacher_Name = '" + username + "' AND Password = '" + password + "' AND Role = '"+role+"'  ";
                dbAccess.readDatathroughAdapter(query, TeacherTbl);
                dbAccess.closeConn();

                if (TeacherTbl.Rows.Count == 1)
                    {
                    if (role == "Admin") EnterAdminsFORM();
                    else if (role == "Teacher") EnterTeachersFORM();
                    }
                else { MessageBox.Show("Username/Password Incorrect/Incorrect Selection of Role", "Error"); }
                }


            }
        }
    }
