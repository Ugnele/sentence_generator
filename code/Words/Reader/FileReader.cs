using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Words.Reader
{
    public class FileReader
    {
        public CloudStorageAccount storageAccount;
        public CloudBlobClient serviceClient;
        public CloudBlobContainer container;
        public CloudBlockBlob blob;

        public string ReadBlobContents(string connectionString, string fileName)
        {         
            storageAccount = CloudStorageAccount.Parse(connectionString);
            serviceClient = storageAccount.CreateCloudBlobClient();
            container = serviceClient.GetContainerReference($"project");
            blob = container.GetBlockBlobReference($"{fileName}");

            string contents = blob.DownloadTextAsync().Result;

            return contents;
        }

        public string[] ReadFile(string connectionString, string wordsFile)
        {
            string contents = ReadBlobContents(connectionString, wordsFile + ".txt");
            string[] words = contents.Split("\r\n");
            return words;
        }

        public List<string> GetRandomWords(string[] words, string key)
        {
            var random = new Random();
            int randomIndex;
            List<string> selectedWords = new();
            if(key.Equals("nouns"))
            {
                randomIndex = random.Next(0, words.Length);
                selectedWords.Add(words[randomIndex]);
            }
            randomIndex = random.Next(0, words.Length);
            selectedWords.Add(words[randomIndex]);
            
            return selectedWords;
        }
    }
}
