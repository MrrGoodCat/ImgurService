using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Models;

namespace ImgurService
{
    public class Data
    {
        public List<IImage> TopImages;
        public List<IGalleryAlbum> Galerys;

        public Data()
        {
            TopImages = new List<IImage>();
            Galerys = new List<IGalleryAlbum>();
        }


        public int GetAlbumImagesCount(IGalleryAlbum album)
        {
            return album.ImagesCount;
        }
    }
}
