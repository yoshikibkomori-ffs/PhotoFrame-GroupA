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
            this.components = new System.ComponentModel.Container();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PrevBox = new System.Windows.Forms.PictureBox();
            this.NextBox = new System.Windows.Forms.PictureBox();
            this.StartStopBox = new System.Windows.Forms.PictureBox();
            this.RandomBox = new System.Windows.Forms.PictureBox();
            this.RepeatBox = new System.Windows.Forms.PictureBox();
            this.Timer_ChangeImg = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrevBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartStopBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.PictureBox1.Location = new System.Drawing.Point(67, 22);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(900, 600);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            // 
            // PrevBox
            // 
            this.PrevBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PrevBox.Location = new System.Drawing.Point(12, 269);
            this.PrevBox.Name = "PrevBox";
            this.PrevBox.Size = new System.Drawing.Size(50, 100);
            this.PrevBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PrevBox.TabIndex = 1;
            this.PrevBox.TabStop = false;
            this.PrevBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Previous);
            this.PrevBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp_Previous);
            // 
            // NextBox
            // 
            this.NextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NextBox.Location = new System.Drawing.Point(973, 269);
            this.NextBox.Name = "NextBox";
            this.NextBox.Size = new System.Drawing.Size(50, 100);
            this.NextBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NextBox.TabIndex = 2;
            this.NextBox.TabStop = false;
            this.NextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Next);
            this.NextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp_Next);
            // 
            // StartStopBox
            // 
            this.StartStopBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StartStopBox.Location = new System.Drawing.Point(319, 645);
            this.StartStopBox.Name = "StartStopBox";
            this.StartStopBox.Size = new System.Drawing.Size(106, 54);
            this.StartStopBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StartStopBox.TabIndex = 3;
            this.StartStopBox.TabStop = false;
            this.StartStopBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Start_Stop);
            this.StartStopBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp_Start_Stop);
            // 
            // RandomBox
            // 
            this.RandomBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RandomBox.Location = new System.Drawing.Point(469, 645);
            this.RandomBox.Name = "RandomBox";
            this.RandomBox.Size = new System.Drawing.Size(106, 54);
            this.RandomBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RandomBox.TabIndex = 4;
            this.RandomBox.TabStop = false;
            this.RandomBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Random);
            this.RandomBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp_Random);
            // 
            // RepeatBox
            // 
            this.RepeatBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RepeatBox.Location = new System.Drawing.Point(613, 645);
            this.RepeatBox.Name = "RepeatBox";
            this.RepeatBox.Size = new System.Drawing.Size(106, 54);
            this.RepeatBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RepeatBox.TabIndex = 5;
            this.RepeatBox.TabStop = false;
            this.RepeatBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Repeat);
            this.RepeatBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp_Repeat);
            // 
            // Timer_ChangeImg
            // 
            this.Timer_ChangeImg.Interval = 3000;
            this.Timer_ChangeImg.Tick += new System.EventHandler(this.Timer_ChangeImg_Tick);
            // 
            // SlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 712);
            this.Controls.Add(this.RepeatBox);
            this.Controls.Add(this.RandomBox);
            this.Controls.Add(this.StartStopBox);
            this.Controls.Add(this.NextBox);
            this.Controls.Add(this.PrevBox);
            this.Controls.Add(this.PictureBox1);
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "SlideShow";
            this.Text = "SlideShow";
            this.Load += new System.EventHandler(this.SlideShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrevBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartStopBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.PictureBox PrevBox;
        private System.Windows.Forms.PictureBox NextBox;
        private System.Windows.Forms.PictureBox StartStopBox;
        private System.Windows.Forms.PictureBox RandomBox;
        private System.Windows.Forms.PictureBox RepeatBox;
        private System.Windows.Forms.Timer Timer_ChangeImg;
    }
}