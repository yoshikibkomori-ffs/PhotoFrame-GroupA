using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Domain.UseCase
{
    public class CreatePhotoList
    {
        private readonly PhotoRepository photoRepository;
        private readonly PhotoFileService photoFileService;

        public CreatePhotoList(PhotoRepository in_photoRepository, PhotoFileService in_photoFileService)
        {
            this.photoRepository = in_photoRepository;
            this.photoFileService = in_photoFileService;
        }

        /// <summary>
        /// 指定したディレクトリ直下のフォトのリストを返す
        /// </summary>
        /// <param name="dirpath"></param>
        /// <returns></returns>
        public List<Photo> Execute(string dirpath)
        {
            //ディレクトリパスが入力されていない場合
            if (dirpath.Length == 0 || dirpath == null)
            {
                throw new ArgumentNullException("ディレクトリパスが入力されていません");
            }

            //ディレクトリ内に存在する写真ファイルの一覧を取得（Fileインスタンス)
            IEnumerable<Domain.Model.File> files = photoFileService.FindAllPhotoFilesFromDirectory(dirpath);

            List<Photo> photosInDirectory = new List<Photo>();

            foreach (File file in files)
            {
                //クエリ
                Func<IQueryable<Photo>, IQueryable<Photo>> query = allPhotos =>
                {
                    List<Photo> photos = new List<Photo>();
                    foreach (Photo photo in allPhotos)
                    {
                        if (photo.File.FilePath == file.FilePath)
                        {
                            photos.Add(photo);
                        }
                    }
                    if (photos.Count() == 0)
                    {
                        photos.Add(Photo.CreateFromFile(file));
                    }
                    return photos.AsQueryable();

                };

                //既にDBに写真データが登録されているか
                Photo hitPhoto = photoRepository.Find(query).First();

                //登録されていたら
                if (hitPhoto != null)
                {
                    photosInDirectory.Add(hitPhoto);
                }
                //登録されていなかったら
                else
                {
                    photosInDirectory.Add(Photo.CreateFromFile(file));
                }
            }
            //写真ファイルが存在しなかった場合
            if (photosInDirectory == null)
            {
                return null;
            }
            return photosInDirectory;
        }

    }
}
