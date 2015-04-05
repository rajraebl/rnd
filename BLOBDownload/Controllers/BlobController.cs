using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLOBDownload.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace BLOBDownload.Controllers
{
    public class BlobController : Controller
    {
        StorageCredentials credentials = new StorageCredentials("cdn0storage", "BUkzLIzJJQ7T/mzHP+j+sllgOzKMHTBd8M1lxKUU0uQHQDEJHswjccFXRX5aQK2TNehc0NKvlkbwaq0qUlu+Sw==");
        CloudStorageAccount storageAccount;

        public BlobController()
        {
            storageAccount = new CloudStorageAccount(credentials, true);
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Blob objBlob)
        {
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(objBlob.ContainerName);
            var blob = container.GetBlockBlobReference(objBlob.FileName);

            MemoryStream ms = new MemoryStream();
            blob.DownloadToStream(ms);

            Response.ContentType = blob.Properties.ContentType;
            Response.AddHeader("Content-Disposition","Attachment; filename=" + objBlob.FileName);
            Response.AddHeader("Content-Length", blob.Properties.Length.ToString());

            Response.BinaryWrite(ms.ToArray());

            return View();
        }

    }
}
