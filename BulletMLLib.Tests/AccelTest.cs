using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLib.SharedProject.Tasks;
using BulletMLLibTests;
using BulletMLSample;
using Godot;
using NUnit.Framework;

namespace BulletMLTests;

[TestFixture]
public class AccelTest
{
    private MoverManager manager;
    private MyShip dude;
    private BulletPattern pattern;

    [SetUp]
    public void SetupHarness()
    {
        dude = new();
        manager = new(dude.Position);
        pattern = new();
    }

    [Test]
    public void CorrectSpeedAbs()
    {
        var filename = $"{Constants.ContentPath}/AccelAbs.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);
        Assert.AreEqual(20.0f, mover.Acceleration.X);
        Assert.AreEqual(40.0f, mover.Acceleration.Y);
    }

    [Test]
    public void CorrectSpeedAbs1()
    {
        var filename = $"{Constants.ContentPath}/AccelAbs.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        manager.Update();

        Assert.AreEqual(19.0f, mover.Acceleration.X);
        Assert.AreEqual(38.0f, mover.Acceleration.Y);
    }

    [Test]
    public void CorrectSpeedAbs2()
    {
        var filename = $"{Constants.ContentPath}/AccelAbs.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        for (int i = 0; i < 10; i++)
        {
            manager.Update();
        }

        Assert.AreEqual(10.0f, mover.Acceleration.X);
        Assert.AreEqual(20.0f, mover.Acceleration.Y);
    }

    [Test]
    public void CorrectSpeedRel()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        manager.Update();

        Assert.AreEqual(21.0f, mover.Acceleration.X);
        Assert.AreEqual(42.0f, mover.Acceleration.Y);
    }

    [Test]
    public void CorrectSpeedRel1()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        for (int i = 0; i < 10; i++)
        {
            manager.Update();
        }

        Assert.AreEqual(30.0f, mover.Acceleration.X);
        Assert.AreEqual(60.0f, mover.Acceleration.Y);
    }

    [Test]
    public void CorrectSpeedRel2()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        BulletMLTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel);
        Assert.IsNotNull(myTask);
    }

    [Test]
    public void CorrectSpeedRel3()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        AccelTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel) as AccelTask;
        Assert.IsNotNull(myTask);
    }

    [Test]
    public void CorrectSpeedRel4()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        AccelTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel) as AccelTask;
        Assert.AreEqual(1.0f, myTask.Acceleration.X);
        Assert.AreEqual(2.0f, myTask.Acceleration.Y);
    }

    [Test]
    public void CorrectSpeedRel5()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        AccelTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel) as AccelTask;
        BulletMLNode myNode = myTask.Node.GetChild(ENodeName.horizontal);
        Assert.AreEqual(10.0f, myNode.GetValue(myTask, mover));
    }

    [Test]
    public void CorrectSpeedRel6()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        AccelTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel) as AccelTask;
        BulletMLNode myNode = myTask.Node.GetChild(ENodeName.vertical);
        Assert.AreEqual(ENodeType.relative, myNode.NodeType);
    }

    [Test]
    public void CorrectSpeedRel7()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        AccelTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel) as AccelTask;
        BulletMLNode myNode = myTask.Node.GetChild(ENodeName.horizontal);
        Assert.AreEqual(ENodeType.relative, myNode.NodeType);
    }

    [Test]
    public void CorrectSpeedRel8()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        AccelTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel) as AccelTask;
        BulletMLNode myNode = myTask.Node.GetChild(ENodeName.vertical);
        Assert.AreEqual(20.0f, myNode.GetValue(myTask, mover));
    }

    [Test]
    public void CorrectSpeedRel9()
    {
        var filename = $"{Constants.ContentPath}/AccelRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        AccelTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel) as AccelTask;
        Assert.AreEqual(10.0f, myTask.Duration);
    }

    [Test]
    public void CorrectSpeedSeq()
    {
        var filename = $"{Constants.ContentPath}/AccelSeq.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        AccelTask myTask = mover.FindTaskByLabelAndName("test", ENodeName.accel) as AccelTask;
        Assert.AreEqual(1.0f, myTask.Acceleration.X);
        Assert.AreEqual(2.0f, myTask.Acceleration.Y);
    }

    [Test]
    public void CorrectSpeedSeq1()
    {
        var filename = $"{Constants.ContentPath}/AccelSeq.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        manager.Update();

        Assert.AreEqual(21.0f, mover.Acceleration.X);
        Assert.AreEqual(42.0f, mover.Acceleration.Y);
    }

    [Test]
    public void CorrectSpeedSeq2()
    {
        var filename = $"{Constants.ContentPath}/AccelSeq.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Acceleration = new(20.0f, 40.0f);
        mover.InitTopNode(pattern.RootNode);

        for (int i = 0; i < 10; i++)
        {
            manager.Update();
        }

        Assert.AreEqual(30.0f, mover.Acceleration.X);
        Assert.AreEqual(60.0f, mover.Acceleration.Y);
    }
}