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
    public partial class Splash : Form
        {
        public Splash()
            {
            InitializeComponent();
            }

        private void Splash_Load(object sender, EventArgs e)
            {
            ProgressTimer.Start();
            }

        int startpoint = 0;
        private void ProgressTimer_Tick(object sender, EventArgs e)
            {
            startpoint += 1;
            progressBar1.Value = startpoint;
            if (progressBar1.Value == 100)
                {
                progressBar1.Value = 0;
                ProgressTimer.Stop();
                Login login = new Login();
                this.Hide();
                login.Show();
                }
            }

 
        }
    }
