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

namespace PhotoFrameApp
{
    public partial class SlideShow : Form
    {
        public SlideShow(List<Photo> photos)
        {

        }


        private void SlideShow_Load(object sender, EventArgs e)
        {
            Default();
        }

        //スライドショー・ボタンの状態を保持
        //0の時：Stop,RandomOFF,RepeatOFF
        //1の時：Start,RandomON,RepeatON
        int startstop, random, repeat = 0;

        //Mouseイベント
        //
        //Start_Stop切り替え
        #region 
        private void MouseDown_Start_Stop(object sender, MouseEventArgs e)
        {
            if (startstop == 0)
            {
                StartMD();
            }
            else
            {
                StopMD();
            }
        }
        private void MouseUp_Start_Stop(object sender, MouseEventArgs e)
        {
            if (startstop == 0)  //再生中は停止ボタンを表示
            {
                Stop();
                startstop = 1;
            }
            else  //停止中は再生ボタンを表示
            {
                Start();
                startstop = 0;
            }
        }
        #endregion
        //
        //Random配列の生成・元配列の復元
        #region
        private void MouseDown_Random(object sender, MouseEventArgs e)
        {
            RandomMD();
        }
        private void MouseUp_Random(object sender, MouseEventArgs e)
        {
            if(startstop == 1)
            {
                Start();
                startstop = 0;                
            }
            if (random == 0)
            {
                Random();
                random = 1;
            }
            else
            {
                RandomNA();
                random = 0;
            }
        }
        #endregion
        //
        //Repeat
        #region
        private void MouseDown_Repeat(object sender, MouseEventArgs e)
        {
            RepeatMD();
        }
        private void MouseUp_Repeat(object sender, MouseEventArgs e)
        {
            if (repeat == 0)
            {
                Repeat();
                repeat = 1;
            }
            else
            {
                RepeatNA();
                repeat = 0;
            }
        }
        #endregion

        //ボタン画像呼び出し関数
        #region
        private void Default()
        {
            PrevNA();
            NextA();
            Start();
            RandomNA();
            RepeatNA();
        }
        private void PrevA()  //Active
        {
            PrevBox.Image = System.Drawing.Image.FromFile(@"..\..\img\0 PrevA.png");
        }
        private void PrevNA()  //NonActive
        {
            PrevBox.Image = System.Drawing.Image.FromFile(@"..\..\img\0 PrevNA.png");
        }
        private void NextA()  //Active
        {
            NextBox.Image = System.Drawing.Image.FromFile(@"..\..\img\0 NextA.png");
        }
        private void NextNA()  //NonActive
        {
            NextBox.Image = System.Drawing.Image.FromFile(@"..\..\img\0 NextNA.png");
        }
        private void Start()  //Active
        {
            StartStopBox.Image = System.Drawing.Image.FromFile(@"..\..\img\StartA.png");
        }
        private void Stop()  //Active
        {
            StartStopBox.Image = System.Drawing.Image.FromFile(@"..\..\img\StopA.png");
        }
        private void StartMD()  //MouseDown
        {
            StartStopBox.Image = System.Drawing.Image.FromFile(@"..\..\img\StartMD.png");
        }
        private void StopMD()  //MouseDown
        {
            StartStopBox.Image = System.Drawing.Image.FromFile(@"..\..\img\StopMD.png");
        }
        private void Random()  //Active
        {
            RandomBox.Image = System.Drawing.Image.FromFile(@"..\..\img\RandomA.png");
        }
        private void RandomNA()  //NonActive
        {
            RandomBox.Image = System.Drawing.Image.FromFile(@"..\..\img\RandomNA.png");
        }
        private void RandomMD()  //MouseDown
        {
            RandomBox.Image = System.Drawing.Image.FromFile(@"..\..\img\RandomMD.png");
        }
        private void Repeat()  //Active
        {
            RepeatBox.Image = System.Drawing.Image.FromFile(@"..\..\img\RepeatA.png");
        }
        private void RepeatNA()  //NonActive
        {
            RepeatBox.Image = System.Drawing.Image.FromFile(@"..\..\img\RepeatNA.png");
        }
        private void RepeatMD()  //MouseDown
        {
            RepeatBox.Image = System.Drawing.Image.FromFile(@"..\..\img\RepeatMD.png");
        }
        #endregion
    }
}


//IEnumerable<Photo> photos;
//int photo_index;

///// <summary>
///// コンストラクタ
///// </summary>
///// <param name="photos"></param>
//public SlideShow(IEnumerable<Photo> photos)
//{
//    InitializeComponent();
//    this.photos = photos;
//    this.photo_index = 0;
//}

///// <summary>
///// スライドショー画面の初期設定
///// </summary>
///// <param name="sender"></param>
///// <param name="e"></param>
//private void SlideShow_Load(object sender, EventArgs e)
//{
//    if(photos.Count() > 0)
//    {
//        pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
//        timer_ChangePhoto.Interval = 3000;
//        if (checkBox_AutoPlay.Checked)
//        {
//            timer_ChangePhoto.Start();
//        }
//    }
//}

///// <summary>
///// 一定時間ごとに画像を切り替え
///// </summary>
///// <param name="sender"></param>
///// <param name="e"></param>
//private void timer_ChangePhoto_Tick(object sender, EventArgs e)
//{
//    photo_index++;

//    if(photo_index >= photos.Count())
//    {
//        photo_index = 0;
//    }
//    pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
//}

///// <summary>
///// 自動再生のON/OFF切り替え
///// </summary>
///// <param name="sender"></param>
///// <param name="e"></param>
//private void checkBox_AutoPlay_CheckedChanged(object sender, EventArgs e)
//{
//    if (checkBox_AutoPlay.Checked)
//    {
//        timer_ChangePhoto.Start();
//    }
//    else
//    {
//        timer_ChangePhoto.Stop();
//    }
//}

///// <summary>
///// 次の画像に切り替える(自動再生OFF)
///// </summary>
///// <param name="sender"></param>
///// <param name="e"></param>
//private void button_Next_Click(object sender, EventArgs e)
//{
//    checkBox_AutoPlay.Checked = false;
//    timer_ChangePhoto.Stop();

//    photo_index++;

//    if (photo_index >= photos.Count())
//    {
//        photo_index = 0;
//    }

//    pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
//}

///// <summary>
///// 一つ前の画像に戻す(自動再生OFF)
///// </summary>
///// <param name="sender"></param>
///// <param name="e"></param>
//private void button_Back_Click(object sender, EventArgs e)
//{
//    checkBox_AutoPlay.Checked = false;
//    timer_ChangePhoto.Stop();

//    photo_index--;

//    if (photo_index < 0)
//    {
//        photo_index = photos.Count() - 1;
//    }

//    pictureBox_SelectedPhotos.ImageLocation = photos.ElementAt(photo_index).File.FilePath;
//}