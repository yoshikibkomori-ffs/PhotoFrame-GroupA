using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Domain.Model
{
    public class Keyword/* : IEntity*/
    {
        public string Id { get; private set; }

        /// <summary>
        /// アルバム名
        /// </summary>
        public string KeyText { get; private set; }

        /// <summary>
        /// 説明
        /// </summary>
        //public string Description { get; private set; }

        /// <summary>
        /// 所属写真（コレクション）
        /// </summary>
        public virtual ICollection<Photo> Photos { get; private set; }

        public static Keyword Create(string keytext)
            => new Keyword(Guid.NewGuid().ToString(), keytext);

        public Keyword(string keywordId, string keytext)
        {
            Id = keywordId;
            KeyText = keytext;
        }

        private Keyword() { }

        //public void Rename(string newName)
        //{
        //    Name = newName;
        //}

        //public void ChangeDescription(string newDescription)
        //{
        //    Description = newDescription;
        //}

        public override bool Equals(object obj)
        {
            if ((object)this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            return Id == ((Keyword)obj).Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Keyword keyword1, Keyword keyword2)
        {
            if (ReferenceEquals(keyword1, keyword2)) return true;
            if ((object)keyword1 == null || (object)keyword2 == null) return false;
            return keyword1.Equals(keyword2);
        }

        public static bool operator !=(Keyword keyword1, Keyword keyword2) => !(keyword1 == keyword2);
    }
}
