using DancellApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                var ruta = string.Empty;
                if (result != null)
                {
                    var size = await GetStreamSizeAsync(result);
                    imageModel.Text = $"{result.FileName}";
                  
                    var ext = Path.GetExtension(result.FileName).ToLowerInvariant();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                    {
                        var stream = await result.OpenReadAsync();
                        imageModel.Image = ImageSource.FromStream(() => stream);
                        imageModel.IsVisible = true;

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
