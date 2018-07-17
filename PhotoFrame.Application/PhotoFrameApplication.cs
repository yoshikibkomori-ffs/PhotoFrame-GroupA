using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.Repositories.EF;
using PhotoFrame.Persistence;

namespace PhotoFrame.Application
{
    /// <summary>
    /// PhotoFrameのUIの指示にしたがってドメインのユースケースを起動する
    /// </summary>
    public class PhotoFrameApplication
    {
        private readonly CreatePhotoList createPhotoList;　//変更済み
        private readonly AddKeyword addKeyword; //変更済み
        private readonly ChangeKeyword changeKeyword; //変更済み
        private readonly ChangeFavorite changeFavorite; //変更済み
        private readonly SearchKeyword searchKeyword; //変更済み
        private readonly SearchFavorite searchFavorite; //変更済み
        private readonly SearchDate searchDate; //変更済み
        private readonly SortDate sortDate; //変更済み
        private readonly SortSlideList sortSlideList; //変更済み

        public PhotoFrameApplication(KeywordRepository keywordRepository, PhotoRepository photoRepository, PhotoFileService photoFileService)
        {
            this.createPhotoList = new CreatePhotoList(photoRepository, photoFileService); //済み
            this.addKeyword = new AddKeyword(keywordRepository); //済み
            this.changeKeyword = new ChangeKeyword(keywordRepository, photoRepository); //済み
            this.changeFavorite = new ChangeFavorite(photoRepository); //済み
            this.searchKeyword = new SearchKeyword(); //済み
            this.searchFavorite = new SearchFavorite(); //済み
            this.searchDate = new SearchDate(); //済み
            this.sortDate = new SortDate(); //済み
            this.sortSlideList = new SortSlideList(); //済み
        }

        public List<Photo> CreatePhotoList(string dirpath)
        {
            return createPhotoList.Execute(dirpath); //済み
        }

        public int AddKeyword(string albumName)
        {
            return addKeyword.Execute(albumName); //済み
        }

        public Photo Changekeyword(Photo photo, string keytext)
        {
            return changeKeyword.Execute(photo, keytext); //済み
        }

        public async Task<Photo> ChangeKeywordAsync(Photo photo, string keytext)
        {
            Photo ret_photo = await changeKeyword.ExecuteAsync(photo, keytext); //済み
            return ret_photo;
        }

        public Photo ChangeFavorite(Photo photo)
        {
            return changeFavorite.Execute(photo); //済み
        }

        public async Task<Photo> ChangeFavoriteAsync(Photo photo)
        {
            Photo ret_photo = await changeFavorite.ExecuteAsync(photo); //済み
            return ret_photo;
        }

        public List<Photo> SearchKeyword(List<Photo> photos, string keytext)
        {
            return searchKeyword.Execute(photos, keytext); //済み
        }

        public List<Photo> SearchFavorite(List<Photo> photos)
        {
            return searchFavorite.Execute(photos); //済み
        }

        public List<Photo> SearchDate(List<Photo> photos, DateTime s_Date, DateTime e_Date)
        {
            return searchDate.Execute(photos, s_Date, e_Date); //済み
        }

        public List<Photo> SortDate(List<Photo> photos, Boolean order)
        {
            return sortDate.Execute(photos, order); //済み
        }

        public List<Photo> SortSlideList(List<Photo> photos)
        {
            return sortSlideList.Execute(photos); //済み
        }
    }
}