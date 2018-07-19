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
            this.Directory_TextBox = new System.Windows.Forms.TextBox();
            this.SelectDir = new System.Windows.Forms.Button();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Display = new System.Windows.Forms.Button();
            this.Start_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.End_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SelectDate = new System.Windows.Forms.Button();
            this.Select_KeywordComboBox = new System.Windows.Forms.ComboBox();
            this.SelectKeyword = new System.Windows.Forms.Button();
            this.SelectFavorite = new System.Windows.Forms.Button();
            this.PhotoListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Preview_PictureBox = new System.Windows.Forms.PictureBox();
            this.Add_KeywordComboBox = new System.Windows.Forms.ComboBox();
            this.AddKeyword = new System.Windows.Forms.Button();
            this.ToggleFavorite = new System.Windows.Forms.Button();
            this.SlideShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Preview_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Directory_TextBox
            // 
            this.Directory_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Directory_TextBox.BackColor = System.Drawing.Color.White;
            this.Directory_TextBox.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.Directory_TextBox.Location = new System.Drawing.Point(20, 30);
            this.Directory_TextBox.Name = "Directory_TextBox";
            this.Directory_TextBox.ReadOnly = true;
            this.Directory_TextBox.Size = new System.Drawing.Size(420, 26);
            this.Directory_TextBox.TabIndex = 0;
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
            this.SelectDir.Click += new System.EventHandler(this.Click_SelectDir);
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
            this.Display.Click += new System.EventHandler(this.Click_Display);
            // 
            // Start_DateTimePicker
            // 
            this.Start_DateTimePicker.CalendarFont = new System.Drawing.Font("HG明朝B", 14F);
            this.Start_DateTimePicker.CustomFormat = "\"yyyy年mm月\"";
            this.Start_DateTimePicker.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.Start_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Start_DateTimePicker.Location = new System.Drawing.Point(20, 75);
            this.Start_DateTimePicker.MaxDate = new System.DateTime(2018, 7, 11, 19, 46, 4, 0);
            this.Start_DateTimePicker.Name = "Start_DateTimePicker";
            this.Start_DateTimePicker.Size = new System.Drawing.Size(240, 26);
            this.Start_DateTimePicker.TabIndex = 3;
            this.Start_DateTimePicker.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.Start_DateTimePicker.ValueChanged += new System.EventHandler(this.Click_StartCalenderDialog);
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
            // End_DateTimePicker
            // 
            this.End_DateTimePicker.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.End_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.End_DateTimePicker.Location = new System.Drawing.Point(295, 75);
            this.End_DateTimePicker.MaxDate = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            this.End_DateTimePicker.Name = "End_DateTimePicker";
            this.End_DateTimePicker.Size = new System.Drawing.Size(240, 26);
            this.End_DateTimePicker.TabIndex = 5;
            this.End_DateTimePicker.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            this.End_DateTimePicker.ValueChanged += new System.EventHandler(this.Click_EndCalenderDialog);
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
            this.SelectDate.Click += new System.EventHandler(this.Click_SelectDate);
            // 
            // Select_KeywordComboBox
            // 
            this.Select_KeywordComboBox.BackColor = System.Drawing.Color.White;
            this.Select_KeywordComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Select_KeywordComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Select_KeywordComboBox.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.Select_KeywordComboBox.FormattingEnabled = true;
            this.Select_KeywordComboBox.Location = new System.Drawing.Point(20, 120);
            this.Select_KeywordComboBox.Name = "Select_KeywordComboBox";
            this.Select_KeywordComboBox.Size = new System.Drawing.Size(240, 27);
            this.Select_KeywordComboBox.TabIndex = 7;
            this.Select_KeywordComboBox.SelectedIndexChanged += new System.EventHandler(this.Select_KeywordComboBox_SelectedIndexChanged);
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
            this.SelectKeyword.Click += new System.EventHandler(this.Click_SelectKeyword);
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
            this.SelectFavorite.Click += new System.EventHandler(this.Click_SelectFavorite);
            // 
            // PhotoListView
            // 
            this.PhotoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.PhotoListView.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PhotoListView.FullRowSelect = true;
            this.PhotoListView.LabelWrap = false;
            this.PhotoListView.Location = new System.Drawing.Point(20, 165);
            this.PhotoListView.Name = "PhotoListView";
            this.PhotoListView.OwnerDraw = true;
            this.PhotoListView.Size = new System.Drawing.Size(333, 280);
            this.PhotoListView.TabIndex = 10;
            this.PhotoListView.UseCompatibleStateImageBehavior = false;
            this.PhotoListView.View = System.Windows.Forms.View.Details;
            this.PhotoListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Click_DateSort);
            this.PhotoListView.SelectedIndexChanged += new System.EventHandler(this.Click_ShowPreview);
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
            // Preview_PictureBox
            // 
            this.Preview_PictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.Preview_PictureBox.Location = new System.Drawing.Point(360, 165);
            this.Preview_PictureBox.Name = "Preview_PictureBox";
            this.Preview_PictureBox.Size = new System.Drawing.Size(280, 280);
            this.Preview_PictureBox.TabIndex = 14;
            this.Preview_PictureBox.TabStop = false;
            // 
            // Add_KeywordComboBox
            // 
            this.Add_KeywordComboBox.DropDownWidth = 265;
            this.Add_KeywordComboBox.Font = new System.Drawing.Font("HG明朝B", 14F);
            this.Add_KeywordComboBox.FormattingEnabled = true;
            this.Add_KeywordComboBox.Location = new System.Drawing.Point(20, 460);
            this.Add_KeywordComboBox.Name = "Add_KeywordComboBox";
            this.Add_KeywordComboBox.Size = new System.Drawing.Size(240, 27);
            this.Add_KeywordComboBox.TabIndex = 11;
            this.Add_KeywordComboBox.SelectedIndexChanged += new System.EventHandler(this.Add_KeywordComboBox_SelectedIndexChanged);
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
            this.AddKeyword.Click += new System.EventHandler(this.Click_AddKeyword);
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
            this.ToggleFavorite.Click += new System.EventHandler(this.Click_AddFavorite);
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
            this.SlideShow.Click += new System.EventHandler(this.Click_SlideShow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 507);
            this.Controls.Add(this.SlideShow);
            this.Controls.Add(this.ToggleFavorite);
            this.Controls.Add(this.AddKeyword);
            this.Controls.Add(this.Add_KeywordComboBox);
            this.Controls.Add(this.Preview_PictureBox);
            this.Controls.Add(this.PhotoListView);
            this.Controls.Add(this.SelectFavorite);
            this.Controls.Add(this.SelectKeyword);
            this.Controls.Add(this.Select_KeywordComboBox);
            this.Controls.Add(this.SelectDate);
            this.Controls.Add(this.End_DateTimePicker);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Start_DateTimePicker);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.SelectDir);
            this.Controls.Add(this.Directory_TextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Preview_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Directory_TextBox;
        private System.Windows.Forms.Button SelectDir;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.Button Display;
        private System.Windows.Forms.DateTimePicker Start_DateTimePicker;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DateTimePicker End_DateTimePicker;
        private System.Windows.Forms.Button SelectDate;
        private System.Windows.Forms.ComboBox Select_KeywordComboBox;
        private System.Windows.Forms.Button SelectKeyword;
        private System.Windows.Forms.Button SelectFavorite;
        private System.Windows.Forms.ListView PhotoListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.PictureBox Preview_PictureBox;
        private System.Windows.Forms.ComboBox Add_KeywordComboBox;
        private System.Windows.Forms.Button AddKeyword;
        private System.Windows.Forms.Button ToggleFavorite;
        private System.Windows.Forms.Button SlideShow;
    }
}

