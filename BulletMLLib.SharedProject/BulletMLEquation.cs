using System;
using System.Diagnostics;
using Equationator;

namespace BulletMLLib.SharedProject;

/// <summary>
/// This is an equation used in BulletML nodes.
/// This is an eays way to set up the grammar for all our equations.
/// </summary>
public class BulletMLEquation : Equation
{
    /// <summary>
    /// A randomizer for getting random values
    /// </summary>
    private static readonly Random g_Random = new(DateTime.Now.Millisecond);

    public BulletMLEquation()
    {
        //add the specific functions we will use for bulletml grammar
        AddFunction("rand", RandomValue);
        AddFunction("rank", GameDifficulty);
    }

    /// <summary>
    /// used as a callback function in bulletml euqations
    /// </summary>
    /// <returns>The value.</returns>
    private double RandomValue()
    {
        //this value is "$rand", return a random number
        return g_Random.NextDouble();
    }

    private double GameDifficulty()
    {
        //This number is "$rank" which is the game difficulty.
        Debug.Assert(null != GameManager.GameDifficulty);
        return GameManager.GameDifficulty();
    }
}