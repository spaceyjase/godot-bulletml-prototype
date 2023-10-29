using BulletMLLib.SharedProject;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests;

[TestFixture]
public class TestDoubleRepeatXml
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
    public void CorrectNumberOfBullets()
    {
        var filename = $"{Constants.ContentPath}/DoubleRepeat.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        //there should be 20 bullets
        Assert.AreEqual(20, manager.movers.Count);
    }

    [Test]
    public void CorrectSpeedFirstSet()
    {
        var filename = $"{Constants.ContentPath}/DoubleRepeat.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        Assert.AreEqual(manager.movers[0].Speed, 1);
    }

    [Test]
    public void CorrectSpeedFirstSet1()
    {
        var filename = $"{Constants.ContentPath}/DoubleRepeat.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        Assert.AreEqual(manager.movers[1].Speed, 2);
    }

    [Test]
    public void CorrectSpeedFirstSet2()
    {
        var filename = $"{Constants.ContentPath}/DoubleRepeat.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        Assert.AreEqual(manager.movers[0].Speed, 1);
        Assert.AreEqual(manager.movers[1].Speed, 2);
        Assert.AreEqual(manager.movers[2].Speed, 3);
        Assert.AreEqual(manager.movers[3].Speed, 4);
        Assert.AreEqual(manager.movers[4].Speed, 5);
        Assert.AreEqual(manager.movers[5].Speed, 6);
        Assert.AreEqual(manager.movers[6].Speed, 7);
        Assert.AreEqual(manager.movers[7].Speed, 8);
        Assert.AreEqual(manager.movers[8].Speed, 9);
        Assert.AreEqual(manager.movers[9].Speed, 10);
    }

    [Test]
    public void CorrectSpeedFirstSet3()
    {
        var filename = $"{Constants.ContentPath}/DoubleRepeat.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        for (int i = 0; i < 9; i++)
        {
            Assert.AreEqual(i + 1, manager.movers[i].Speed);
        }
    }

    [Test]
    public void CorrectSpeedSecondSet()
    {
        var filename = $"{Constants.ContentPath}/DoubleRepeat.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        Assert.AreEqual(1, manager.movers[10].Speed);
    }

    [Test]
    public void CorrectSpeedSecondSet1()
    {
        var filename = $"{Constants.ContentPath}/DoubleRepeat.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        Assert.AreEqual(2, manager.movers[11].Speed);
    }

    [Test]
    public void CorrectSpeedAll()
    {
        var filename = $"{Constants.ContentPath}/DoubleRepeat.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        Assert.AreEqual(manager.movers[0].Speed, 1);
        Assert.AreEqual(manager.movers[1].Speed, 2);
        Assert.AreEqual(manager.movers[2].Speed, 3);
        Assert.AreEqual(manager.movers[3].Speed, 4);
        Assert.AreEqual(manager.movers[4].Speed, 5);
        Assert.AreEqual(manager.movers[5].Speed, 6);
        Assert.AreEqual(manager.movers[6].Speed, 7);
        Assert.AreEqual(manager.movers[7].Speed, 8);
        Assert.AreEqual(manager.movers[8].Speed, 9);
        Assert.AreEqual(manager.movers[9].Speed, 10);
        Assert.AreEqual(manager.movers[10].Speed, 1);
        Assert.AreEqual(manager.movers[11].Speed, 2);
        Assert.AreEqual(manager.movers[12].Speed, 3);
        Assert.AreEqual(manager.movers[13].Speed, 4);
        Assert.AreEqual(manager.movers[14].Speed, 5);
        Assert.AreEqual(manager.movers[15].Speed, 6);
        Assert.AreEqual(manager.movers[16].Speed, 7);
        Assert.AreEqual(manager.movers[17].Speed, 8);
        Assert.AreEqual(manager.movers[18].Speed, 9);
        Assert.AreEqual(manager.movers[19].Speed, 10);
    }
}