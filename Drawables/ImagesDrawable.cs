using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace DancellApp.Drawables
{
    internal class LoadImageDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            IImage image;
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("DancellApp.Resources.Images.header.png"))
            {
                image = PlatformImage.FromStream(stream);
            }
            if (image != null)
            {
                canvas.DrawImage(image, 10, 10, image.Width, image.Height);
            }
        }
    }
}
