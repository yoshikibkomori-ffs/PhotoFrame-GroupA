using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IAlbumRepository">の実装クラス
    /// </summary>
    public class AlbumRepository
    {
        //◆追加
        System.Data.Entity.SqlServer.SqlProviderServices instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;


        public bool Exists(Album entity)
        {
            return ExistsBy(entity.Id);
        }

        public bool ExistsBy(string id)
        {
            Boolean flag = false;
            using (var context = new Album_PhotoDBEntities())
            {
                foreach(var m_Album in context.M_Album)
                {
                    if(m_Album.Id == id)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        public IEnumerable<Album> Find(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            // TODO: DBプログラミング講座で実装
            List<Album> albums = new List<Album>();
            IQueryable<Album> query_albums;
            using (var context = new Album_PhotoDBEntities())
            {
                if (context.M_Album != null)
                {
                    foreach (var m_Album in context.M_Album)
                    {
                        albums.Add(ConvertM_AlbumToAlbum(m_Album));
                    }
                    query_albums = albums.AsQueryable();
                }
                else
                {
                    query_albums = null;
                }
            }
            if (query_albums != null)
            {
                return query(albums.AsQueryable());
            }
            else
            {
                return null;
            }
        }

        public Album Find(Func<IQueryable<Album>, Album> query)
        {
            List<Album> albums = new List<Album>();
            using (var context = new Album_PhotoDBEntities())
            {
                foreach(var m_Album in context.M_Album)
                {
                    albums.Add(ConvertM_AlbumToAlbum(m_Album)); 
                }
            }

            return query(albums.AsQueryable());
        }
        public Album FindBy(string id)
        {
            Album album = null;
            using (var context = new Album_PhotoDBEntities())
            {
                var query = from Album in context.M_Album
                            where Album.Id == id
                            select Album;

                foreach (var m_Album in query)
                {
                    album = ConvertM_AlbumToAlbum(m_Album);
                }
                return album;
            }
        }

        public Album Store(Album entity)
        {
            using (var context = new Album_PhotoDBEntities())
            {
                var query = from Album in context.M_Album
                            where Album.Id == entity.Id
                            select Album;
                foreach (var m_Album in query)
                {
                    context.M_Album.Remove(m_Album);
                }
                context.M_Album.Add(ConvertAlbumToM_Album(entity));
                context.SaveChanges();
                return entity;
            }
        }
        private static M_Album ConvertAlbumToM_Album(Album album)
        {
            M_Album m_Album = new M_Album();
            m_Album.Id = album.Id;
            m_Album.Name = album.Name;
            m_Album.Discription = album.Description;
            return m_Album;
        }

        private static Album ConvertM_AlbumToAlbum(M_Album m_album)
        {
            return new Album(m_album.Id, m_album.Name, m_album.Discription);
        }

    }
}
