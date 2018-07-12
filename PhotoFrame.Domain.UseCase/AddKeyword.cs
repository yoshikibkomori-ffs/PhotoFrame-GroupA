using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Domain.UseCase
{
    /// <summary>
    /// アルバムを作成するユースケースを実現する
    /// </summary>
    public class AddKeyword
    {
        private readonly IAlbumRepository albumRepository;

        public AddKeyword(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        /// <summary>
        /// キーワードの登録
        /// </summary>
        /// <param name="keytext"></param>
        /// <returns>終了状態を数値で返す</returns>
        public int Execute(string keytext)
        {
            IEnumerable<Keyword> result = albumRepository.Find((IQueryable<Keyword> keywords) => (from p in keywords where p.KeyText == keytext select p));

            if(keytext != "")
            {
                // 登録済みのキーワード名でない場合
                if (result == null || result.Count() == 0)
                {

                    var keyword = Keyword.Create(keytext);
                    albumRepository.Store(keyword);

                    // 正常終了
                    return 0;
                }
                else
                {
                    // 既存のアルバム名
                    return 2;
                }
            }
            else
            {
                // アルバム名未入力
                return 1;
            }
            
        }
    }
}
