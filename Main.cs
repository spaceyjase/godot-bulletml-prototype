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
	
	private Mover mover;
	
	private int currentPattern = 0;
	private List<Node2D> bullets;

	public Main()
	{
		instance = this;
		moveManager = new MoveManager(() => new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y - 100f));
	}

	public override void _Ready()
  {
    base._Ready();

    GameManager.GameDifficulty = () => 0.0f;
    
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

	  moveManager.Update(delta);

	  for (var i = 0; i < moveManager.Movers.Count(); ++i)
	  {
		  if (i >= bullets.Count) break;
		  
		  // TODO: physics
		  bullets[i].Position = mover.Position;
	  }
  }

  private void AddBullet()
	{
		//clear out all the bullets
		moveManager.Clear();

		//add a new bullet in the center of the screen
		mover = (Mover)moveManager.CreateTopBullet();
		mover.Position = new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y / 2f);
		mover.InitTopNode(myPatterns[currentPattern].RootNode);

		bullets = new List<Node2D>();
		foreach (var mover in moveManager.Movers)
		{
			var scene = ResourceLoader.Load<PackedScene>("Bullet.tscn");
			var bullet = scene.Instance() as Node2D;
			bullets.Add(bullet);

			GD.Print(bullet.Name);
			
			this.AddChild(bullet);
		}
	}
}
