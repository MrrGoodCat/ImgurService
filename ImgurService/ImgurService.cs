using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Json;

namespace ImgurService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ImgurService : IImgurService
    {
        ImgurAPI imgurApi = new ImgurAPI();
        public string DoWork()
        {
            return imgurApi.ImagesFromGallery.First().Link;
        }

        public string GetAlbumById(string albumId)
        {
            string result = null;
            foreach (var item in imgurApi.Albums)
            {
                if (item.Id == albumId)
                {
                    result = item.ToJSON();
                }
            }
            return result;
        }

        public string[] GetAllAlbums()
        {
            string[] albums = new string[imgurApi.Albums.Count];
            for (int i = 0; i < albums.Length; i++)
            {
                albums[i] = imgurApi.Albums[i].ToJSON();
            }
            return albums;
        }

        public string[] GetAllImagesFromAlbum(string albumId)
        {
            string[] images = null;
            foreach (var item in imgurApi.Albums)
            {
                if (albumId == item.Id)
                {
                    images = new string[item.ImagesCount];
                    int index = 0;
                    foreach (var img in item.Images)
                    {
                        images[index] = img.ToJSON();
                        index++;
                    }
                }
            }
            return images;
        }

        public string[] GetTopImages(int count)
        {
            if (count > imgurApi.ImagesFromGallery.Count)
            {
                count = imgurApi.ImagesFromGallery.Count;
            }

            string[] images = new string[count];
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = imgurApi.ImagesFromGallery[i].ToJSON();
            }
            return images;
        }
    }
}
