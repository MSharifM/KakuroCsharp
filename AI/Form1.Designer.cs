namespace AI
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.webBQuestion = new System.Windows.Forms.WebBrowser();
            this.webBSolve = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnInputFile
            // 
            this.btnInputFile.BackColor = System.Drawing.Color.Lime;
            this.btnInputFile.Font = new System.Drawing.Font("Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnInputFile.ForeColor = System.Drawing.Color.Black;
            this.btnInputFile.Location = new System.Drawing.Point(216, 18);
            this.btnInputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(100, 35);
            this.btnInputFile.TabIndex = 0;
            this.btnInputFile.Text = "انتخاب فایل";
            this.btnInputFile.UseVisualStyleBackColor = false;
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // webBQuestion
            // 
            this.webBQuestion.Location = new System.Drawing.Point(12, 61);
            this.webBQuestion.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBQuestion.Name = "webBQuestion";
            this.webBQuestion.Size = new System.Drawing.Size(250, 232);
            this.webBQuestion.TabIndex = 1;
            // 
            // webBSolve
            // 
            this.webBSolve.Location = new System.Drawing.Point(270, 61);
            this.webBSolve.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBSolve.Name = "webBSolve";
            this.webBSolve.Size = new System.Drawing.Size(250, 232);
            this.webBSolve.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(113, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "سوال";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(370, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "پاسخ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBSolve);
            this.Controls.Add(this.webBQuestion);
            this.Controls.Add(this.btnInputFile);
            this.Font = new System.Drawing.Font("Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.WebBrowser webBQuestion;
        private System.Windows.Forms.WebBrowser webBSolve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

