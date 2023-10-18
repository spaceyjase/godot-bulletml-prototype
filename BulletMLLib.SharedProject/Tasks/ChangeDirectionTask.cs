using System;
using System.Diagnostics;
using BulletMLLib.SharedProject.Nodes;

namespace BulletMLLib.SharedProject.Tasks
{
    /// <summary>
    /// This task changes the direction a little bit every frame
    /// </summary>
    public class ChangeDirectionTask : BulletMLTask
    {
        #region Members
        /// <summary>
        /// The amount pulled out of the node
        /// </summary>
        private float NodeDirection;

        /// <summary>
        /// the type of direction change, pulled out of the node
        /// </summary>
        private ENodeType ChangeType;

        /// <summary>
        /// How long to run this task... measured in frames
        /// </summary>
        private float Duration { get; set; }

        /// <summary>
        /// How many frames this dude has ran
        /// </summary>
        private float RunDelta { get; set; }
        #endregion //Members

        #region Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="BulletMLTask"/> class.
        /// </summary>
        /// <param name="node">Node.</param>
        /// <param name="owner">Owner.</param>
        public ChangeDirectionTask(ChangeDirectionNode node, BulletMLTask owner)
            : base(node, owner)
        {
            Debug.Assert(null != Node);
            Debug.Assert(null != Owner);
        }

        /// <summary>
        /// this sets up the task to be run.
        /// </summary>
        /// <param name="bullet">Bullet.</param>
        protected override void SetupTask(Bullet bullet)
        {
            RunDelta = 0;

            //set the time length to run this dude
            Duration = Node.GetChildValue(ENodeName.term, this, bullet);

            //check for divide by 0
            if (Duration == 0.0f)
            {
                Duration = 1.0f;
            }

            //Get the amount to change direction from the nodes
            var dirNode = Node.GetChild(ENodeName.direction) as DirectionNode;
            NodeDirection = dirNode.GetValue(this, bullet) * (float)Math.PI / 180.0f; //also make sure to convert to radians

            //How do we want to change direction?
            ChangeType = dirNode.NodeType;
        }

        private float GetDirection(Bullet bullet)
        {
            //How do we want to change direction?
            var direction = ChangeType switch
            {
                ENodeType.sequence
                    =>
                    //We are going to add this amount to the direction every frame
                    NodeDirection,
                ENodeType.absolute
                    =>
                    //We are going to go in the direction we are given, regardless of where we are pointing right now
                    NodeDirection - bullet.Direction,
                ENodeType.relative
                    =>
                    //The direction change will be relative to our current direction
                    NodeDirection,
                _ => (NodeDirection + bullet.GetAimDir()) - bullet.Direction
            };

            //keep the direction between -180 and 180
            direction = MathHelper.WrapAngle(direction);

            //The sequence type of change direction is unaffected by the duration
            if (ChangeType == ENodeType.absolute)
            {
                //divide by the amount fo time remaining
                direction /= Duration - RunDelta;
            }
            else if (ChangeType != ENodeType.sequence)
            {
                //Divide by the duration so we ease into the direction change
                direction /= Duration;
            }

            return direction;
        }

        public override ERunStatus Run(Bullet bullet)
        {
            //change the direction of the bullet by the correct amount
            bullet.Direction += GetDirection(bullet);

            //decrement the amount if time left to run and return End when this task is finished
            RunDelta += 1.0f * bullet.TimeSpeed;
            if (!(Duration <= RunDelta))
                return ERunStatus.Continue;

            TaskFinished = true;
            return ERunStatus.End;

            //since this task isn't finished, run it again next time
        }
        #endregion //Methods
    }
}
