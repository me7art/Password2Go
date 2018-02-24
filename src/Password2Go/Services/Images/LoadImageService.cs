using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using ImageProcessor;
using ImageProcessor.Imaging;

namespace Password2Go.Services.Images
{
    public class LoadImageService : IDisposable
    {
        Dictionary<string, ImageFactory> loadedImages = new Dictionary<string, ImageFactory>();

        public LoadImageService() { }

        public void Dispose()
        {
            RemoveLoadedImages();
        }

        public void RemoveLoadedImages()
        {
            foreach (var iitem in loadedImages)
            {
                iitem.Value?.Dispose();
            }
            loadedImages.Clear();
        }

        public void LoadImagesConfig(Data.Configs.ImagesConfig config, string rootDirectory)
        {
            foreach(var item in config.Images)
            {
                var path = Path.Combine(rootDirectory, item.Filename);
                LoadImage(path, item.Name);
            }
        }

        public void LoadImage(string imagePath, string name)
        {
            if (loadedImages.ContainsKey(name))
            {
                throw new ArgumentException($"Already added image with name: {name}");
            }

            ImageFactory image = new ImageFactory().Load(imagePath);
            loadedImages.Add(name, image);
        }

        public bool Exists(string name)
        {
            return loadedImages.ContainsKey(name);
        }

        public ImageFactory GetImage(string name)
        {
            return loadedImages[name];
        }
    }
}
