using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Domain.UseCase
{
    public class ChangeKeyword
    {
        private readonly KeywordRepository keywordRepository;
        private readonly PhotoRepository photoRepository;

        public ChangeKeyword(KeywordRepository in_keywordRepository, PhotoRepository in_photoRepository)
        {
            this.keywordRepository = in_keywordRepository;
            this.photoRepository = in_photoRepository;
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
            //入力されたキーワードの文字数が100文字を超えていた場合
            if (keytext.Length > 100)
            {
                throw new ArgumentOutOfRangeException("入力されたkeywordの文字数が制限を超えています");
            }
            //Photoインスタンスが入力されていない場合
            if (photo == null)
            {
                throw new ArgumentNullException("写真が選択されていません");
            }
            //クエリ
            Func<IQueryable<Keyword>, IQueryable<Keyword>> query = allKeywords =>
            {
                List<Keyword> keys = new List<Keyword>();
                foreach (Keyword keyword in allKeywords)
                {
                    if (keyword.KeyText == keytext)
                    {
                        keys.Add(keyword);
                    }
                }
                return keys.AsQueryable();
            };

            //入力されたkeywordと等しいKeywordインスタンスを取得
            Keyword newKeyword = keywordRepository.Find(query).First();

            //Keywordインスタンスを取得できた場合
            if (newKeyword != null)
            {
                photo.IsAssignedTo(newKeyword);
                photoRepository.Store(photo);
            }
            //出来なかった場合
            else
            {
                return null;
            }

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
            //入力されたキーワードの文字数が100文字を超えていた場合
            if (keytext.Length > 100)
            {
                throw new ArgumentOutOfRangeException("入力されたkeywordの文字数が制限を超えています");
            }
            //Photoインスタンスが入力されていない場合
            if (photo == null)
            {
                throw new ArgumentNullException("写真が選択されていません");
            }
            //クエリ
            Func<IQueryable<Keyword>, IQueryable<Keyword>> query = allKeywords =>
            {
                List<Keyword> keys = new List<Keyword>();
                foreach (Keyword keyword in allKeywords)
                {
                    if (keyword.KeyText == keytext)
                    {
                        keys.Add(keyword);
                    }
                }
                return keys.AsQueryable();
            };

            //入力されたkeywordと等しいKeywordインスタンスを取得
            Keyword newKeyword = keywordRepository.Find(query).First();

            //Keywordインスタンスを取得できた場合
            if (newKeyword != null)
            {
                photo.IsAssignedTo(newKeyword);
                await Task.Run(() =>
                {
                    photoRepository.Store(photo);
                });
            }
            //出来なかった場合
            else
            {
                return null;
            }

            return photo;

        }
    }
}
