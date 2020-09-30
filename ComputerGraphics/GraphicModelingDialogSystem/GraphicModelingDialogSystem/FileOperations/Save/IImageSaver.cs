using System.Windows;

namespace GraphicModelingDialogSystem.FileOperations.Save
{
    interface IImageSaver
    {
        string FileName { get; set; }
        void SaveToPng(FrameworkElement image);
        void SaveToJpeg(FrameworkElement image);
        void SaveModel(FrameworkElement image);
    }
}
