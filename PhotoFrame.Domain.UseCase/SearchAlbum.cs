using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;


namespace PhotoFrame.Domain.UseCase
{
    public class SearchAlbum
    {
        private readonly IPhotoRepository photoRepository;

        public SearchAlbum(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }

        /// <summary>
        /// 指定した名前のアルバムに属するフォトのリストを返す
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string albumName)
        {
            return photoRepository.Find(photos => (from p in photos where p.Album.Name == albumName select p).ToList().AsQueryable());
        }
    }
}
