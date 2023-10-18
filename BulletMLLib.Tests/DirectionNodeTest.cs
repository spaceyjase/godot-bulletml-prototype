using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;

namespace BulletMLTests
{
    [TestFixture]
    public class DirectionNodeTest
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
        public void CreatedDirectionNode()
        {
            var filename = $"{Constants.ContentPath}/FireDirection.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            Assert.IsNotNull(pattern.RootNode);
        }

        [Test]
        public void CreatedDirectionNode1()
        {
            var filename = $"{Constants.ContentPath}/FireDirection.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            Assert.IsNotNull(testActionNode.GetChild(ENodeName.fire));
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            Assert.IsNotNull(testFireNode);
        }

        [Test]
        public void CreatedDirectionNode2()
        {
            var filename = $"{Constants.ContentPath}/FireDirection.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            Assert.IsNotNull(testFireNode.GetChild(ENodeName.direction));
            Assert.IsNotNull(testFireNode.GetChild(ENodeName.direction) as DirectionNode);
        }

        [Test]
        public void DirectionNodeDefaultValue()
        {
            var filename = $"{Constants.ContentPath}/FireDirection.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            DirectionNode testDirectionNode =
                testFireNode.GetChild(ENodeName.direction) as DirectionNode;

            Assert.AreEqual(ENodeType.aim, testDirectionNode.NodeType);
        }

        [Test]
        public void DirectionNodeAim()
        {
            var filename = $"{Constants.ContentPath}/FireDirectionAim.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            DirectionNode testDirectionNode =
                testFireNode.GetChild(ENodeName.direction) as DirectionNode;

            Assert.AreEqual(ENodeType.aim, testDirectionNode.NodeType);
        }

        [Test]
        public void DirectionNodeAbsolute()
        {
            var filename = $"{Constants.ContentPath}/FireDirectionAbsolute.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            DirectionNode testDirectionNode =
                testFireNode.GetChild(ENodeName.direction) as DirectionNode;

            Assert.AreEqual(ENodeType.absolute, testDirectionNode.NodeType);
        }

        [Test]
        public void DirectionNodeSequence()
        {
            var filename = $"{Constants.ContentPath}/FireDirectionSequence.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            DirectionNode testDirectionNode =
                testFireNode.GetChild(ENodeName.direction) as DirectionNode;

            Assert.AreEqual(ENodeType.sequence, testDirectionNode.NodeType);
        }

        [Test]
        public void DirectionNodeRelative()
        {
            var filename = $"{Constants.ContentPath}/FireDirectionRelative.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);

            ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
            FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
            DirectionNode testDirectionNode =
                testFireNode.GetChild(ENodeName.direction) as DirectionNode;

            Assert.AreEqual(ENodeType.relative, testDirectionNode.NodeType);
        }
    }
}
