using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SearchDirectory
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IPhotoFileService photoFileService;

        public SearchDirectory(IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.photoRepository = photoRepository;
            this.photoFileService = photoFileService;
        }

        /// <summary>
        /// 指定したディレクトリ直下のフォトのリストを返す
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string directoryName)
        {
            IEnumerable<Domain.Model.File> files = photoFileService.FindAllPhotoFilesFromDirectory(directoryName);
            List<Photo> photosInDirectory = new List<Photo>();

            foreach(File file in files)
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

            return photosInDirectory;
        }

    }
}
