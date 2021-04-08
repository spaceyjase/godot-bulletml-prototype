using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using BulletMLLib;

public class MoveManager : Node, IBulletManager
{
  [Export] private float timeSpeed = 1.0f;
  [Export] private float scale = 1.0f;
      
  private readonly List<Mover> movers = new List<Mover>();
  private readonly List<Mover> topLevelMovers = new List<Mover>();

  private PositionDelegate GetPlayerPosition;

  public MoveManager(PositionDelegate playerPosition)
  {
    Debug.Assert(playerPosition != null);
    GetPlayerPosition = playerPosition;
  }

  public IEnumerable<Mover> Movers => movers;

  public void Update(float delta)
  {
    foreach (var t in movers)
    {
      t.Update();
    }

    foreach (var t in topLevelMovers)
    {
      t.Update();
    }

    FreeMovers();
  }

  private void FreeMovers()
  {
    for (var i = 0; i < movers.Count; i++)
    {
      if (movers[i].Used) continue;
      movers.Remove(movers[i]);
      i--;
    }

    //clear out top level bullets
    for (var i = 0; i < topLevelMovers.Count; i++)
    {
      if (!topLevelMovers[i].TasksFinished()) continue;
      topLevelMovers.RemoveAt(i);
      i--;
    }
  }

  public Vector2 PlayerPosition(IBullet targettedBullet)
  {
    //just give the player's position
    Debug.Assert(null != GetPlayerPosition);
    return GetPlayerPosition();
  }

  public void RemoveBullet(IBullet deadBullet)
  {
    if (deadBullet is Mover myMover)
    {
      myMover.Used = false;
    }
  }

  public IBullet CreateBullet()
  {
    var mover = new Mover(this) { TimeSpeed = timeSpeed, Scale = scale };

    //initialize, store in our list, and return the bullet
    mover.Init();
    movers.Add(mover);
    return mover;
  }

  public IBullet CreateTopBullet()
  {
    var mover = new Mover(this) { TimeSpeed = timeSpeed, Scale = scale };

    //initialize, store in our list, and return the bullet
    mover.Init();
    topLevelMovers.Add(mover);
    return mover;
  }

  public double Tier()
  {
    return 0.0;
  }

  public void Clear()
  {
    movers.Clear();
    topLevelMovers.Clear();
  }
}