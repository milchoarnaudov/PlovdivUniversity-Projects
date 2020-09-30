using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace GraphicModelingDialogSystem.FileOperations.Save
{
    class SaveImageToFile : IImageSaver
    {
        public SaveImageToFile()
        {
            this.FileName = "New Image.png";
        }

        public string FileName { get; set; }

        public void SaveToPng(FrameworkElement image)
        {
            var encoder = new PngBitmapEncoder();
            SaveUsingEncoder(image, encoder);
        }

        public void SaveToJpeg(FrameworkElement image)
        {
            var encoder = new JpegBitmapEncoder();
            SaveUsingEncoder(image, encoder);
        }

        private void SaveUsingEncoder(FrameworkElement image, BitmapEncoder encoder)
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)image.ActualWidth, (int)image.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            Size imageSize = new Size(image.ActualWidth, image.ActualHeight);
            var clone = Clone(image);
            clone.Measure(imageSize);
            clone.Arrange(new Rect(imageSize));
            bitmap.Render(clone);
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);

            using (var stream = File.Create(FileName))
            {
                encoder.Save(stream);
            }
        }

        public void SaveModel(FrameworkElement canvas)
        {
            string mystrXAML = XamlWriter.Save(canvas);

            using (var filestream = File.Create("model.xaml"))
            {
                using (var streamwriter = new StreamWriter(filestream))
                {
                    streamwriter.Write(mystrXAML);
                }
            }
        }

        private FrameworkElement Clone(FrameworkElement objToCopy)
        {
            string objXaml = XamlWriter.Save(objToCopy);
            StringReader stringReader = new StringReader(objXaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            FrameworkElement clone = (FrameworkElement)XamlReader.Load(xmlReader);
            return clone;
        }
    }
}
