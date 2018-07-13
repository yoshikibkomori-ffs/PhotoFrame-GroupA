using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.EF
{
    //PhotoRepository(DB)
    class PhotoRepository
    {
        //コンストラクタ
        public PhotoRepository()
        {
        }
        //PhotoのIdが同じものがあれば除外し、DBにPhotoを追加する
        public Photo Store(Photo entity)
        {
            using (var context = new PhotoFrameEntities())
            {
                IQueryable<Table_Photo>
                    query = from Photo in context.Table_Photo
                            where Photo.Id == entity.Id
                            select Photo;
                foreach (var table_Photo in query)
                {
                    context.Table_Photo.Remove(table_Photo);
                }
                context.Table_Photo.Add(Convert_Photo_to_MPhoto(entity));
                context.SaveChanges();
                return entity;
            }
        }
        //queryの条件に一致するIEnumerable<Keyword>を返す
        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            // TODO: DBプログラミング講座で実装
            List<Photo> photos = new List<Photo>();
            using (var context = new PhotoFrameEntities())
            {
                foreach (var table_Photo in context.Table_Photo)
                {
                    photos.Add(Convert_MPhoto_to_Photo(table_Photo));
                }
                return query(photos.AsQueryable());
            };
        }

        private static Table_Photo Convert_Photo_to_MPhoto(Photo photo)
        {
            Table_Photo table_Photo = new Table_Photo();
            table_Photo.Id = photo.Id;
            table_Photo.FilePath = photo.File.FilePath;
            table_Photo.IsFavorite = photo.IsFavorite;
            table_Photo.DateTime = photo.File.DateTime;
            table_Photo.KeywordId = photo.Keyword.Id;
            return table_Photo;
        }

        private static Photo Convert_MPhoto_to_Photo(Table_Photo table_Photo)
        {
            Photo photo = new Photo(table_Photo.Id, new Domain.Model.File(table_Photo.FilePath), Convert.ToBoolean(table_Photo.IsFavorite), new Keyword(table_Photo.KeywordId,table_Photo.Table_Keyword.Keytext));
            photo.File.AddDateTime(table_Photo.DateTime);
            return photo;
        }
    }
}