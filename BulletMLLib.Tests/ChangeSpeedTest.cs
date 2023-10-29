using BulletMLSample;
using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLibTests;

namespace BulletMLTests;

[TestFixture]
public class ChangeSpeedTest
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
    public void CorrectSpeed()
    {
        var filename = $"{Constants.ContentPath}/ChangeSpeed.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        Assert.AreEqual(0, mover.Speed);
    }

    [Test]
    public void CorrectSpeed1()
    {
        var filename = $"{Constants.ContentPath}/ChangeSpeed.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();

        Assert.AreEqual(1, mover.Speed);
    }

    [Test]
    public void ChangeSpeedAbs()
    {
        var filename = $"{Constants.ContentPath}/ChangeSpeedAbs.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        mover.Speed = 110;
        mover.InitTopNode(pattern.RootNode);

        Assert.AreEqual(110, mover.Speed);
        manager.Update();
        Assert.AreEqual(100, mover.Speed);

        for (int i = 0; i < 10; i++)
        {
            manager.Update();
        }

        Assert.AreEqual(10, mover.Speed);
    }

    [Test]
    public void ChangeSpeedRel()
    {
        var filename = $"{Constants.ContentPath}/ChangeSpeedRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Speed = 100;
        mover.InitTopNode(pattern.RootNode);

        Assert.AreEqual(100, mover.Speed);
        manager.Update();
        Assert.AreEqual(101, mover.Speed);

        for (int i = 0; i < 10; i++)
        {
            manager.Update();
        }

        Assert.AreEqual(110, mover.Speed);
    }

    [Test]
    public void ChangeSpeedSeq()
    {
        var filename = $"{Constants.ContentPath}/ChangeSpeedSeq.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Speed = 100;
        mover.InitTopNode(pattern.RootNode);

        Assert.AreEqual(100, mover.Speed);
        manager.Update();
        Assert.AreEqual(110, mover.Speed);

        for (int i = 0; i < 10; i++)
        {
            manager.Update();
        }

        Assert.AreEqual(200, mover.Speed);
    }
}