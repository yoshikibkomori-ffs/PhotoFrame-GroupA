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
            End_DateTimePicker.MaxDate = DateTime.Today;
        }
        /// <summary>
        /// ディレクトリパスを入手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SelectDir(object sender, EventArgs e)
        {
             DialogResult dialogResult = FolderBrowserDialog1.ShowDialog();
             if (dialogResult == System.Windows.Forms.DialogResult.OK)
             {
                 Directory_TextBox.Text = FolderBrowserDialog1.SelectedPath;
             }
        }

        /// <summary>
        /// ディレクトリパスに格納された写真ファイルを、リストビュー上に配置する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Display(object sender, EventArgs e)
        {
            try
            {
                string dirpath = Directory_TextBox.Text;
                PhotoListView.Items.Clear();
                this.photos = createPhotoList.Execute(dirpath);
                Set_PhotoList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"エラー");
                Directory_TextBox.Clear();
            }
        } 

        /// <summary>
        /// データタイムピッカーを開き、画像の最初の日時を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_StartCalenderDialog(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// データタイムピッカーを開き、画像の終わりの日時を選択する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_EndCalenderDialog(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 設定した日時の範囲の画像一覧をリストに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SelectDate(object sender, EventArgs e)
        {
            DateTime s_Date = Start_DateTimePicker.Value;
            DateTime e_Date = End_DateTimePicker.Value;
            try
            {
                this.photos = searchDate.Execute(this.photos, s_Date, e_Date);
                Set_PhotoList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"日付を入力しなおしてください", "エラー");
                Start_DateTimePicker.ResetText();
                End_DateTimePicker.ResetText();
                s_Date = Start_DateTimePicker.Value;
                e_Date = End_DateTimePicker.Value;
            }

            //if (s_Date <= e_Date)
            //{
            //    this.photos = searchDate.Execute(this.photos, s_Date, e_Date);
            //    Set_PhotoList();
            //}
            //else
            //{
            //    MessageBox.Show("不正な範囲の期間が設定されました。\n再入力してください。", "エラー");
            //    //throw new ArgumentException("不正な範囲の期間が設定されました。\n再入力してください。");
            //}
        }

        private void Select_KeywordComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 設定したキーワードを持つ画像一覧をリストに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SelectKeyword(object sender, EventArgs e)
        {
            try
            {
                string keytext = Select_KeywordComboBox.Text;
                this.photos = searchKeyword.Execute(this.photos, keytext);
                Set_PhotoList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
            
        }

        /// <summary>
        /// お気に入りの画像一覧をリストに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SelectFavorite(object sender, EventArgs e)
        {
            try
            {
                this.photos = searchFavorite.Execute(this.photos);
                Set_PhotoList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }


        private void Add_KeywordComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 画像一覧で選択された画像データに、キーワードを追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_AddKeyword(object sender, EventArgs e)
        {
            //ListView1.Enabled = false;
            string keytext = Add_KeywordComboBox.Text;
            //if(ListView1.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("リストの写真を選択してください", "エラー");
            //}
            try
            {
                for (int i = 0; i < PhotoListView.SelectedItems.Count; i++)
                {

                    int index = PhotoListView.SelectedItems[i].Index;
                    Photo photo = this.photos.ElementAt(index);
                    bool result = addKeyword.Execute(keytext);
                    if (result)
                    {
                        photo = changeKeyword.Execute(photo, keytext);
                        Update_PhotoList(index, photo);
                    }
                    else
                    {
                        //追加をしない
                    }

                    //photo = changeKeyword.Execute(photo, keytext); 
                    //Update_PhotoList(index, photo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
            //ListView.Enabled = true;
        }

        /// <summary>
        /// 画像一覧で選択された画像データのお気に入り情報を変更する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_AddFavorite(object sender, EventArgs e)
        {
            try
            {
                //ListView1.Enabled = false;
                for (int i = 0; i < PhotoListView.SelectedItems.Count; i++)
                {
                    int index = PhotoListView.SelectedItems[i].Index;
                    Photo photo = this.photos.ElementAt(index);
                    photo = changeFavorite.Execute(photo);
                    Update_PhotoList(index, photo);
                }
                //ListView.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// スライドショー画面を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_SlideShow(object sender, EventArgs e)
        {
            
            if (this.photos.Count != 0)
            {
                //SlideShow slideShowForm = new SlideShow(this.photos,keywordRepository,photoRepository,photoFileService);
                SlideShow slideShowForm = new SlideShow();
                slideShowForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("スライドショーに表示する写真が存在しません","エラー");
            }

        }

        /// <summary>
        /// 日時でリストを昇順、降順に並び替える
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_DateSort(object sender, ColumnClickEventArgs e)
        {
            try
            {
                if (e.Column == 3)
                {
                    order = !order;
                    this.photos = sortDate.Execute(this.photos, order);
                    Set_PhotoList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// 画像一覧で選択された画像データのプレビューを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_ShowPreview(object sender, EventArgs e)
        {
            if(PhotoListView.SelectedItems.Count == 1)
            {
                int index = PhotoListView.SelectedItems[0].Index;
                Preview_PictureBox.ImageLocation = this.photos.ElementAt(index).File.FilePath;
            }
        }

        /// <summary>
        /// リストを生成する
        /// </summary>
        private void Set_PhotoList()
        {
            DateTime Min_DateTime = new DateTime(1753, 1, 1, 0, 0, 0);
            if (this.photos != null)
            {
                foreach (var photo in photos)
                {
                    string Keyword, isFavorite, PhotoDateTime;

                    if (photo.Keyword.KeyText != null)
                    {
                        Keyword = photo.Keyword.KeyText;
                    }
                    else
                    {
                        Keyword = "";
                    }

                    if (photo.IsFavorite)
                    {
                        isFavorite = "★";
                    }
                    else
                    {
                        isFavorite = "";
                    }

                    if (photo.File.DateTime !=Min_DateTime)
                    {
                        PhotoDateTime = photo.File.DateTime.ToString();
                    }
                    else
                    {
                        PhotoDateTime = "";
                    }

                    string[] item = { Path.GetFileName(photo.File.FilePath), Keyword, isFavorite, PhotoDateTime };
                    PhotoListView.Items.Add(new ListViewItem(item));
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
            DateTime Min_DateTime = new DateTime(1753,1,1,0,0,0);
            string Keyword, isFavorite, PhotoDateTime;

            if (photo.Keyword.KeyText != null)
            {
                Keyword = photo.Keyword.KeyText;
            }
            else
            {
                Keyword = "";
            }

            if (photo.IsFavorite)
            {
                isFavorite = "★";
            }
            else
            {
                isFavorite = "";
            }

            if (photo.File.DateTime != Min_DateTime)
            {
                PhotoDateTime = photo.File.DateTime.ToString();
            }
            else
            {
                PhotoDateTime = "";
            }
            PhotoListView.Items[index].SubItems[0].Text = Path.GetFileName(photo.File.FilePath);
            PhotoListView.Items[index].SubItems[1].Text = photo.Keyword.KeyText;
            PhotoListView.Items[index].SubItems[2].Text = isFavorite;
            PhotoListView.Items[index].SubItems[3].Text = PhotoDateTime;
        }

    }
}
