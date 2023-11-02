using Godot;

public partial class Player : Sprite2D
{
    [Export]
    private float movementSpeed = 400f;

    public override void _Process(double _delta)
    {
        var delta = (float)_delta;
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
        position.X = Mathf.Clamp(position.X, 0f, GetViewportRect().Size.X);
        position.Y = Mathf.Clamp(position.Y, 0f, GetViewportRect().Size.Y);
        Position = position;
    }

    private void _on_Area2D_area_entered(Node area)
    {
        GetNode<AnimationPlayer>(nameof(AnimationPlayer)).Play("hit");
    }
}
