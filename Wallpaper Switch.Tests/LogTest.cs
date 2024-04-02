using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.Logger;

namespace Wallpaper_Switch.Tests
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        [Ignore]
        public void TestWithoutPath()
        {
            Logger.AppednLog(LogLevel.Info, "test message");

            var result = File.Exists("C:\\TestResults\\log.txt");

            Assert.IsFalse(result,"Файл с логами создался");
        }

        [TestMethod]
        public void TestWithPath()
        {
            Logger log = new Logger("C:\\TestResults\\");

            Logger.AppednLog(LogLevel.Info, "test message");

            var result = File.Exists("C:\\TestResults\\log.txt");

            Assert.IsTrue(result, "Файл с логами не создался");
        }

        [TestMethod]
        public void TestWithType()
        {
            Logger log = new Logger("C:\\TestResults\\");

            Logger.AppednLog(LogLevel.Info, "test message", this.GetType());

            var result = File.Exists("C:\\TestResults\\log.txt");

            Assert.IsTrue(result, "Файл с логами не создался");
        }
    }
}
