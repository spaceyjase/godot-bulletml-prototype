using System.Collections.Generic;
using BulletMLLib.SharedProject;
using Godot;

namespace bulletmltemplate
{
	public class Main : Node2D
	{
		// TODO: GameManager/Globals
		public static float ViewportWidth => Instance.GetViewportRect().Size.x;
		public static float ViewportHeight => Instance.GetViewportRect().Size.y;
		public static Main Instance { get; private set; }

		private readonly List<BulletPattern> myPatterns = new List<BulletPattern>();

		private readonly MoveManager moveManager;
	
		private int currentPattern;
		private Mover topLevelBullet;

		public Main()
		{
			Instance = this;
			moveManager = new MoveManager(() => new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y - 100f));
		}

		public override void _Ready()
		{
			base._Ready();

			GameManager.GameDifficulty = () => 1.0f;
			
			foreach (var source in System.IO.Directory.GetFiles("./samples", "*.xml"))
			{
				// load the pattern
				var pattern = new BulletPattern();
				pattern.ParseXML(source);
				myPatterns.Add(pattern);
			}

			AddBullet();
		}

		public override void _Process(float delta)
		{
			base._Process(delta);

			if (Input.IsActionJustPressed("ui_select"))
			{
				currentPattern++;
				if (currentPattern >= myPatterns.Count)
				{
					currentPattern = 0;
				}

				AddBullet();
		  
				return;
			}

			moveManager.Update(delta);
	  
			// TODO: physics?

			moveManager.PostUpdate();
		}

		private void AddBullet()
		{
			// clear out all the bullets
			foreach (var child in GetChildren())
			{
				// TODO: object pooling
				(child as Node2D)?.QueueFree();
			}

			moveManager.Clear();

			// add a new bullet in the center of the screen (ish)
			topLevelBullet = (Mover)moveManager.CreateTopBullet();
			topLevelBullet.Position = new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y / 2f - 100f);
			topLevelBullet.InitTopNode(myPatterns[currentPattern].RootNode);
			
			// Add a dummy player sprite
      var scene = ResourceLoader.Load<PackedScene>("Player.tscn");
      var player = scene.Instance() as Sprite;
      player.Position = new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y - 100f);
      AddChild(player);
		}
	}
}
