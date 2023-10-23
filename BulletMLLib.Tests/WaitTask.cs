using BulletMLLib.SharedProject;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests
{
    [TestFixture]
    public class WaitTask
    {
        private MoverManager manager;
        private MyShip dude;
        private BulletPattern pattern;

        [SetUp]
        public void SetupHarness()
        {
            dude = new();
            manager = new(dude.Position);
            pattern = new();
        }

        [Test]
        public void WaitOneTaskTest()
        {
            var filename = $"{Constants.ContentPath}/WaitOne.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            Assert.AreEqual(1, manager.movers.Count);
        }

        [Test]
        public void WaitOneTaskTest1()
        {
            var filename = $"{Constants.ContentPath}/WaitOne.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Assert.AreEqual(1, manager.movers.Count);
        }

        [Test]
        public void WaitOneTaskTest2()
        {
            var filename = $"{Constants.ContentPath}/WaitOne.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            manager.Update();
            Assert.AreEqual(0, manager.movers.Count);
        }

        [Test]
        public void WaitOneTaskTest3()
        {
            var filename = $"{Constants.ContentPath}/Vanish.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            manager.Update();
            Assert.AreEqual(0, manager.movers.Count);
        }

        [Test]
        public void WaitZeroTaskTest()
        {
            var filename = $"{Constants.ContentPath}/Vanish.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Assert.AreEqual(0, manager.movers.Count);
        }

        [Test]
        public void WaitTwoTaskTest()
        {
            var filename = $"{Constants.ContentPath}/WaitTwo.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            Assert.AreEqual(1, manager.movers.Count);
            manager.Update();
        }

        [Test]
        public void WaitTwoTaskTest1()
        {
            var filename = $"{Constants.ContentPath}/WaitTwo.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Assert.AreEqual(1, manager.movers.Count);
        }

        [Test]
        public void WaitTwoTaskTest2()
        {
            var filename = $"{Constants.ContentPath}/WaitTwo.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            manager.Update();
            Assert.AreEqual(1, manager.movers.Count);
        }

        [Test]
        public void WaitTwoTaskTest3()
        {
            var filename = $"{Constants.ContentPath}/WaitTwo.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            manager.Update();
            manager.Update();
            Assert.AreEqual(0, manager.movers.Count);
        }
    }
}
