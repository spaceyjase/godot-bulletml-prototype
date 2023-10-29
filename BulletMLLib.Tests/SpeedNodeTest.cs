using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;

namespace BulletMLTests;

[TestFixture]
public class SpeedNodeTest
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
    public void CreatedSpeedNode()
    {
        var filename = $"{Constants.ContentPath}/FireSpeed.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.IsNotNull(pattern.RootNode);
    }

    [Test]
    public void CreatedSpeedNode1()
    {
        var filename = $"{Constants.ContentPath}/FireSpeed.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        Assert.IsNotNull(testActionNode.GetChild(ENodeName.fire));
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        Assert.IsNotNull(testFireNode);
    }

    [Test]
    public void CreatedSpeedNode2()
    {
        var filename = $"{Constants.ContentPath}/FireSpeed.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        Assert.IsNotNull(testFireNode.GetChild(ENodeName.speed));
    }

    [Test]
    public void CreatedSpeedNode3()
    {
        var filename = $"{Constants.ContentPath}/FireSpeed.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        Assert.IsNotNull(testFireNode.GetChild(ENodeName.speed) as SpeedNode);
    }

    [Test]
    public void SpeedNodeDefaultValue()
    {
        var filename = $"{Constants.ContentPath}/FireSpeed.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        SpeedNode testSpeedNode = testFireNode.GetChild(ENodeName.speed) as SpeedNode;

        Assert.AreEqual(ENodeType.absolute, testSpeedNode.NodeType);
    }

    [Test]
    public void SpeedNodeAbsolute()
    {
        var filename = $"{Constants.ContentPath}/FireSpeedAbsolute.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        SpeedNode testSpeedNode = testFireNode.GetChild(ENodeName.speed) as SpeedNode;

        Assert.AreEqual(ENodeType.absolute, testSpeedNode.NodeType);
    }

    [Test]
    public void SpeedNodeSequence()
    {
        var filename = $"{Constants.ContentPath}/FireSpeedSequence.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        SpeedNode testSpeedNode = testFireNode.GetChild(ENodeName.speed) as SpeedNode;

        Assert.AreEqual(ENodeType.sequence, testSpeedNode.NodeType);
    }

    [Test]
    public void SpeedNodeRelative()
    {
        var filename = $"{Constants.ContentPath}/FireSpeedRelative.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        SpeedNode testSpeedNode = testFireNode.GetChild(ENodeName.speed) as SpeedNode;

        Assert.AreEqual(ENodeType.relative, testSpeedNode.NodeType);
    }
}