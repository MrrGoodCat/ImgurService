using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgurClient.ImgService;
using System.Threading;

namespace ImgurClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IImgurService ImgService = new ImgurServiceClient();
            System.Diagnostics.Process.Start(ImgService.DoWork()); 

                
            Console.WriteLine("ok...");
            //Console.WriteLine(ImgService.DoWork());

            

            Console.ReadLine();
        }
    }
}
