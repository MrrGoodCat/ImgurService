using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
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

        private string ClientID = "59b901759d20a52";
        private string ClientSecret = "3480e60e6a98105ebdf387dfe4dcb8aa56ee4561";
        public static List<string> links;
        public ImgurAPI()
        {
            links = new List<string>();
            GetGallery();
        }
        public async void GetGallery()
        {            
            var client = new ImgurClient("59b901759d20a52");
            var endpoint = new GalleryEndpoint(client);
            var gallery = await endpoint.GetGalleryAsync();

            foreach (var item in gallery)
            {
                if (item.GetType() == typeof(Imgur.API.Models.Impl.GalleryImage))
                {
                    links.Add(item.GetType().GetProperty("Link").GetValue(item).ToString());
                }
            }
        }

    }
}
