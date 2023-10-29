using BulletMLSample;
using NUnit.Framework;
using System;
using BulletMLLib.SharedProject;
using BulletMLLibTests;
using Godot;

namespace BulletMLTests;

[TestFixture]
public class ChangeDirectionTest
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
    public void ChangeDirectionAbsSetupCorrect()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionAbs.xml";
        pattern.ParseXML(filename);
        dude.pos = new(0, 100);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(0, (int)direction);
    }

    [Test]
    public void ChangeDirectionAbs()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionAbs.xml";
        pattern.ParseXML(filename);
        dude.pos = new(0, 100);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();
        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(45, (int)direction);
    }

    [Test]
    public void ChangeDirectionAbs1()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionAbs.xml";
        pattern.ParseXML(filename);
        dude.pos = new(0, 100);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();
        manager.Update();
        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(90, (int)direction);
    }

    [Test]
    public void ChangeDirectionAimSetupCorrect()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionAim.xml";
        pattern.ParseXML(filename);
        dude.pos = new(100.0f, 0.0f);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(0, (int)direction);
    }

    [Test]
    public void ChangeDirectionAim()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionAim.xml";
        pattern.ParseXML(filename);
        dude.pos = new(0.0f, 100.0f);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();
        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(45, (int)direction);
    }

    [Test]
    public void ChangeDirectionAim1()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionAim.xml";
        pattern.ParseXML(filename);
        dude.pos = new(0.0f, 100.0f);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();
        manager.Update();
        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(67, (int)direction);
    }

    [Test]
    public void ChangeDirectionRelSetupCorrect()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(0, (int)direction);
    }

    [Test]
    public void ChangeDirectionRel()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();
        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(-45, (int)direction);
    }

    [Test]
    public void ChangeDirectionRel1()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionRel.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();
        manager.Update();
        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(-90, (int)direction);
    }

    [Test]
    public void ChangeDirectionSeqSetupCorrect()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionSeq.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(0, (int)direction);
    }

    [Test]
    public void ChangeDirectionSeq()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionSeq.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();
        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(90, (int)direction);
    }

    [Test]
    public void ChangeDirectionSeq1()
    {
        var filename = $"{Constants.ContentPath}/ChangeDirectionSeq.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);

        manager.Update();
        manager.Update();
        float direction = mover.Direction * 180 / (float)Math.PI;
        Assert.AreEqual(180, (int)direction);
    }
}