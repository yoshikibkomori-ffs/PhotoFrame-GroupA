using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SearchFavorite
    {
        /// <summary>
        /// "お気に入り"に登録されているフォトのリストを返す
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public List<Photo> Execute(List<Photo> photos)
        {
            List<Photo> photolist = new List<Photo>();
            photolist = (from p in photos where p.IsFavorite == true select p).ToList();
            return photolist;
            // return photoRepository.Find(photos => (from p in photos where p.Album.Name == albumName select p).ToList().AsQueryable());
        }
    }
}
