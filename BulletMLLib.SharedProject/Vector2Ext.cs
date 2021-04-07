using System;

namespace BulletMLLib
{
  public static class Vector2Ext
  {
    public static Vector2 ToVector2(this string strVector)
    {
      Vector2 zero = Vector2.Zero;
      if (!string.IsNullOrEmpty(strVector))
      {
        string[] strArray = strVector.Split(' ');
        if (strArray.Length >= 1)
          zero.X = Convert.ToSingle(strArray[0]);
        if (strArray.Length >= 2)
          zero.Y = Convert.ToSingle(strArray[1]);
      }
      return zero;
    }

    public static string StringFromVector(this Vector2 myVector) => myVector.X.ToString() + " " + myVector.Y.ToString();

    public static Vector2 Perp(this Vector2 myVector) => new Vector2(-myVector.Y, myVector.X);

    public static int Sign(this Vector2 myVector, Vector2 v2) => myVector.Y * (double) v2.X > myVector.X * (double) v2.Y ? -1 : 1;

    public static Vector2 Truncate(this Vector2 myVector, float maxLength)
    {
      if (myVector.LengthSquared() > maxLength * (double) maxLength)
      {
        myVector.Normalize();
        myVector *= maxLength;
      }
      return myVector;
    }

    public static bool LineIntersection2D(
      Vector2 A,
      Vector2 B,
      Vector2 C,
      Vector2 D,
      ref float dist,
      ref Vector2 point)
    {
      float num1 = (float) ((A.Y - (double) C.Y) * (D.X - (double) C.X) - (A.X - (double) C.X) * (D.Y - (double) C.Y));
      float num2 = (float) ((B.X - (double) A.X) * (D.Y - (double) C.Y) - (B.Y - (double) A.Y) * (D.X - (double) C.X));
      float num3 = (float) ((A.Y - (double) C.Y) * (B.X - (double) A.X) - (A.X - (double) C.X) * (B.Y - (double) A.Y));
      float num4 = (float) ((B.X - (double) A.X) * (D.Y - (double) C.Y) - (B.Y - (double) A.Y) * (D.X - (double) C.X));
      if (num2 == 0.0 || num4 == 0.0)
        return false;
      float num5 = num1 / num2;
      float num6 = num3 / num4;
      if (num5 > 0.0 && num5 < 1.0 && (num6 > 0.0 && num6 < 1.0))
      {
        dist = Vector2.Distance(A, B) * num5;
        point = A + num5 * (B - A);
        return true;
      }
      dist = 0.0f;
      return false;
    }

    public static float Angle(this Vector2 vector) => (float) Math.Atan2(vector.Y, vector.X);

    public static float AngleBetweenVectors(this Vector2 a, Vector2 b) => b.Angle() - a.Angle();

    public static Vector2 ToVector2(this float angle) => new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle));

    public static Vector2 ToVector2(this double angle) => new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle));

    public static bool IsNaN(this Vector2 vect) => !float.IsNaN(vect.X) && !float.IsNaN(vect.Y);

    public static Vector2 Normalized(this Vector2 myVector)
    {
      float num = myVector.Length();
      return new Vector2(myVector.X / num, myVector.Y / num);
    }
  }
}