using BulletMLSample;
using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Tasks;
using BulletMLLibTests;

namespace BulletMLTests
{
    [TestFixture]
    public class TaskTest
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
        public void OneAction()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.AreEqual(1, mover.Tasks.Count);
        }

        [Test]
        public void OneAction1()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.IsNotNull(mover.Tasks[0] is ActionTask);
        }

        [Test]
        public void NoChildTasks()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.AreEqual(mover.Tasks[0].ChildTasks.Count, 0);
        }

        [Test]
        public void NoParams()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.AreEqual(mover.Tasks[0].ParamList.Count, 0);
        }

        [Test]
        public void NoOwner()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.IsNull(mover.Tasks[0].Owner);
        }

        [Test]
        public void CorrectNode()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.IsNotNull(mover.Tasks[0].Node);
        }

        [Test]
        public void NotFinished()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.IsFalse(mover.Tasks[0].TaskFinished);
        }

        [Test]
        public void OkFinished()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.AreEqual(ERunStatus.End, mover.Tasks[0].Run(mover));
        }

        [Test]
        public void TaskFinishedFlag()
        {
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Tasks[0].Run(mover);

            Assert.IsTrue(mover.Tasks[0].TaskFinished);
        }
    }
}
