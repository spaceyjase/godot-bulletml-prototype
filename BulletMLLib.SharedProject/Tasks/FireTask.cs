using System;
using System.Diagnostics;
using BulletMLLib.SharedProject.Nodes;

namespace BulletMLLib.SharedProject.Tasks
{
  /// <summary>
  /// A task to shoot a bullet
  /// </summary>
  public class FireTask : BulletMLTask
  {
    #region Members

    /// <summary>
    /// The direction that this task will fire a bullet.
    /// </summary>
    /// <value>The fire direction.</value>
    public float FireDirection { get; private set; }

    /// <summary>
    /// The speed that this task will fire a bullet.
    /// </summary>
    /// <value>The fire speed.</value>
    public float FireSpeed { get; private set; }

    /// <summary>
    /// The number of times init has been called on this task
    /// </summary>
    /// <value>The number times initialized.</value>
    public int NumTimesInitialized { get; private set; }

    /// <summary>
    /// Flag used to tell if this is the first time this task has been run
    /// Used to determine if we should use the "initial" or "sequence" nodes to set bullets.
    /// </summary>
    /// <value><c>true</c> if initial run; otherwise, <c>false</c>.</value>
    public bool InitialRun
    {
      get
      {
        return NumTimesInitialized <= 0;
      }
    }

    /// <summary>
    /// If this fire node shoots from a bullet ref node, this will be a task created for it.
    /// This is needed so the params of the bullet ref can be set correctly.
    /// </summary>
    /// <value>The bullet reference task.</value>
    public BulletMLTask BulletRefTask { get; private set; }

    /// <summary>
    /// The node we are going to use to set the direction of any bullets shot with this task
    /// </summary>
    /// <value>The dir node.</value>
    public SetDirectionTask InitialDirectionTask { get; private set; }

    /// <summary>
    /// The node we are going to use to set the speed of any bullets shot with this task
    /// </summary>
    /// <value>The speed node.</value>
    public SetSpeedTask InitialSpeedTask { get; private set; }

    /// <summary>
    /// If there is a sequence direction node used to increment the direction of each successive bullet that is fired
    /// </summary>
    /// <value>The sequence direction node.</value>
    public SetDirectionTask SequenceDirectionTask { get; private set; }

    /// <summary>
    /// If there is a sequence direction node used to increment the direction of each successive bullet that is fired
    /// </summary>
    /// <value>The sequence direction node.</value>
    public SetSpeedTask SequenceSpeedTask { get; private set; }

    #endregion //Members

    #region Methods

    /// <summary>
    /// Initializes a new instance of the <see cref="FireTask"/> class.
    /// </summary>
    /// <param name="node">Node.</param>
    /// <param name="owner">Owner.</param>
    public FireTask(FireNode node, BulletMLTask owner) : base(node, owner)
    {
      Debug.Assert(null != Node);
      Debug.Assert(null != Owner);

      NumTimesInitialized = 0;
    }

    /// <summary>
    /// Parse a specified node and bullet into this task
    /// </summary>
    /// <param name="bullet">the bullet this dude is controlling</param>
    public override void ParseTasks(Bullet bullet)
    {
      if (null == bullet)
      {
        throw new NullReferenceException("bullet argument cannot be null");
      }

      foreach (var childNode in Node.ChildNodes)
      {
        ParseChildNode(childNode, bullet);
      }

      //Setup all the direction nodes
      GetDirectionTasks(this);
      GetDirectionTasks(BulletRefTask);

      //setup all the speed nodes
      GetSpeedNodes(this);
      GetSpeedNodes(BulletRefTask);
    }

    /// <summary>
    /// Parse a specified node and bullet into this task
    /// </summary>
    /// <param name="childNode">the node for this dude</param>
    /// <param name="bullet">the bullet this dude is controlling</param>
    protected override void ParseChildNode(BulletMLNode childNode, Bullet bullet)
    {
      Debug.Assert(null != childNode);
      Debug.Assert(null != bullet);

      switch (childNode.Name)
      {
        case ENodeName.bulletRef:
          {
            //Create a task for the bullet ref 
            if (childNode is BulletRefNode refNode) BulletRefTask = new BulletMLTask(refNode.ReferencedBulletNode, this);

            //populate the params of the bullet ref
            foreach (var node in childNode.ChildNodes)
            {
              BulletRefTask.ParamList.Add(node.GetValue(this, bullet));
            }

            BulletRefTask.ParseTasks(bullet);
            ChildTasks.Add(BulletRefTask);
          }
          break;

        case ENodeName.bullet:
          {
            //Create a task for the bullet ref 
            BulletRefTask = new BulletMLTask(childNode, this);
            BulletRefTask.ParseTasks(bullet);
            ChildTasks.Add(BulletRefTask);
          }
          break;

        default:
          {
            //run the node through the base class if we don't want it
            base.ParseChildNode(childNode, bullet);
          }
          break;
      }
    }

    /// <summary>
    /// This gets called when nested repeat nodes get initialized.
    /// </summary>
    /// <param name="bullet">Bullet.</param>
    protected override void HardReset(Bullet bullet)
    {
      //This is the whole point of the hard reset, so the sequence nodes get reset.
      NumTimesInitialized = 0;

      base.HardReset(bullet);
    }

    /// <summary>
    /// this sets up the task to be run.
    /// </summary>
    /// <param name="bullet">Bullet.</param>
    protected override void SetupTask(Bullet bullet)
    {
      //get the direction to shoot the bullet

      //is this the first time it has ran?  If there isn't a sequence node, we don't care!
      if (InitialRun || null == SequenceDirectionTask)
      {
        //do we have an initial direction node?
        if (null != InitialDirectionTask)
        {
          //Set the fire direction to the "initial" value
          var newBulletDirection = InitialDirectionTask.GetNodeValue(bullet) * (float)Math.PI / 180.0f;
          FireDirection = InitialDirectionTask.Node.NodeType switch
          {
            ENodeType.absolute =>
              //the new bullet points right at a particular direction
              newBulletDirection,
            ENodeType.relative =>
              //the new bullet direction will be relative to the old bullet
              newBulletDirection + bullet.Direction,
            _ => newBulletDirection + bullet.GetAimDir()
          };
        }
        else
        {
          //There isn't an initial direction task, so just aim at the bad guy.
          //aim the bullet at the player
          FireDirection = bullet.GetAimDir();
        }
      }
      else
      {
        //else if there is a sequence node, add the value to the "shoot direction"
        FireDirection += SequenceDirectionTask.GetNodeValue(bullet) * (float)Math.PI / 180.0f;
      }

      //Set the speed to shoot the bullet

      //is this the first time it has ran?  If there isn't a sequence node, we don't care!
      if (InitialRun || (null == SequenceSpeedTask))
      {
        //do we have an initial speed node?
        if (null != InitialSpeedTask)
        {
          //set the shoot speed to the "initial" value.
          var newBulletSpeed = InitialSpeedTask.GetNodeValue(bullet);
          FireSpeed = InitialSpeedTask.Node.NodeType switch
          {
            ENodeType.relative =>
              //the new bullet speed will be relative to the old bullet
              newBulletSpeed + bullet.Speed,
            _ => newBulletSpeed
          };
        }
        else
        {
          //there is no initial speed task, use the old dude's speed
          FireSpeed = bullet.Speed;
        }
      }
      else
      {
        //else if there is a sequence node, add the value to the "shoot direction"
        FireSpeed += SequenceSpeedTask.GetNodeValue(bullet);
      }

      //make sure the direction is between 0 and 359
      while (FireDirection > Math.PI)
      {
        FireDirection -= (2.0f * (float)Math.PI);
      }
      while (-Math.PI > FireDirection)
      {
        FireDirection += (2.0f * (float)Math.PI);
      }

      //make sure we don't overwrite the initial values if we aren't supposed to
      NumTimesInitialized++;
    }

    /// <summary>
    /// Run this task and all subtasks against a bullet
    /// This is called once a frame during runtime.
    /// </summary>
    /// <returns>ERunStatus: whether this task is done, paused, or still running</returns>
    /// <param name="bullet">The bullet to update this task against.</param>
    public override ERunStatus Run(Bullet bullet)
    {
      //Create the new bullet
      var newBullet = bullet.MyBulletManager.CreateBullet();

      if (newBullet == null)
      {
        //wtf did you do???
        TaskFinished = true;
        return ERunStatus.End;
      }

      //set the location of the new bullet
      newBullet.X = bullet.X;
      newBullet.Y = bullet.Y;

      //set the direction of the new bullet
      newBullet.Direction = FireDirection;

      //set teh speed of the new bullet
      newBullet.Speed = FireSpeed;

      //initialize the bullet with the bullet node stored in the Fire node
      var myFireNode = Node as FireNode;
      Debug.Assert(null != myFireNode);
      newBullet.InitNode(myFireNode.BulletDescriptionNode);

      //set the owner of all the top level tasks for the new bullet to this dude
      foreach (var task in newBullet.Tasks)
      {
        task.Owner = this;
      }

      TaskFinished = true;
      return ERunStatus.End;
    }

    /// <summary>
    /// Given a node, pull the direction nodes out from underneath it and store them if necessary
    /// </summary>
    /// <param name="taskToCheck">task to check if has a child direction node.</param>
    private void GetDirectionTasks(BulletMLTask taskToCheck)
    {
      //check if the dude has a direction node
      if (!(taskToCheck?.Node.GetChild(ENodeName.direction) is DirectionNode dirNode)) return;

      //check if it is a sequence type of node
      if (ENodeType.sequence == dirNode.NodeType)
      {
        //do we need a sequence node?
        if (null == SequenceDirectionTask)
        {
          //store it in the sequence direction node
          SequenceDirectionTask = new SetDirectionTask(dirNode, taskToCheck);
        }
      }
      else
      {
        //else do we need an initial node?
        if (null == InitialDirectionTask)
        {
          //store it in the initial direction node
          InitialDirectionTask = new SetDirectionTask(dirNode, taskToCheck);
        }
      }
    }

    /// <summary>
    /// Given a node, pull the speed nodes out from underneath it and store them if necessary
    /// </summary>
    /// <param name="taskToCheck">Node to check.</param>
    private void GetSpeedNodes(BulletMLTask taskToCheck)
    {
      //check if the dude has a speed node
      if (!(taskToCheck?.Node.GetChild(ENodeName.speed) is SpeedNode spdNode)) return;

      //check if it is a sequence type of node
      if (ENodeType.sequence == spdNode.NodeType)
      {
        //do we need a sequence node?
        if (null == SequenceSpeedTask)
        {
          //store it in the sequence speed node
          SequenceSpeedTask = new SetSpeedTask(spdNode, taskToCheck);
        }
      }
      else
      {
        //else do we need an initial node?
        if (null == InitialSpeedTask)
        {
          //store it in the initial speed node
          InitialSpeedTask = new SetSpeedTask(spdNode, taskToCheck);
        }
      }
    }

    #endregion //Methods
  }
}