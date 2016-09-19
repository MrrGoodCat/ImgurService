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
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine(ImgService.DoWork());
            }
            

            Console.ReadLine();
        }
    }
}
