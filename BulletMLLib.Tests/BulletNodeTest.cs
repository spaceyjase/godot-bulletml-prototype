using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests
{
    [TestFixture]
    public class BulletNodeTest
    {
        private MoverManager manager;
        private MyShip dude;

        [SetUp]
        public void SetupHarness()
        {
            dude = new();
            manager = new(dude.Position);
        }

        [Test]
        public void CreatedBulletNode()
        {
            var filename = $"{Constants.ContentPath}/BulletEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            Assert.IsNotNull(pattern.RootNode);
        }

        [Test]
        public void CreatedBulletNode1()
        {
            var filename = $"{Constants.ContentPath}/BulletEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            BulletNode testBulletNode = pattern.RootNode.GetChild(ENodeName.bullet) as BulletNode;
            Assert.IsNotNull(testBulletNode);
        }

        [Test]
        public void SetBulletLabelNode()
        {
            var filename = $"{Constants.ContentPath}/BulletEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            BulletNode testBulletNode = pattern.RootNode.GetChild(ENodeName.bullet) as BulletNode;
            Assert.AreEqual("test", testBulletNode.Label);
        }
    }
}
