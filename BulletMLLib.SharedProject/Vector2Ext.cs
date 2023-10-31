using System;
using Godot;

namespace BulletMLLib.SharedProject;

public static class Vector2Ext
{
    public static Vector2 ToVector2(this string strVector)
    {
        var zero = Vector2.Zero;
        if (string.IsNullOrEmpty(strVector))
            return zero;
        var strArray = strVector.Split(' ');
        if (strArray.Length >= 2)
            zero.Y = Convert.ToSingle(strArray[1]);
        if (strArray.Length >= 1)
            zero.X = Convert.ToSingle(strArray[0]);
        return zero;
    }

    public static string StringFromVector(this Vector2 myVector) =>
        $"{myVector.X} {myVector.Y}";

    public static Vector2 Perp(this Vector2 myVector) => new(-myVector.Y, myVector.X);

    public static int Sign(this Vector2 myVector, Vector2 v2) =>
        myVector.Y * (double)v2.X > myVector.X * (double)v2.Y ? -1 : 1;

    public static Vector2 Truncate(this Vector2 myVector, float maxLength)
    {
        if (myVector.LengthSquared() > maxLength * (double)maxLength)
        {
            myVector.Normalized();
            myVector *= maxLength;
        }
        return myVector;
    }

    public static float Angle(this Vector2 vector) => (float)Math.Atan2(vector.Y, vector.X);

    public static float AngleBetweenVectors(this Vector2 a, Vector2 b) => b.Angle() - a.Angle();

    public static Vector2 ToVector2(this float angle) =>
        new((float)Math.Cos(angle), (float)Math.Sin(angle));

    public static Vector2 ToVector2(this double angle) =>
        new((float)Math.Cos(angle), (float)Math.Sin(angle));

    public static bool IsNaN(this Vector2 vect) => !float.IsNaN(vect.X) && !float.IsNaN(vect.Y);

    public static Vector2 Normalized(this Vector2 myVector)
    {
        var num = myVector.Length();
        return new(myVector.X / num, myVector.Y / num);
    }
}