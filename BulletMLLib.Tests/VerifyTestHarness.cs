using BulletMLSample;
using NUnit.Framework;
using System.IO;
using BulletMLLib.SharedProject;
using BulletMLLibTests;

namespace BulletMLTests;

[TestFixture]
public class VerifyTestHarness
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
    public void MakeSureNothingCrashes()
    {
        foreach (var source in Directory.GetFiles("BulletMLLib.Tests/Content", "*.xml"))
        {
            //load & validate the pattern
            BulletPattern pattern = new();
            pattern.ParseXML(source);

            //fire in the hole
            manager.movers.Clear();
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
        }
    }

    [Test]
    public void NoBullet()
    {
        var filename = $"{Constants.ContentPath}/Empty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.FreeMovers();

        Assert.AreEqual(0, manager.movers.Count);
    }

    [Test]
    public void NoBullet1()
    {
        var filename = $"{Constants.ContentPath}/FireEmptyNoBullets.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.FreeMovers();

        Assert.AreEqual(0, manager.movers.Count);
    }

    [Test]
    public void NoBullet2()
    {
        var filename = $"{Constants.ContentPath}/BulletEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.FreeMovers();

        Assert.AreEqual(0, manager.movers.Count);
    }

    [Test]
    public void NoBullet3()
    {
        var filename = $"{Constants.ContentPath}/ActionEmpty.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.FreeMovers();

        Assert.AreEqual(0, manager.movers.Count);
    }

    [Test]
    public void OneBullet()
    {
        var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.FreeMovers();

        Assert.AreEqual(1, manager.movers.Count);
    }

    [Test]
    public void OneBullet1()
    {
        var filename = $"{Constants.ContentPath}/FireDirection.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.FreeMovers();

        Assert.AreEqual(1, manager.movers.Count);
    }

    [Test]
    public void TwoBullets()
    {
        var filename = $"{Constants.ContentPath}/ActionManyTop.xml";
        BulletPattern pattern = new();
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateTopBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.FreeMovers();

        Assert.AreEqual(0, manager.movers.Count);
    }
}