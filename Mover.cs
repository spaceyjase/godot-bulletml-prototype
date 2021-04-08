using Godot;
using BulletMLLib;

public class Mover : Bullet
{
  public Mover(IBulletManager myBulletManager) : base(myBulletManager)
  {
  }

  public override void PostUpdate()
  {
    // something something out of bounds
    if (X < 0f || X > Main.ViewportWidth || Y < 0f || Y > Main.ViewportHeight)
    {
      Used = false;
    }
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
