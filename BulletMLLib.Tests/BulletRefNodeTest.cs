using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests
{
    [TestFixture]
    public class BulletRefNodeTest
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
        public void ValidXML()
        {
            var filename = $"{Constants.ContentPath}/BulletRef.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            Assert.IsNotNull(pattern.RootNode);
        }

        [Test]
        public void SetBulletLabelNode()
        {
            var filename = $"{Constants.ContentPath}/BulletRef.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            BulletNode testBulletNode = pattern.RootNode.GetChild(ENodeName.bullet) as BulletNode;
            Assert.AreEqual("test", testBulletNode.Label);
        }

        [Test]
        public void CreatedBulletRefNode1()
        {
            var filename = $"{Constants.ContentPath}/BulletRef.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            Assert.IsNotNull(testActionNode);
            Assert.IsNotNull(testActionNode.GetChild(ENodeName.fire));
            Assert.IsNotNull(testActionNode.GetChild(ENodeName.fire) as FireNode);
        }

        [Test]
        public void CreatedBulletRefNode2()
        {
            var filename = $"{Constants.ContentPath}/BulletRef.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            Assert.IsNotNull(testFireNode.GetChild(ENodeName.bulletRef));
        }

        [Test]
        public void CreatedBulletRefNode3()
        {
            var filename = $"{Constants.ContentPath}/BulletRef.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            Assert.IsNotNull(testFireNode.GetChild(ENodeName.bulletRef));
            Assert.IsNotNull(testFireNode.GetChild(ENodeName.bulletRef) as BulletRefNode);
        }

        [Test]
        public void FoundBulletNode()
        {
            var filename = $"{Constants.ContentPath}/BulletRef.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            BulletRefNode refNode = testFireNode.GetChild(ENodeName.bulletRef) as BulletRefNode;
            Assert.IsNotNull(refNode.ReferencedBulletNode);
        }

        [Test]
        public void FoundBulletNode1()
        {
            var filename = $"{Constants.ContentPath}/BulletRef.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            BulletRefNode refNode = testFireNode.GetChild(ENodeName.bulletRef) as BulletRefNode;
            Assert.IsNotNull(refNode.ReferencedBulletNode as BulletNode);
        }

        [Test]
        public void FoundBulletNode2()
        {
            var filename = $"{Constants.ContentPath}/BulletRef.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            BulletRefNode refNode = testFireNode.GetChild(ENodeName.bulletRef) as BulletRefNode;
            BulletNode testBulletNode = refNode.ReferencedBulletNode as BulletNode;

            Assert.AreEqual("test", testBulletNode.Label);
        }

        [Test]
        public void FoundCorrectBulletNode()
        {
            var filename = $"{Constants.ContentPath}/BulletRefTwoBullets.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            BulletRefNode refNode = testFireNode.GetChild(ENodeName.bulletRef) as BulletRefNode;
            BulletNode testBulletNode = refNode.ReferencedBulletNode as BulletNode;

            Assert.AreEqual("test2", testBulletNode.Label);
        }
    }
}
