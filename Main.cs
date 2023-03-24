using System.Collections.Generic;
using System.IO;
using BulletMLLib.SharedProject;
using Godot;

namespace bulletmltemplate
{
	public partial class Main : Node2D
	{
		[Export] private PackedScene playerScene;
		
		// TODO: GameManager/Globals
		public static float ViewportWidth => Instance.GetViewportRect().Size.X;
		public static float ViewportHeight => Instance.GetViewportRect().Size.Y;
		public static Main Instance { get; private set; }

		private readonly List<BulletPattern> myPatterns = new();

		private readonly MoveManager moveManager;
	
		private int currentPattern;
		private Mover topLevelBullet;
		private Sprite2D playerInstance;	// TODO: PlayerManager

		public Main()
		{
			Instance = this;
			moveManager = new MoveManager(GetPlayerPosition);
		}

		private Vector2 GetPlayerPosition()
		{
			return playerInstance?.Position ?? new Vector2(GetViewportRect().Size.X / 2f, GetViewportRect().Size.Y - 100f);
		}

		public override void _Ready()
		{
			base._Ready();

			GameManager.GameDifficulty = () => 1.0f;
			
			foreach (var source in Directory.GetFiles("./samples", "*.xml"))
			{
				// load the pattern
				var pattern = new BulletPattern();
				pattern.ParseXML(source);
				myPatterns.Add(pattern);
			}

			AddBullet();
			
			// Add a dummy player sprite
	  var scene = ResourceLoader.Load<PackedScene>(playerScene.ResourcePath);
	  if (!(scene.Instantiate() is Sprite2D player)) return;
	  playerInstance = player;
	  player.Position = new Vector2(GetViewportRect().Size.X / 2f, GetViewportRect().Size.Y - 100f);
	  AddChild(player);
		}

		public override void _Process(double bigDelta)
		{
			var delta = (float) bigDelta;
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
				if (child is Sprite2D) continue;	// HACK: the player
				
				// TODO: object pooling
				(child as Node2D)?.QueueFree();
			}

			moveManager.Clear();

			// add a new bullet in the center of the screen (ish)
			topLevelBullet = (Mover)moveManager.CreateTopBullet();
			topLevelBullet.Position = new Vector2(GetViewportRect().Size.X / 2f, GetViewportRect().Size.Y / 2f - 100f);
			topLevelBullet.InitTopNode(myPatterns[currentPattern % myPatterns.Count].RootNode);
		}
	}
}
