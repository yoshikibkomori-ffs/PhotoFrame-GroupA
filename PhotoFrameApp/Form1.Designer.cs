﻿namespace PhotoFrameApp
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_CreateAlbum = new System.Windows.Forms.Button();
            this.textBox_CreateAlbum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_AlbumName = new System.Windows.Forms.RadioButton();
            this.radioButton_DirectoryName = new System.Windows.Forms.RadioButton();
            this.button_Search = new System.Windows.Forms.Button();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listView_PhotoList = new System.Windows.Forms.ListView();
            this.columnHeader_PhotoPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AlbumName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Favorite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox_ChangeAlbum = new System.Windows.Forms.ComboBox();
            this.button_ChangeAlbum = new System.Windows.Forms.Button();
            this.button_ToggleFavorite = new System.Windows.Forms.Button();
            this.button_SlideShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(576, 546);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_CreateAlbum);
            this.panel3.Controls.Add(this.textBox_CreateAlbum);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(42, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(425, 31);
            this.panel3.TabIndex = 2;
            // 
            // button_CreateAlbum
            // 
            this.button_CreateAlbum.Location = new System.Drawing.Point(340, 5);
            this.button_CreateAlbum.Name = "button_CreateAlbum";
            this.button_CreateAlbum.Size = new System.Drawing.Size(56, 23);
            this.button_CreateAlbum.TabIndex = 1;
            this.button_CreateAlbum.Text = "作成";
            this.button_CreateAlbum.UseVisualStyleBackColor = true;
            this.button_CreateAlbum.Click += new System.EventHandler(this.button_CreateAlbum_Click);
            // 
            // textBox_CreateAlbum
            // 
            this.textBox_CreateAlbum.Location = new System.Drawing.Point(78, 7);
            this.textBox_CreateAlbum.Name = "textBox_CreateAlbum";
            this.textBox_CreateAlbum.Size = new System.Drawing.Size(256, 19);
            this.textBox_CreateAlbum.TabIndex = 0;
            this.textBox_CreateAlbum.Text = "Album1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "アルバム名";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton_AlbumName);
            this.panel1.Controls.Add(this.radioButton_DirectoryName);
            this.panel1.Controls.Add(this.button_Search);
            this.panel1.Controls.Add(this.textBox_Search);
            this.panel1.Location = new System.Drawing.Point(42, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 57);
            this.panel1.TabIndex = 0;
            // 
            // radioButton_AlbumName
            // 
            this.radioButton_AlbumName.AutoSize = true;
            this.radioButton_AlbumName.Location = new System.Drawing.Point(112, 9);
            this.radioButton_AlbumName.Name = "radioButton_AlbumName";
            this.radioButton_AlbumName.Size = new System.Drawing.Size(74, 16);
            this.radioButton_AlbumName.TabIndex = 1;
            this.radioButton_AlbumName.Text = "アルバム名";
            this.radioButton_AlbumName.UseVisualStyleBackColor = true;
            // 
            // radioButton_DirectoryName
            // 
            this.radioButton_DirectoryName.AutoSize = true;
            this.radioButton_DirectoryName.Checked = true;
            this.radioButton_DirectoryName.Location = new System.Drawing.Point(18, 9);
            this.radioButton_DirectoryName.Name = "radioButton_DirectoryName";
            this.radioButton_DirectoryName.Size = new System.Drawing.Size(70, 16);
            this.radioButton_DirectoryName.TabIndex = 0;
            this.radioButton_DirectoryName.TabStop = true;
            this.radioButton_DirectoryName.Text = "フォルダ名";
            this.radioButton_DirectoryName.UseVisualStyleBackColor = true;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(340, 31);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(56, 23);
            this.button_Search.TabIndex = 3;
            this.button_Search.Text = "検索";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(78, 35);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(256, 19);
            this.textBox_Search.TabIndex = 2;
            this.textBox_Search.Text = "Album1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listView_PhotoList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.button_ToggleFavorite);
            this.splitContainer2.Panel2.Controls.Add(this.button_SlideShow);
            this.splitContainer2.Size = new System.Drawing.Size(576, 416);
            this.splitContainer2.SplitterDistance = 309;
            this.splitContainer2.TabIndex = 0;
            // 
            // listView_PhotoList
            // 
            this.listView_PhotoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_PhotoPath,
            this.columnHeader_AlbumName,
            this.columnHeader_Favorite});
            this.listView_PhotoList.FullRowSelect = true;
            this.listView_PhotoList.Location = new System.Drawing.Point(23, 13);
            this.listView_PhotoList.Name = "listView_PhotoList";
            this.listView_PhotoList.Size = new System.Drawing.Size(530, 278);
            this.listView_PhotoList.TabIndex = 0;
            this.listView_PhotoList.UseCompatibleStateImageBehavior = false;
            this.listView_PhotoList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_PhotoPath
            // 
            this.columnHeader_PhotoPath.Text = "ファイルパス";
            this.columnHeader_PhotoPath.Width = 294;
            // 
            // columnHeader_AlbumName
            // 
            this.columnHeader_AlbumName.Text = "アルバム名";
            this.columnHeader_AlbumName.Width = 140;
            // 
            // columnHeader_Favorite
            // 
            this.columnHeader_Favorite.Text = "お気に入り";
            this.columnHeader_Favorite.Width = 85;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox_ChangeAlbum);
            this.panel2.Controls.Add(this.button_ChangeAlbum);
            this.panel2.Location = new System.Drawing.Point(104, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 50);
            this.panel2.TabIndex = 0;
            // 
            // comboBox_ChangeAlbum
            // 
            this.comboBox_ChangeAlbum.FormattingEnabled = true;
            this.comboBox_ChangeAlbum.Location = new System.Drawing.Point(18, 16);
            this.comboBox_ChangeAlbum.Name = "comboBox_ChangeAlbum";
            this.comboBox_ChangeAlbum.Size = new System.Drawing.Size(190, 20);
            this.comboBox_ChangeAlbum.TabIndex = 0;
            // 
            // button_ChangeAlbum
            // 
            this.button_ChangeAlbum.Location = new System.Drawing.Point(225, 16);
            this.button_ChangeAlbum.Name = "button_ChangeAlbum";
            this.button_ChangeAlbum.Size = new System.Drawing.Size(88, 23);
            this.button_ChangeAlbum.TabIndex = 1;
            this.button_ChangeAlbum.Text = "アルバム変更";
            this.button_ChangeAlbum.UseVisualStyleBackColor = true;
            this.button_ChangeAlbum.Click += new System.EventHandler(this.button_ChangeAlbum_Click);
            // 
            // button_ToggleFavorite
            // 
            this.button_ToggleFavorite.Location = new System.Drawing.Point(464, 23);
            this.button_ToggleFavorite.Name = "button_ToggleFavorite";
            this.button_ToggleFavorite.Size = new System.Drawing.Size(89, 23);
            this.button_ToggleFavorite.TabIndex = 0;
            this.button_ToggleFavorite.Text = "お気に入り";
            this.button_ToggleFavorite.UseVisualStyleBackColor = true;
            this.button_ToggleFavorite.Click += new System.EventHandler(this.button_ToggleFavorite_Click);
            // 
            // button_SlideShow
            // 
            this.button_SlideShow.Location = new System.Drawing.Point(464, 52);
            this.button_SlideShow.Name = "button_SlideShow";
            this.button_SlideShow.Size = new System.Drawing.Size(89, 23);
            this.button_SlideShow.TabIndex = 1;
            this.button_SlideShow.Text = "スライドショー";
            this.button_SlideShow.UseVisualStyleBackColor = true;
            this.button_SlideShow.Click += new System.EventHandler(this.button_SlideShow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 546);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listView_PhotoList;
        private System.Windows.Forms.ColumnHeader columnHeader_PhotoPath;
        private System.Windows.Forms.ColumnHeader columnHeader_AlbumName;
        private System.Windows.Forms.ColumnHeader columnHeader_Favorite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox_ChangeAlbum;
        private System.Windows.Forms.Button button_ChangeAlbum;
        private System.Windows.Forms.Button button_ToggleFavorite;
        private System.Windows.Forms.Button button_SlideShow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_CreateAlbum;
        private System.Windows.Forms.TextBox textBox_CreateAlbum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_AlbumName;
        private System.Windows.Forms.RadioButton radioButton_DirectoryName;
    }
}

