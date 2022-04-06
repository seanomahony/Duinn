using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Duinn
{
    class DropboxUploader
    {
        static string reportName;
        static string filePath;
        static readonly int IsCompressed = 1; //Set Flag = 1 to unzip file
        public static void UploadToDropbox(Stream file, string DropboxFolderPath, string DropboxKey)
        {
            reportName = "ReportName.csv";
            filePath = DropboxFolderPath + reportName;  //Replace with your filename
            using (var client = new DropboxClient(DropboxKey))
            {
                using (var stream = IsFileCompressedCheck(file))
                {
                    var resp = client.Files.UploadAsync(filePath, WriteMode.Overwrite.Instance, body: stream).Result;
                }
            }
            Console.WriteLine($"Saved to {filePath}\n\n");
        }

        private static Stream IsFileCompressedCheck(Stream file)
        {
            if (IsCompressed == 1)
            {
                file = UnZip(file);
            }

            return file;
        }

        private static Stream UnZip(Stream file)
        {
            using (ZipArchive archive = new ZipArchive(file, ZipArchiveMode.Read))
            {
                ZipArchiveEntry entry = archive.Entries.FirstOrDefault();
                using (StreamReader reader = new StreamReader(entry.Open()))
                {
                    MemoryStream stream = new MemoryStream();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(reader.ReadToEnd());
                    writer.Flush();
                    stream.Position = 0;
                    file = stream;
                    reportName = entry.Name;
                    Console.WriteLine(entry.Name);
                }
            }

            return file;
        }
    }

}