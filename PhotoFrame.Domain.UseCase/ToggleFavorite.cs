using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence.Csv;

namespace PhotoFrame.Domain.UseCase
{
    public class ToggleFavorite
    {
        private readonly PhotoRepository photoRepository;

        public ChangeFavorite(PhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }

        /// <summary>
        /// 引数で渡したフォトのお気に入りON/OFFを切り替えて返す
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public Photo Execute(Photo photo)
        {
           if(photo.IsFavorite == true)
            {
                photo.MarkAsUnFavorite();
            }
            else
            {
                photo.MarkAsFavorite();
            }

            photoRepository.Store(photo);
            

            return photo;
        }
    }
}
