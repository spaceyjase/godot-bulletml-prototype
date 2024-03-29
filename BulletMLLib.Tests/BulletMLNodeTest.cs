using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLibTests;
using NUnit.Framework;

namespace BulletMLTests;

[TestFixture]
public class BulletMLNodeTest
{
    [SetUp]
    public void SetupHarness() { }

    [Test]
    public void TestStringToType()
    {
        Assert.AreEqual(BulletMLNode.StringToType(""), ENodeType.none);
        Assert.AreEqual(BulletMLNode.StringToType("none"), ENodeType.none);
        Assert.AreEqual(BulletMLNode.StringToType("aim"), ENodeType.aim);
        Assert.AreEqual(BulletMLNode.StringToType("absolute"), ENodeType.absolute);
        Assert.AreEqual(BulletMLNode.StringToType("relative"), ENodeType.relative);
        Assert.AreEqual(BulletMLNode.StringToType("sequence"), ENodeType.sequence);
    }

    [Test]
    public void TestEmpty()
    {
        var filename = $"{Constants.ContentPath}/Empty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.AreEqual(filename, pattern.Filename);
        Assert.AreEqual(EPatternType.none, pattern.Orientation);

        Assert.IsNotNull(pattern.RootNode);
        Assert.AreEqual(pattern.RootNode.Name, ENodeName.bulletml);
        Assert.AreEqual(pattern.RootNode.NodeType, ENodeType.none);
    }

    [Test]
    public void TestEmptyHoriz()
    {
        var filename = $"{Constants.ContentPath}/EmptyHoriz.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.AreEqual(filename, pattern.Filename);
        Assert.AreEqual(EPatternType.horizontal, pattern.Orientation);

        Assert.IsNotNull(pattern.RootNode);
        Assert.AreEqual(pattern.RootNode.Name, ENodeName.bulletml);
        Assert.AreEqual(pattern.RootNode.NodeType, ENodeType.none);
    }

    [Test]
    public void TestEmptyVert()
    {
        var filename = $"{Constants.ContentPath}/EmptyVert.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.AreEqual(filename, pattern.Filename);
        Assert.AreEqual(EPatternType.vertical, pattern.Orientation);

        Assert.IsNotNull(pattern.RootNode);
        Assert.AreEqual(pattern.RootNode.Name, ENodeName.bulletml);
        Assert.AreEqual(pattern.RootNode.NodeType, ENodeType.none);
    }

    [Test]
    public void TestIsParent()
    {
        var filename = $"{Constants.ContentPath}/Empty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);

        Assert.AreEqual(pattern.RootNode, pattern.RootNode.GetRootNode());
    }
}