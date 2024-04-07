using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.Logger;
using Wallpaper_Switch.Core.Controllers.Source;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Tests
{
    [TestClass]
    public class SourceTest
    {
        private static string error;

        public SourceTest()
        {
            Logger logger = new Logger("C:\\TestResults\\");
        }

        [TestMethod]
        public void Test1()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper";

            controller.AddSource(source1,ref error);

            Assert.AreEqual(controller.GetSources().Count, 1, "Запись не добавилась");
        }

        [TestMethod]
        public void Test2()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper";

            controller.AddSource(source1,ref error);

            Assert.IsTrue(System.IO.File.Exists(ConstTestData.path + "source.xml"), "файл с источниками не создан");
        }

        [TestMethod]
        public void Test3()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper\\";

            Source source2 = new Source();
            source2.Name = "Test2";
            source2.Path = "C:\\TestResults\\images\\";

            controller.AddSource(source1,ref error);
            controller.AddSource(source2,ref error);

            Assert.AreEqual(controller.GetSources().Count, 2, "Запись не добавилась");
        }


        [TestMethod]
        public void Test4()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper\\";

            Source source2 = new Source();
            source2.Name = "Test2";
            source2.Path = "C:\\TestResults\\images\\";

            controller.AddSource(source1, ref error);
            controller.AddSource(source2, ref error);

            Assert.AreEqual(controller.GetSources().Count, 2, "Записи не добавились");

            var result = controller.DeleteSource(1);

            Assert.AreEqual(controller.GetSources().Count, 1, "Запись не удалисась");

            controller.AddSource(source2, ref error);

            Assert.AreEqual(controller.GetSources().Count, 2, "Запись не добавились");

        }

        [TestMethod]
        public void Test5()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper\\";

            controller.AddSource(source1, ref error);

            Source source2 = new Source();
            source2.Name = "Test2";
            source2.Path = "D:\\Wallpaper\\";

            controller.EditSource(source2, source1);

            var result = controller.GetSources();

            Assert.AreEqual("Test2", result[0].Name, "запись не отредактировалась");

        }

        [TestMethod]
        public void Test6()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper\\";

            controller.AddSource(source1, ref error);

            Source source2 = new Source();
            source2.Name = "Test1";
            source2.Path = "C:\\TestResults\\images\\";

            controller.EditSource(source2, source1);

            var result = controller.GetSources();

            Assert.AreEqual("C:\\TestResults\\images\\", result[0].Path, "запись не отредактировалась");

        }

        [TestMethod]
        public void Test7()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper\\";

            Source source2 = new Source();
            source2.Name = "Test2";
            source2.Path = "C:\\TestResults\\images\\";

            Source update = new Source();
            update.Name = "Test1";
            update.Path = "C:\\TestResults\\";

            controller.AddSource(source1, ref error);
            controller.AddSource(source2, ref error);

            controller.EditSource(update, source2);

            var result = controller.GetSources();

            Assert.AreEqual("Test2", result[1].Name, "запись отредактировалась");
            Assert.AreEqual("C:\\TestResults\\images\\", result[1].Path, "запись отредактировалась");
        }

        [TestMethod]
        public void Test8()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper\\";

            Source source2 = new Source();
            source2.Name = "Test2";
            source2.Path = "C:\\TestResults\\images\\";

            controller.AddSource(source1, ref error);
            controller.AddSource(source2, ref error);

            controller.DiacitvateSource(0);

            var result = controller.GetSources();

            Assert.IsFalse(result[0].IsActive, "Источник активен");
        }

        [TestMethod]
        public void Test9()
        {
            if (System.IO.File.Exists(ConstTestData.path + "source.xml"))
                System.IO.File.Delete(ConstTestData.path + "source.xml");

            SourceController controller = new SourceController("C:\\TestResults\\");

            Source source1 = new Source();
            source1.Name = "Test1";
            source1.Path = "D:\\Wallpaper\\";

            Source source2 = new Source();
            source2.Name = "Test2";
            source2.Path = "C:\\TestResults\\images\\";

            controller.AddSource(source1, ref error);
            controller.AddSource(source2, ref error );

            controller.DiacitvateSource(0);

            var result = controller.GetSources();

            Assert.IsFalse(result[0].IsActive, "Источник активен");

            controller.AcitvateSource(0);

            Assert.IsTrue(result[0].IsActive, "Источник не активен");
        }
    }
}
