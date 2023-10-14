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
        private Node2D ParentNode { get; set; }
        private Node2D BulletNode { get; set; }

        public Mover(IBulletManager myBulletManager)
            : base(myBulletManager) { }

        public override void PostUpdate()
        {
            // something something out of bounds
            if (X < 0f || X > Main.ViewportWidth || Y < 0f || Y > Main.ViewportHeight)
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

                BulletNode.Position = Position;
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

                BulletNode.Position = Position;
            }
        }

        public Vector2 Position { get; set; }

        public bool Used
        {
            get => used;
            set
            {
                used = value;
                BulletNode.Visible = value;
            }
        }

        public void Init()
        {
            ParentNode = Main.Instance;
            var scene = ResourceLoader.Load<PackedScene>("Bullet.tscn");
            BulletNode = scene.Instantiate() as Node2D;
            ParentNode.AddChild(BulletNode);

            Used = true;
        }
    }
}
