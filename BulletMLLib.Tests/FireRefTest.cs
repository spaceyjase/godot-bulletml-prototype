using BulletMLSample;
using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLibTests;

namespace BulletMLTests
{
    [TestFixture]
    public class FireRefTest
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
        public void CorrectBullets()
        {
            var filename = $"{Constants.ContentPath}/FireRef.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            manager.Update();

            Assert.AreEqual(2, manager.movers.Count);

            mover = manager.movers[1];
            Assert.AreEqual("testBullet", mover.Label);
        }

        [Test]
        public void CorrectSpeedFromParam()
        {
            var filename = $"{Constants.ContentPath}/FireRefParam.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            manager.Update();

            Assert.AreEqual(2, manager.movers.Count);

            mover = manager.movers[1];
            Assert.AreEqual("testBullet", mover.Label);
            Assert.AreEqual(15.0f, mover.Speed);
        }
    }
}
