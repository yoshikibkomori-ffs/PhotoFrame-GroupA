using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PhotoFrame.Persistence.Csv;

namespace PhotoFrame.Persistence.Csv
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    public class PhotoRepository/* : IPhotoRepository*/
    {
        /// <summary>
        /// 永続化ストアとして利用するCSVファイルパス
        /// </summary>
        private string CsvFilePath { get; }
        private KeywordRepository keywordRepository;

        public PhotoRepository(string databaseName, KeywordRepository keywordRepository)
        {
            this.CsvFilePath = $"{databaseName}_Photo.csv"; // $"{...}" : 文字列展開
            this.keywordRepository = keywordRepository;
        }

        public bool Exists(Photo entity)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }

        public bool ExistsBy(string id)
        {
            // TODO: ファイルIO講座以降で実装可能
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> Find(List<Photo> photos)
        {
            // TODO: イベント・デリゲート講座で実装予定
            return photos;
        }

        //public Photo Find(List<Photo> photos)
        //{
        //    // TODO: イベント・デリゲート講座で実装予定
        //    return photos.First();
        //}

        public Photo FindBy(string id)
        {
            // TODO: ファイルIO講座で実装
            // 保存したcsvからidを検索

            // なかったよ
            return null;
        }

        public Photo Store(Photo entity)
        {
            // TODO: ファイルIO講座で実装
            // entityをcsvファイルに1行出力して保存する

            return entity;
            //throw new NotImplementedException();
        }
    }
}
