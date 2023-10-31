using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;

namespace BulletMLTests;

[TestFixture]
public class FireNodeTest
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
    public void CreatedFireNode()
    {
        var filename = $"{Constants.ContentPath}/FireEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.IsNotNull(pattern.RootNode);
    }

    [Test]
    public void CreatedFireNode1()
    {
        var filename = $"{Constants.ContentPath}/FireEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        //get teh child action node
        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        Assert.IsNotNull(testActionNode);
        Assert.IsNotNull(testActionNode.GetChild(ENodeName.fire));
    }

    [Test]
    public void CreatedFireNode2()
    {
        var filename = $"{Constants.ContentPath}/FireEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        Assert.IsNotNull(testActionNode.GetChild(ENodeName.fire));
        Assert.IsNotNull(testActionNode.GetChild(ENodeName.fire) as FireNode);
    }

    [Test]
    public void GotBulletNode()
    {
        var filename = $"{Constants.ContentPath}/FireEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        Assert.IsNotNull(testFireNode.BulletDescriptionNode);
    }

    [Test]
    public void CreatedTopLevelFireNode()
    {
        var filename = $"{Constants.ContentPath}/FireEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        FireNode testFireNode = pattern.RootNode.GetChild(ENodeName.fire) as FireNode;
        Assert.IsNotNull(testFireNode);
        Assert.IsNotNull(testFireNode.BulletDescriptionNode);
        Assert.AreEqual("test", testFireNode.Label);
    }
}