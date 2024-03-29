﻿using Equationator;
using System.Collections.Generic;
using System.Diagnostics;
using BulletMLLib.SharedProject;
using Godot;

namespace BulletMLSample;

public class MoverManager : IBulletManager
{
    #region Properties

    public readonly List<Mover> movers = new();

    private readonly List<Mover> topLevelMovers = new();

    private readonly PositionDelegate GetPlayerPosition;

    private float _timeSpeed = 1.0f;
    private float _scale = 1.0f;

    /// <summary>
    /// How fast time moves in this game.
    /// Can be used to do slowdown, speedup, etc.
    /// </summary>
    /// <value>The time speed.</value>
    public float TimeSpeed
    {
        get => _timeSpeed;
        set
        {
            //set my time speed
            _timeSpeed = value;

            //set all the bullet time speeds
            foreach (Mover myDude in movers)
            {
                myDude.TimeSpeed = _timeSpeed;
            }
        }
    }

    /// <summary>
    /// Change the size of this bulletml script
    /// If you want to reuse a script for a game but the size is wrong, this can be used to resize it
    /// </summary>
    /// <value>The scale.</value>
    public float Scale
    {
        get => _scale;
        set
        {
            //set my scale
            _scale = value;

            //set all the bullet scales
            foreach (Mover myDude in movers)
            {
                myDude.Scale = _scale;
            }
        }
    }

    public double Difficulty { get; set; }

    public Dictionary<string, FunctionDelegate> CallbackFunctions { get; set; } = new();

    public FunctionDelegate GameDifficulty => () => Difficulty;

    #endregion //Properties

    public MoverManager(PositionDelegate playerDelegate)
    {
        Debug.Assert(null != playerDelegate);
        GetPlayerPosition = playerDelegate;
    }

    /// <summary>
    /// a method to get current position of the player
    /// This is used to target bullets at that position
    /// </summary>
    /// <returns>The position to aim the bullet at</returns>
    /// <param name="targettedBullet">the bullet we are getting a target for</param>
    public Vector2 PlayerPosition(IBullet targettedBullet)
    {
        //just give the player's position
        Debug.Assert(null != GetPlayerPosition);
        return GetPlayerPosition();
    }

    public IBullet CreateBullet()
    {
        //create the new bullet
        Mover mover = new(this);

        //set the speed and scale of the bullet
        mover.TimeSpeed = TimeSpeed;
        mover.Scale = Scale;

        //initialize, store in our list, and return the bullet
        mover.Init();
        movers.Add(mover);
        return mover;
    }

    /// <summary>
    /// Create a new bullet that will be initialized from a top level node.
    /// These are usually special bullets that dont need to be drawn or kept around after they finish tasks etc.
    /// </summary>
    /// <returns>A shiny new top-level bullet</returns>
    public IBullet CreateTopBullet()
    {
        //create the new bullet
        Mover mover = new(this);

        //set the speed and scale of the bullet
        mover.TimeSpeed = TimeSpeed;
        mover.Scale = Scale;

        //initialize, store in our list, and return the bullet
        mover.Init();
        topLevelMovers.Add(mover);
        return mover;
    }

    public void RemoveBullet(IBullet deadBullet)
    {
        if (deadBullet is Mover myMover)
        {
            myMover.Used = false;
        }
    }

    public void Update()
    {
        for (int i = 0; i < movers.Count; i++)
        {
            movers[i].Update();
        }

        for (int i = 0; i < topLevelMovers.Count; i++)
        {
            topLevelMovers[i].Update();
        }

        FreeMovers();
    }

    public void FreeMovers()
    {
        for (int i = 0; i < movers.Count; i++)
        {
            if (movers[i].Used)
                continue;

            movers.Remove(movers[i]);
            i--;
        }

        //clear out top level bullets
        for (int i = 0; i < topLevelMovers.Count; i++)
        {
            if (!topLevelMovers[i].TasksFinished())
                continue;

            topLevelMovers.RemoveAt(i);
            i--;
        }
    }

    public void Clear()
    {
        movers.Clear();
        topLevelMovers.Clear();
    }

    public double Tier()
    {
        return 0.0;
    }
}