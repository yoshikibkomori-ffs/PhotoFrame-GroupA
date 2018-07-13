using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.Repositories.EF
{
    //KeywordRepository(DB)
    public class KeywordRepository
    {
        //コンストラクタ
        public KeywordRepository()
        {
        }

        //キーワードのIdが同じものがあれば除外し、DBにキーワードを追加する
        public Keyword Store(Keyword entity)
        {
            using (var context = new PhotoFrameEntities())
            {
                IQueryable<Table_Keyword> 
                    query = from keyword in context.Table_Keyword
                    where keyword.Id == entity.Id
                    select keyword;
                foreach (var table_Keyword in query)
                {
                    context.Table_Keyword.Remove(table_Keyword);
                }
                context.Table_Keyword.Add(Convert_Key_to_MKey(entity));
                context.SaveChanges();
                return entity;
            }
        }

        //queryの条件に一致するIEnumerable<Keyword>を返す
        public IEnumerable<Keyword> Find(Func<IQueryable<Keyword>, IQueryable<Keyword>> query)
        {
            // TODO: DBプログラミング講座で実装
            List<Keyword> keywords = new List<Keyword>();
            using (var context = new PhotoFrameEntities())
            {
                foreach (var table_Keyword in context.Table_Keyword)
                {
                    keywords.Add(Convert_MKey_to_Key(table_Keyword));
                }
                return query(keywords.AsQueryable());
            };
        }

        //keytextが一致するIEnumerable<Keyword>を返す
        public Keyword Exist(string keytext)
        {
            IEnumerable<Keyword> keywords = Find(x =>
            {
                return (from keyword in x where keyword.KeyText == keytext select keyword);
            });
            if(keywords == null)
            {
                return Keyword.Create(keytext);
            }
            return keywords.First();           
        }

        private Table_Keyword Convert_Key_to_MKey(Keyword keyword)

        {
            Table_Keyword table_Keyword = new Table_Keyword();
            table_Keyword.Id = keyword.Id;
            table_Keyword.Keytext = keyword.KeyText;
            return table_Keyword;
        }

        private Keyword Convert_MKey_to_Key(Table_Keyword table_Keyword)
        {
            return new Keyword(table_Keyword.Id, table_Keyword.Keytext);
        }
    }
}

