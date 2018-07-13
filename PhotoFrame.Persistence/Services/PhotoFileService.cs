using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhotoFrame.Persistence
{
    public class PhotoFileService
    {
        public IEnumerable<Domain.Model.File> FindAllPhotoFilesFromDirectory(string directory)
        {
            // TODO: コレクション講座で実装予定
            List<Domain.Model.File> file_list = new List<Domain.Model.File>();

            // directoryが存在する場合
            if (Directory.Exists(directory))
            {
                List<string> path_list = Enumerate(directory);
                foreach (string filePath in path_list)
                {
                    Domain.Model.File file = new Domain.Model.File(filePath);
                    if (file.IsPhoto)
                    {
                        using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(filePath))
                        {
                            foreach (System.Drawing.Imaging.PropertyItem item in bmp.PropertyItems)
                            {
                                //Exif情報から撮影時間を取得する
                                if (item.Id == 0x9003 && item.Type == 2)
                                {
                                    //文字列に変換する
                                    string val = System.Text.Encoding.ASCII.GetString(item.Value);
                                    val = val.Trim(new char[] { '\0' });
                                    //DateTimeに変換
                                    file.AddDateTime(DateTime.ParseExact(val, "yyyy:MM:dd HH:mm:ss", null));
                                }
                            }
                            file_list.Add(file);
                        }
                    }
                }
            }
            return file_list;
        }

        private List<string> Enumerate(string dir)
        {
            string[] files = Directory.GetFiles(dir);
            List<string> file_list = new List<string>();

            foreach (string s in files)
            {
                file_list.Add(s);
            }

            string[] dirs = Directory.GetDirectories(dir);

            foreach (string s in dirs)
            {
                List<string> temp_list = Enumerate(s);

                foreach (string t in temp_list)
                {
                    file_list.Add(t);
                }
            }

            return file_list;
        }
    }
}