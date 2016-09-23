using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using ImgurService.APIResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurService
{
    public class ImgurAPI
    {
        private string EndPoint = "https://api.imgur.com/3/";
        public static List<IImage> GetedImages;
        public List<IGalleryAlbum> Galerys;
        private string ClientID = "59b901759d20a52";
        private string ClientSecret = "3480e60e6a98105ebdf387dfe4dcb8aa56ee4561";
        public static List<Image> links;
        public Data data;
        public ImgurAPI()
        {
            data = new Data();
            links = new List<Image>();
            GetedImages = new List<IImage>();
            Galerys = new List<IGalleryAlbum>();
            GetGallery();
            GetGallerys();
        }
        public async void GetGallery()
        {
            var client = new ImgurClient(ClientID);
            var endpoint = new GalleryEndpoint(client);
            var gallery = await endpoint.GetGalleryAsync();

            foreach (var item in gallery)
            {
                if (item.GetType() == typeof(Imgur.API.Models.Impl.GalleryImage))
                {
                    var endp = new ImageEndpoint(client);
                    var im = endp.GetImageAsync(item.GetType().GetProperty("Id").GetValue(item).ToString());
                    GetedImages.Add(im.Result);
                    //Image image = new Image();
                    //foreach (var img in image.GetType().GetProperties())
                    //{
                    //    img.SetValue(image, item.GetType().GetProperty(img.Name).GetValue(item).ToString());                        
                    //}
                    //links.Add(image);
                }
            }
        }

        public async Task<IImage> GetPopularImages()
        {
            var client = new ImgurClient("59b901759d20a52");
            var endpoint = new GalleryEndpoint(client);
            var gallery = await endpoint.GetGalleryAsync();

            foreach (var item in gallery)
            {
                if (item.GetType() == typeof(Imgur.API.Models.Impl.GalleryImage))
                {
                    var endp = new ImageEndpoint(client);
                    var im = endp.GetImageAsync(item.GetType().GetProperty("Id").GetValue(item).ToString());
                    return im.Result;
                }
            }
            return null;
        }

        public async void GetGallerys()
        {
            var client = new ImgurClient(ClientID);
            var endpoint = new GalleryEndpoint(client);
            var gallery = await endpoint.GetGalleryAsync();

            foreach (var item in gallery)
            {
                if (item.GetType() == typeof(Imgur.API.Models.Impl.GalleryAlbum))
                {
                    var endp = new GalleryEndpoint(client);
                    var galleryAlbum = endp.GetGalleryAlbumAsync(item.GetType().GetProperty("Id").GetValue(item).ToString());
                    Galerys.Add(galleryAlbum.Result);                    
                }
            }
        }
    }
}
