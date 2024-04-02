using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Interface;

namespace Wallpaper_Switch.Core.Controllers.File
{
    public class XmlFileSaver<T> : IFileSaver<T> where T : class
    {
        public string FileName { get; }

        public XmlFileSaver(string fileName)
        {
            FileName = fileName;
        }

        public T Save(T value, string path)
        {
            try
            {
                if(value == null)
                    throw new ArgumentNullException("value");

                if(!Directory.Exists(path))
                    throw new DirectoryNotFoundException("Not correct path: " +path);

                if (string.IsNullOrWhiteSpace(FileName))
                    throw new ArgumentNullException("FileNAme");


                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                using (FileStream fs = new FileStream($"{path}{FileName}.xml", FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, value);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(LogLevel.Error, ex.Message, this.GetType());
                return null;
            }


            return value;
        }
    }
}
