using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence.Csv;

namespace PhotoFrame.Domain.UseCase
{
    public class ChangeAlbum
    {
        private readonly KeywordRepository keywordRepository;
        private readonly PhotoRepository photoRepository;

        public ChangeKeyword(KeywordRepository albumRepository, PhotoRepository photoRepository)
        {
            this.keywordRepository = albumRepository;
            this.photoRepository = photoRepository;
        }

        /// <summary>
        /// 引数のフォトの所属アルバムを変更する
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="newAlbumName"></param>
        /// <returns></returns>
        public Photo Execute(Photo photo, string newAlbumName)
        {
            Func<IQueryable<Album>, Album> query = allAlbums =>
            {
                foreach (Album album in allAlbums)
                {
                    if (album.Name == newAlbumName)
                    {
                        return album;
                    }
                }

                return null;
            };

            Keyword newKeyword = keywordRepository.Find(query);

            if(newAlbum != null)
            {
                photo.IsAssignedTo(newAlbum);
            }

            photoRepository.Store(photo);

            return photo;
        }

        /// <summary>
        /// 引数のフォトの所属アルバムを変更する
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// （非同期型）
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="newAlbumName"></param>
        /// <returns></returns>
        public async Task<Photo> ExecuteAsync(Photo photo, string newAlbumName)
        {
            Func<IQueryable<Album>, Album> query = allAlbums =>
            {
                foreach (Album album in allAlbums)
                {
                    if (album.Name == newAlbumName)
                    {
                        return album;
                    }
                }

                return null;
            };

            Keyword newKeyword = keywordRepository.Find(query);

            if (newAlbum != null)
            {
                photo.IsAssignedTo(newAlbum);
            }

            await Task.Run(() =>
            {
                photoRepository.Store(photo);
            });

            return photo;
        }
    }
}
