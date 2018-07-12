﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SearchDate
    {
        /// <summary>
        /// 開始日と終了日を指定し、期間内のExifデータが関連付けられているフォトのリストを返す
        /// </summary>
        /// <param name="photos"></param>
        /// <param name="s_Date"></param>
        /// <param name="e_Date"></param>
        /// <returns></returns>
        public List<Photo> Execute(List<Photo> photos, DateTime s_Date, DateTime e_Date)
        {
            List<Photo> photolist = new List<Photo>();
            photolist = (from p in photos where p.File.Date <= s_Date && p.File.Date >= e_Date select p).ToList();
            return photolist;
            // return photoRepository.Find(photos => (from p in photos where p.Album.Name == albumName select p).ToList().AsQueryable());
        }
    }
}
