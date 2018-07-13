using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Persistence;
using PhotoFrame.Persistence.Csv;
using PhotoFrame.Domain.Model;

namespace PhotoFrameApp
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            KeyWordRepository keyWordRepository = new KeyWordRepository();
            PhotoRepository photoRepository = new PhotoRepository();
            PhotoFileService photoFileService = new PhotoFileService(); 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(keyWordRepository,photoRepository,photoFileService));

        }

        
    }
}
