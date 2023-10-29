using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;

namespace BulletMLTests;

[TestFixture]
public class FireRefNodeTest
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
    public void CreatedFireRefNode()
    {
        var filename = $"{Constants.ContentPath}/FireRef.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.IsNotNull(pattern.RootNode);
    }

    [Test]
    public void CreatedFireNode1()
    {
        var filename = $"{Constants.ContentPath}/FireRef.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        //get teh child action node
        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        Assert.IsNotNull(testActionNode);
        Assert.IsNotNull(testActionNode.GetChild(ENodeName.fireRef));
    }

    [Test]
    public void CreatedFireNode2()
    {
        var filename = $"{Constants.ContentPath}/FireRef.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        Assert.IsNotNull(testActionNode.GetChild(ENodeName.fireRef));
        Assert.IsNotNull(testActionNode.GetChild(ENodeName.fireRef) as FireRefNode);
    }

    [Test]
    public void GotFireNode()
    {
        var filename = $"{Constants.ContentPath}/FireRef.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireRefNode testFireNode = testActionNode.GetChild(ENodeName.fireRef) as FireRefNode;
        Assert.IsNotNull(testFireNode.ReferencedFireNode);
    }

    [Test]
    public void GotFireNode1()
    {
        var filename = $"{Constants.ContentPath}/FireRef.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireRefNode testFireNode = testActionNode.GetChild(ENodeName.fireRef) as FireRefNode;
        Assert.IsNotNull(testFireNode.ReferencedFireNode as FireNode);
    }

    [Test]
    public void GotCorrectFireNode()
    {
        var filename = $"{Constants.ContentPath}/FireRef.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireRefNode testFireNode = testActionNode.GetChild(ENodeName.fireRef) as FireRefNode;
        FireNode fireNode = testFireNode.ReferencedFireNode as FireNode;
        Assert.AreEqual("test", fireNode.Label);
    }

    [Test]
    public void NoBulletNode()
    {
        var filename = $"{Constants.ContentPath}/FireRef.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireRefNode testFireNode = testActionNode.GetChild(ENodeName.fireRef) as FireRefNode;
        Assert.IsNull(testFireNode.BulletDescriptionNode);
    }
}