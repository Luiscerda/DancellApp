using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DancellApp.Models
{
    public class ImageModel
    {
        public string Title { get; set; }
        public bool IsVisible { get; set; }
        public string Text { get; set; }
        public ImageSource Image { get; set; }
    }
}
