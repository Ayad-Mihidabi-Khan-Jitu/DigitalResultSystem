using IronOcr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalResultSystem
    {
    public partial class ExcutionFormDe : Form
        {
        DB dbAccess = new DB();

        List<Hashtable> Student = new List<Hashtable>();
        //List<Hashtable> Student;
        DataTable StudentDataTable = new DataTable();
        Hashtable infoTable;
        string path = "";
        int countPaper = 0;
        public ExcutionFormDe()
            {
            InitializeComponent();
            }

        private void buttonPress_Click(object sender, EventArgs e)
            {

            //textBoxResult.Text = ImageToText(@"C:\Users\HP 840 G1\Desktop\Biometric\ScanImages\Papers3croped.jpg");
            getMultipleImage(path);
            countPaper = Student.Count;
            int noCopy = Convert.ToInt32(textBoxTCopy.Text);
            if(countPaper == noCopy)
                {
                MessageBox.Show("Selected Crieteria Matched with Scanned Result\n");
                texboxpulate();
                insertStudentDataTable();
                }
            else MessageBox.Show("Unsuccessful Scanned Result");
            
            }

        private void pictureBoxBrowse_Click(object sender, EventArgs e)
            {
            path = browseFolder();
            }

        string browseFolder()
            {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                return folderPath;
                }
            else return null;
            }

        void getMultipleImage(string path)
            {
            //string imageDirectory = @"C:\Users\HP 840 G1\Desktop\Biometric\ScanImages";
            string imageDirectory = path;

            string[] imageFileList = Directory.GetFiles(imageDirectory);

            int iCtr = 0, iHtr = 0;
            foreach (string imageFile in imageFileList)
                {
                PictureBox eachPictureBox = new PictureBox();
                eachPictureBox.Size = new Size(100, 150);
                //eachPictureBox.Location = new Point(iCtr * 150 + 1, 1);
                //textBoxResult.AppendText(ImageToText(imageFile));
                //textBoxResult.AppendText("\n--------------------------------\n");
                textBoxResult.AppendText(ImageToTextCroped(imageFile) + Environment.NewLine);

                if (iCtr % 3 == 0 && iCtr != 0)
                    {
                    iCtr = 0;
                    ++iHtr;
                    eachPictureBox.Location = new Point(iCtr * 120 + 1, iHtr * 170 + 1);

                    }
                else
                    {
                    eachPictureBox.Location = new Point(iCtr * 120 + 1, iHtr * 170 + 1);
                    }

                eachPictureBox.Image = Image.FromFile(imageFile);
                eachPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                iCtr++;

                panel1.Controls.Add(eachPictureBox);

                }
            }

        string ImageToText()
            {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput("C://Users//HP 840 G1//Desktop//Biometric//RE(1).jpg"))
                {
                Input.Deskew();  // use if image not straight
                Input.DeNoise(); // use if image contains digital noise
                Input.ToGrayScale();
                Input.Contrast();
                Input.DeepCleanBackgroundNoise();
                Input.EnhanceResolution();
                var Result = Ocr.Read(Input);
                //Console.WriteLine(Result.Text);
                return Result.Text;
                }
            }

        string ImageToText(string img)
            {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput(img))
                {
                Input.Deskew();  // use if image not straight
                Input.DeNoise(); // use if image contains digital noise
                Input.ToGrayScale();
                Input.Contrast();
                Input.DeepCleanBackgroundNoise();
                Input.EnhanceResolution();
                var Result = Ocr.Read(Input);
                //Console.WriteLine(Result.Text);
                return Result.Text;
                }

            }


        string ImageToTextCroped(string img)
            {
            var Ocr = new IronTesseract();
            using (var Input = new OcrInput())
                {
                Input.Deskew();  // use if image not straight
                Input.DeNoise(); // use if image contains digital noise
                Input.ToGrayScale();
                Input.Contrast();
                Input.DeepCleanBackgroundNoise();
                Input.EnhanceResolution();

                //var ContentAreaStudentInfo = new Rectangle() { X = 5, Y = 1, Height = 110, Width = 467 };
                //Input.AddImage(img, ContentAreaStudentInfo);
                //var ContentAreaMarkInfo = new Rectangle() { X = 234, Y = 528, Height = 30, Width = 265 };
                //Input.AddImage(img, ContentAreaMarkInfo);
                //var Result = Ocr.Read(Input);

                var ContentAreaStudentInfo = new Rectangle() { X = 10, Y = 5, Height = 140, Width = 580 };
                var ContentAreaMarkInfo = new Rectangle() { X = 180, Y = 520, Height = 40, Width = 400 };
                var ResultS = Ocr.Read(img, ContentAreaStudentInfo);
                var ResultM = Ocr.Read(img, ContentAreaMarkInfo);

                string newline = "\r\n"; //ata new line er jonno
                var Result = ResultS.Text.Trim() + newline + ResultM.Text.Trim() + newline;
                studentlist(Result);
                return Result;
                }
            }

        void studentlist(string studentinfo)
            {
            string input = studentinfo;
            infoTable = new Hashtable();
            string[] singleArray = input.Split('\n');
            /*
             Exam Name: Semester Final Exam B. Sc. in CSE
             ID: 1702028 Reg.: 07598
             Semester: 5 Course Code: CCE-321
             Date: 28-06-21
             Total Obtained Mark =79
             */

            for (int i = 0; i < singleArray.Length - 1; i++)
                {
                if (i == 1)
                    {
                    string idreg = singleArray[i];
                    string idpart = "";
                    string regpart = "";
                    for (int j = 0; j < idreg.Length; j++)
                        {
                        if (j <= 10) idpart += idreg[j];
                        else regpart += idreg[j];
                        }
                    string[] keyValueid = idpart.Split(':');
                    infoTable.Add(keyValueid[0].Trim(), keyValueid[1].Trim());
                    string[] keyValuereg = regpart.Split(':');
                    infoTable.Add(keyValuereg[0].Trim(), keyValuereg[1].Trim());
                    }
                else if (i == 2)
                    {
                    string SemCC = singleArray[i];
                    string sempart = "";
                    string ccpart = "";
                    for (int j = 0; j < SemCC.Length; j++)
                        {
                        if (j <= 10) sempart += SemCC[j];
                        else ccpart += SemCC[j];
                        }
                    string[] keyValuesem = sempart.Split(':');
                    infoTable.Add(keyValuesem[0].Trim(), keyValuesem[1].Trim());
                    string[] keyValuecc = ccpart.Split(':');
                    infoTable.Add(keyValuecc[0].Trim(), keyValuecc[1].Trim());
                    }
                else
                    {
                    string[] keyValue = singleArray[i].Split(new Char[] { ':', '=' });
                    infoTable.Add(keyValue[0].Trim(), keyValue[1].Trim());
                    }

                //MessageBox.Show(singleArray[i]);
                }
            //Student = new List<Hashtable>();
            Student.Add(infoTable);
            }

        void insertStudentDataTable()
            {

                StudentDataTable.Columns.Add("SL", typeof(int));
                StudentDataTable.Columns.Add("ID", typeof(string));
                StudentDataTable.Columns.Add("Reg", typeof(string));
                //StudentDataTable.Columns.Add("Session", typeof(string));
                StudentDataTable.Columns.Add("Semester", typeof(string));
                StudentDataTable.Columns.Add("Course_Code", typeof(string));
                StudentDataTable.Columns.Add("Mark", typeof(string));
                StudentDataTable.Columns.Add("GPA", typeof(string));
                StudentDataTable.Columns.Add("Grade", typeof(string));
                StudentDataTable.Columns.Add("Exam_Name", typeof(string));
                StudentDataTable.Columns.Add("Date", typeof(string));

            int scount = 0;
            foreach (var student in Student)
                {
                ++scount;
                int i = 0;
                string grade = "N/A";
                string gpa = "N/A";
                string [] rowval = {"","","","","","","","",""};
                foreach (var key in student.Keys)
                    {
                    i++;
                    rowval[i] = student[key].ToString();
                    if (i == 6)
                        {
                        int mark = Convert.ToInt16(rowval[6]);
                        //grade = calculateGPA(mark);
                       Tuple <double,string> ggpa = calculateGPAGrade(mark);
                        gpa = Convert.ToString(ggpa.Item1);
                        grade = ggpa.Item2;
                        }
                    }
                //StudentDataTable.Rows.Add(scount,rowval[1], rowval[2], rowval[5], rowval[3], rowval[4], rowval[7], rowval[0], rowval[6]);
                StudentDataTable.Rows.Add(scount,rowval[3], rowval[4], rowval[1], rowval[5], rowval[6], gpa, grade, rowval[2], rowval[7]);
              // insertStudentResult(scount, rowval[3], rowval[4], rowval[1], Convert.ToDouble(rowval[5]), rowval[6], Convert.ToDouble(gpa), Convert.ToDouble(grade), rowval[2], rowval[7]);

                }

            dataGridViewPaper.DataSource = StudentDataTable;

            }

        string calculateGrade(int mark)
            {
            if (mark < 0 || mark > 100)
                {
                MessageBox.Show("Sorry Invalid Input. Please Type valid Input");
                return "N/A";
                }
            else if (mark >= 80 && mark <= 100)
                { return "A+"; } //4.00
            else if (mark >= 75 && mark <= 79)
                { return "A"; } //3.75
            else if (mark >= 70 && mark <= 74)
                { return "A-"; } //3.50
            else if (mark >= 65 && mark <= 69)
                { return "B+"; } //3.25
            else if (mark >= 60 && mark <= 64)
                { return "B"; } //3.00
            else if (mark >= 55 && mark <= 59)
                { return "B-"; } //2.75
            else if (mark >= 50 && mark <= 54)
                { return "C+"; } //2.50
            else if (mark >= 45 && mark <= 49)
                { return "C"; } //2.25
            else if (mark >= 40 && mark <= 44)
                { return "D"; } //2.00
            else
                { return "F"; }

            }

        Tuple<double , string > calculateGPAGrade(int mark)
            {
            if (mark < 0 || mark > 100)
                {
                MessageBox.Show("Sorry Invalid Input. Please Type valid Input");
                Tuple<double, string> gragpa = Tuple.Create(0.00, "N/A");
                return gragpa;
                }
            else if (mark >= 80 && mark <= 100)
                {
                Tuple<double, string> gragpa = Tuple.Create(4.00, "A+");
                return gragpa;
                } //4.00
            else if (mark >= 75 && mark <= 79)
                {
                Tuple<double, string> gragpa = Tuple.Create(3.75, "A");
                return gragpa;
                }
            else if (mark >= 70 && mark <= 74)
                {
                Tuple<double, string> gragpa = Tuple.Create(3.50, "A-");
                return gragpa;
                } //3.50
            else if (mark >= 65 && mark <= 69)
                {
                Tuple<double, string> gragpa = Tuple.Create(3.25, "B+");
                return gragpa;
                } //3.25
            else if (mark >= 60 && mark <= 64)
                {
                Tuple<double, string> gragpa = Tuple.Create(3.00, "B");
                return gragpa;
                } //3.00
            else if (mark >= 55 && mark <= 59)
                {
                Tuple<double, string> gragpa = Tuple.Create(2.75, "B-");
                return gragpa;
                 } //2.75
            else if (mark >= 50 && mark <= 54)
                {
                Tuple<double, string> gragpa = Tuple.Create(2.50, "C+");
                return gragpa;
                } //2.50
            else if (mark >= 45 && mark <= 49)
                {
                Tuple<double, string> gragpa = Tuple.Create(2.25, "C");
                return gragpa;
                } //2.25
            else if (mark >= 40 && mark <= 44)
                {
                Tuple<double, string> gragpa = Tuple.Create(2.00, "D");
                return gragpa;
                } //2.00
            else
                {
                Tuple<double, string> gragpa = Tuple.Create(0.00, "F");
                return gragpa;
                }
            
            }


        void texboxpulate()
            {
            int stucount = 0;
            foreach (var student in Student)
                {
                ++stucount;
                //Console.WriteLine("Student:" + Student.LastIndexOf(student));
                textBox1.AppendText("Student: " + stucount);
                textBox1.AppendText("\r\n");
                foreach (var key in student.Keys)
                    {
                    //Console.WriteLine(key + ": " + student[key]);
                    textBox1.AppendText(key + " : " + student[key].ToString());
                    textBox1.AppendText("\r\n");
                    }
                textBox1.AppendText("\r\n");

                }
            }

        void insertStudentResult(int sl, string name, string idNo,string regNo, string semester, string cCode, double mark, double courseGPA, string courseGrade, string date)
            {

                try
                    {
                       // int sl = 0;
                        //string name = "";
                        //string idNo = "";
                        //string regNo = "";
                        //string semester = "";
                        //string cTitle = "";
                        //string cCode = "";
                        //double creditHr = 0.0;
                        //double courseGPA = 0.0;
                        //string courseGrade = "";
                        //string date = ""; 
                        
                        string query = "INSERT INTO CourseResult(SL, S_Name, IDNo, RegNo, Semester, CTitle, CCode, Mark, CourseGPA, CourseGrade, Date)" +
                        "VALUES (@sl, @name, @idNo, @regNo, @semester, @cTitle, @cCode, @mark, @courseGPA, @courseGrade, @date)";
                        //string query = "INSERT INTO Student(Student_ID, Student_Name, Student_Reg, Student_Session, Student_Semester, Student_Mobile, Student_Fingerprint_ID)" +
                        // "VALUES (@student_id, @student_name, @student_registration, @student_session, @student_semester, @student_mobile, @int_student_fingerprint)";
                        SqlCommand insertCommand = new SqlCommand(query);
                        insertCommand.Parameters.AddWithValue("@sl", sl);
                        insertCommand.Parameters.AddWithValue("@name", name);
                        insertCommand.Parameters.AddWithValue("@idNo", idNo);
                        insertCommand.Parameters.AddWithValue("@regNo", regNo);
                        insertCommand.Parameters.AddWithValue("@semester", semester);
                        insertCommand.Parameters.AddWithValue("@cCode", cCode);
                        insertCommand.Parameters.AddWithValue("@mark", mark);
                        insertCommand.Parameters.AddWithValue("@courseGPA", courseGPA);
                        insertCommand.Parameters.AddWithValue("@courseGrade", courseGrade);
                        insertCommand.Parameters.AddWithValue("@date", date);
                        
                        int row = dbAccess.executeQuery(insertCommand);
                        dbAccess.closeConn();
                if (row == 1) MessageBox.Show("Inserted");
                }
                catch (Exception ex)
                    {
                    MessageBox.Show(ex.Message);
                    }
                
            }

        private void buttonBack_Click(object sender, EventArgs e)
            {
            this.Hide();
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.Show();
            }
        }
    }
