using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SortSlideList
    {
        /// <summary>
        /// ランダムにフォトのリストを並び替える
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public List<Photo> Execute(List<Photo> photos)
        {
            List<Photo> photolist = new List<Photo>();

            //ランダムに並び替え（生成されたGUIDの大きさで並び替える）
            photolist = photos.OrderByDescending(x => Guid.NewGuid()).ToList();

            return photolist;

            // return photoRepository.Find(photos => (from p in photos where p.Album.Name == albumName select p).ToList().AsQueryable());
        }
    }
}
