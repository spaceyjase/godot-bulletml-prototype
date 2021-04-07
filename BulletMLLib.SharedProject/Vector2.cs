using System;
using System.Diagnostics;

namespace BulletMLLib
{
  /// <summary>Describes a 2D-vector.</summary>
  [DebuggerDisplay("{DebugDisplayString,nq}")]
  public struct Vector2 : IEquatable<Vector2>
  {
    private static readonly Vector2 zeroVector = new Vector2(0.0f, 0.0f);
    private static readonly Vector2 unitVector = new Vector2(1f, 1f);
    private static readonly Vector2 unitXVector = new Vector2(1f, 0.0f);
    private static readonly Vector2 unitYVector = new Vector2(0.0f, 1f);
    /// <summary>
    /// The x coordinate of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    public float X;
    /// <summary>
    /// The y coordinate of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    public float Y;

    /// <summary>
    /// Returns a <see cref="T:Microsoft.Xna.Framework.Vector2" /> with components 0, 0.
    /// </summary>
    public static Vector2 Zero => zeroVector;

    /// <summary>
    /// Returns a <see cref="T:Microsoft.Xna.Framework.Vector2" /> with components 1, 1.
    /// </summary>
    public static Vector2 One => unitVector;

    /// <summary>
    /// Returns a <see cref="T:Microsoft.Xna.Framework.Vector2" /> with components 1, 0.
    /// </summary>
    public static Vector2 UnitX => unitXVector;

    /// <summary>
    /// Returns a <see cref="T:Microsoft.Xna.Framework.Vector2" /> with components 0, 1.
    /// </summary>
    public static Vector2 UnitY => unitYVector;

    internal string DebugDisplayString => X + "  " + Y;

    /// <summary>Constructs a 2d vector with X and Y from two values.</summary>
    /// <param name="x">The x coordinate in 2d-space.</param>
    /// <param name="y">The y coordinate in 2d-space.</param>
    public Vector2(float x, float y)
    {
      X = x;
      Y = y;
    }

    /// <summary>
    /// Constructs a 2d vector with X and Y set to the same value.
    /// </summary>
    /// <param name="value">The x and y coordinates in 2d-space.</param>
    public Vector2(float value)
    {
      X = value;
      Y = value;
    }

    /// <summary>
    /// Inverts values in the specified <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <param name="value">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the right of the sub sign.</param>
    /// <returns>Result of the inversion.</returns>
    public static Vector2 operator -(Vector2 value)
    {
      value.X = -value.X;
      value.Y = -value.Y;
      return value;
    }

    /// <summary>Adds two vectors.</summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the left of the add sign.</param>
    /// <param name="value2">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the right of the add sign.</param>
    /// <returns>Sum of the vectors.</returns>
    public static Vector2 operator +(Vector2 value1, Vector2 value2)
    {
      value1.X += value2.X;
      value1.Y += value2.Y;
      return value1;
    }

    /// <summary>
    /// Subtracts a <see cref="T:Microsoft.Xna.Framework.Vector2" /> from a <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the left of the sub sign.</param>
    /// <param name="value2">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the right of the sub sign.</param>
    /// <returns>Result of the vector subtraction.</returns>
    public static Vector2 operator -(Vector2 value1, Vector2 value2)
    {
      value1.X -= value2.X;
      value1.Y -= value2.Y;
      return value1;
    }

    /// <summary>
    /// Multiplies the components of two vectors by each other.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the left of the mul sign.</param>
    /// <param name="value2">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the right of the mul sign.</param>
    /// <returns>Result of the vector multiplication.</returns>
    public static Vector2 operator *(Vector2 value1, Vector2 value2)
    {
      value1.X *= value2.X;
      value1.Y *= value2.Y;
      return value1;
    }

    /// <summary>Multiplies the components of vector by a scalar.</summary>
    /// <param name="value">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the left of the mul sign.</param>
    /// <param name="scaleFactor">Scalar value on the right of the mul sign.</param>
    /// <returns>Result of the vector multiplication with a scalar.</returns>
    public static Vector2 operator *(Vector2 value, float scaleFactor)
    {
      value.X *= scaleFactor;
      value.Y *= scaleFactor;
      return value;
    }

    /// <summary>Multiplies the components of vector by a scalar.</summary>
    /// <param name="scaleFactor">Scalar value on the left of the mul sign.</param>
    /// <param name="value">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the right of the mul sign.</param>
    /// <returns>Result of the vector multiplication with a scalar.</returns>
    public static Vector2 operator *(float scaleFactor, Vector2 value)
    {
      value.X *= scaleFactor;
      value.Y *= scaleFactor;
      return value;
    }

    /// <summary>
    /// Divides the components of a <see cref="T:Microsoft.Xna.Framework.Vector2" /> by the components of another <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the left of the div sign.</param>
    /// <param name="value2">Divisor <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the right of the div sign.</param>
    /// <returns>The result of dividing the vectors.</returns>
    public static Vector2 operator /(Vector2 value1, Vector2 value2)
    {
      value1.X /= value2.X;
      value1.Y /= value2.Y;
      return value1;
    }

    /// <summary>
    /// Divides the components of a <see cref="T:Microsoft.Xna.Framework.Vector2" /> by a scalar.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" /> on the left of the div sign.</param>
    /// <param name="divider">Divisor scalar on the right of the div sign.</param>
    /// <returns>The result of dividing a vector by a scalar.</returns>
    public static Vector2 operator /(Vector2 value1, float divider)
    {
      float num = 1f / divider;
      value1.X *= num;
      value1.Y *= num;
      return value1;
    }

    /// <summary>
    /// Compares whether two <see cref="T:Microsoft.Xna.Framework.Vector2" /> instances are equal.
    /// </summary>
    /// <param name="value1"><see cref="T:Microsoft.Xna.Framework.Vector2" /> instance on the left of the equal sign.</param>
    /// <param name="value2"><see cref="T:Microsoft.Xna.Framework.Vector2" /> instance on the right of the equal sign.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public static bool operator ==(Vector2 value1, Vector2 value2) => value1.X == (double)value2.X && value1.Y == (double)value2.Y;

    /// <summary>
    /// Compares whether two <see cref="T:Microsoft.Xna.Framework.Vector2" /> instances are not equal.
    /// </summary>
    /// <param name="value1"><see cref="T:Microsoft.Xna.Framework.Vector2" /> instance on the left of the not equal sign.</param>
    /// <param name="value2"><see cref="T:Microsoft.Xna.Framework.Vector2" /> instance on the right of the not equal sign.</param>
    /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
    public static bool operator !=(Vector2 value1, Vector2 value2) => value1.X != (double)value2.X || value1.Y != (double)value2.Y;

    /// <summary>
    /// Performs vector addition on <paramref name="value1" /> and <paramref name="value2" />.
    /// </summary>
    /// <param name="value1">The first vector to add.</param>
    /// <param name="value2">The second vector to add.</param>
    /// <returns>The result of the vector addition.</returns>
    public static Vector2 Add(Vector2 value1, Vector2 value2)
    {
      value1.X += value2.X;
      value1.Y += value2.Y;
      return value1;
    }

    /// <summary>
    /// Performs vector addition on <paramref name="value1" /> and
    /// <paramref name="value2" />, storing the result of the
    /// addition in <paramref name="result" />.
    /// </summary>
    /// <param name="value1">The first vector to add.</param>
    /// <param name="value2">The second vector to add.</param>
    /// <param name="result">The result of the vector addition.</param>
    public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
    {
      result.X = value1.X + value2.X;
      result.Y = value1.Y + value2.Y;
    }

    /// <summary>Returns the distance between two vectors.</summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <returns>The distance between two vectors.</returns>
    public static float Distance(Vector2 value1, Vector2 value2)
    {
      float num1 = value1.X - value2.X;
      float num2 = value1.Y - value2.Y;
      return (float)Math.Sqrt(num1 * (double)num1 + num2 * (double)num2);
    }

    /// <summary>Returns the distance between two vectors.</summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <param name="result">The distance between two vectors as an output parameter.</param>
    public static void Distance(ref Vector2 value1, ref Vector2 value2, out float result)
    {
      float num1 = value1.X - value2.X;
      float num2 = value1.Y - value2.Y;
      result = (float)Math.Sqrt(num1 * (double)num1 + num2 * (double)num2);
    }

    /// <summary>Returns the squared distance between two vectors.</summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <returns>The squared distance between two vectors.</returns>
    public static float DistanceSquared(Vector2 value1, Vector2 value2)
    {
      float num1 = value1.X - value2.X;
      float num2 = value1.Y - value2.Y;
      return (float)(num1 * (double)num1 + num2 * (double)num2);
    }

    /// <summary>Returns the squared distance between two vectors.</summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <param name="result">The squared distance between two vectors as an output parameter.</param>
    public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out float result)
    {
      float num1 = value1.X - value2.X;
      float num2 = value1.Y - value2.Y;
      result = (float)(num1 * (double)num1 + num2 * (double)num2);
    }

    /// <summary>
    /// Divides the components of a <see cref="T:Microsoft.Xna.Framework.Vector2" /> by the components of another <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="value2">Divisor <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <returns>The result of dividing the vectors.</returns>
    public static Vector2 Divide(Vector2 value1, Vector2 value2)
    {
      value1.X /= value2.X;
      value1.Y /= value2.Y;
      return value1;
    }

    /// <summary>
    /// Divides the components of a <see cref="T:Microsoft.Xna.Framework.Vector2" /> by the components of another <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="value2">Divisor <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="result">The result of dividing the vectors as an output parameter.</param>
    public static void Divide(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
    {
      result.X = value1.X / value2.X;
      result.Y = value1.Y / value2.Y;
    }

    /// <summary>
    /// Divides the components of a <see cref="T:Microsoft.Xna.Framework.Vector2" /> by a scalar.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="divider">Divisor scalar.</param>
    /// <returns>The result of dividing a vector by a scalar.</returns>
    public static Vector2 Divide(Vector2 value1, float divider)
    {
      float num = 1f / divider;
      value1.X *= num;
      value1.Y *= num;
      return value1;
    }

    /// <summary>
    /// Divides the components of a <see cref="T:Microsoft.Xna.Framework.Vector2" /> by a scalar.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="divider">Divisor scalar.</param>
    /// <param name="result">The result of dividing a vector by a scalar as an output parameter.</param>
    public static void Divide(ref Vector2 value1, float divider, out Vector2 result)
    {
      float num = 1f / divider;
      result.X = value1.X * num;
      result.Y = value1.Y * num;
    }

    /// <summary>Returns a dot product of two vectors.</summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <returns>The dot product of two vectors.</returns>
    public static float Dot(Vector2 value1, Vector2 value2) => (float)(value1.X * (double)value2.X + value1.Y * (double)value2.Y);

    /// <summary>Returns a dot product of two vectors.</summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <param name="result">The dot product of two vectors as an output parameter.</param>
    public static void Dot(ref Vector2 value1, ref Vector2 value2, out float result) => result = (float)(value1.X * (double)value2.X + value1.Y * (double)value2.Y);

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="T:System.Object" />.
    /// </summary>
    /// <param name="obj">The <see cref="T:System.Object" /> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public override bool Equals(object obj) => obj is Vector2 other && Equals(other);

    /// <summary>
    /// Compares whether current instance is equal to specified <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <param name="other">The <see cref="T:Microsoft.Xna.Framework.Vector2" /> to compare.</param>
    /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
    public bool Equals(Vector2 other) => X == (double)other.X && Y == (double)other.Y;

    /// <summary>
    /// Gets the hash code of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <returns>Hash code of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.</returns>
    public override int GetHashCode() => X.GetHashCode() * 397 ^ Y.GetHashCode();

    /// <summary>
    /// Returns the length of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <returns>The length of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.</returns>
    public float Length() => (float)Math.Sqrt(X * (double)X + Y * (double)Y);

    /// <summary>
    /// Returns the squared length of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <returns>The squared length of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.</returns>
    public float LengthSquared() => (float)(X * (double)X + Y * (double)Y);

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a maximal values from the two vectors.
    /// </summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <returns>The <see cref="T:Microsoft.Xna.Framework.Vector2" /> with maximal values from the two vectors.</returns>
    public static Vector2 Max(Vector2 value1, Vector2 value2) => new Vector2(value1.X > (double)value2.X ? value1.X : value2.X, value1.Y > (double)value2.Y ? value1.Y : value2.Y);

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a maximal values from the two vectors.
    /// </summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <param name="result">The <see cref="T:Microsoft.Xna.Framework.Vector2" /> with maximal values from the two vectors as an output parameter.</param>
    public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
    {
      result.X = value1.X > (double)value2.X ? value1.X : value2.X;
      result.Y = value1.Y > (double)value2.Y ? value1.Y : value2.Y;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a minimal values from the two vectors.
    /// </summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <returns>The <see cref="T:Microsoft.Xna.Framework.Vector2" /> with minimal values from the two vectors.</returns>
    public static Vector2 Min(Vector2 value1, Vector2 value2) => new Vector2(value1.X < (double)value2.X ? value1.X : value2.X, value1.Y < (double)value2.Y ? value1.Y : value2.Y);

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a minimal values from the two vectors.
    /// </summary>
    /// <param name="value1">The first vector.</param>
    /// <param name="value2">The second vector.</param>
    /// <param name="result">The <see cref="T:Microsoft.Xna.Framework.Vector2" /> with minimal values from the two vectors as an output parameter.</param>
    public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
    {
      result.X = value1.X < (double)value2.X ? value1.X : value2.X;
      result.Y = value1.Y < (double)value2.Y ? value1.Y : value2.Y;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a multiplication of two vectors.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="value2">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <returns>The result of the vector multiplication.</returns>
    public static Vector2 Multiply(Vector2 value1, Vector2 value2)
    {
      value1.X *= value2.X;
      value1.Y *= value2.Y;
      return value1;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a multiplication of two vectors.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="value2">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="result">The result of the vector multiplication as an output parameter.</param>
    public static void Multiply(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
    {
      result.X = value1.X * value2.X;
      result.Y = value1.Y * value2.Y;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a multiplication of <see cref="T:Microsoft.Xna.Framework.Vector2" /> and a scalar.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="scaleFactor">Scalar value.</param>
    /// <returns>The result of the vector multiplication with a scalar.</returns>
    public static Vector2 Multiply(Vector2 value1, float scaleFactor)
    {
      value1.X *= scaleFactor;
      value1.Y *= scaleFactor;
      return value1;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a multiplication of <see cref="T:Microsoft.Xna.Framework.Vector2" /> and a scalar.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="scaleFactor">Scalar value.</param>
    /// <param name="result">The result of the multiplication with a scalar as an output parameter.</param>
    public static void Multiply(ref Vector2 value1, float scaleFactor, out Vector2 result)
    {
      result.X = value1.X * scaleFactor;
      result.Y = value1.Y * scaleFactor;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains the specified vector inversion.
    /// </summary>
    /// <param name="value">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <returns>The result of the vector inversion.</returns>
    public static Vector2 Negate(Vector2 value)
    {
      value.X = -value.X;
      value.Y = -value.Y;
      return value;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains the specified vector inversion.
    /// </summary>
    /// <param name="value">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="result">The result of the vector inversion as an output parameter.</param>
    public static void Negate(ref Vector2 value, out Vector2 result)
    {
      result.X = -value.X;
      result.Y = -value.Y;
    }

    /// <summary>
    /// Turns this <see cref="T:Microsoft.Xna.Framework.Vector2" /> to a unit vector with the same direction.
    /// </summary>
    public void Normalize()
    {
      float num = 1f / (float)Math.Sqrt(X * (double)X + Y * (double)Y);
      X *= num;
      Y *= num;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a normalized values from another vector.
    /// </summary>
    /// <param name="value">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <returns>Unit vector.</returns>
    public static Vector2 Normalize(Vector2 value)
    {
      float num = 1f / (float)Math.Sqrt(value.X * (double)value.X + value.Y * (double)value.Y);
      value.X *= num;
      value.Y *= num;
      return value;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains a normalized values from another vector.
    /// </summary>
    /// <param name="value">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="result">Unit vector as an output parameter.</param>
    public static void Normalize(ref Vector2 value, out Vector2 result)
    {
      float num = 1f / (float)Math.Sqrt(value.X * (double)value.X + value.Y * (double)value.Y);
      result.X = value.X * num;
      result.Y = value.Y * num;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains reflect vector of the given vector and normal.
    /// </summary>
    /// <param name="vector">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="normal">Reflection normal.</param>
    /// <returns>Reflected vector.</returns>
    public static Vector2 Reflect(Vector2 vector, Vector2 normal)
    {
      float num = (float)(2.0 * (vector.X * (double)normal.X + vector.Y * (double)normal.Y));
      Vector2 vector2;
      vector2.X = vector.X - normal.X * num;
      vector2.Y = vector.Y - normal.Y * num;
      return vector2;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains reflect vector of the given vector and normal.
    /// </summary>
    /// <param name="vector">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="normal">Reflection normal.</param>
    /// <param name="result">Reflected vector as an output parameter.</param>
    public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
    {
      float num = (float)(2.0 * (vector.X * (double)normal.X + vector.Y * (double)normal.Y));
      result.X = vector.X - normal.X * num;
      result.Y = vector.Y - normal.Y * num;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains subtraction of on <see cref="T:Microsoft.Xna.Framework.Vector2" /> from a another.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="value2">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <returns>The result of the vector subtraction.</returns>
    public static Vector2 Subtract(Vector2 value1, Vector2 value2)
    {
      value1.X -= value2.X;
      value1.Y -= value2.Y;
      return value1;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Xna.Framework.Vector2" /> that contains subtraction of on <see cref="T:Microsoft.Xna.Framework.Vector2" /> from a another.
    /// </summary>
    /// <param name="value1">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="value2">Source <see cref="T:Microsoft.Xna.Framework.Vector2" />.</param>
    /// <param name="result">The result of the vector subtraction as an output parameter.</param>
    public static void Subtract(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
    {
      result.X = value1.X - value2.X;
      result.Y = value1.Y - value2.Y;
    }

    /// <summary>
    /// Returns a <see cref="T:System.String" /> representation of this <see cref="T:Microsoft.Xna.Framework.Vector2" /> in the format:
    /// {X:[<see cref="F:Microsoft.Xna.Framework.Vector2.X" />] Y:[<see cref="F:Microsoft.Xna.Framework.Vector2.Y" />]}
    /// </summary>
    /// <returns>A <see cref="T:System.String" /> representation of this <see cref="T:Microsoft.Xna.Framework.Vector2" />.</returns>
    public override string ToString() => "{X:" + X + " Y:" + Y + "}";

    /// <summary>
    /// Deconstruction method for <see cref="T:Microsoft.Xna.Framework.Vector2" />.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void Deconstruct(out float x, out float y)
    {
      x = X;
      y = Y;
    }
  }
}
