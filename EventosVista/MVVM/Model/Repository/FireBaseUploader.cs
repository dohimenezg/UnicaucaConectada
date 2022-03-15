using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;

namespace EventosVista.MVVM.Model.Repository
{
    internal class FireBaseUploader
    {
        public string latestUpload { get; set; }
        public async Task UploadFile(string pathToFile)
        {
            try
            {
                var stream = File.OpenRead(pathToFile);
                //var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyDj4h0NvWvATAjBxvIpazVqWPf-gtS9a0g"));
                //var a = await auth.SignInWithEmailAndPasswordAsync("pdaniel@unicauca.edu.co", "user123");
                var task = new FirebaseStorage(
                "unicaucaconectada-images.appspot.com",
                new FirebaseStorageOptions
                {
                //AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                ThrowOnCancel = true,
                })
                .Child("images")
                .Child(Path.GetFileName(pathToFile))
                .PutAsync(stream);

                // Track progress of the upload
                task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                // await the task to wait until upload completes and get the download url
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
