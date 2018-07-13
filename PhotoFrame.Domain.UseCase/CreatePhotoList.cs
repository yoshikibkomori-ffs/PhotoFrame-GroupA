using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

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
            IEnumerable<Domain.Model.File> files = photoFileService.FindAllPhotoFilesFromDirectory(dirpath);
            List<Photo> photosInDirectory = new List<Photo>();

            if (dirpath.Length == 0 || dirpath == null)
            {
                throw new ArgumentNullException("ディレクトリパスが入力されていません");
            }

            foreach (File file in files)
            {
                Func<IQueryable<Photo>, Photo> query = allPhotos =>
                {
                    foreach (Photo photo in allPhotos)
                    {
                        if (photo.File.FilePath == file.FilePath)
                        {
                            return photo;
                        }
                    }

                    return Photo.CreateFromFile(file);
                };

                Photo hitPhoto = photoRepository.Find(query);

                if(hitPhoto != null)
                {
                    photosInDirectory.Add(hitPhoto);
                }
                else
                {
                    photosInDirectory.Add(Photo.CreateFromFile(file));
                }
            }
            if(photosInDirectory == null)
            {
                return null;
            }
            return photosInDirectory;
        }

    }
}
