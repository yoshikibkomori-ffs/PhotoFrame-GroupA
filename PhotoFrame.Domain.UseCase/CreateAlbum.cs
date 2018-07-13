using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.Csv;

namespace PhotoFrame.Domain.UseCase
{
    /// <summary>
    /// アルバムを作成するユースケースを実現する
    /// </summary>
    // TODO: 仮実装
    public class CreateAlbum
    {
        private readonly KeywordRepository keywordRepository;

        public AddKeyword(KeywordRepository keywordRepository)
        {
            this.keywordRepository = keywordRepository;
        }

        /// <summary>
        /// アルバムの登録
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns>終了状態を数値で返す</returns>
        public int Execute(string albumName)
        {
            IEnumerable<Keyword> result = keywordRepository.Find((IQueryable<Keyword> keywords) => (from p in keywords where p.KeyText == keytext select p));

            if(albumName != "")
            {
                // 登録済みのアルバム名でない場合
                if (result == null || result.Count() == 0)
                {

                    var keyword = Keyword.Create(keytext);
                    keywordRepository.Store(keyword);

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
