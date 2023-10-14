
using Godot;

namespace BulletMLLib.SharedProject
{
	/// <summary>
	/// This is a callback method for getting a Vector2 position
	/// used to break out dependencies
	/// </summary>
	/// <returns>a method to get a position.</returns>
	public delegate Vector2 PositionDelegate2D();

	/// <summary>
	/// This is a callback method for getting a Vector3 position
	/// used to break out dependencies
	/// </summary>
	/// <returns>a method to get a position.</returns>
	public delegate Vector3 PositionDelegate3D();

	/// <summary>
	/// a method to get a float from somewhere
	/// separate from delgates
	/// </summary>
	/// <returns>get a float from somewhere</returns>
	public delegate float FloatDelegate();

	public delegate bool BoolDelegate();
}
