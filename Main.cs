using System.Collections.Generic;
using BulletMLLib.SharedProject;
using Godot;

namespace bulletmltemplate
{
	public class Main : Node2D
	{
		[Export] private PackedScene playerScene;
		
		// TODO: GameManager/Globals
		public static float ViewportWidth => Instance.GetViewportRect().Size.x;
		public static float ViewportHeight => Instance.GetViewportRect().Size.y;
		public static Main Instance { get; private set; }

		private readonly List<BulletPattern> myPatterns = new List<BulletPattern>();

		private readonly MoveManager moveManager;
	
		private int currentPattern;
		private Mover topLevelBullet;
		private Sprite playerInstance;	// TODO: PlayerManager

		public Main()
		{
			Instance = this;
			moveManager = new MoveManager(GetPlayerPosition);
		}

		private Vector2 GetPlayerPosition()
		{
			return playerInstance?.Position ?? new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y - 100f);
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
			
			// Add a dummy player sprite
      var scene = ResourceLoader.Load<PackedScene>(playerScene.ResourcePath);
      if (!(scene.Instance() is Sprite player)) return;
      playerInstance = player;
      player.Position = new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y - 100f);
      AddChild(player);
		}

		public override void _Process(float delta)
		{
			base._Process(delta);

			if (Input.IsActionJustPressed("ui_select"))
			{
				currentPattern++;

				AddBullet();
		  
				return;
			}

			moveManager.Update(delta);
	  
			// TODO: physics?

			moveManager.PostUpdate();
		}

		private void AddBullet()
		{
			var label = GetNode<Label>("Control/BulletPatternLabel");
			label.Text = $"Pattern: {myPatterns[currentPattern % myPatterns.Count].Filename}";
			label.Show();

			// clear out all the bullets
			foreach (var child in GetChildren())
			{
				if (child is Sprite) continue;	// HACK: the player
				
				// TODO: object pooling
				(child as Node2D)?.QueueFree();
			}

			moveManager.Clear();

			// add a new bullet in the center of the screen (ish)
			topLevelBullet = (Mover)moveManager.CreateTopBullet();
			topLevelBullet.Position = new Vector2(GetViewportRect().Size.x / 2f, GetViewportRect().Size.y / 2f - 100f);
			topLevelBullet.InitTopNode(myPatterns[currentPattern % myPatterns.Count].RootNode);
		}
	}
}
