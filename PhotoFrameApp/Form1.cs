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
using PhotoFrame.Persistence.Repositories.EF;
using PhotoFrame.Persistence.EF;
using System.IO;

namespace PhotoFrameApp
{
    public partial class Form1 : Form
    {
        bool order = false;
        private KeywordRepository keywordRepository;
        private PhotoRepository photoRepository;
        private PhotoFileService photoFileService;
        private List<Photo> photos;

        private AddKeyword addKeyword;
        private ChangeFavorite changeFavorite;
        private ChangeKeyword changeKeyword;
        private CreatePhotoList createPhotoList;
        private SearchDate searchDate;
        private SearchFavorite searchFavorite;
        private SearchKeyword searchKeyword;
        private SortDate sortDate;

        public Form1(KeywordRepository in_keywordRepository, PhotoRepository in_photoRepository, PhotoFileService in_photoFileService)
        {
            InitializeComponent();
            this.keywordRepository = in_keywordRepository;
            this.photoRepository = in_photoRepository;
            this.photoFileService = in_photoFileService;
            addKeyword = new AddKeyword(keywordRepository);
            changeFavorite = new ChangeFavorite(photoRepository);
            changeKeyword = new ChangeKeyword(keywordRepository, photoRepository);
            createPhotoList = new CreatePhotoList(photoRepository,photoFileService);
            searchDate = new SearchDate();
            searchFavorite = new SearchFavorite();
            searchKeyword = new SearchKeyword();
            sortDate = new SortDate();

        }
        /// <summary>
        /// ディレクトリパスを入手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SeachDir(object sender, EventArgs e)
        {
            DialogResult dr = FolderBrowserDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                TextBox1.Text = FolderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// ディレクトリパスに格納された写真ファイルを、リストビュー上に配置する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Display(object sender, EventArgs e)
        {
            string dirpath = TextBox1.Text;
            ListView1.Items.Clear();
            this.photos = createPhotoList.Execute(dirpath);
            Set_PhotoList();
        } 

        /// <summary>
        /// データタイムピッカーを開き、画像の最初の日時を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_StartDateTimePicker(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// データタイムピッカーを開き、画像の終わりの日時を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_EndDateTimePicker(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 設定した日時の範囲の画像一覧をリストに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SelectDate(object sender, EventArgs e)
        {

            DateTime s_Date = DateTimePicker1.Value;
            DateTime e_Date = DateTimePicker2.Value;
            this.photos = searchDate.Execute(this.photos, s_Date, e_Date);
            Set_PhotoList();
        }

        private void KeywordBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 設定したキーワードを持つ画像一覧をリストに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SelectKeyword(object sender, EventArgs e)
        {
            string keytext = KeywordBox1.SelectedText;
            this.photos = searchKeyword.Execute(this.photos, keytext);
            Set_PhotoList();
        }

        /// <summary>
        /// お気に入りの画像一覧をリストに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SelectFavorite(object sender, EventArgs e)
        {
            this.photos = searchFavorite.Execute(this.photos);
            Set_PhotoList();
        }


        private void KeywordBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 画像一覧で選択された画像データに、キーワードを追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_AddKeyword(object sender, EventArgs e)
        {
            for (int i = 0; i < ListView1.SelectedItems.Count; i++)
            {
                int index = ListView1.SelectedItems[i].Index;
                Photo photo = this.photos.ElementAt(index);
                Update_PhotoList(index, photo);
            }
        }

        /// <summary>
        /// 画像一覧で選択された画像データのお気に入り情報を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_AddFavorite(object sender, EventArgs e)
        {
            for(int i = 0; i < ListView1.SelectedItems.Count; i++)
            {
                int index = ListView1.SelectedItems[i].Index;
                Photo photo = this.photos.ElementAt(index);
                Update_PhotoList(index, photo);
            }
        }

        /// <summary>
        /// スライドショー画面を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SlideShow(object sender, EventArgs e)
        {
            //SlideShow slideShowForm = new SlideShow(this.photos);
            SlideShow slideShowForm = new SlideShow();
            slideShowForm.ShowDialog();

        }

        /// <summary>
        /// 日時でリストを昇順、降順に並び替える
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_DateSort(object sender, ColumnClickEventArgs e)
        {
            if(e.Column == 3)
            {
                order = !order;
                this.photos = sortDate.Execute(this.photos, order);
                Set_PhotoList();
            }
        }

        /// <summary>
        /// 画像一覧で選択された画像データのプレビューを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_ShowPreview(object sender, EventArgs e)
        {
            if(ListView1.SelectedItems.Count == 1)
            {
                int index = ListView1.SelectedItems[0].Index;
                PictureBox1.ImageLocation = this.photos.ElementAt(index).File.FilePath;
            }
        }

        /// <summary>
        /// リストを生成する
        /// </summary>
        private void Set_PhotoList()
        {
            if (photos != null)
            {
                foreach (var photo in photos)
                {
                    string KeyWord, isFavorite, PhotoDateTime;

                    if (photo.Keyword.KeyText != null)
                    {
                        KeyWord = photo.Keyword.KeyText;
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

                    if (photo.File.DateTime != null)
                    {
                        PhotoDateTime = photo.File.DateTime.ToString();
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
        /// <summary>
        /// 1行分のリストを更新する
        /// </summary>
        /// <param name="index"></param>
        /// <param name="photo"></param>
        private void Update_PhotoList(int index, Photo photo)
        {
            string KeyWord, isFavorite, PhotoDateTime;

            if (photo.Keyword.KeyText != null)
            {
                KeyWord = photo.Keyword.KeyText;
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

            if (photo.File.DateTime != null)
            {
                PhotoDateTime = photo.File.DateTime.ToString();
            }
            else
            {
                PhotoDateTime = "";
            }
            ListView1.Items[index].SubItems[0].Text = Path.GetFileName(photo.File.FilePath);
            ListView1.Items[index].SubItems[1].Text = photo.Keyword.KeyText;
            ListView1.Items[index].SubItems[2].Text = isFavorite;
            ListView1.Items[index].SubItems[3].Text = PhotoDateTime;
        }

    }
}
