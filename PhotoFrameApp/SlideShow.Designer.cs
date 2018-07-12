namespace PhotoFrameApp
{
    partial class SlideShow
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

        // <summary>
        // Required method for Designer support - do not modify
        // the contents of this method with the code editor.
        // </summary>
        private void InitializeComponent()
        {
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.NextBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.PictureBox1.Location = new System.Drawing.Point(44, 38);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(900, 600);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // NextBox2
            // 
            this.NextBox2.Location = new System.Drawing.Point(12, 269);
            this.NextBox2.Name = "NextBox2";
            this.NextBox2.Size = new System.Drawing.Size(26, 97);
            this.NextBox2.TabIndex = 1;
            this.NextBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(950, 269);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 97);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(317, 671);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(105, 46);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(445, 671);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(105, 46);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(567, 671);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(105, 46);
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // SlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 762);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.NextBox2);
            this.Controls.Add(this.PictureBox1);
            this.Name = "SlideShow";
            this.Text = "SlideShow";
            this.Load += new System.EventHandler(this.SlideShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.PictureBox NextBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}



//private void InitializeComponent()
//{
//    this.components = new System.ComponentModel.Container();
//    this.timer_ChangePhoto = new System.Windows.Forms.Timer(this.components);
//    this.PictureBox1 = new System.Windows.Forms.PictureBox();
//    ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
//    this.SuspendLayout();
//    // 
//    // timer_ChangePhoto
//    // 
//    this.timer_ChangePhoto.Tick += new System.EventHandler(this.timer_ChangePhoto_Tick);
//    // 
//    // PictureBox1
//    // 
//    this.PictureBox1.Location = new System.Drawing.Point(44, 38);
//    this.PictureBox1.Name = "PictureBox1";
//    this.PictureBox1.Size = new System.Drawing.Size(900, 600);
//    this.PictureBox1.TabIndex = 0;
//    this.PictureBox1.TabStop = false;
//    this.PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
//    // 
//    // SlideShow
//    // 
//    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
//    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//    this.ClientSize = new System.Drawing.Size(984, 762);
//    this.Controls.Add(this.PictureBox1);
//    this.Name = "SlideShow";
//    this.Text = "SlideShow";
//    this.Load += new System.EventHandler(this.SlideShow_Load);
//    ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
//    this.ResumeLayout(false);

//}

//#endregion
//private System.Windows.Forms.Timer timer_ChangePhoto;
//private System.Windows.Forms.PictureBox PictureBox1;