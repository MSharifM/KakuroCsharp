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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.webBQuestion = new System.Windows.Forms.WebBrowser();
            this.webBSolve = new System.Windows.Forms.WebBrowser();
            this.btnBackTrackFC = new System.Windows.Forms.Button();
            this.btnBackTrack = new System.Windows.Forms.Button();
            this.btnMinConflict = new System.Windows.Forms.Button();
            this.btnBackTrackMRV = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // webBQuestion
            // 
            this.webBQuestion.Location = new System.Drawing.Point(12, 64);
            this.webBQuestion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBQuestion.MinimumSize = new System.Drawing.Size(18, 15);
            this.webBQuestion.Name = "webBQuestion";
            this.webBQuestion.Size = new System.Drawing.Size(264, 236);
            this.webBQuestion.TabIndex = 1;
            this.webBQuestion.Visible = false;
            // 
            // webBSolve
            // 
            this.webBSolve.Location = new System.Drawing.Point(394, 64);
            this.webBSolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBSolve.MinimumSize = new System.Drawing.Size(18, 15);
            this.webBSolve.Name = "webBSolve";
            this.webBSolve.Size = new System.Drawing.Size(264, 236);
            this.webBSolve.TabIndex = 2;
            this.webBSolve.Visible = false;
            // 
            // btnBackTrackFC
            // 
            this.btnBackTrackFC.BackColor = System.Drawing.Color.Lime;
            this.btnBackTrackFC.Font = new System.Drawing.Font("Nazanin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBackTrackFC.ForeColor = System.Drawing.Color.Black;
            this.btnBackTrackFC.Location = new System.Drawing.Point(151, 11);
            this.btnBackTrackFC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBackTrackFC.Name = "btnBackTrackFC";
            this.btnBackTrackFC.Size = new System.Drawing.Size(125, 47);
            this.btnBackTrackFC.TabIndex = 5;
            this.btnBackTrackFC.Text = "BackTrack - FC";
            this.btnBackTrackFC.UseVisualStyleBackColor = false;
            this.btnBackTrackFC.Click += new System.EventHandler(this.btnBackTrackFC_Click);
            // 
            // btnBackTrack
            // 
            this.btnBackTrack.BackColor = System.Drawing.Color.Lime;
            this.btnBackTrack.Font = new System.Drawing.Font("Nazanin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBackTrack.ForeColor = System.Drawing.Color.Black;
            this.btnBackTrack.Location = new System.Drawing.Point(394, 11);
            this.btnBackTrack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBackTrack.Name = "btnBackTrack";
            this.btnBackTrack.Size = new System.Drawing.Size(125, 47);
            this.btnBackTrack.TabIndex = 6;
            this.btnBackTrack.Text = "BackTrack";
            this.btnBackTrack.UseVisualStyleBackColor = false;
            this.btnBackTrack.Click += new System.EventHandler(this.btnBackTrack_Click);
            // 
            // btnMinConflict
            // 
            this.btnMinConflict.BackColor = System.Drawing.Color.Lime;
            this.btnMinConflict.Font = new System.Drawing.Font("Nazanin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMinConflict.ForeColor = System.Drawing.Color.Black;
            this.btnMinConflict.Location = new System.Drawing.Point(533, 11);
            this.btnMinConflict.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinConflict.Name = "btnMinConflict";
            this.btnMinConflict.Size = new System.Drawing.Size(125, 47);
            this.btnMinConflict.TabIndex = 7;
            this.btnMinConflict.Text = "MinConflict";
            this.btnMinConflict.UseVisualStyleBackColor = false;
            this.btnMinConflict.Click += new System.EventHandler(this.btnMinConflict_Click);
            // 
            // btnBackTrackMRV
            // 
            this.btnBackTrackMRV.BackColor = System.Drawing.Color.Lime;
            this.btnBackTrackMRV.Font = new System.Drawing.Font("Nazanin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBackTrackMRV.ForeColor = System.Drawing.Color.Black;
            this.btnBackTrackMRV.Location = new System.Drawing.Point(13, 11);
            this.btnBackTrackMRV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBackTrackMRV.Name = "btnBackTrackMRV";
            this.btnBackTrackMRV.Size = new System.Drawing.Size(125, 47);
            this.btnBackTrackMRV.TabIndex = 8;
            this.btnBackTrackMRV.Text = "BackTrack-FC-MRV";
            this.btnBackTrackMRV.UseVisualStyleBackColor = false;
            this.btnBackTrackMRV.Click += new System.EventHandler(this.btnBackTrackMRV_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(282, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(669, 344);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBackTrackMRV);
            this.Controls.Add(this.btnMinConflict);
            this.Controls.Add(this.btnBackTrack);
            this.Controls.Add(this.btnBackTrackFC);
            this.Controls.Add(this.webBSolve);
            this.Controls.Add(this.webBQuestion);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kakuro";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.WebBrowser webBQuestion;
        private System.Windows.Forms.WebBrowser webBSolve;
        private System.Windows.Forms.Button btnBackTrackFC;
        private System.Windows.Forms.Button btnBackTrack;
        private System.Windows.Forms.Button btnMinConflict;
        private System.Windows.Forms.Button btnBackTrackMRV;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

