using Godot;
using System;

public class Player : Sprite
{
  [Export]
  private float movementSpeed = 400f;
  
  public override void _Process(float delta)
  {
    base._Process(delta);
    
    if (Input.IsActionPressed("ui_right"))
    {
      Position += new Vector2(movementSpeed * delta, 0f);
    }
    else if (Input.IsActionPressed("ui_left"))
    {
      Position += new Vector2(-movementSpeed * delta, 0f);
    }
    if (Input.IsActionPressed("ui_up"))
    {
      Position += new Vector2(0f, -movementSpeed * delta);
    }
    else if (Input.IsActionPressed("ui_down"))
    {
      Position += new Vector2(0f, movementSpeed * delta);
    }

    var position = Position;
    position.x = Mathf.Clamp(position.x, 0f, GetViewport().Size.x);
    position.y = Mathf.Clamp(position.y, 0f, GetViewport().Size.y);
    Position = position;
  }
}
