using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;

namespace EventosVista.Source.Access
{
    internal class FireBaseUploader
    {
        public string latestUpload { get; set; }
        public async Task UploadFile(string pathToFile)
        {
            try
            {
                var stream = File.OpenRead(pathToFile);

                var task = new FirebaseStorage(
                "unicaucaconectada-images.appspot.com",
                new FirebaseStorageOptions
                {

                    ThrowOnCancel = true,
                })
                .Child("images")
                .Child(Path.GetFileName(pathToFile))
                .PutAsync(stream);

                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                var downloadUrl = await task;

                latestUpload = downloadUrl.Substring(0, downloadUrl.IndexOf("&"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
