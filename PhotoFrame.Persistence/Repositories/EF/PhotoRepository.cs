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

        public Photo Store(Photo entity)
        {
            // TODO: DBプログラミング講座で実装
            //using (var context = new Album_PhotoDBEntities())
            //{
            //    if (Exists(entity))
            //    {
            //        context.M_Photo.Remove(ConvertPhotoToM_Photo(entity));
            //    }
            //    context.M_Photo.Add(ConvertPhotoToM_Photo(entity));
            //    context.SaveChanges();
            //    return entity;
            //}
            using (var context = new Album_PhotoDBEntities())
            {
                IQueryable query = from Photo in context.M_Photo
                                   where Photo.Id == entity.Id
                                   select Photo;
                foreach (var m_Photo in query)
                {
                    context.M_Photo.Remove(m_Photo);
                }
                context.M_Photo.Add(ConvertPhotoToM_Photo(entity));
                context.SaveChanges();
                return entity;
            }

        }

        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            // TODO: DBプログラミング講座で実装
            List<Photo> photos = new List<Photo>();
            using (var context = new Album_PhotoDBEntities())
            {
                foreach (var m_Photo in context.M_Photo)
                {
                    photos.Add(ConvertM_PhotoToPhoto(m_Photo));
                }
                return query(photos.AsQueryable());
            };
        }

        private static M_Photo Convert_Photo_to_MPhoto(Photo photo)

        {
            M_Photo m_Photo = new M_Photo();
            m_Photo.Id = photo.Id;
            m_Photo.FilePath = photo.File.FilePath;
            m_Photo.IsFavorite = photo.IsFavorite;
            m_Photo.AlbumId = photo.AlbumId;
            return m_Photo;
        }

        private static Photo Convert_MPhoto_to_Photo(M_Photo m_Photo)
        {
            return new Photo(m_Photo.Id, new Domain.Model.File(m_Photo.FilePath), Convert.ToBoolean(m_Photo.IsFavorite), m_Photo.AlbumId);
        }
    }
}