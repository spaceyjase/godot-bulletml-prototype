using BulletMLLib.SharedProject;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests
{
    [TestFixture]
    public class TestRepeatSequenceXml
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
        public void CorrectSpeed()
        {
            var filename = $"{Constants.ContentPath}/RepeatSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            Assert.AreEqual(0, mover.Speed);
        }

        [Test]
        public void CorrectSpeed1()
        {
            var filename = $"{Constants.ContentPath}/RepeatSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            for (int i = 0; i < 10; i++)
            {
                manager.Update();
            }

            Assert.AreEqual(10, mover.Speed);
        }

        [Test]
        public void CorrectSpeed2()
        {
            var filename = $"{Constants.ContentPath}/RepeatSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();

            Assert.AreEqual(1, mover.Speed);
        }
    }
}
