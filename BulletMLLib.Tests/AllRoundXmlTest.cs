using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLib.SharedProject.Tasks;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests;

[TestFixture]
public class AllRoundXmlTest
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
    public void TestOneTop()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);

        ActionNode testNode =
            pattern.RootNode.FindLabelNode("top", ENodeName.action) as ActionNode;
        Assert.IsNotNull(testNode);
    }

    [Test]
    public void TestNoRepeatNode()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);

        ActionNode testNode =
            pattern.RootNode.FindLabelNode("top", ENodeName.action) as ActionNode;
        Assert.IsNull(testNode.ParentRepeatNode);
    }

    [Test]
    public void CorrectNode()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        Assert.IsNotNull(mover.Tasks[0].Node);
        Assert.IsNotNull(mover.Tasks[0].Node is ActionNode);
    }

    [Test]
    public void RepeatOnce()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask myAction = mover.Tasks[0] as ActionTask;

        ActionNode testNode =
            pattern.RootNode.FindLabelNode("top", ENodeName.action) as ActionNode;
        Assert.AreEqual(1, testNode.RepeatNum(myAction, mover));
    }

    [Test]
    public void CorrectAction()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        BulletMLTask myTask = mover.Tasks[0];
        Assert.AreEqual(1, myTask.ChildTasks.Count);
    }

    [Test]
    public void CreatedActionRefTask()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;
        Assert.IsNotNull(testTask);
    }

    [Test]
    public void CreatedActionRefTask1()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;

        Assert.AreEqual(ENodeName.actionRef, testTask.Node.Name);
    }

    [Test]
    public void CreatedActionRefTask2()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;

        Assert.AreEqual("circle", testTask.Node.Label);
    }

    [Test]
    public void CreatedActionTask()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;
        Assert.AreEqual(1, testTask.ChildTasks.Count);
    }

    [Test]
    public void CreatedActionTask1()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;
        Assert.IsNotNull(testTask.ChildTasks[0]);
    }

    [Test]
    public void CreatedActionTask2()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;
        ActionTask testActionTask = testTask.ChildTasks[0] as ActionTask;
        Assert.IsNotNull(testActionTask);
    }

    [Test]
    public void CreatedActionTask3()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;
        ActionTask testActionTask = testTask.ChildTasks[0] as ActionTask;
        Assert.IsNotNull(testActionTask.Node);
    }

    [Test]
    public void CreatedActionTask4()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;
        ActionTask testActionTask = testTask.ChildTasks[0] as ActionTask;
        Assert.AreEqual(ENodeName.action, testActionTask.Node.Name);
    }

    [Test]
    public void CreatedActionTask5()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.actionRef) as ActionTask;
        ActionTask testActionTask = testTask.ChildTasks[0] as ActionTask;
        Assert.AreEqual("circle", testActionTask.Node.Label);
    }

    [Test]
    public void CreatedActionTask10()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        ActionTask testTask =
            mover.FindTaskByLabelAndName("circle", ENodeName.action) as ActionTask;
        Assert.IsNotNull(testTask);
    }

    [Test]
    public void CorrectNumberOfBullets()
    {
        var filename = $"{Constants.ContentPath}/AllRound.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        //there should be 11 bullets
        Assert.AreEqual(21, manager.movers.Count);
    }
}