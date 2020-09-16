using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphicModelingDialogSystem.Save
{
    interface IImageSaver
    {
        string FileName { get; set; }
        void SaveToPng(FrameworkElement image);
        void SaveToJpeg(FrameworkElement image);
    }
}
