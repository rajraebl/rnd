using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
namespace BlobsInCDN
{
    class Program
    {
        static void Main(string[] args)
        {
            //Specify storage credentials.
            StorageCredentials credentials = new StorageCredentials("cdn0storage", "BUkzLIzJJQ7T/mzHP+j+sllgOzKMHTBd8M1lxKUU0uQHQDEJHswjccFXRX5aQK2TNehc0NKvlkbwaq0qUlu+Sw==");

            //Create a reference to your storage account, passing in your credentials.
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);

            //Create a new client object, which will provide access to Blob service resources.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Create a new container.
            CloudBlobContainer container = blobClient.GetContainerReference("cdncontent");
            container.CreateIfNotExists();

            //Specify that the container is publicly accessible.
            BlobContainerPermissions containerAccess = new BlobContainerPermissions();
            containerAccess.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(containerAccess);

            //Create a new blob and write some text to it.
            var  blob = container.GetBlockBlobReference("testblob.txt");
            blob.UploadText("This is a test blob.");

            //Set the Cache-Control header on the blob to specify your desired refresh interval.
            blob.SetCacheControl("public, max-age=31536000");

            Console.Read();
        }
    }
    public static class BlobExtensions
    {
        //A convenience method to set the Cache-Control header.
        public static void SetCacheControl(this CloudBlockBlob blob, string value)
        {
            blob.Properties.CacheControl = value;
            blob.SetProperties();
        }
    }
}
