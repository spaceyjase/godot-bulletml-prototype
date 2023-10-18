using NUnit.Framework;
using System.IO;
using BulletMLLib.SharedProject;
using BulletMLSample;

namespace BulletMLTests
{
    [TestFixture]
    public class Test
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
        public void ValidateTestData()
        {
            foreach (var source in Directory.GetFiles("BulletMLLib.Tests/Content", "*.xml"))
            {
                //load & validate the pattern
                BulletPattern pattern = new();
                pattern.ParseXML(source);
            }
        }
    }
}
