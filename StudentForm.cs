using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace DigitalResultSystem
    {
    public partial class StudentForm : Form
        {

        DB dbAccess = new DB();
        DataTable StudentTbl = new DataTable();
        MemoryStream msimgtobi;
        OpenFileDialog fileOpen;
        string photoLocation;
        byte[] byteimage = null;
        public static int SsL;

        public StudentForm()
            {
            InitializeComponent();
            }

        private void StudentForm_Load(object sender, EventArgs e)
            {
            fillStudentCombo();

            comboBoxStudent.DataSource = StudentTbl;
            comboBoxStudent.DisplayMember = "Student_Name";

            initiateTextboxValue("", "", "", "--Select--", "", "", "");
            initiateTextLebelValue("--Select Student--", "", "", "", "", "", "");

            pictureBoxStudent.Image = null;
            pictureBoxStudent.Visible = false;
            }

        private void buttonAddStudent_Click(object sender, EventArgs e)
            {
            studentInsertValidation();
            }

        private void buttonUpdateStudent_Click(object sender, EventArgs e)
            {
            studentUpdateValidation();
            }

        private void buttonDeleteStudent_Click(object sender, EventArgs e)
            {
            studentDeleteValidation();
            }

        private void labelImgBrowse_Click(object sender, EventArgs e)
            {
            browsePhoto();
            }


        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
            {
            pictureBoxStudent.Visible = true;
            if (comboBoxStudent.SelectedIndex != -1)
                {
                textBoxName.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Name"].ToString();
                textBoxID.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_ID"].ToString();
                TextBoxReg.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Reg"].ToString();
                comboBoxSemester.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Semester"].ToString();
                textBoxSession.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Session"].ToString();
                textBoxEmail.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Email"].ToString();

                comboBoxStudent.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Name"].ToString();
                StudentNameLbl.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Name"].ToString();
                IDLbl.Text = "ID: " + StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_ID"].ToString();
                RegisLbl.Text = "Reg. " + StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Reg"].ToString();
                SemesterLbl.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Semester"].ToString();
                sessionLbl.Text = "Session: " + StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Session"].ToString();
                mobileLbl.Text = "Email: " + StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Email"].ToString();

                if (StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Photo"] == null)
                    {
                    pictureBoxStudent.Image = null;
                    }
                else
                    {
                    try
                        {
                        MemoryStream ms = new MemoryStream((byte[])StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Photo"]);
                        pictureBoxStudent.Image = new Bitmap(ms);
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show(ex.Message);
                        }
                    }

                SsL = Convert.ToInt32(StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Serial"].ToString());
                }
            }


        void studentInsertValidation()
            {
            try
                {
                string student_name = textBoxName.Text.Trim();
                string student_id = textBoxID.Text.Trim();
                string student_registration = TextBoxReg.Text.Trim();
                string student_semester = comboBoxSemester.Text.Trim();
                string student_session = textBoxSession.Text.Trim();
                string student_email = textBoxEmail.Text.Trim();
                string student_faculty = "CSE";
                byte[] image = ImgToBinaryMem();

                if (student_name == "" || student_id == "" || student_registration == "" || student_semester == "" || student_session == "" || student_email == "")
                    { MessageBox.Show("Fields can not be Empty!"); }
                else if (IsIDuplicateSID() == 0)
                    {
                    string query = "INSERT INTO Student(Student_ID, Student_Name, Student_Reg, Student_Session, Student_Semester, Student_Email, Student_Photo, Student_Faculty)" +
                    "VALUES (@student_id, @student_name, @student_registration, @student_session, @student_semester, @student_email, @image, @student_faculty)";
                    //string query = "INSERT INTO Student(Student_ID, Student_Name, Student_Reg, Student_Session, Student_Semester, Student_Mobile, Student_Fingerprint_ID)" +
                    // "VALUES (@student_id, @student_name, @student_registration, @student_session, @student_semester, @student_mobile, @int_student_fingerprint)";
                    SqlCommand insertCommand = new SqlCommand(query);
                    insertCommand.Parameters.AddWithValue("@student_id", student_id);
                    insertCommand.Parameters.AddWithValue("@student_name", student_name);
                    insertCommand.Parameters.AddWithValue("@student_registration", student_registration);
                    insertCommand.Parameters.AddWithValue("@student_session", student_session);
                    insertCommand.Parameters.AddWithValue("@student_semester", student_semester);
                    insertCommand.Parameters.AddWithValue("@student_email", student_email);
                    insertCommand.Parameters.AddWithValue("@student_faculty", student_faculty);
                    insertCommand.Parameters.AddWithValue("@image", image);

                    int row = dbAccess.executeQuery(insertCommand);
                    dbAccess.closeConn();

                    if (row == 1)
                        {
                        MessageBox.Show("New Student Added!!");
                        refreshCombo();
                        }
                    else { MessageBox.Show("Could not Insert.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else
                    {
                    MessageBox.Show("Sorry, could't add this student.\n" + "Student ID " + student_id +  " is already exists!! ", "Could not Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        void studentUpdateValidation()
            {
            try
                {
                string student_name = textBoxName.Text;
                string student_id = textBoxID.Text.Trim();
                string student_registration = TextBoxReg.Text.Trim();
                string student_semester = comboBoxSemester.Text.Trim();
                string student_session = textBoxSession.Text.Trim();
                string student_email = textBoxEmail.Text.Trim();
                byte[] image = ImgToBinaryMem();

                if (student_name == "" || student_id == "" || student_registration == "" || student_semester == "" || student_session == "" || student_email == "")
                    { MessageBox.Show("Fields can not be Empty!"); }
                else
                    {
                    SqlCommand updateCommand;
                    if (photoLocation == null)
                        {
                        string query = " UPDATE Student SET Student_ID = @student_id, Student_Name = @student_name , Student_Reg = @student_registration ," +
                               "Student_Session = @student_session, Student_Semester = @student_semester, Student_Email = @student_email WHERE Serial = '" + SsL + "' ";
                        //string query = " UPDATE Student SET Student_ID = '" + student_id + "', Student_Name = '" + student_name + "' ,Student_Reg = '"
                        //+ student_registration + "' ,Student_Session = '" + student_session + "', Student_Semester = '" + student_semester + "', Student_Mobile = '" + student_mobile +
                        //"' WHERE Serial = '" + SsL + "' ";
                        updateCommand = new SqlCommand(query);
                        updateCommand.Parameters.AddWithValue("@student_id", student_id);
                        updateCommand.Parameters.AddWithValue("@student_name", student_name);
                        updateCommand.Parameters.AddWithValue("@student_registration", student_registration);
                        updateCommand.Parameters.AddWithValue("@student_session", student_session);
                        updateCommand.Parameters.AddWithValue("@student_semester", student_semester);
                        updateCommand.Parameters.AddWithValue("@student_email", student_email);
                        }
                    else
                        {
                        string query = " UPDATE Student SET Student_ID = @student_id, Student_Name = @student_name , Student_Reg = @student_registration ," +
                             "Student_Session = @student_session, Student_Semester = @student_semester, Student_Email = @student_email, Student_Photo = @image WHERE Serial = '" + SsL + "' ";
                        //string query = " UPDATE Student SET Student_ID = '" + student_id + "', Student_Name = '" + student_name + "' ,Student_Reg = '"
                        //+ student_registration + "' ,Student_Session = '" + student_session + "', Student_Semester = '" + student_semester + "', Student_Mobile = '" + student_mobile +
                        //"' WHERE Serial = '" + SsL + "' ";
                        updateCommand = new SqlCommand(query);
                        updateCommand.Parameters.AddWithValue("@student_id", student_id);
                        updateCommand.Parameters.AddWithValue("@student_name", student_name);
                        updateCommand.Parameters.AddWithValue("@student_registration", student_registration);
                        updateCommand.Parameters.AddWithValue("@student_session", student_session);
                        updateCommand.Parameters.AddWithValue("@student_semester", student_semester);
                        updateCommand.Parameters.AddWithValue("@student_email", student_email);
                        updateCommand.Parameters.AddWithValue("@image", image);

                        }
                    int row = dbAccess.executeQuery(updateCommand);
                    dbAccess.closeConn();

                    if (row == 1)
                        {
                        MessageBox.Show("Student Updated!!!");
                        refreshCombo();
                        }
                    else { MessageBox.Show("Could not Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }


        void studentDeleteValidation()
            {
            DialogResult d;
            d = MessageBox.Show("Do you want to delete? ", " Warning!! ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
                {

                try
                    {
                    string query = " DELETE FROM Student WHERE Serial = '" + SsL + "' ";
                    SqlCommand deleteCommand = new SqlCommand(query);

                    int row = dbAccess.executeQuery(deleteCommand);
                    dbAccess.closeConn();

                    if (row == 1)
                        {
                        MessageBox.Show("Student Deleted!!!");
                        refreshCombo();
                        }
                    else { MessageBox.Show("Could not Delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show(ex.Message);
                    }
                }
            }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
            {

            StudentTbl.Columns.Clear();
            StudentTbl.Rows.Clear();
            StudentTbl.Clear();

            string name = textBoxSearch.Text;
            string query = " SELECT * FROM Student WHERE Student_Name LIKE '%" + name + "%' ";
            dbAccess.readDatathroughAdapter(query, StudentTbl);

            if (StudentTbl.Rows.Count >= 1)
                {
                if (comboBoxStudent.SelectedIndex != -1)
                    {
                    StudentNameLbl.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Name"].ToString();
                    IDLbl.Text = "ID: " + StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_ID"].ToString();
                    RegisLbl.Text = "Reg. " + StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Reg"].ToString();
                    SemesterLbl.Text = StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Semester"].ToString();
                    sessionLbl.Text = "Session: " + StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Session"].ToString();
                    mobileLbl.Text = "Email: " + StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Email"].ToString();

                    if (StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Photo"] == null)
                        {
                        pictureBoxStudent.Image = null;
                        }
                    else
                        {
                        try
                            {
                            MemoryStream ms = new MemoryStream((byte[])StudentTbl.Rows[comboBoxStudent.SelectedIndex]["Student_Photo"]);
                            pictureBoxStudent.Image = new Bitmap(ms);
                            //pictureBoxTeacher.Image = Image.FromStream(ms);
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            else
                {
                comboBoxStudent.Text = "No Student found";
                StudentNameLbl.Text = "Name";
                IDLbl.Text = "Student ID";
                RegisLbl.Text = "Registration No.";
                SemesterLbl.Text = "Semester";
                sessionLbl.Text = "Session ";
                mobileLbl.Text = "Email";
                pictureBoxStudent.Image = null;
                }

            }

        private void textBoxSearch_Click(object sender, EventArgs e)
            {
            var search = (TextBox)sender;
            search.SelectAll();
            search.Focus();
            }

        void refreshCombo()
            {
            StudentTbl.Rows.Clear();
            StudentTbl.Columns.Clear();
            StudentTbl.Clear();

            fillStudentCombo();
            comboBoxStudent.DataSource = null;
            comboBoxStudent.Items.Clear();
            comboBoxStudent.DataSource = StudentTbl;
            comboBoxStudent.DisplayMember = "Student_Name";
            initiateTextboxValue("", "", "", "--Select--", "", "", "");
            initiateTextLebelValue("--Select Student--", "", "", "", "", "", "");
            pictureBoxStudent.Image = null;
            pictureBoxStudent.Visible = false;
            }

        void fillStudentCombo()
            {
            string query = " SELECT * FROM Student ";
            dbAccess.readDatathroughAdapter(query, StudentTbl);
            dbAccess.closeConn();
            }

        void initiateTextboxValue(string name, string id, string reg, string semester, string session, string mobile, string fid)
            {
            textBoxName.Text = name;
            textBoxID.Text = id;
            TextBoxReg.Text = reg;
            comboBoxSemester.Text = semester;
            textBoxSession.Text = session;
            textBoxEmail.Text = mobile;
            }
        void initiateTextLebelValue(string comboItem, string name, string id, string reg, string semester, string session, string mobile)
            {
            comboBoxStudent.Text = comboItem;
            StudentNameLbl.Text = name;
            IDLbl.Text = id;
            RegisLbl.Text = reg;
            SemesterLbl.Text = semester;
            sessionLbl.Text = session;
            mobileLbl.Text = mobile;
            }

        int IsIDuplicateSID()
            {
            string student_Id = textBoxID.Text.Trim();
            DataTable IsIDAvailable = new DataTable();
            string query = " SELECT Student_ID FROM Student WHERE Student_ID ='" + student_Id + "' ";
            dbAccess.readDatathroughAdapter(query, IsIDAvailable);
            int i = IsIDAvailable.Rows.Count;
            dbAccess.closeConn();
            return i;
            }

        void browsePhoto()
            {
            //OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen = new OpenFileDialog();
            fileOpen.Title = "Open Image file";
            fileOpen.Filter = "JPG Files (*.jpg)| *.jpg";

            if (fileOpen.ShowDialog() == DialogResult.OK)
                {
                photoLocation = fileOpen.FileName.ToString();
                pictureBoxBrowse.Image = Image.FromFile(fileOpen.FileName);
                }
            fileOpen.Dispose();
            }

        byte[] ImgToBinaryMem()
            {
            msimgtobi = new MemoryStream();
            pictureBoxBrowse.Image.Save(msimgtobi, ImageFormat.Jpeg);
            byteimage = new byte[msimgtobi.Length];
            msimgtobi.Position = 0;
            msimgtobi.Read(byteimage, 0, byteimage.Length);
            return byteimage;
            }


            
        }
    }
