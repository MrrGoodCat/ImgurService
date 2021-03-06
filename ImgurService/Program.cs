﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ImgurService
{
    class Program
    {
        static void Main(string[] args)
        {
            ImgurAPI imgurApi = new ImgurAPI();
            Data data = new Data();
            //imgurApi.GetGallery();
            try
            {
                Console.WriteLine("Creating service host");
                ServiceHost serviceHost = new ServiceHost(typeof(ImgurService));

                //Console.WriteLine("Create binding");
                //BasicHttpBinding basicHttp = new BasicHttpBinding();

                //Console.WriteLine("Add service endpoint");
                //ServiceMetadataBehavior mex = new ServiceMetadataBehavior();

                //mex.HttpGetEnabled = true;
                //mex.HttpGetUrl = new Uri("http://localhost:8585/ImgurService");
                //serviceHost.Description.Behaviors.Add(mex);
                //serviceHost.AddServiceEndpoint(typeof(IImgurService), basicHttp, "http://localhost:8585/ImgurService");
                //Console.WriteLine("Try to start service");
                serviceHost.Open();
                //Thread.Sleep(60000);
                Console.WriteLine("Service started. Press enter to close!");
                foreach (var item in imgurApi.Albums)
                {
                    Console.WriteLine(item.ImagesCount);
                }
                Console.WriteLine("Albums count is: {0}",imgurApi.Albums.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }


            Console.ReadLine();
        }

        static async void ShowAlbums()
        {

        }
    }
}
