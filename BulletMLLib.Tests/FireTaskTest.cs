using BulletMLSample;
using NUnit.Framework;
using System;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLib.SharedProject.Tasks;
using BulletMLLibTests;

namespace BulletMLTests
{
    [TestFixture]
    public class FireTaskTest
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
        public void CorrectNode()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.IsNotNull(mover.Tasks[0].Node);
            Assert.IsNotNull(mover.Tasks[0].Node is ActionNode);
        }

        [Test]
        public void RepeatOnce()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            ActionTask myAction = mover.Tasks[0] as ActionTask;

            ActionNode testNode =
                pattern.RootNode.FindLabelNode("top", ENodeName.action) as ActionNode;
            Assert.AreEqual(1, testNode!.RepeatNum(myAction, mover));
        }

        [Test]
        public void CorrectAction()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            Assert.AreEqual(1, myTask.ChildTasks.Count);
        }

        [Test]
        public void CorrectAction1()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            Assert.AreEqual(1, myTask.ChildTasks.Count);
            Assert.IsTrue(myTask.ChildTasks[0] is FireTask);
        }

        [Test]
        public void CorrectAction2()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNotNull(testTask!.Node);
            Assert.IsTrue(testTask!.Node.Name == ENodeName.fire);
            Assert.AreEqual(testTask!.Node.Label, "test1");
        }

        [Test]
        public void NoSubTasks()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(1, testTask!.ChildTasks.Count);
        }

        [Test]
        public void NoSubTasks1()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedBulletSpeed.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(1, testTask!.ChildTasks.Count);
        }

        [Test]
        public void FireDirectionInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            float direction = testTask!.FireDirection * 180 / (float)Math.PI;
            Assert.AreEqual(0.0f, direction);
        }

        [Test]
        public void FireDirectionInitCorrect1()
        {
            dude.pos.X = 100.0f;
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            float direction = testTask!.FireDirection * 180 / (float)Math.PI;
            Assert.AreEqual(0.0f, direction);
        }

        [Test]
        public void FireDirectionInitCorrect2()
        {
            dude.pos.X = 0.0f;
            dude.pos.Y = 100.0f;
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            float direction = testTask!.FireDirection * 180 / (float)Math.PI;
            Assert.AreEqual(direction, 90.0f);
        }

        [Test]
        public void FireDirectionInitCorrect3()
        {
            dude.pos.X = -100.0f;
            dude.pos.Y = 0.0f;
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            float direction = testTask!.FireDirection * 180 / (float)Math.PI;
            Assert.AreEqual(180.0f, direction);
        }

        [Test]
        public void FireSpeedInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(0, testTask!.FireSpeed);
        }

        [Test]
        public void FireInitialRunInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(false, testTask!.InitialRun);
        }

        [Test]
        public void FireBulletRefInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNotNull(testTask!.BulletRefTask);
        }

        [Test]
        public void FireInitDirInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNull(testTask!.InitialDirectionTask);
        }

        [Test]
        public void FireSpeedInitInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNull(testTask!.InitialSpeedTask);
        }

        [Test]
        public void FireDirSeqInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNull(testTask!.SequenceDirectionTask);
        }

        [Test]
        public void FireSpeedSeqInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireEmpty.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNull(testTask!.SequenceSpeedTask);
        }

        [Test]
        public void FoundBullet()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            Assert.IsNotNull(testTask!.BulletRefTask);
        }

        [Test]
        public void FoundBulletNoSubTasks()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(1, testTask!.ChildTasks.Count);
        }
    }
}
