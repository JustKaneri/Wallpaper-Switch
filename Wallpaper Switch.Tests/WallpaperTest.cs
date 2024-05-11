using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.Source;
using Wallpaper_Switch.Core.Controllers.Wallpaper;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Tests
{
    [TestClass]
    public class WallpaperTest
    {
        [TestMethod]
        public void TestCollertor() 
        {
            WallpaperCollector collector = new WallpaperCollector(ConstTestData.path);
            WallpaperCollector.IsolationOfBrokenFile(ConstTestData.path + "images\\testImage.jpg");

            var sourcDirectory = System.IO.File.Exists(ConstTestData.path + "images\\testImage.jpg");
            var ignoreDirecotry = System.IO.File.Exists(ConstTestData.path + "BrokenWallpaper\\testImage.jpg");

            Assert.AreEqual(sourcDirectory, false, "Файл не удалился");
            Assert.AreEqual(ignoreDirecotry, true, "Файл не переместился");
        }

        [TestMethod]
        public void TestCollertor2()
        {
            WallpaperCollector collector = new WallpaperCollector(ConstTestData.path);
            var result = WallpaperCollector.IsolationOfBrokenFile(ConstTestData.path + "images\\testImage2.jpg");

            Assert.AreEqual(result, false, "Файл был добавлен в исключения");
        }

        private List<Source> SourceInit()
        {
            Source source = new Source();
            source.Name = "Test2";
            source.Path = "C:\\TestResults\\images\\";
            source.IsActive = true;

            List<Source> sources = new List<Source>();
            sources.Add(source);

            return sources;
        }

        [TestMethod]
        public void TestController1()
        {
            WallpaperController controller = new WallpaperController(SourceInit());

            var result = controller.GetCurrentWallpaper();

            Assert.IsNotNull(result, "Не удалось получить текущие обои");
        }

        [TestMethod]
        public void TestController2()
        {
            WallpaperController controller = new WallpaperController(SourceInit());

            var result = controller.SwitchOnRandomWallpaper();

            Assert.IsNotNull(result, "Не удалось получить cлучайные обои");
        }

        [TestMethod]
        public void TestController3()
        {
            WallpaperController controller = new WallpaperController(new List<Source>());

            var result = controller.SwitchOnRandomWallpaper();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestController4()
        {
            var source = SourceInit();
            source[0].IsActive = false;

            WallpaperController controller = new WallpaperController(source);

            var result = controller.SwitchOnRandomWallpaper();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestController5()
        {
            WallpaperController controller = new WallpaperController(new List<Source>());

            controller.SwitchOnRandomWallpaper();

            var result = controller.GetOldWallpaper();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestController6()
        {
            WallpaperController controller = new WallpaperController(SourceInit());

            controller.SwitchOnRandomWallpaper();
            controller.SwitchOnRandomWallpaper();

            var result = controller.GetOldWallpaper();

            Assert.IsNotNull(result, "Не удалось получить прошлые обои");
        }
    }
}
