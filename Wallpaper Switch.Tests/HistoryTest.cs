using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallpaper_Switch.Core.Controllers.History;
using Wallpaper_Switch.Core.Model;

namespace Wallpaper_Switch.Tests
{
    [TestClass]
    public class HistoryTest
    {
        [TestMethod]
        public void HistoryAdd2Test()
        {
            HistoryController historyController = new HistoryController(ConstTestData.path);

            for (int i = 1; i <= 2; i++)
            {
                var wallpaper = new Wallpaper();
                wallpaper.FileName = "image_" + i;
                historyController.Push(wallpaper);
            }

            var history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 2);
            Assert.AreEqual(history[0].FileName, "image_2");
        }

        [TestMethod]
        public void HistoryAdd4Test()
        {
            HistoryController historyController = new HistoryController(ConstTestData.path);

            for (int i = 1; i <= 4; i++)
            {
                var wallpaper = new Wallpaper();
                wallpaper.FileName = "image_" + i;
                historyController.Push(wallpaper);
            }

            var history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 4);
            Assert.AreEqual(history[0].FileName, "image_4");
            Assert.AreEqual(history[1].FileName, "image_3");
            Assert.AreEqual(history[2].FileName, "image_2");
            Assert.AreEqual(history[3].FileName, "image_1");
        }

        [TestMethod]
        public void HistoryAdd5Test()
        {
            HistoryController historyController = new HistoryController(ConstTestData.path);

            for (int i = 1; i <= 5; i++)
            {
                var wallpaper = new Wallpaper();
                wallpaper.FileName = "image_" + i;
                historyController.Push(wallpaper);
            }

            var history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 4);
            Assert.AreEqual(history[0].FileName, "image_5");
            Assert.AreEqual(history[1].FileName, "image_4");
            Assert.AreEqual(history[2].FileName, "image_3");
            Assert.AreEqual(history[3].FileName, "image_2");
        }

        [TestMethod]
        public void HistoryRemoveTest()
        {
            HistoryController historyController = new HistoryController(ConstTestData.path);

            var wallpaper = new Wallpaper();
            wallpaper.FileName = "image_1";
            historyController.Push(wallpaper);

            var history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 1);
            Assert.AreEqual(history[0].FileName, "image_1");

            historyController.Remove(wallpaper);

            history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 0);
        }

        [TestMethod]
        public void HistoryRemoveNotExistTest()
        {
            HistoryController historyController = new HistoryController(ConstTestData.path);

            var wallpaper = new Wallpaper();
            wallpaper.FileName = "image_1";

            var history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 0);

            historyController.Remove(wallpaper);

            history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 0);
        }

        [TestMethod]
        public void HistoryRemove2Test()
        {
            HistoryController historyController = new HistoryController(ConstTestData.path);

            for (int i = 1; i <= 5; i++)
            {
                var wallpaper = new Wallpaper();
                wallpaper.FileName = "image_" + i;
                historyController.Push(wallpaper);
            }

            var history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 4);
            Assert.AreEqual(history[0].FileName, "image_5");
            Assert.AreEqual(history[1].FileName, "image_4");
            Assert.AreEqual(history[2].FileName, "image_3");
            Assert.AreEqual(history[3].FileName, "image_2");


            historyController.Remove(3);
            history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 3);
            Assert.AreEqual(history[0].FileName, "image_5");
            Assert.AreEqual(history[1].FileName, "image_4");
            Assert.AreEqual(history[2].FileName, "image_3");

        }

        [TestMethod]
        public void HistoryRemove3Test()
        {
            HistoryController historyController = new HistoryController(ConstTestData.path);

            for (int i = 1; i <= 5; i++)
            {
                var wallpaper = new Wallpaper();
                wallpaper.FileName = "image_" + i;
                historyController.Push(wallpaper);
            }

            var history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 4);
            Assert.AreEqual(history[0].FileName, "image_5");
            Assert.AreEqual(history[1].FileName, "image_4");
            Assert.AreEqual(history[2].FileName, "image_3");
            Assert.AreEqual(history[3].FileName, "image_2");


            historyController.Remove(2);
            history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 3);
            Assert.AreEqual(history[0].FileName, "image_5");
            Assert.AreEqual(history[1].FileName, "image_4");
            Assert.AreEqual(history[2].FileName, "image_2");

        }

        [TestMethod]
        public void HistoryRemove4Test()
        {
            HistoryController historyController = new HistoryController(ConstTestData.path);

            for (int i = 1; i <= 5; i++)
            {
                var wallpaper = new Wallpaper();
                wallpaper.FileName = "image_" + i%2;
                wallpaper.Path = "path_" + i%2;
                historyController.Push(wallpaper);
            }

            var history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 4);
            Assert.AreEqual(history[0].FileName, "image_1");
            Assert.AreEqual(history[1].FileName, "image_0");
            Assert.AreEqual(history[2].FileName, "image_1");
            Assert.AreEqual(history[3].FileName, "image_0");

            historyController.Remove(history[0]);
            history = historyController.GetHistory();

            Assert.AreEqual(history.Count, 2);
            Assert.AreEqual(history[0].FileName, "image_0");
            Assert.AreEqual(history[1].FileName, "image_0");

        }
    }
}
