using BulletMLLib.SharedProject;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests;

[TestFixture]
public class VanishTask
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
    public void VanishTaskTest()
    {
        var filename = $"{Constants.ContentPath}/Vanish.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();
        Assert.AreEqual(0, manager.movers.Count);
    }

    [Test]
    public void NestedVanish()
    {
        var filename = $"{Constants.ContentPath}/NestedVanish.xml";
        pattern.ParseXML(filename);
        Mover mover = (Mover)manager.CreateBullet();
        mover.InitTopNode(pattern.RootNode);
        manager.Update();
        Assert.AreEqual(0, manager.movers.Count);
    }
}