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
	private readonly Dictionary<int, Node2D> bullets = new Dictionary<int, Node2D>();

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
	  
	  moveManager.Update(delta);
	  
		// TODO: physics
		
		// HACK: draw bullets for each mover
		DrawBullet(moveManager.TopLevelMovers);
		DrawBullet(moveManager.Movers);
  }

  private void DrawBullet(IReadOnlyList<Mover> movers)
  {
	  for (var i = 0; i < movers.Count; ++i)
	  {
		  var mover = movers[i];
		  
		  if (!mover.Used) continue;

		  Node2D bullet;
		  if (bullets.ContainsKey(i))
		  {
			  bullet = bullets[i];
		  }
		  else
		  {
			  var scene = ResourceLoader.Load<PackedScene>("Bullet.tscn");
			  bullet = scene.Instance() as Node2D;
			  AddChild(bullet);
			  bullets[i] = bullet;
		  }
			bullet.Position = mover.Position;
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

		bullets.Clear();
		moveManager.Clear();

		//add a new bullet in the center of the screen
		topLevelBullet = (Mover)moveManager.CreateTopBullet();
		topLevelBullet.Position = new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y / 2f);
		topLevelBullet.InitTopNode(myPatterns[currentPattern].RootNode);
	}
}
