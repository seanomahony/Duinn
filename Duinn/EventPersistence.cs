using Dropbox.Api;
using Dropbox.Api.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duinn
{
    static class EventPersistence
    {
        static readonly string fileName = "duinndata";

        public static async Task LoadEventsAsync()
        {
            var data = await AzureStorage.GetFileAsync(fileName);
            var stringData = Encoding.UTF8.GetString(data);
            Models.CalendarEvents.EventsList = JsonConvert.DeserializeObject<List<Models.CalendarEvent>>(stringData);
        }

        public static async void SaveEvents()
        {
            string output = JsonConvert.SerializeObject(Models.CalendarEvents.EventsList);
            var byteData = Encoding.UTF8.GetBytes(output);
            var uploadedFilename = await AzureStorage.UploadFileAsync(new MemoryStream(byteData));

        }

        public static async void ClearEvents()
        {
            string output = JsonConvert.SerializeObject(new List<Models.CalendarEvent>());
            var byteData = Encoding.UTF8.GetBytes(output);
            var uploadedFilename = await AzureStorage.UploadFileAsync(new MemoryStream(byteData));
        }
    }
}
