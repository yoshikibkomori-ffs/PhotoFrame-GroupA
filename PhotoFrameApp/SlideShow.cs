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
            photos = originalphotos;
            DefaultButton();
            PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
        }
        
        //
        //Mouseイベント(Main)
        //
        //Start_Stop切り替え
        #region 
        private void MouseDown_Start_Stop(object sender, MouseEventArgs e)
        {
            if (startstop == false)  //停止中
            {
                MouseDownStartButton();
            }
            else  //再生中
            {
                MouseDownStopButton();
            }
        }
        private void MouseUp_Start_Stop(object sender, MouseEventArgs e)
        {
            if (startstop == false)  //停止中
            {
                SlideShowStart();
            }
            else  //再生中
            {
                SlideShowStop();
            }
        }
        #endregion
        //
        //Random配列の生成・元配列の復元?
        #region
        private void MouseDown_Random(object sender, MouseEventArgs e)
        {
            MouseDownRandomButton();
            if (startstop == true)  //再生中はスライドショーを停止
            {
                SlideShowStop();
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
            MouseDownRepeatButton();
        }
        private void MouseUp_Repeat(object sender, MouseEventArgs e)
        {
            if (repeat == false)
            {
                RepeatButtonActivate();
            }
            else
            {
                RepeatButtonInactivate();
            }
            ChangeArrowButtonState();
        }
        #endregion
        //
        //Next
        #region
        private void MouseDown_Next(object sender, MouseEventArgs e)
        {
            if (startstop == true)  //再生中はスライドショーを停止
            {
                SlideShowStop();
            }
        }
        private void MouseUp_Next(object sender, MouseEventArgs e)
        {
            NextImg();
        }
        #endregion
        //
        //Previous
        #region
        private void MouseDown_Previous(object sender, MouseEventArgs e)
        {
            if (startstop == true)  //再生中はスライドショーを停止
            {
                SlideShowStop();
            }
        }
        private void MouseUp_Previous(object sender, MouseEventArgs e)
        {
            PrevImg();
        }
        #endregion
        

        //
        //スライドショーの再生(Mouseイベント(Main)で呼び出す)
        private void SlideShowStart()
        {
            StopButtonActivate();  //再生中は停止ボタンを表示
            Timer_ChangeImg.Start();
        }
        //
        //スライドショーの停止
        private void SlideShowStop()
        {
            StartButtonActivate();  //停止中は再生ボタンを表示
            Timer_ChangeImg.Stop();
        }
        //
        //ランダムON
        private void RandomON()
        {
            RandomButtonActivate();
            if (originalphotos.Count() != 1)  //写真が2枚以上の場合
            {
                List<Photo> handoverphotos = new List<Photo>(photos);
                handoverphotos.Remove(photos[photoIndex]);
                randomphotos = application.SortSlideList(handoverphotos);
                randomphotos.Insert(0, photos[photoIndex]);
                photos = randomphotos;
            }            
            photoIndex = 0;
            ChangeArrowButtonState();
            PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
        }
        //
        //ランダムOFF
        private void RandomOFF()
        {
            RandomButtonInactivate();
            photoIndex = originalphotos.IndexOf(photos[photoIndex]);
            photos = originalphotos;
            ChangeArrowButtonState();
            PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
        }
        //
        //Next
        private void NextImg()
        {
            if (photoIndex < photos.Count()-1)
            {
                photoIndex++;
            }
            else
            {
                photoIndex = 0;
            }            
            ChangeArrowButtonState();
            PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
        }
        //
        //Prev
        private void PrevImg()
        {
            if (photoIndex == 0)
            {
                photoIndex = photos.Count()-1;
            }
            else
            {
                photoIndex--;
            }            
            ChangeArrowButtonState();
            PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
        }
        
        //
        //一定時間経過で画像の切り替え
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
                    SlideShowStop();
                    MessageBox.Show("スライドショーが終了しました。", "終了", MessageBoxButtons.OK);
                }
            }
            else
            {
                PictureBox1.ImageLocation = photos.ElementAt(photoIndex).File.FilePath;
            }
            ChangeArrowButtonState();
        }
        //
        //矢印の状態の分岐
        private void ChangeArrowButtonState()
        {
            if (repeat == true)
            {
                PreviousButtonActivate();
                NextButtonActivate();
            }
            else
            {
                if (photos.Count() == 1)
                {
                    PreviousButtonInactivate();
                    NextButtonInactivate();
                }
                else
                {
                    if (photoIndex == 0)
                    {
                        PreviousButtonInactivate();
                        NextButtonActivate();
                    }
                    else if (photoIndex >= photos.Count() - 1)
                    {
                        PreviousButtonActivate();
                        NextButtonInactivate();
                    }
                    else
                    {
                        PreviousButtonActivate();
                        NextButtonActivate();
                    }
                }
            }
        }

        //
        //ボタン画像呼び出し、状態変更
        #region
        //
        //デフォルトで表示するボタンの設定
        private void DefaultButton()
        {
            ChangeArrowButtonState();
            StartButtonActivate();
            RandomButtonInactivate();
            RepeatButtonInactivate();
        }
        private void PreviousButtonActivate()  //Active
        {
            PrevBox.Image = Image.FromFile(@"..\..\img\0 PrevA.png");
            PrevBox.Enabled = true;
        }
        private void PreviousButtonInactivate()  //NonActive
        {
            PrevBox.Image = Image.FromFile(@"..\..\img\0 PrevNA.png");
            PrevBox.Enabled = false;
        }
        private void NextButtonActivate()  //Active
        {
            NextBox.Image = Image.FromFile(@"..\..\img\0 NextA.png");
            NextBox.Enabled = true;
        }
        private void NextButtonInactivate()  //NonActive
        {
            NextBox.Image = Image.FromFile(@"..\..\img\0 NextNA.png");
            NextBox.Enabled = false;
        }
        private void StartButtonActivate()  //Active
        {
            StartStopBox.Image = Image.FromFile(@"..\..\img\StartA.png");
            startstop = false;
        }
        private void MouseDownStartButton()  //MouseDown
        {
            StartStopBox.Image = Image.FromFile(@"..\..\img\StartMDA.png");
        }
        private void StopButtonActivate()  //Active
        {
            StartStopBox.Image = Image.FromFile(@"..\..\img\StopA.png");
            startstop = true;
        }
        private void MouseDownStopButton()  //MouseDown
        {
            StartStopBox.Image = Image.FromFile(@"..\..\img\StopMDA.png");
        }
        private void RandomButtonActivate()  //Active
        {
            RandomBox.Image = Image.FromFile(@"..\..\img\RandomA.png");
            random = true;
        }
        private void RandomButtonInactivate()  //NonActive
        {
            RandomBox.Image = Image.FromFile(@"..\..\img\RandomNA.png");
            random = false;
        }
        private void MouseDownRandomButton()  //MouseDown
        {
            RandomBox.Image = Image.FromFile(@"..\..\img\RandomMDA.png");
        }
        private void RepeatButtonActivate()  //Active
        {
            RepeatBox.Image = Image.FromFile(@"..\..\img\RepeatA.png");
            repeat = true;
        }
        private void RepeatButtonInactivate()  //NonActive
        {
            RepeatBox.Image = Image.FromFile(@"..\..\img\RepeatNA.png");
            repeat = false;
        }
        private void MouseDownRepeatButton()  //MouseDown
        {
            RepeatBox.Image = Image.FromFile(@"..\..\img\RepeatMDA.png");
        }
        #endregion
    }
}