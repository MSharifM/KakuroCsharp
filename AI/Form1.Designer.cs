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
            this.webBQuestion = new System.Windows.Forms.WebBrowser();
            this.webBSolve = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBackTrackFC = new System.Windows.Forms.Button();
            this.btnBackTrack = new System.Windows.Forms.Button();
            this.btnMinConflict = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            // btnBackTrackFC
            // 
            this.btnBackTrackFC.BackColor = System.Drawing.Color.Aqua;
            this.btnBackTrackFC.Font = new System.Drawing.Font("Nazanin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBackTrackFC.ForeColor = System.Drawing.Color.Black;
            this.btnBackTrackFC.Location = new System.Drawing.Point(13, 18);
            this.btnBackTrackFC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBackTrackFC.Name = "btnBackTrackFC";
            this.btnBackTrackFC.Size = new System.Drawing.Size(102, 35);
            this.btnBackTrackFC.TabIndex = 5;
            this.btnBackTrackFC.Text = "BackTrack - FC";
            this.btnBackTrackFC.UseVisualStyleBackColor = false;
            // 
            // btnBackTrack
            // 
            this.btnBackTrack.BackColor = System.Drawing.Color.Aqua;
            this.btnBackTrack.Font = new System.Drawing.Font("Nazanin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBackTrack.ForeColor = System.Drawing.Color.Black;
            this.btnBackTrack.Location = new System.Drawing.Point(211, 18);
            this.btnBackTrack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBackTrack.Name = "btnBackTrack";
            this.btnBackTrack.Size = new System.Drawing.Size(100, 35);
            this.btnBackTrack.TabIndex = 6;
            this.btnBackTrack.Text = "BackTrack";
            this.btnBackTrack.UseVisualStyleBackColor = false;
            this.btnBackTrack.Click += new System.EventHandler(this.btnBackTrack_Click);
            // 
            // btnMinConflict
            // 
            this.btnMinConflict.BackColor = System.Drawing.Color.Aqua;
            this.btnMinConflict.Font = new System.Drawing.Font("Nazanin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMinConflict.ForeColor = System.Drawing.Color.Black;
            this.btnMinConflict.Location = new System.Drawing.Point(419, 18);
            this.btnMinConflict.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMinConflict.Name = "btnMinConflict";
            this.btnMinConflict.Size = new System.Drawing.Size(100, 35);
            this.btnMinConflict.TabIndex = 7;
            this.btnMinConflict.Text = "MinConflict";
            this.btnMinConflict.UseVisualStyleBackColor = false;
            this.btnMinConflict.Click += new System.EventHandler(this.btnMinConflict_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 378);
            this.Controls.Add(this.btnMinConflict);
            this.Controls.Add(this.btnBackTrack);
            this.Controls.Add(this.btnBackTrackFC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBSolve);
            this.Controls.Add(this.webBQuestion);
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
        private System.Windows.Forms.WebBrowser webBQuestion;
        private System.Windows.Forms.WebBrowser webBSolve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBackTrackFC;
        private System.Windows.Forms.Button btnBackTrack;
        private System.Windows.Forms.Button btnMinConflict;
    }
}

