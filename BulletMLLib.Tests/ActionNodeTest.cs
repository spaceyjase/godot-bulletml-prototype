using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests
{
    [TestFixture]
    public class ActionNodeTest
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
        public void TestOneTop()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testNode =
                pattern.RootNode.FindLabelNode("top", ENodeName.action) as ActionNode;
            Assert.IsNotNull(testNode);
        }

        [Test]
        public void TestNoRepeatNode()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testNode =
                pattern.RootNode.FindLabelNode("top", ENodeName.action) as ActionNode;
            Assert.IsNull(testNode.ParentRepeatNode);
        }

        [Test]
        public void TestManyTop()
        {
            var filename = $"{Constants.ContentPath}/ActionManyTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testNode =
                pattern.RootNode.FindLabelNode("top1", ENodeName.action) as ActionNode;
            Assert.IsNotNull(testNode);
            testNode = pattern.RootNode.FindLabelNode("top2", ENodeName.action) as ActionNode;
            Assert.IsNotNull(testNode);
        }
    }
}
