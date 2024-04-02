using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.File;
using Wallpaper_Switch.Core.Controllers.Logger;

namespace Wallpaper_Switch.Tests
{
    [TestClass]
    public class FileTest
    {
        public class TestData
        {
            public string Name { get; set; }
            public string DateTime { get; set; } 
        }

        public FileTest()
        {
            Logger logger = new Logger("C:\\TestResults\\");
        }

        [TestMethod]
        public void CreateFile1()
        {
            XmlFileSaver<TestData> xmlFileSaver = new XmlFileSaver<TestData>("testCreateFile1");
            TestData data = new TestData();
            data.Name = "test1";
            data.DateTime = DateTime.Now.ToShortDateString();

            xmlFileSaver.Save(data, "C:\\TestResults\\");

            var result = File.Exists("C:\\TestResults\\testCreateFile.xml");

            Assert.IsTrue(result, "Файл не создался");
        }

        /// <summary>
        /// Без указания названия файла
        /// </summary>
        [TestMethod]
        public void CreateFile2()
        {
            XmlFileSaver<TestData> xmlFileSaver = new XmlFileSaver<TestData>(null);
            TestData data = new TestData();
            data.Name = "test1";
            data.DateTime = DateTime.Now.ToShortDateString();

            xmlFileSaver.Save(data, "C:\\TestResults\\");

            var result = File.Exists("C:\\TestResults\\testCreateFile2.xml");

            Assert.IsFalse(result, "Файл создался");
        }

        /// <summary>
        /// Не правильный путь
        /// </summary>
        [TestMethod]
        public void CreateFile3()
        {
            XmlFileSaver<TestData> xmlFileSaver = new XmlFileSaver<TestData>("testCreateFile3.xml");
            TestData data = new TestData();
            data.Name = "test1";
            data.DateTime = DateTime.Now.ToShortDateString();

            xmlFileSaver.Save(data, "C:\\NotExists\\");

            var result = File.Exists("C:\\NotExists\\testCreateFile3.xml");

            Assert.IsFalse(result, "Файл создался");
        }

        [TestMethod]
        public void CreateLoadFile()
        {
            XmlFileSaver<TestData> xmlFileSaver = new XmlFileSaver<TestData>("testLoadFile1");

            TestData data = new TestData();
            data.Name = "testLoad1";
            data.DateTime = DateTime.Now.ToShortDateString();

            xmlFileSaver.Save(data, "C:\\TestResults\\");


            XmlFileLoader<TestData> xmlFileLoader = new XmlFileLoader<TestData>("testLoadFile1");

            var result = File.Exists("C:\\TestResults\\testLoadFile1.xml");

            Assert.IsTrue(result, "Файл создался");


            TestData dataResult = xmlFileLoader.Load("C:\\TestResults\\");

            Assert.AreEqual(data.Name, dataResult.Name, "Содержимое файла не сопало");
        }
    }
}
