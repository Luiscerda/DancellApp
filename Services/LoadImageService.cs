using DancellApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DancellApp.Services
{
    public class LoadImageService
    {
        public ImageModel imageModel;
        public LoadImageService()
        { 
        }
        public async Task<FileResult> PickAndShow(MediaPickerOptions options)
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync(options);
                imageModel = new ImageModel();

                if (result != null)
                {
                    var size = await GetStreamSizeAsync(result);
                    
                    imageModel.Text = $"File Name: {result.FileName} ({size:0.00} KB)";

                    var ext = Path.GetExtension(result.FileName).ToLowerInvariant();                   
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                    {
                        var stream = await result.OpenReadAsync();
                        string fileDestiny = Path.Combine(FileSystem.Current.AppDataDirectory, Path.GetFileName(result.FileName));
                        using var resourceStream = await FileSystem.OpenAppPackageFileAsync("DancellApp/Resources");
                        if (resourceStream is FileStream)
                        {
                            string absolutePath = (resourceStream as FileStream).Name;
                        }
                        using (var fileStream = File.Create(fileDestiny))
                        {
                            imageModel.Image = ImageSource.FromStream(() => stream);
                            imageModel.IsVisible = true;
                            stream.Seek(0, SeekOrigin.Begin);
                            stream.CopyTo(fileStream);
                        }                     
                    }
                    else
                    {
                        imageModel.IsVisible = false;
                    }
                }
                else
                {
                    imageModel.Text = $"Pick cancelled.";
                }

                return result;
            }
            catch (Exception ex)
            {
                imageModel.Text = ex.ToString();
                imageModel.IsVisible = false;
                return null;
            }
        }

        async Task<double> GetStreamSizeAsync(FileResult result)
        {
            try
            {
                using var stream = await result.OpenReadAsync();
                return stream.Length / 1024.0;
            }
            catch
            {
                return 0.0;
            }
        }
    }
}
