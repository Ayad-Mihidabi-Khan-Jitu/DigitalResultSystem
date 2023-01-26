
namespace DigitalResultSystem
    {
    partial class TeacherForm
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.buttonManageStudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrntUser = new System.Windows.Forms.Label();
            this.buttonProcessResult = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonManageStudent
            // 
            this.buttonManageStudent.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonManageStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageStudent.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonManageStudent.Location = new System.Drawing.Point(183, 163);
            this.buttonManageStudent.Name = "buttonManageStudent";
            this.buttonManageStudent.Size = new System.Drawing.Size(190, 132);
            this.buttonManageStudent.TabIndex = 1;
            this.buttonManageStudent.Text = "Manage Students";
            this.buttonManageStudent.UseVisualStyleBackColor = false;
            this.buttonManageStudent.Click += new System.EventHandler(this.buttonManageStudent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hello!!";
            // 
            // labelCurrntUser
            // 
            this.labelCurrntUser.AutoSize = true;
            this.labelCurrntUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrntUser.Location = new System.Drawing.Point(122, 29);
            this.labelCurrntUser.Name = "labelCurrntUser";
            this.labelCurrntUser.Size = new System.Drawing.Size(40, 29);
            this.labelCurrntUser.TabIndex = 3;
            this.labelCurrntUser.Text = "---";
            // 
            // buttonProcessResult
            // 
            this.buttonProcessResult.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonProcessResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProcessResult.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonProcessResult.Location = new System.Drawing.Point(404, 163);
            this.buttonProcessResult.Name = "buttonProcessResult";
            this.buttonProcessResult.Size = new System.Drawing.Size(174, 132);
            this.buttonProcessResult.TabIndex = 4;
            this.buttonProcessResult.Text = "Process Result";
            this.buttonProcessResult.UseVisualStyleBackColor = false;
            this.buttonProcessResult.Click += new System.EventHandler(this.buttonProcessResult_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DigitalResultSystem.Properties.Resources.logout;
            this.pictureBox1.Location = new System.Drawing.Point(683, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonProcessResult);
            this.Controls.Add(this.labelCurrntUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonManageStudent);
            this.Name = "TeacherForm";
            this.Text = "TeacherForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Button buttonManageStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrntUser;
        private System.Windows.Forms.Button buttonProcessResult;
        private System.Windows.Forms.PictureBox pictureBox1;
        }
    }