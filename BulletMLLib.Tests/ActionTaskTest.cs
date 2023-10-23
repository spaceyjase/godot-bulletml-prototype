using BulletMLLib.SharedProject;
using BulletMLLib.SharedProject.Nodes;
using BulletMLLib.SharedProject.Tasks;
using BulletMLLibTests;
using BulletMLSample;
using NUnit.Framework;

namespace BulletMLTests
{
    [TestFixture]
    public class ActionTaskTest
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
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
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
            var filename = $"{Constants.ContentPath}/ActionOneTop.xml";
            BulletPattern pattern = new();
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
            var filename = $"{Constants.ContentPath}/ActionRepeatOnce.xml";
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
            var filename = $"{Constants.ContentPath}/ActionRepeatOnce.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            Assert.AreEqual(1, myTask.ChildTasks.Count);
            Assert.IsTrue(myTask.ChildTasks[0] is ActionTask);
        }

        [Test]
        public void CorrectAction2()
        {
            var filename = $"{Constants.ContentPath}/ActionRepeatOnce.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            ActionTask testTask = myTask.ChildTasks[0] as ActionTask;

            Assert.IsNotNull(testTask.Node);
            Assert.IsTrue(testTask.Node.Name == ENodeName.action);
            Assert.AreEqual(testTask.Node.Label, "test");
        }

        [Test]
        public void RepeatNumInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/ActionRepeatOnce.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            ActionTask testTask = myTask.ChildTasks[0] as ActionTask;
            Assert.AreEqual(0, testTask.RepeatNum);
        }

        [Test]
        public void RepeatNumMaxInitCorrect()
        {
            var filename = $"{Constants.ContentPath}/ActionRepeatOnce.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            BulletMLTask myTask = mover.Tasks[0];
            ActionTask testTask = myTask.ChildTasks[0] as ActionTask;
            ActionNode actionNode = testTask.Node as ActionNode;

            Assert.AreEqual(1, actionNode.RepeatNum(testTask, mover));
        }

        [Test]
        public void RepeatNumMaxCorrect()
        {
            var filename = $"{Constants.ContentPath}/ActionRepeatMany.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            ActionTask testTask = mover.FindTaskByLabel("test") as ActionTask;
            Assert.IsNotNull(testTask);
        }

        [Test]
        public void RepeatNumMaxCorrect1()
        {
            var filename = $"{Constants.ContentPath}/ActionRepeatMany.xml";
            BulletPattern pattern = new();
            pattern.ParseXML(filename);
            Mover mover = (Mover)manager.CreateBullet();
            mover.InitTopNode(pattern.RootNode);
            ActionTask testTask = mover.FindTaskByLabel("test") as ActionTask;
            ActionNode actionNode = testTask.Node as ActionNode;

            Assert.AreEqual(10, actionNode.RepeatNum(testTask, mover));
        }
    }
}
