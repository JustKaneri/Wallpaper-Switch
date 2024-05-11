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
            Logger log = new Logger(ConstTestData.path);
        }

        [TestMethod]
        public void Test1()
        {
            SettingsController settingsController = new SettingsController(ConstTestData.path);

            var result =  File.Exists(ConstTestData.path+"settings.xml");

            Assert.IsTrue(result,"Файл конфигурации не был создан");
        }

        [TestMethod]
        public void TestStartTimer2()
        {
            SettingsController settingsController = new SettingsController(ConstTestData.path);

            settingsController.EnableAutoChange(5);

            var result = settingsController.AutoChangeStatus();

            Assert.AreEqual(5, result.time, "Время не совпадает");
            Assert.AreEqual(true, result.isChange, "Таймер не запущен");
        }

        [TestMethod]
        public void TestStopTimer3()
        {
            SettingsController settingsController = new SettingsController(ConstTestData.path);

            settingsController.EnableAutoChange(5);

            settingsController.DisableAutoChange();

            var result = settingsController.AutoChangeStatus();

            Assert.AreEqual(5, result.time, "Время не совпадает");
            Assert.AreEqual(false, result.isChange, "Таймер запущен");
        }

        [TestMethod]
        public void TestAutoStart4()
        {
            SettingsController settingsController = new SettingsController(ConstTestData.path);

            settingsController.EnableAutoStart();

            var result = settingsController.AutoStartStatus();

            Assert.IsTrue(result, "Приложение не добавилось в автозагрузку");
        }

        [TestMethod]
        public void TestAutoStart5()
        {
            SettingsController settingsController = new SettingsController(ConstTestData.path);

            settingsController.EnableAutoStart();

            settingsController.DisableAutoStart();

            var result = settingsController.AutoStartStatus();

            Assert.IsFalse(result, "Приложение не удалилось из автозагрузки");
        }
    }
}
