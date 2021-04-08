using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using BulletMLLib;

public class Main : Node2D
{
	[Export] private string bulletXml;

	private static Main instance;
	
	// TODO: GameManager/Globals
	public static float ViewportWidth => instance.GetViewportRect().Size.x;
	public static float ViewportHeight => instance.GetViewportRect().Size.y;
	
	private List<string> patternNames = new List<string>();
	private readonly List<BulletPattern> myPatterns = new List<BulletPattern>();

	private readonly MoveManager moveManager;
	
	private int currentPattern = 0;
	private Mover topLevelBullet;

	public Main()
	{
		instance = this;
		moveManager = new MoveManager(() => new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y - 100f));
	}

	public override void _Ready()
  {
    base._Ready();

    GameManager.GameDifficulty = () => 1.0f;
    
    //foreach (var source in System.IO.Directory.GetFiles("res://samples/", "*.xml"))
    foreach (var source in new List<string> { bulletXml })
		{
			//store the name
			patternNames.Add(source);

			//load the pattern
			var pattern = new BulletPattern();
			pattern.ParseXML(source);
			myPatterns.Add(pattern);
		}

    AddBullet();
  }

  public override void _Process(float delta)
  {
	  base._Process(delta);
	  
		// HACK: clear out all the bullets
		foreach (var child in GetChildren())
		{
			// HACK: object pooling and bullet mapping to godot nodes 'cos this is painful...
			(child as Node).QueueFree();
		}

	  moveManager.Update(delta);
	  
		// TODO: physics
		// HACK: draw bullets for each mover
	  for (var i = 0; i < moveManager.TopLevelMovers.Count(); ++i)
	  {
			var scene = ResourceLoader.Load<PackedScene>("Bullet.tscn");
			var bullet = scene.Instance() as Node2D;
			bullet.Position = moveManager.TopLevelMovers[i].Position;
			AddChild(bullet);
	  }
	  for (var i = 0; i < moveManager.Movers.Count(); ++i)
	  {
			var scene = ResourceLoader.Load<PackedScene>("Bullet.tscn");
			var bullet = scene.Instance() as Node2D;
			bullet.Position = moveManager.Movers[i].Position;
			AddChild(bullet);
	  }
  }

  private void AddBullet()
	{
		//clear out all the bullets
		foreach (var child in GetChildren())
		{
			// TODO: object pooling
			(child as Node).QueueFree();
		}
		moveManager.Clear();

		//add a new bullet in the center of the screen
		topLevelBullet = (Mover)moveManager.CreateTopBullet();
		topLevelBullet.Position = new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y / 2f);
		topLevelBullet.InitTopNode(myPatterns[currentPattern].RootNode);
	}
}
