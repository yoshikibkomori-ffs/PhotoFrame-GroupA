using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoFrame.Persistence;
using PhotoFrame.Persistence.Repositories.EF;
using PhotoFrame.Persistence.EF;
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
            KeywordRepository keyWordRepository = new KeywordRepository();
            PhotoRepository photoRepository = new PhotoRepository();
            PhotoFileService photoFileService = new PhotoFileService(); 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(keyWordRepository,photoRepository,photoFileService));

        }

        
    }
}
