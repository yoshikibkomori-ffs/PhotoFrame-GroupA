using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SearchKeyword
    {
        /// <summary>
        /// 指定したキーワードに属するフォトのリストを返す
        /// </summary>
        /// <param name="photos"></param>
        /// <param name="keytext"></param>
        /// <returns></returns>
        public List<Photo> Execute(List<Photo> photos, string keytext)
        {
            if (photos == null)
            {
                throw new ArgumentNullException("空のフォトリストが入力されています");
            }
            if (keytext.Length > 100 || keytext.Length <= 0)
            {
                throw new ArgumentOutOfRangeException("入力されたkeywordの文字数が0以上100以下になっていません");
            }
            List<Photo> photolist = new List<Photo>();

            photolist = (from p in photos where p.Keyword.KeyText == keytext select p).ToList();
            return photolist;
            // return photoRepository.Find(photos => (from p in photos where p.Album.Name == albumName select p).ToList().AsQueryable());
        }
    }
}
