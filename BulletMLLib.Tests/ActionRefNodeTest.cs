using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests;

[TestFixture]
public class ActionRefNodeTest
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
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.IsNotNull(pattern.RootNode);
    }

    [Test]
    public void GotActionRefNode()
    {
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        Assert.IsNotNull(testActionNode);
    }

    [Test]
    public void GotActionRefNode1()
    {
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        Assert.IsNotNull(testFireNode);
    }

    [Test]
    public void GotActionRefNode2()
    {
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletNode testBulletNode = testFireNode.GetChild(ENodeName.bullet) as BulletNode;
        Assert.IsNotNull(testBulletNode);
    }

    [Test]
    public void GotActionRefNode3()
    {
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletNode testBulletNode = testFireNode.GetChild(ENodeName.bullet) as BulletNode;
        Assert.IsNotNull(testBulletNode.GetChild(ENodeName.actionRef));
    }

    [Test]
    public void GotActionRefNode4()
    {
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletNode testBulletNode = testFireNode.GetChild(ENodeName.bullet) as BulletNode;
        Assert.IsNotNull(testBulletNode.GetChild(ENodeName.actionRef) as ActionRefNode);
    }

    [Test]
    public void FoundActionNode()
    {
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletNode testBulletNode = testFireNode.GetChild(ENodeName.bullet) as BulletNode;
        ActionRefNode testActionRefNode =
            testBulletNode.GetChild(ENodeName.actionRef) as ActionRefNode;

        Assert.IsNotNull(testActionRefNode.ReferencedActionNode);
    }

    [Test]
    public void FoundActionNode1()
    {
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletNode testBulletNode = testFireNode.GetChild(ENodeName.bullet) as BulletNode;
        ActionRefNode testActionRefNode =
            testBulletNode.GetChild(ENodeName.actionRef) as ActionRefNode;

        Assert.IsNotNull(testActionRefNode.ReferencedActionNode as ActionNode);
    }

    [Test]
    public void FoundActionNode2()
    {
        var filename = $"{Constants.ContentPath}/ActionRefEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletNode testBulletNode = testFireNode.GetChild(ENodeName.bullet) as BulletNode;
        ActionRefNode testActionRefNode =
            testBulletNode.GetChild(ENodeName.actionRef) as ActionRefNode;
        ActionNode refNode = testActionRefNode.ReferencedActionNode as ActionNode;

        Assert.AreEqual(refNode.Label, "test");
    }

    [Test]
    public void FoundCorrectActionNode()
    {
        var filename = $"{Constants.ContentPath}/ActionRefParam.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletNode testBulletNode = testFireNode.GetChild(ENodeName.bullet) as BulletNode;
        ActionRefNode testActionRefNode =
            testBulletNode.GetChild(ENodeName.actionRef) as ActionRefNode;
        ActionNode refNode = testActionRefNode.ReferencedActionNode as ActionNode;

        Assert.AreEqual(refNode.Label, "test2");
    }
}