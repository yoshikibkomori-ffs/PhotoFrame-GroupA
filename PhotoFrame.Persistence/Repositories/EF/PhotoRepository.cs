using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    class PhotoRepository : IPhotoRepository
    {
        public bool Exists(Photo entity)
        {
            return ExistsBy(entity.Id);
        }

        public bool ExistsBy(string id)
        {
            Boolean flag = false;
            using (var context = new Album_PhotoDBEntities())
            {
                foreach (var m_Photo in context.M_Photo)
                {
                    if (m_Photo.Id == id)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
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

        public Photo Find(Func<IQueryable<Photo>, Photo> query)
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

        public Photo FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            //throw new NotImplementedException();
            Photo photo = null;
            using (var context = new Album_PhotoDBEntities())
            {
                var query = from Photo in context.M_Photo
                            where Photo.Id == id
                            select Photo;

                foreach (var m_Photo in query)
                {
                    photo = ConvertM_PhotoToPhoto(m_Photo);
                }
                return photo;
            }

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
                var query = from Photo in context.M_Photo
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

        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        private static M_Photo ConvertPhotoToM_Photo(Photo photo)
        {
            M_Photo m_Photo = new M_Photo();
            m_Photo.Id = photo.Id;
            m_Photo.FilePath = photo.File.FilePath;
            m_Photo.IsFavorite = photo.IsFavorite;
            m_Photo.AlbumId = photo.AlbumId;
            return m_Photo;
        }

        private static Photo ConvertM_PhotoToPhoto(M_Photo m_Photo)
        {
            return new Photo(m_Photo.Id, new Domain.Model.File(m_Photo.FilePath), Convert.ToBoolean(m_Photo.IsFavorite), m_Photo.AlbumId);
        }
        //private static Photo Duplication(DbSet<>)
        //{
        //    foreach(var photo in m_Photo)
        //    {
        //
        //    }
        //    return null;
        //}
    }
}
