using System;
using Godot;

namespace BulletMLLib.SharedProject
{
  public static class Vector2Ext
  {
    public static Vector2 ToVector2(this string strVector)
    {
      var zero = Vector2.Zero;
      if (!string.IsNullOrEmpty(strVector))
      {
        var strArray = strVector.Split(' ');
        if (strArray.Length >= 1)
          zero.x = Convert.ToSingle(strArray[0]);
        if (strArray.Length >= 2)
          zero.y = Convert.ToSingle(strArray[1]);
      }
      return zero;
    }

    public static string StringFromVector(this Vector2 myVector) => myVector.x.ToString() + " " + myVector.y.ToString();

    public static Vector2 Perp(this Vector2 myVector) => new Vector2(-myVector.y, myVector.x);

    public static int Sign(this Vector2 myVector, Vector2 v2) => myVector.y * (double) v2.x > myVector.x * (double) v2.y ? -1 : 1;

    public static Vector2 Truncate(this Vector2 myVector, float maxLength)
    {
      if (myVector.LengthSquared() > maxLength * (double) maxLength)
      {
        myVector.Normalized();
        myVector *= maxLength;
      }
      return myVector;
    }

    public static float Angle(this Vector2 vector) => (float) Math.Atan2(vector.y, vector.x);

    public static float AngleBetweenVectors(this Vector2 a, Vector2 b) => b.Angle() - a.Angle();

    public static Vector2 ToVector2(this float angle) => new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle));

    public static Vector2 ToVector2(this double angle) => new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle));

    public static bool IsNaN(this Vector2 vect) => !float.IsNaN(vect.x) && !float.IsNaN(vect.y);

    public static Vector2 Normalized(this Vector2 myVector)
    {
      var num = myVector.Length();
      return new Vector2(myVector.x / num, myVector.y / num);
    }
  }
}