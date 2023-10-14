using BulletMLLib.SharedProject;
using Godot;

namespace bulletmltemplate
{
  /// <summary>
  /// Mover - represents a bullet in game, moved by the MoveManager.
  /// </summary>
  public class Mover : Bullet
  {
	private bool used;
	private float bulletLifetime = 5;
	private Node ParentNode { get; set; }
	private Node BulletNode { get; set; }

	public Mover(IBulletManager myBulletManager) : base(myBulletManager)
	{
	}

	public override void PostUpdate()
	{
	  // something something out of bounds
	  if (X < 0f || X > Main.Viewport.X || Y < 0f || Y > Main.Viewport.Y)
	  {
		Used = false;
	  }
	}
  
	public override float X
	{
	  get => Position.X;
	  set
	  { 
		var position = Position;
		position.X = value;
		Position = position;
	  
		if (GameManager.UseXZ)(BulletNode as Node3D).Position = new Vector3(position.X,  0, position.Y);
		else (BulletNode as Node2D).Position = Position;
	  }
	}

	public override float Y
	{
	  get => Position.Y;
	  set
	  { 
		var position = Position;
		position.Y = value;
		Position = position;
		if (GameManager.UseXZ)(BulletNode as Node3D).Position = new Vector3(position.X,  0, position.Y);
		else (BulletNode as Node2D).Position = Position;
	  }
	}
  
	public Vector2 Position { get; set; }

	public bool Used
	{
	  get => used;
	  set
	  {
		used = value;
		if (GameManager.UseXZ) (BulletNode as Node3D).Visible = value;
		else (BulletNode as Node2D).Visible = value;
		BulletNode.ProcessMode = value ? Node.ProcessModeEnum.Always : Node.ProcessModeEnum.Disabled;
	  }
	}


	public void Init()
	{
	  ParentNode = Main.Instance;
	  var scene = ResourceLoader.Load<PackedScene>(GameManager.UseXZ?"Bullet3D.tscn":"Bullet.tscn");
	  BulletNode = scene.Instantiate();
	  ParentNode.AddChild(BulletNode);
	  Used = true;
	}
  }
}
