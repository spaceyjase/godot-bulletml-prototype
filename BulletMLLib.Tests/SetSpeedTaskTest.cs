using BulletMLSample;
using NUnit.Framework;
using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLib.SharedProject.Tasks;
using BulletMLLibTests;

namespace BulletMLTests
{
    [TestFixture]
    public class SetSpeedTaskTest
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
        public void CorrectNode()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);

            Assert.IsNotNull(mover.Tasks[0].Node);
            Assert.IsNotNull(mover.Tasks[0].Node is ActionNode);
        }

        [Test]
        public void RepeatOnce()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            ActionTask myAction = mover.Tasks[0] as ActionTask;

            ActionNode testNode =
                pattern.RootNode.FindLabelNode("top", ENodeName.action) as ActionNode;
            Assert.AreEqual(1, testNode.RepeatNum(myAction, mover));
        }

        [Test]
        public void CorrectAction()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            Assert.AreEqual(1, myTask.ChildTasks.Count);
        }

        [Test]
        public void CorrectAction1()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
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
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNotNull(testTask.Node);
            Assert.IsTrue(testTask.Node.Name == ENodeName.fire);
        }

        [Test]
        public void NoSubTasks()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(1, testTask.ChildTasks.Count);
        }

        [Test]
        public void FireSpeedInitInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNotNull(testTask.InitialSpeedTask);
        }

        [Test]
        public void FireSpeedInitInitCorrect1()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsTrue(testTask.InitialSpeedTask is SetSpeedTask);
        }

        [Test]
        public void FireSpeedTaskValue()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            SetSpeedTask speedTask = testTask.InitialSpeedTask as SetSpeedTask;

            Assert.IsNotNull(speedTask.Node);
        }

        [Test]
        public void FireSpeedTaskValue1()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            SetSpeedTask speedTask = testTask.InitialSpeedTask as SetSpeedTask;

            Assert.IsTrue(speedTask.Node is SpeedNode);
        }

        [Test]
        public void FireSpeedTaskValue2()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            SetSpeedTask speedTask = testTask.InitialSpeedTask as SetSpeedTask;
            SpeedNode speedNode = speedTask.Node as SpeedNode;

            Assert.IsNotNull(speedNode);
        }

        [Test]
        public void FireSpeedTaskValue3()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            SetSpeedTask speedTask = testTask.InitialSpeedTask as SetSpeedTask;
            SpeedNode speedNode = speedTask.Node as SpeedNode;

            Assert.AreEqual(5.0f, speedNode.GetValue(speedTask, mover));
        }

        [Test]
        public void FireSpeedInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/FireSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(5.0f, testTask.FireSpeed);
        }

        [Test]
        public void FireSpeedInitCorrect1()
        {
            var filename = $"{Constants.ContentPath}/FireSpeedBulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(5.0f, testTask.FireSpeed);
        }

        [Test]
        public void BulletSpeedInitInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsNotNull(testTask.InitialSpeedTask);
        }

        [Test]
        public void BulletSpeedInitInitCorrect1()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.IsTrue(testTask.InitialSpeedTask is SetSpeedTask);
        }

        [Test]
        public void BulletSpeedTaskValue()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            SetSpeedTask speedTask = testTask.InitialSpeedTask as SetSpeedTask;

            Assert.IsNotNull(speedTask.Node);
        }

        [Test]
        public void BulletSpeedTaskValue1()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            SetSpeedTask speedTask = testTask.InitialSpeedTask as SetSpeedTask;

            Assert.IsTrue(speedTask.Node is SpeedNode);
        }

        [Test]
        public void BulletSpeedTaskValue2()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            SetSpeedTask speedTask = testTask.InitialSpeedTask as SetSpeedTask;
            SpeedNode speedNode = speedTask.Node as SpeedNode;

            Assert.IsNotNull(speedNode);
        }

        [Test]
        public void BulletSpeedTaskValue3()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;
            SetSpeedTask speedTask = testTask.InitialSpeedTask as SetSpeedTask;
            SpeedNode speedNode = speedTask.Node as SpeedNode;

            Assert.AreEqual(10.0f, speedNode.GetValue(speedTask, mover));
        }

        [Test]
        public void BulletSpeedInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/BulletSpeed.xml";
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            FireTask testTask = myTask.ChildTasks[0] as FireTask;

            Assert.AreEqual(10.0f, testTask.FireSpeed);
        }
    }
}
