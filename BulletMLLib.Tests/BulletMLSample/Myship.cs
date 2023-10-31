using Godot;

namespace BulletMLSample;

public class MyShip
{
    public Vector2 pos;
    private float speed = 3;

    public Vector2 Position()
    {
        return pos;
    }

    public void Init()
    {
        //pos.X = Game1.graphics.PreferredBackBufferWidth / 2f;
        //pos.Y = Game1.graphics.PreferredBackBufferHeight / 2f;
    }

    public void Update() { }
}