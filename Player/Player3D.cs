using Godot;

public partial class Player3D : Node3D
{
  [Export] private float movementSpeed = 400f;

  public override void _Process(double _delta)
  {
	var delta = (float)_delta;
	base._Process(delta);

	var movement = new Vector3();

	if (Input.IsActionPressed("ui_right"))     movement += Vector3.Right;
	else if (Input.IsActionPressed("ui_left")) movement += Vector3.Left;

	if (Input.IsActionPressed("ui_up"))        movement += Vector3.Forward;
	else if (Input.IsActionPressed("ui_down")) movement += Vector3.Back;

	Position += movement.Normalized() * movementSpeed * delta;

	var position = Position;
	Position = position;
  }

  private void _on_Area3D_area_entered(Node area)
  {
	  GetNode<AnimationPlayer>(nameof(AnimationPlayer)).Play("hit");
  }
}
