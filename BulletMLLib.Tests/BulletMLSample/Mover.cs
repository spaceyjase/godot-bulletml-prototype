using BulletMLLib.SharedProject;
using Godot;

namespace BulletMLSample;

public class Mover : Bullet
{
    private Vector2 pos;

    public override float X
    {
        get => pos.X;
        set => pos.X = value;
    }

    public override float Y
    {
        get => pos.Y;
        set => pos.Y = value;
    }

    public bool Used { get; set; }

    public Mover(IBulletManager myBulletManager)
        : base(myBulletManager) { }

    public void Init()
    {
        Used = true;
    }

    public override void PostUpdate()
    {
        if (X is < 0 or > 640 || Y is < 0 or > 480)
        {
            Used = false;
        }
    }
}