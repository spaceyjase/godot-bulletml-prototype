using Godot;
using System;
using BulletMLLib;
using SharpDX.Direct3D11;

public class Mover : Bullet
{
  public Mover(IBulletManager myBulletManager) : base(myBulletManager)
  {
  }

  public override void PostUpdate()
  {
    // something something out of bounds
  }
  
  public override float X
  {
    get => Position.x;
    set
    { 
      var position = Position;
      position.x = value;
      Position = position;
    }
  }

  public override float Y
  {
    get => Position.y;
    set
    { 
      var position = Position;
      position.y = value;
      Position = position;
    }
  }
  
  public Vector2 Position { get; set; }
  public bool Used { get; set; }

  public void Init()
  {
    Used = true;
  }
}
