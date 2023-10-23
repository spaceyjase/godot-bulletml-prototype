using BulletMLSample;
using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLib.SharedProject.Tasks;
using BulletMLLibTests;

namespace BulletMLTests
{
    [TestFixture]
    public class InitializeSpeedTest
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
        public void bulletCreated()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Speed = 100;

            manager.Update();
            Assert.AreEqual(manager.movers.Count, 2);
        }

        [Test]
        public void bulletDefaultSpeed()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNull(testTask.InitialSpeedTask);
            Assert.IsNull(testTask.SequenceSpeedTask);
            Assert.IsNull(testTask.InitialDirectionTask);
            Assert.IsNull(testTask.SequenceDirectionTask);
        }

        [Test]
        public void bulletDefaultSpeed1()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Speed = 100.0f;
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            FireTask testDude = new(testTask.Node as FireNode, testTask);
            Assert.IsTrue(testDude.InitialRun);
            testDude.InitTask(mover);

            Assert.IsNull(testDude.InitialSpeedTask);
            Assert.IsNull(testDude.SequenceSpeedTask);
            Assert.IsNull(testDude.InitialDirectionTask);
            Assert.IsNull(testDude.SequenceDirectionTask);

            Assert.AreEqual(100.0f, testDude.FireSpeed);
        }

        [Test]
        public void bulletDefaultSpeed2()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Mover testDude = manager.movers[1];

            Assert.AreEqual(100.0f, testDude.Speed);
        }

        [Test]
        public void SpeedDefault()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Mover testDude = manager.movers[1];

            Assert.AreEqual(5.0f, testDude.Speed);
        }

        [Test]
        public void AbsSpeedDefault()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedAbsolute.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Speed = 100;
            manager.Update();
            Mover testDude = manager.movers[1];

            Assert.AreEqual(5.0f, testDude.Speed);
        }

        [Test]
        public void RelSpeedDefault()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedRelative.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Mover testDude = manager.movers[1];

            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(105.0f, testTask.FireSpeed);
        }

        [Test]
        public void RelSpeedDefault1()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedRelative.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Mover testDude = manager.movers[1];

            Assert.AreEqual(105.0f, testDude.Speed);
        }

        [Test]
        public void RightInitSpeed()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedBulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Speed = 100;
            manager.Update();
            Mover testDude = manager.movers[1];

            Assert.AreEqual(5.0f, testDude.Speed);
        }

        [Test]
        public void IgnoreSequenceInitSpeed()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Speed = 100;
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNull(testTask.InitialSpeedTask);
            Assert.IsNotNull(testTask.SequenceSpeedTask);
        }

        [Test]
        public void IgnoreSequenceInitSpeed1()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Speed = 100;
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(ENodeType.sequence, testTask.SequenceSpeedTask.Node.NodeType);
        }

        [Test]
        public void IgnoreSequenceInitSpeed2()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Speed = 100;
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(100.0f, mover.Speed);
            Assert.IsFalse(testTask.InitialRun);
            Assert.AreEqual(5.0f, testTask.SequenceSpeedTask.Node.GetValue(testTask, mover));
        }

        [Test]
        public void IgnoreSequenceInitSpeed23()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            mover.Speed = 100;
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNull(testTask.InitialSpeedTask);
            Assert.IsNotNull(testTask.SequenceSpeedTask);
            Assert.AreEqual(ENodeType.sequence, testTask.SequenceSpeedTask.Node.NodeType);
            Assert.AreEqual(100.0f, mover.Speed);
            Assert.IsFalse(testTask.InitialRun);
            Assert.AreEqual(5.0f, testTask.SequenceSpeedTask.Node.GetValue(testTask, mover));
        }

        [Test]
        public void IgnoreSequenceInitSpeed3()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(100.0f, testTask.FireSpeed);
        }

        [Test]
        public void IgnoreSequenceInitSpeed4()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedSequence.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Mover testDude = manager.movers[1];

            Assert.AreEqual(100.0f, testDude.Speed);
        }

        [Test]
        public void FireAbsSpeed()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedAbsolute.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Mover testDude = manager.movers[1];

            Assert.AreEqual(5.0f, testDude.Speed);
        }

        [Test]
        public void FireRelSpeed()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedRelative.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.Speed = 100;
            mover.InitTopNode(pattern.RootNode);
            manager.Update();
            Mover testDude = manager.movers[1];

            Assert.AreEqual(105.0f, testDude.Speed);
        }

        [Test]
        public void NestedBullets()
        {
            var filename = $"{Constants.ContentPath}/NestedBulletsSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();

            //test the second bullet
            Mover testDude = manager.movers[1];
            Assert.AreEqual(10.0f, testDude.Speed);
        }

        [Test]
        public void NestedBullets1()
        {
            var filename = $"{Constants.ContentPath}/NestedBulletsSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();

            Assert.AreEqual(3, manager.movers.Count);
        }

        [Test]
        public void NestedBullets2()
        {
            var filename = $"{Constants.ContentPath}/NestedBulletsSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            manager.Update();

            //test the second bullet
            Mover testDude = manager.movers[2];
            Assert.AreEqual(20.0f, testDude.Speed);
        }
    }
}
