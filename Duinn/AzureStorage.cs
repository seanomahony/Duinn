using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;

namespace Duinn
{
    public static class AzureStorage
    {
        static readonly string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=duinnstorage;AccountKey=9x/RqzRnFrK81ie0RcCwN58TZMdfaN8TW4QBMftccJeQXw+8+8s03SZ3eqRzh8wJ2sBbMZ42iPtp+AStnaAq4A==;EndpointSuffix=core.windows.net";
        static readonly string containerName = "duinnstorage";
        static readonly string fileName = "duinndata";

        static CloudBlobContainer GetContainer()
        {
            var account = CloudStorageAccount.Parse(storageConnectionString);
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference(containerName);
        }

        public static async Task<IList<string>> GetFilesListAsync()
        {
            var container = GetContainer();

            var allBlobsList = new List<string>();
            BlobContinuationToken token = null;

            do
            {
                var result = await container.ListBlobsSegmentedAsync(token);
                if (result.Results.Count() > 0)
                {
                    var blobs = result.Results.Cast<CloudBlockBlob>().Select(b => b.Name);
                    allBlobsList.AddRange(blobs);
                }
                token = result.ContinuationToken;
            } while (token != null);

            return allBlobsList;
        }

        public static async Task<byte[]> GetFileAsync(string name)
        {
            var container = GetContainer();

            var blob = container.GetBlobReference(name);
            if (await blob.ExistsAsync())
            {
                await blob.FetchAttributesAsync();
                byte[] blobBytes = new byte[blob.Properties.Length];

                await blob.DownloadToByteArrayAsync(blobBytes, 0);
                return blobBytes;
            }
            return null;
        }

        public static async Task<string> UploadFileAsync(Stream stream)
        {
            var container = GetContainer();
            await container.CreateIfNotExistsAsync();

            var fileBlob = container.GetBlockBlobReference(fileName);
            await fileBlob.UploadFromStreamAsync(stream);

            return fileName;
        }

        public static async Task<bool> DeleteFileAsync(string name)
        {
            var container = GetContainer();
            var blob = container.GetBlobReference(name);
            return await blob.DeleteIfExistsAsync();
        }

        public static async Task<bool> DeleteContainerAsync()
        {
            var container = GetContainer();
            return await container.DeleteIfExistsAsync();
        }
    }
}