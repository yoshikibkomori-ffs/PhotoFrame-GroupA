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
using PhotoFrame.Persistence.EF;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrameApp
{
    public partial class SlideShow : Form
    {
        int photoIndex = 0;
        //スライドショー・ボタンの状態を保持
        Boolean startstop, random, repeat = false;
        List<Photo> originalphotos,randomphotos,photos;
        private KeywordRepository sskeywordRepository;
        private PhotoRepository ssphotoRepository;
        private PhotoFileService ssphotoFileService;
        private PhotoFrameApplication application;

        public SlideShow(List<Photo> photolist,KeywordRepository keywordRepository, PhotoRepository photoRepository, PhotoFileService photoFileService)
        {
            this.originalphotos = photolist;  //メイン画面から配列の受け取り
            this.sskeywordRepository = new KeywordRepository();
            this.ssphotoRepository = new PhotoRepository();
            this.ssphotoFileService = new PhotoFileService();
            this.application = new PhotoFrameApplication(keywordRepository, photoRepository, photoFileService);
        }

        private void SlideShow_Load(object sender, EventArgs e)  //スライドショー画面の初期表示
        {
            DefaultButton();
            photos = originalphotos;
            PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
        }

        //Mouseイベント
        //
        //Start_Stop切り替え
        #region 
        private void MouseDown_Start_Stop(object sender, MouseEventArgs e)
        {
            if (startstop == false)  //停止中
            {
                StartMD();
            }
            else  //再生中
            {
                StopMD();
            }
        }
        private void MouseUp_Start_Stop(object sender, MouseEventArgs e)
        {
            if (startstop == false)  //停止中
            {
                StartSS();
            }
            else  //再生中
            {
                StopSS();
            }
        }
        #endregion
        //
        //Random配列の生成・元配列の復元?
        #region
        private void MouseDown_Random(object sender, MouseEventArgs e)
        {
            RandomMD();
            if (startstop == true)  //再生中はスライドショーを停止
            {
                StopSS();
            }
        }
        private void MouseUp_Random(object sender, MouseEventArgs e)
        {
            if (random == false)
            {
                RandomON();
            }
            else
            {
                RandomOFF();
            }
        }
        #endregion
        //
        //Repeat(ボタンデザイン・状態の変更のみ)
        #region
        private void MouseDown_Repeat(object sender, MouseEventArgs e)
        {
            RepeatMD();
        }
        private void MouseUp_Repeat(object sender, MouseEventArgs e)
        {
            if (repeat == false)
            {
                RepeatA();
            }
            else
            {
                RepeatNA();
            }
        }
        #endregion
        //
        //Next
        #region
        private void MouseDown_Next(object sender, MouseEventArgs e)
        {
            if (startstop == true)  //再生中はスライドショーを停止
            {
                StopSS();
            }
        }
        private void MouseUp_Next(object sender, MouseEventArgs e)
        {
            photoIndex++;
            PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
            PrevA();
            if (photoIndex == photos.Count())
            {
                NextNA();
            }
            else
            {
                NextA();
            }
        }
        #endregion
        //
        //Previous
        #region
        private void MouseDown_Previous(object sender, MouseEventArgs e)
        {
            if (startstop == true)  //再生中はスライドショーを停止
            {
                StopSS();
            }
        }
        private void MouseUp_Previous(object sender, MouseEventArgs e)
        {
            photoIndex--;
            PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
            if(photoIndex == 0)
            {
                PrevNA();
            }
            else
            {
                PrevA();
            }
            NextA();
        }
        #endregion
        

        //
        //スライドショーの再生
        private void StartSS()
        {
            StopA();  //再生中は停止ボタンを表示
            Timer_ChangeImg.Start();
        }
        //
        //スライドショーの停止
        private void StopSS()
        {
            StartA();  //停止中は再生ボタンを表示
            Timer_ChangeImg.Stop();
        }
        //
        //ランダムON
        private void RandomON()
        {
            RandomA();
            List<Photo> tempphotos;
            tempphotos = photos;
            tempphotos.Remove(photos[photoIndex]);
            randomphotos = application.SortSlideList(tempphotos);
            photos = randomphotos;
            photoIndex = 0;
        }
        //
        //ランダムOFF
        private void RandomOFF()
        {
            RandomNA();
            photoIndex = originalphotos.IndexOf(randomphotos[photoIndex]);
            photos = originalphotos;
        }
        
        //
        //画像の表示・リピートON/OFFの場合の切り替え
        private void Timer_ChangeImg_Tick(object sender, EventArgs e)
        {
            photoIndex++;
            if (photoIndex >= photos.Count())
            {
                if (repeat == true)
                {
                    photoIndex = 0;
                    PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
                }
                else
                {
                    StopSS();
                }
            }
            else
            {
                PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
            }
        }
        
        //
        //ボタン画像呼び出し、状態変更
        #region
        private void DefaultButton()
        {
            PrevNA();
            NextA();
            StartA();
            RandomNA();
            RepeatNA();
        }
        private void PrevA()  //Active
        {
            PrevBox.Image = Image.FromFile(@"..\..\img\0 PrevA.png");
            PrevBox.Enabled = true;
        }
        private void PrevNA()  //NonActive
        {
            PrevBox.Image = Image.FromFile(@"..\..\img\0 PrevNA.png");
            PrevBox.Enabled = false;
        }
        private void NextA()  //Active
        {
            NextBox.Image = Image.FromFile(@"..\..\img\0 NextA.png");
            NextBox.Enabled = true;
        }
        private void NextNA()  //NonActive
        {
            NextBox.Image = Image.FromFile(@"..\..\img\0 NextNA.png");
            NextBox.Enabled = false;
        }
        private void StartA()  //Active
        {
            StartStopBox.Image = Image.FromFile(@"..\..\img\StartA.png");
            startstop = false;
        }
        private void StartMD()  //MouseDown
        {
            StartStopBox.Image = Image.FromFile(@"..\..\img\StartMD.png");
        }
        private void StopA()  //Active
        {
            StartStopBox.Image = Image.FromFile(@"..\..\img\StopA.png");
            startstop = true;
        }
        private void StopMD()  //MouseDown
        {
            StartStopBox.Image = Image.FromFile(@"..\..\img\StopMD.png");
        }
        private void RandomA()  //Active
        {
            RandomBox.Image = Image.FromFile(@"..\..\img\RandomA.png");
            random = true;
        }
        private void RandomNA()  //NonActive
        {
            RandomBox.Image = Image.FromFile(@"..\..\img\RandomNA.png");
            random = false;
        }       
        private void RandomMD()  //MouseDown
        {
            RandomBox.Image = Image.FromFile(@"..\..\img\RandomMD.png");
        }
        private void RepeatA()  //Active
        {
            RepeatBox.Image = Image.FromFile(@"..\..\img\RepeatA.png");
            repeat = true;
        }

        private void RepeatNA()  //NonActive
        {
            RepeatBox.Image = Image.FromFile(@"..\..\img\RepeatNA.png");
            repeat = false;
        }
        private void RepeatMD()  //MouseDown
        {
            RepeatBox.Image = Image.FromFile(@"..\..\img\RepeatMD.png");
        }
        #endregion
    }

}