using System.Collections.Generic;
using System.IO;
using BulletMLLib.SharedProject;
using Godot;

namespace bulletmltemplate
{
	public partial class Main : Node
	{
		[Export] private bool UseXZ = false;
		[Export] private PackedScene playerScene;
		[Export] private Vector2 PlayerSpawnPosition;
		[Export] private Label label;
		// TODO: GameManager/Globals
		public static Main Instance { get; private set; }

		private readonly List<BulletPattern> myPatterns = new();

		private readonly MoveManager moveManager;
		public static Vector2 Viewport;
		private int currentPattern;
		private Mover topLevelBullet;
		[Export] private Node playerInstance;	// TODO: PlayerManager

		public Main()
		{
			Instance = this;
			moveManager = new MoveManager(GetPlayerPosition);
			Viewport = new Vector2(
				(float)ProjectSettings.GetSetting("display/window/size/viewport_width"),
				(float)ProjectSettings.GetSetting("display/window/size/viewport_height")
			);
		}

		private Vector2 GetPlayerPosition()
		{

			if (playerInstance!=null){
				return new Vector2(
					GameManager.UseXZ?(playerInstance as Node3D).GlobalPosition.X:(playerInstance as Node2D).GlobalPosition.X,
					GameManager.UseXZ?(playerInstance as Node3D).GlobalPosition.Z:(playerInstance as Node2D).GlobalPosition.Y
				);
			} else return PlayerSpawnPosition; 
		}
		public override void _Ready()
		{
			base._Ready();

			GameManager.GameDifficulty = () => 1.0f;
			GameManager.UseXZ = UseXZ;
			
			foreach (var source in Directory.GetFiles("./samples", "*.xml"))
			{
				// load the pattern
				var pattern = new BulletPattern();
				pattern.ParseXML(source);
				myPatterns.Add(pattern);
			}

			AddBullet();
			
			// Add a dummy player sprite
			if (playerInstance==null){
	  			var scene = ResourceLoader.Load<PackedScene>(playerScene.ResourcePath);
				if (!(scene.Instantiate() is Node player)) return;
				playerInstance = player;
				if (UseXZ) (player as Node3D).Position = new Vector3(PlayerSpawnPosition.X, 0, PlayerSpawnPosition.Y)
;				else (player as Node2D).Position = PlayerSpawnPosition;
				AddChild(player);
			}
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
			// var label = GetNode<Label>("Control/BulletPatternLabel");
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
			topLevelBullet.Position =  GameManager.UseXZ?Vector2.Zero:new Vector2(Viewport.X/2, (Viewport.Y/2)-100);
			topLevelBullet.InitTopNode(myPatterns[currentPattern % myPatterns.Count].RootNode);
		}
	}
}
