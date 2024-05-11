using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Interface;

namespace Wallpaper_Switch.Core.Controllers.File
{
    public class FileXMLControllerExpansion <T> where T: class
    {
        private List<T> _values;
        private XmlFileLoader<T> _loaderOne;
        private XmlFileSaver<T> _saverOne;
        private FileController _fileControllerOne;

        private T _value;
        private XmlFileLoader<List<T>> _loaderMany;
        private XmlFileSaver<List<T>> _saverMany;
        private FileController _fileControllerMany;

        public FileXMLControllerExpansion(List<T> values,string fileName)
        {
            _values = values;
            _loaderMany = new XmlFileLoader<List<T>>(fileName);
            _saverMany= new XmlFileSaver<List<T>>(fileName);
            _fileControllerMany = new FileController();
        }

        public FileXMLControllerExpansion(T value, string fileName)
        {
            _value = value;
            _loaderOne = new XmlFileLoader<T>(fileName);
            _saverOne = new XmlFileSaver<T>(fileName);
            _fileControllerOne = new FileController();
        }

        public void SaveOne(string path)
        {
            try
            {
                _fileControllerOne.Save<T>(_value, path,_saverOne);
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }
        }

        public void SaveMany(string path)
        {
            try
            {
                _fileControllerMany.Save(_values, path, _saverMany);
            }
            catch (Exception ex)
            {
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }
        }

        public T LoadOne(string path)
        {

            try
            {
                _value = _fileControllerOne.Load<T>(path,_loaderOne);
            }
            catch (Exception ex)
            {
                _value = null;
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }


            return _value;
        }

        public List<T> LoadMany(string path)
        {

            try
            {
                _values = _fileControllerMany.Load(path, _loaderMany);
            }
            catch (Exception ex)
            {
                _values = new List<T>();
                Logger.Logger.AppednLog(Logger.LogLevel.Error, ex.Message);
            }


            return _values;
        }
    }
}
