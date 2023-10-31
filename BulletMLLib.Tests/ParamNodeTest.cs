using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using BulletMLSample;

namespace BulletMLTests;

[TestFixture]
public class ParamNodeTest
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
    public void CreatedParamNode()
    {
        var filename = $"{Constants.ContentPath}/FireRefParam.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.IsNotNull(pattern.RootNode);
    }

    [Test]
    public void GotParamNode()
    {
        var filename = $"{Constants.ContentPath}/FireRefParam.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireRefNode testFireNode = testActionNode.GetChild(ENodeName.fireRef) as FireRefNode;
        Assert.IsNotNull(testFireNode.GetChild(ENodeName.param));
    }

    [Test]
    public void GotParamNode1()
    {
        var filename = $"{Constants.ContentPath}/FireRefParam.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireRefNode testFireNode = testActionNode.GetChild(ENodeName.fireRef) as FireRefNode;
        Assert.IsNotNull(testFireNode.GetChild(ENodeName.param) as ParamNode);
    }

    [Test]
    public void GotParamNode2()
    {
        var filename = $"{Constants.ContentPath}/BulletRefParam.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletRefNode refNode = testFireNode.GetChild(ENodeName.bulletRef) as BulletRefNode;
        Assert.IsNotNull(refNode.GetChild(ENodeName.param) as ParamNode);
    }

    [Test]
    public void GotParamNode3()
    {
        var filename = $"{Constants.ContentPath}/ActionRefParam.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        ActionNode testActionNode = pattern.RootNode.GetChild(ENodeName.action) as ActionNode;
        FireNode testFireNode = testActionNode.GetChild(ENodeName.fire) as FireNode;
        BulletNode testBulletNode = testFireNode.GetChild(ENodeName.bullet) as BulletNode;
        ActionRefNode testActionRefNode =
            testBulletNode.GetChild(ENodeName.actionRef) as ActionRefNode;
        Assert.IsNotNull(testActionRefNode.GetChild(ENodeName.param) as ParamNode);
    }
}