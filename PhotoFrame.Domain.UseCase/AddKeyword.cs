using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Domain.UseCase
{
    /// <summary>
    /// アルバムを作成するユースケースを実現する
    /// </summary>
    public class AddKeyword
    {
        private readonly KeywordRepository keywordRepository;

        public AddKeyword(KeywordRepository in_keywordRepository)
        {
            this.keywordRepository = in_keywordRepository;
        }

        /// <summary>
        /// キーワードの登録
        /// </summary>
        /// <param name="keytext"></param>
        /// <returns>終了状態を数値で返す</returns>
        public int Execute(string keytext)
        {
            //登録するキーワードの文字数が100文字を超えていた場合
            if(keytext.Length > 100)
            {
                throw new ArgumentOutOfRangeException("入力されたkeywordの文字数が制限を超えています");
            }
            //キーワードが入力されていない場合（初期化無しを想定）
            if(keytext == null)
            {
                throw new ArgumentNullException("keywordが入力されていません");
            }

            //DBに既にキーワードが格納されているか
            IEnumerable<Keyword> result = keywordRepository.Find((IQueryable<Keyword> keywords) => (from p in keywords where p.KeyText == keytext select p));

            if(keytext != "")
            {
                // 登録済みのキーワード名でない場合
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
