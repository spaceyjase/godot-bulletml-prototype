using BulletMLSample;
using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Tasks;
using BulletMLLibTests;

namespace BulletMLTests;

[TestFixture]
public class BulletRefTest
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
    public void CorrectBullets()
    {
        var filename = $"{Constants.ContentPath}/BulletRef.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();

        Assert.AreEqual(2, manager.movers.Count);

        mover = manager.movers[1];
        Assert.AreEqual("test", mover.Label);
    }

    [Test]
    public void CorrectParams()
    {
        var filename = $"{Constants.ContentPath}/BulletRefParam.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        //find the task for the bulletRef
        BulletMLTask bulletRefTask = mover.FindTaskByLabel("test");
        Assert.IsNotNull(bulletRefTask);
    }

    [Test]
    public void CorrectParams1()
    {
        var filename = $"{Constants.ContentPath}/BulletRefParam.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        //find the task for the bulletRef
        BulletMLTask bulletRefTask = mover.FindTaskByLabelAndName("test", ENodeName.bullet);
        Assert.AreEqual(1, bulletRefTask.ParamList.Count);
    }

    [Test]
    public void CorrectParams3()
    {
        var filename = $"{Constants.ContentPath}/BulletRefParam.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        //find the task for the bulletRef
        BulletMLTask bulletRefTask = mover.FindTaskByLabelAndName("test", ENodeName.bullet);
        Assert.AreEqual(15.0f, bulletRefTask.ParamList[0]);
    }

    [Test]
    public void FireTaskCorrect()
    {
        var filename = $"{Constants.ContentPath}/BulletRefParam.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        //find the task for the bulletRef
        FireTask fireTask =
            mover.FindTaskByLabelAndName("testFire", ENodeName.fire) as FireTask;
        Assert.IsNotNull(fireTask);
    }

    [Test]
    public void FireTaskCorrect1()
    {
        var filename = $"{Constants.ContentPath}/BulletRefParam.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        //find the task for the bulletRef
        FireTask fireTask =
            mover.FindTaskByLabelAndName("testFire", ENodeName.fire) as FireTask;
        Assert.IsNotNull(fireTask.InitialSpeedTask);
    }

    [Test]
    public void CorrectSpeedFromParam()
    {
        var filename = $"{Constants.ContentPath}/BulletRefParam.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();

        Assert.AreEqual(2, manager.movers.Count);

        mover = manager.movers[1];
        Assert.AreEqual("test", mover.Label);
        Assert.AreEqual(15.0f, mover.Speed);
    }
}