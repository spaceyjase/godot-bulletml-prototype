using Godot;
using System;

public class Player : Sprite
{
  [Export]
  private float movementSpeed = 400f;
  
  public override void _Process(float delta)
  {
    base._Process(delta);
    
    var movement = new Vector2();
    
    if (Input.IsActionPressed("ui_right"))
    {
      movement += Vector2.Right;
    }
    else if (Input.IsActionPressed("ui_left"))
    {
      movement += Vector2.Left;
    }
    if (Input.IsActionPressed("ui_up"))
    {
      movement += Vector2.Up;
    }
    else if (Input.IsActionPressed("ui_down"))
    {
      movement += Vector2.Down;
    }
    Position += movement.Normalized() * movementSpeed * delta;

    var position = Position;
    position.x = Mathf.Clamp(position.x, 0f, GetViewport().Size.x);
    position.y = Mathf.Clamp(position.y, 0f, GetViewport().Size.y);
    Position = position;
  }

  private void _on_Area2D_area_entered(Node area)
  {
    GetNode<AnimationPlayer>(nameof(AnimationPlayer)).Play("hit");
  }
}
