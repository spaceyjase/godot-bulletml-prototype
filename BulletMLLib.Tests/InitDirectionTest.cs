using BulletMLSample;
using NUnit.Framework;
using System;
using BulletMLLib.SharedProject;
using BulletMLLibTests;

namespace BulletMLTests;

[TestFixture]
public class InitDirectionTest
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
    public void IgnoreSequenceInitSpeed()
    {
        dude.pos.X = 0.0f;
        dude.pos.Y = 100.0f;
        var filename = $"{Constants.ContentPath}/FireDirectionSequence.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();
        Mover testDude = manager.movers[1];

        float direction = testDude.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(90.0f, direction);
    }

    [Test]
    public void FireAbsDirection()
    {
        var filename = $"{Constants.ContentPath}/FireDirectionAbsolute.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();
        Mover testDude = manager.movers[1];

        float direction = testDude.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(10.0f, direction);
    }

    [Test]
    public void FireRelDirection()
    {
        var filename = $"{Constants.ContentPath}/FireDirectionRelative.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.Direction = 100.0f * (float)Math.PI / 180.0f;
        mover.InitTopNode(pattern.RootNode);
        manager.Update();
        Mover testDude = manager.movers[1];

        float direction = testDude.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(110, (int)(direction + 0.5f));
    }

    [Test]
    public void FireAimDirection()
    {
        dude.pos.X = 0.0f;
        dude.pos.Y = 100.0f;
        var filename = $"{Constants.ContentPath}/FireDirectionAim.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();
        Mover testDude = manager.movers[1];

        float direction = testDude.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(direction, 90.0f);
    }

    [Test]
    public void FireDefaultDirection()
    {
        dude.pos.X = 100.0f;
        dude.pos.Y = 0.0f;
        var filename = $"{Constants.ContentPath}/FireDirection.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();
        Mover testDude = manager.movers[1];

        float direction = testDude.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(10.0f, direction);
    }

    [Test]
    public void NestedBulletsDirection()
    {
        var filename = $"{Constants.ContentPath}/NestedBulletsDirection.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        Mover testDude = manager.movers[1];
        float direction = testDude.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(10.0f, direction);
    }

    [Test]
    public void NestedBulletsDirection1()
    {
        var filename = $"{Constants.ContentPath}/NestedBulletsDirection.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();

        Mover testDude = manager.movers[2];
        float direction = testDude.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(20.0f, direction);
    }

    [Test]
    public void InitDirectionWithSequence()
    {
        dude.pos.X = 0.0f;
        dude.pos.Y = -100.0f;
        var filename = $"{Constants.ContentPath}/FireDirectionBulletDirection.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();
        Mover testDude = manager.movers[1];

        float direction = testDude.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(-70.0f, direction);
    }
}