using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;

namespace DigitalResultSystem
    {
    public partial class ExecutionFrom : Form
        {
        List<Hashtable> Student = new List<Hashtable>();
        //List<Hashtable> Student;
        Hashtable infoTable;
        string path = "";
        public ExecutionFrom()
            {
            InitializeComponent();
            }
        
        private void buttonPress_Click(object sender, EventArgs e)
            {
            //textBoxResult.Text = ImageToText(@"C:\Users\HP 840 G1\Desktop\Biometric\ScanImages\Papers3croped.jpg");
            getMultipleImage(path);
            texboxpulate();
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
                textBoxResult.AppendText(ImageToTextCroped(imageFile)+ Environment.NewLine);

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
                var ResultS = Ocr.Read(img,ContentAreaStudentInfo);
                var ResultM = Ocr.Read(img,ContentAreaMarkInfo);

                string newline = "\r\n"; //ata new line er jonno
                var Result = ResultS.Text.Trim() + newline + ResultM.Text.Trim()+ newline;
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

            for (int i = 0; i < singleArray.Length-1; i++)
                    {
                        if(i==1)
                        {
                        string idreg = singleArray[i];
                        string idpart = "";
                        string regpart = "";
                        for (int j=0;j< idreg.Length; j++)
                            {
                            if (j <= 10) idpart += idreg[j];
                            else regpart += idreg[j];
                            }
                        string[] keyValueid = idpart.Split(':');
                        infoTable.Add(keyValueid[0].Trim(), keyValueid[1].Trim());
                        string[] keyValuereg = regpart.Split(':');
                        infoTable.Add(keyValuereg[0].Trim(), keyValuereg[1].Trim());
                        }
                        else if (i==2)
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


        }
    }
