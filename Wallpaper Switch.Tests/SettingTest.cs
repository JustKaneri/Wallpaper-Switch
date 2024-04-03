using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Setting;

namespace Wallpaper_Switch.Tests
{
    [TestClass]
    public class SettingTest
    {
        
        public SettingTest()
        {
            Logger log = new Logger("C:\\TestResults\\");
        }

        [TestMethod]
        public void Test1()
        {
            Logger.AppednLog(LogLevel.Warning, "          Tesst1            ");

            SettingsController settingsController = new SettingsController("C:\\TestResults\\");

            var result =  File.Exists("C:\\TestResults\\settings.xml");

            Assert.IsTrue(result,"Файл конфигурации не был создан");
        }

        [TestMethod]
        public void TestStartTimer2()
        {
            Logger.AppednLog(LogLevel.Warning, "          TestStartTimer2            ");

            SettingsController settingsController = new SettingsController("C:\\TestResults\\");

            settingsController.StartAutoChange(5);

            var result = settingsController.AutoChangeStatus();

            Assert.AreEqual(5, result.time, "Время не совпадает");
            Assert.AreEqual(true, result.isChange, "Таймер не запущен");
        }

        [TestMethod]
        public void TestStopTimer3()
        {
            Logger.AppednLog(LogLevel.Warning, "          TestStopTimer3           ");

            SettingsController settingsController = new SettingsController("C:\\TestResults\\");

            settingsController.StartAutoChange(5);

            settingsController.StopAutoChange();

            var result = settingsController.AutoChangeStatus();

            Assert.AreEqual(5, result.time, "Время не совпадает");
            Assert.AreEqual(false, result.isChange, "Таймер запущен");
        }
    }
}
