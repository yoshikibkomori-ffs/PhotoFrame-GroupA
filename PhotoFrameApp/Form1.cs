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
        private IPhotoRepository photoRepository;
        private IAlbumRepository albumRepository;
        private IPhotoFileService photoFileService;
        private PhotoFrameApplication application;
        private IEnumerable<Photo> searchedPhotos; // リストビュー上のフォトのリスト

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // 各テストごとにデータベースファイルを削除
            // (35-42をコメントアウトしても動きます)
            if (System.IO.File.Exists("_Photo.csv"))
            {
                System.IO.File.Delete("_Photo.csv");
            }
            if (System.IO.File.Exists("_Album.csv"))
            {
                System.IO.File.Delete("_Album.csv");
            }

            // メンバ変数初期化
            RepositoryFactory repositoryFactory = new RepositoryFactory(PhotoFrame.Persistence.Type.Csv);
            ServiceFactory serviceFactory = new ServiceFactory(); 
            photoRepository = repositoryFactory.PhotoRepository;
            albumRepository = repositoryFactory.AlbumRepository;
            photoFileService = serviceFactory.PhotoFileService;
            application = new PhotoFrameApplication(albumRepository, photoRepository, photoFileService);
            searchedPhotos = new List<Photo>().AsEnumerable();

            // 全アルバム名を取得し、アルバム変更リストをセット
            IEnumerable<Album> allAlbums = albumRepository.Find((IQueryable<Album> albums) => albums);

            if(allAlbums != null)
            {
                foreach (Album album in allAlbums)
                {
                    comboBox_ChangeAlbum.Items.Add(album.Name);
                }
            }
            
        }

        /// <summary>
        /// アルバム名でフォトを検索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Search_Click(object sender, EventArgs e)
        {
            if (radioButton_AlbumName.Checked)
            {
                this.searchedPhotos = application.SearchAlbum(textBox_Search.Text);
            }
            else if (radioButton_DirectoryName.Checked)
            {
                this.searchedPhotos = application.SearchDirectory(textBox_Search.Text);
            }

            renewPhotoListView();
        }

        /// <summary>
        /// アルバム新規作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CreateAlbum_Click(object sender, EventArgs e)
        {
            string albumName = textBox_CreateAlbum.Text;
            int result = application.CreateAlbum(albumName);

            switch (result)
            {
                case 0:
                    comboBox_ChangeAlbum.Items.Add(albumName);
                    break;
                case 1:
                    MessageBox.Show("アルバム名が未入力です");
                    break;
                case 2:
                    MessageBox.Show("既存のアルバム名です");
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// お気に入り切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ToggleFavorite_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_PhotoList.SelectedItems.Count; i++)
            {
                int index = listView_PhotoList.SelectedItems[i].Index;

                Photo photo = application.ToggleFavorite(searchedPhotos.ElementAt(index));

                renewPhotoListViewItem(index, photo);
            }

        }

        /// <summary>
        /// 選択中のフォトの所属アルバムを変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button_ChangeAlbum_Click(object sender, EventArgs e)
        {
            string newAlbumName = comboBox_ChangeAlbum.Text;
            var listviewindex = new List<int>();
            for (int i = 0; i < listView_PhotoList.SelectedItems.Count; i++)
            {
                listviewindex.Add(listView_PhotoList.SelectedItems[i].Index);
            }
            foreach(int index in listviewindex)
            {
                Photo photo = await application.ChangeAlbumAsync(searchedPhotos.ElementAt(index), newAlbumName);
                renewPhotoListViewItem(index, photo);
            }
        }

        /// <summary>
        /// リストビュー上のフォトのスライドショーを実行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SlideShow_Click(object sender, EventArgs e)
        {
            if(this.searchedPhotos.Count() > 0)
            {
                SlideShow slideShowForm = new SlideShow(this.searchedPhotos);
                slideShowForm.ShowDialog();
            }
            
        }

        /// <summary>
        /// リストビュー1行分更新
        /// </summary>
        /// <param name="index"></param>
        /// <param name="photo"></param>
        private void renewPhotoListViewItem(int index, Photo photo)
        {
            string albumName, isFavorite;

            if (photo.Album != null)
            {
                albumName = photo.Album.Name;
            }
            else
            {
                albumName = "";
            }


            if (photo.IsFavorite)
            {
                isFavorite = "★";
            }
            else
            {
                isFavorite = "";
            }

            listView_PhotoList.Items[index].SubItems[0].Text = photo.File.FilePath;
            listView_PhotoList.Items[index].SubItems[1].Text = albumName;
            listView_PhotoList.Items[index].SubItems[2].Text = isFavorite;
        }

        /// <summary>
        /// リストビューの更新
        /// </summary>
        /// <param name="photos"></param>
        private void renewPhotoListView()
        {
            listView_PhotoList.Items.Clear();

            if (this.searchedPhotos != null)
            {
                foreach (Photo photo in searchedPhotos)
                {
                    string albumName, isFavorite;

                    if(photo.Album != null)
                    {
                        albumName = photo.Album.Name;
                    }
                    else
                    {
                        albumName = "";
                    }


                    if (photo.IsFavorite)
                    {
                        isFavorite = "★";
                    }
                    else
                    {
                        isFavorite = "";
                    }

                    string[] item = { photo.File.FilePath, albumName, isFavorite };
                    listView_PhotoList.Items.Add(new ListViewItem(item));

                }
            }
        }

        
    }
}
