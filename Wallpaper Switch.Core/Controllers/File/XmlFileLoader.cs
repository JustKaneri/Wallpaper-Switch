using System;
using System.IO;
using System.Xml.Serialization;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Interface;

namespace Wallpaper_Switch.Core.Controllers.File
{
    public class XmlFileLoader<T> : IFileLoader<T> where T : class
    {
        public string FileName { get; }

        public XmlFileLoader(string fileName)
        {
            FileName = fileName;
        }

        public T Load(string path)
        {
            T loadObject;

            try
            {
                if (!Directory.Exists(path))
                    throw new DirectoryNotFoundException("Not correct path: " + path);

                if (string.IsNullOrWhiteSpace(FileName))
                    throw new ArgumentNullException("FileNAme");

                if(!System.IO.File.Exists($"{path}{FileName}.xml"))
                    throw new FileNotFoundException("File not found " + $"{path}{FileName}.xml");


                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "root";
                xRoot.IsNullable = true;

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xRoot);

                using (FileStream fs = new FileStream($"{path}{FileName}.xml", FileMode.OpenOrCreate))
                {
                    loadObject = (T)xmlSerializer.Deserialize(fs);
                }

                Logger.Logger.AppednLog(LogLevel.Info, $"The object {loadObject.GetType()} file has been loaded");
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(LogLevel.Error, ex.Message, this.GetType());
                return null;
            }


            return loadObject;
        }
    }
}
