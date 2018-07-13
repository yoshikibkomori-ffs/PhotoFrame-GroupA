using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class ChangeFavorite
    {
        private readonly PhotoRepository photoRepository;

        public ChangeFavorite(PhotoRepository in_photoRepository)
        {
            this.photoRepository = in_photoRepository;
        }

        /// <summary>
        /// 引数で渡したフォトのお気に入りON/OFFを切り替えて返す
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public Photo Execute(Photo photo)
        {
            if (photo == null)
            {
                throw new ArgumentNullException("写真が選択されていません");
            }
            photo.ToggleFavorite();

            photoRepository.Store(photo);

            return photo;
        }

        /// <summary>
        /// 非同期
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public async Task<Photo> ExecuteAsync(Photo photo)
        {
            if (photo == null)
            {
                throw new ArgumentNullException("写真が選択されていません");
            }
            photo.ToggleFavorite();

            await Task.Run(() =>
            {
                photoRepository.Store(photo);
            });

            return photo;
        }
    }
}
