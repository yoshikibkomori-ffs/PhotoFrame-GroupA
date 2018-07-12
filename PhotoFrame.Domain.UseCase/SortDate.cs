using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SortDate
    {
        /// <summary>
        /// Exifデータの日時を基準とし、昇順/降順にフォトのリストを並び替える
        /// order = true →昇順
        /// order = false→降順
        /// </summary>
        /// <param name="photos"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Photo> Execute(List<Photo> photos, Boolean order)
        {
            List<Photo> photolist = new List<Photo>();

            if (order)
            {
                photolist = photos.OrderBy(x => x.File.Date).ToList();
            }
            else
            {
                photolist = photos.OrderByDescending(x => x.File.Date).ToList();
            }

            return photolist;

            // return photoRepository.Find(photos => (from p in photos where p.Album.Name == albumName select p).ToList().AsQueryable());
        }
    }
}
