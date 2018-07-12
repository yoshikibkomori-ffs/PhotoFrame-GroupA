namespace PhotoFrameApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.SelectDir = new System.Windows.Forms.Button();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Display = new System.Windows.Forms.Button();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.DateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.SelectDate = new System.Windows.Forms.Button();
            this.KeywordBox1 = new System.Windows.Forms.ComboBox();
            this.SelectKeyword = new System.Windows.Forms.Button();
            this.SelectFavorite = new System.Windows.Forms.Button();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.KeywordBox2 = new System.Windows.Forms.ComboBox();
            this.AddKeyword = new System.Windows.Forms.Button();
            this.ToggleFavorite = new System.Windows.Forms.Button();
            this.SlideShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox1.BackColor = System.Drawing.Color.White;
            this.TextBox1.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.TextBox1.Location = new System.Drawing.Point(20, 30);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.Size = new System.Drawing.Size(420, 26);
            this.TextBox1.TabIndex = 0;
            // 
            // SelectDir
            // 
            this.SelectDir.Font = new System.Drawing.Font("Century", 10F);
            this.SelectDir.Location = new System.Drawing.Point(445, 29);
            this.SelectDir.Name = "SelectDir";
            this.SelectDir.Size = new System.Drawing.Size(90, 30);
            this.SelectDir.TabIndex = 1;
            this.SelectDir.Text = "Select Dir";
            this.SelectDir.UseVisualStyleBackColor = true;
            this.SelectDir.Click += new System.EventHandler(this.Click_SeachDir);
            // 
            // Display
            // 
            this.Display.Font = new System.Drawing.Font("Century", 10F);
            this.Display.Location = new System.Drawing.Point(550, 29);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(90, 30);
            this.Display.TabIndex = 2;
            this.Display.Text = "Display";
            this.Display.UseVisualStyleBackColor = true;
            this.Display.Click += new System.EventHandler(this.Display_Click);
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.CalendarFont = new System.Drawing.Font("HG明朝B", 14F);
            this.DateTimePicker1.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker1.Location = new System.Drawing.Point(20, 75);
            this.DateTimePicker1.MaxDate = new System.DateTime(2018, 7, 11, 19, 46, 4, 0);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(240, 26);
            this.DateTimePicker1.TabIndex = 3;
            this.DateTimePicker1.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("HG明朝B", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.Location = new System.Drawing.Point(263, 84);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(29, 19);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "～";
            // 
            // DateTimePicker2
            // 
            this.DateTimePicker2.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker2.Location = new System.Drawing.Point(295, 75);
            this.DateTimePicker2.MaxDate = new System.DateTime(2002, 7, 12, 0, 0, 0, 0);
            this.DateTimePicker2.Name = "DateTimePicker2";
            this.DateTimePicker2.Size = new System.Drawing.Size(240, 26);
            this.DateTimePicker2.TabIndex = 5;
            this.DateTimePicker2.Value = new System.DateTime(2002, 7, 12, 0, 0, 0, 0);
            this.DateTimePicker2.ValueChanged += new System.EventHandler(this.DateTimePicker2_ValueChanged);
            // 
            // SelectDate
            // 
            this.SelectDate.Font = new System.Drawing.Font("Century", 10F);
            this.SelectDate.Location = new System.Drawing.Point(550, 75);
            this.SelectDate.Name = "SelectDate";
            this.SelectDate.Size = new System.Drawing.Size(90, 30);
            this.SelectDate.TabIndex = 6;
            this.SelectDate.Text = "Select Date";
            this.SelectDate.UseVisualStyleBackColor = true;
            this.SelectDate.Click += new System.EventHandler(this.SelectDate_Click);
            // 
            // KeywordBox1
            // 
            this.KeywordBox1.BackColor = System.Drawing.Color.White;
            this.KeywordBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.KeywordBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeywordBox1.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.KeywordBox1.FormattingEnabled = true;
            this.KeywordBox1.Location = new System.Drawing.Point(20, 120);
            this.KeywordBox1.Name = "KeywordBox1";
            this.KeywordBox1.Size = new System.Drawing.Size(240, 27);
            this.KeywordBox1.TabIndex = 7;
            // 
            // SelectKeyword
            // 
            this.SelectKeyword.Font = new System.Drawing.Font("Century", 10F);
            this.SelectKeyword.Location = new System.Drawing.Point(263, 120);
            this.SelectKeyword.Name = "SelectKeyword";
            this.SelectKeyword.Size = new System.Drawing.Size(90, 30);
            this.SelectKeyword.TabIndex = 8;
            this.SelectKeyword.Text = "Select Key";
            this.SelectKeyword.UseVisualStyleBackColor = true;
            // 
            // SelectFavorite
            // 
            this.SelectFavorite.Font = new System.Drawing.Font("Century", 10F);
            this.SelectFavorite.Location = new System.Drawing.Point(550, 120);
            this.SelectFavorite.Name = "SelectFavorite";
            this.SelectFavorite.Size = new System.Drawing.Size(90, 30);
            this.SelectFavorite.TabIndex = 9;
            this.SelectFavorite.Text = "Select Fav";
            this.SelectFavorite.UseVisualStyleBackColor = true;
            // 
            // ListView1
            // 
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.ListView1.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ListView1.FullRowSelect = true;
            this.ListView1.LabelWrap = false;
            this.ListView1.Location = new System.Drawing.Point(20, 165);
            this.ListView1.Name = "ListView1";
            this.ListView1.OwnerDraw = true;
            this.ListView1.Size = new System.Drawing.Size(333, 280);
            this.ListView1.TabIndex = 10;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Keyword";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "★";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 25;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 80;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.PictureBox1.Location = new System.Drawing.Point(360, 165);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(280, 280);
            this.PictureBox1.TabIndex = 14;
            this.PictureBox1.TabStop = false;
            // 
            // KeywordBox2
            // 
            this.KeywordBox2.DropDownWidth = 265;
            this.KeywordBox2.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.KeywordBox2.FormattingEnabled = true;
            this.KeywordBox2.Location = new System.Drawing.Point(20, 460);
            this.KeywordBox2.Name = "KeywordBox2";
            this.KeywordBox2.Size = new System.Drawing.Size(240, 27);
            this.KeywordBox2.TabIndex = 11;
            // 
            // AddKeyword
            // 
            this.AddKeyword.Font = new System.Drawing.Font("Century", 10F);
            this.AddKeyword.Location = new System.Drawing.Point(263, 460);
            this.AddKeyword.Name = "AddKeyword";
            this.AddKeyword.Size = new System.Drawing.Size(90, 30);
            this.AddKeyword.TabIndex = 12;
            this.AddKeyword.Text = "Add Key";
            this.AddKeyword.UseVisualStyleBackColor = true;
            // 
            // ToggleFavorite
            // 
            this.ToggleFavorite.Font = new System.Drawing.Font("Century", 10F);
            this.ToggleFavorite.Location = new System.Drawing.Point(360, 460);
            this.ToggleFavorite.Name = "ToggleFavorite";
            this.ToggleFavorite.Size = new System.Drawing.Size(90, 30);
            this.ToggleFavorite.TabIndex = 13;
            this.ToggleFavorite.Text = "Toggle Fav";
            this.ToggleFavorite.UseVisualStyleBackColor = true;
            // 
            // SlideShow
            // 
            this.SlideShow.Font = new System.Drawing.Font("Century", 10F);
            this.SlideShow.Location = new System.Drawing.Point(550, 460);
            this.SlideShow.Name = "SlideShow";
            this.SlideShow.Size = new System.Drawing.Size(90, 30);
            this.SlideShow.TabIndex = 15;
            this.SlideShow.Text = "Slide Show";
            this.SlideShow.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 507);
            this.Controls.Add(this.SlideShow);
            this.Controls.Add(this.ToggleFavorite);
            this.Controls.Add(this.AddKeyword);
            this.Controls.Add(this.KeywordBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.SelectFavorite);
            this.Controls.Add(this.SelectKeyword);
            this.Controls.Add(this.KeywordBox1);
            this.Controls.Add(this.SelectDate);
            this.Controls.Add(this.DateTimePicker2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.SelectDir);
            this.Controls.Add(this.TextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Button SelectDir;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.Button Display;
        private System.Windows.Forms.DateTimePicker DateTimePicker1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DateTimePicker DateTimePicker2;
        private System.Windows.Forms.Button SelectDate;
        private System.Windows.Forms.ComboBox KeywordBox1;
        private System.Windows.Forms.Button SelectKeyword;
        private System.Windows.Forms.Button SelectFavorite;
        private System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.ComboBox KeywordBox2;
        private System.Windows.Forms.Button AddKeyword;
        private System.Windows.Forms.Button ToggleFavorite;
        private System.Windows.Forms.Button SlideShow;
    }
}

