using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class ChangeKeyword
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IPhotoRepository photoRepository;

        public ChangeKeyword(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
            this.albumRepository = albumRepository;
            this.photoRepository = photoRepository;
        }

        /// <summary>
        /// 引数のフォトのキーワードを変更する
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="keytext"></param>
        /// <returns></returns>
        public Photo Execute(Photo photo, string keytext)
        {
            Func<IQueryable<Keyword>, Keyword> query = allKeywords =>
            {
                foreach (Keyword keyword in allKeywords)
                {
                    if (keyword.KeyText == keytext)
                    {
                        return keyword;
                    }
                }

                return null;
            };

            Keyword newKeyword = albumRepository.Find(query);

            if(newKeyword != null)
            {
                photo.IsAssignedTo(newKeyword);
            }

            photoRepository.Store(photo);

            return photo;
        }

        /// <summary>
        /// 引数のフォトのキーワードを変更する
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// （非同期型）
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="keytext"></param>
        /// <returns></returns>
        public async Task<Photo> ExecuteAsync(Photo photo, string keytext)
        {
            Func<IQueryable<Keyword>, Keyword> query = allKeywords =>
            {
                foreach (Keyword keyword in allKeywords)
                {
                    if (keyword.KeyText == keytext)
                    {
                        return keyword;
                    }
                }

                return null;
            };

            Keyword newKeyword = albumRepository.Find(query);

            if (newKeyword != null)
            {
                photo.IsAssignedTo(newKeyword);
            }

            await Task.Run(() =>
            {
                photoRepository.Store(photo);
            });

            return photo;
        }
    }
}
