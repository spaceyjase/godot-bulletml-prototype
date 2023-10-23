using BulletMLLib.SharedProject;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests
{
    [TestFixture]
    public class ActionRefTest
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
            var filename = $"{Constants.ContentPath}/ActionRefParamChangeSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            manager.Update();

            Assert.AreEqual(2, manager.movers.Count);

            mover = manager.movers[1];
            Assert.AreEqual("test", mover.Label);
        }

        [Test]
        public void CorrectSpeedFromParam()
        {
            var filename = $"{Constants.ContentPath}/ActionRefParamChangeSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            manager.Update();

            Assert.AreEqual(2, manager.movers.Count);

            mover = manager.movers[1];
            Assert.AreEqual("test", mover.Label);
            Assert.AreEqual(5.0f, mover.Speed);

            manager.Update();
            Assert.AreEqual(10.0f, mover.Speed);
        }
    }
}
