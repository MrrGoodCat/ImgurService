﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ImgurService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IImgurService
    {
        [OperationContract]
        string DoWork();

        [OperationContract]
        string[] GetTopImages(int count);

        [OperationContract]
        string GetAlbumById(string albumId);

        [OperationContract]
        string[] GetAllAlbums();

        [OperationContract]
        string[] GetAllImagesFromAlbum(string albumId);
    }
}
