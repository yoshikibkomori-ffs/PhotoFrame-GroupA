using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Application;
using PhotoFrame.Domain;
using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using PhotoFrame.Persistence;
using PhotoFrame.Persistence.Csv;
using System.IO;

namespace PhotoFrameApp
{
    public partial class Form1 : Form
    {
        private KeywordRepository keywordRepository;
        private PhotoRepository photoRepository;
        private PhotoFileService photoFileService;
        private List<Photo> photos;
        bool order = false;

        public Form1(KeywordRepository keywordRepository, PhotoRepository photoRepository, PhotoFileService photoFileService)
        {
            InitializeComponent();
            this.keywordRepository = keywordRepository;
            this.photoRepository = photoRepository;
            this.photoFileService = photoFileService;

        }

        private void Click_SeachDir(object sender, EventArgs e)
        {
            DialogResult dr = FolderBrowserDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                TextBox1.Text = FolderBrowserDialog1.SelectedPath;
            }
        }

        private void Click_Display(object sender, EventArgs e)
        {
            ListView1.Items.Clear();
            this.photos = Application.createPhotoList();
            Set_PhotoList();
        }

        //private void Set_PhotoList(List<Photo> photoList)
        private void Set_PhotoList()
        {
            if(photos != null)
            {
                foreach (var photo in photos)
                {
                    string PhotoName, KeyWord ,isFavorite, PhotoDateTime;

                    //if (photo.Name != null)
                    //{
                    //    PhotoName = photo.Name;
                    //}
                    //else
                    //{
                    //    PhotoName = "";
                    //}

                    if (photo.keyWord.keyWord)
                    {
                        KeyWord = photo.keyWord.keyWord;
                    }
                    else
                    {
                        KeyWord = "";
                    }

                    if (photo.IsFavorite)
                    {
                        isFavorite = "★";
                    }
                    else
                    {
                        isFavorite = "";
                    }

                    if (photo.Date != null)
                    {
                        PhotoDateTime = photo.Date.ToString();
                    }
                    else
                    {
                        PhotoDateTime = "";
                    }

                    string[] item = { Path.GetFileName(photo.File.FilePath), KeyWord, isFavorite, PhotoDateTime };
                    ListView1.Items.Add(new ListViewItem(item));
                }
                

            }
            
        }

        private void Update_PhotoList(int index, Photo photo)
        {

        }

        private void Click_StartDateTimePicker(object sender, EventArgs e)
        {

        }

        private void Click_EndDateTimePicker(object sender, EventArgs e)
        {

        }

        private void Click_SelectDate(object sender, EventArgs e)
        {

            DateTime s_Date = DateTimePicker1.Value;
            DateTime e_Date = DateTimePicker2.Value;
            this.photos = Application.searchDate(this.photos, s_Date, e_Date);
            Set_PhotoList();
        }

        private void KeywordBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Click_SelectKeyword(object sender, EventArgs e)
        {
            string keytext = KeywordBox1.SelectedText;
            this.photos = Application.searchKeyword(this.photos, keytext);
            Set_PhotoList();
        }

        private void Click_SelectFavorite(object sender, EventArgs e)
        {
            this.photos = Application.searchFavorite(this.photos);
            Set_PhotoList();
        }

        private void KeywordBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Click_AddKeyword(object sender, EventArgs e)
        {
            string keytext = KeywordBox2.Text;
            Application.addKeyword(keytext);
            foreach (Photo photo in this.photos)
            { 
            Application.changeKeyword(photo, keytext);
            }
            //インデックスの再表示処理

        }

        private void Click_AddFavorite(object sender, EventArgs e)
        {
            //foreach(Photo photo in this.photos)
            //{
            //    Application.changeFavorite(photo);
            //}
            //インデックスの再表示処理

            for(int i = 0; i < ListView1.SelectedItems.Count; i++)
            {
                int index = ListView1.SelectedItems[i].Index;
                Photo photo = this.photos.ElementAt(index);
            }
        }

        private void Click_SlideShow(object sender, EventArgs e)
        {
            SlideShow slideShowForm = new SlideShow(this.photos);
            slideShowForm.ShowDialog();

        }

        private void Click_DateSort(object sender, ColumnClickEventArgs e)
        {
            if(e.Column == 3)
            {
                order = !order;
                this.photos = Application.sortDate(this.photos, order);
            }
        }

        private void Click_ShowPreview(object sender, EventArgs e)
        {
            if(ListView1.SelectedItems.Count == 1)
            {
                PictureBox1.ImageLocation = ListView1.SelectedItems[0].SubItems[0].ToString();
            }
        }

    }
}
