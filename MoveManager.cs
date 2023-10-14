using System.Collections.Generic;
using System.Diagnostics;
using BulletMLLib.SharedProject;
using Godot;

namespace bulletmltemplate
{
    /// <summary>
    /// MoveManager - represents a bullet manager, i.e. something generating bullets such as an enemy character.
    /// </summary>
    public class MoveManager : IBulletManager
    {
        private const float timeSpeed = 1.0f;
        private const float scale = 1.0f;

        private readonly List<Mover> movers = new();
        private readonly List<Mover> topLevelMovers = new();

        private readonly PositionDelegate GetPlayerPosition;

        public MoveManager(PositionDelegate playerPosition)
        {
            Debug.Assert(playerPosition != null);
            GetPlayerPosition = playerPosition;
        }

        public void Update(float delta)
        {
            for (var i = 0; i < movers.Count; i++)
            {
                movers[i].Update();
            }

            for (var i = 0; i < topLevelMovers.Count; i++)
            {
                topLevelMovers[i].Update();
            }

            FreeMovers();
        }

        private void FreeMovers()
        {
            for (var i = 0; i < movers.Count; i++)
            {
                if (movers[i].Used)
                    continue;
                movers.RemoveAt(i);
                i--;
            }

            //clear out top level bullets
            for (var i = 0; i < topLevelMovers.Count; i++)
            {
                if (!topLevelMovers[i].TasksFinished())
                    continue;
                topLevelMovers.RemoveAt(i);
                i--;
            }
        }

        public Vector2 PlayerPosition(IBullet targettedBullet)
        {
            //just give the player's position
            Debug.Assert(null != GetPlayerPosition);
            return GetPlayerPosition();
        }

        public void RemoveBullet(IBullet deadBullet)
        {
            if (deadBullet is Mover myMover)
            {
                myMover.Used = false;
            }
        }

        public IBullet CreateBullet()
        {
            var mover = new Mover(this) { TimeSpeed = timeSpeed, Scale = scale };

            //initialize, store in our list, and return the bullet
            mover.Init();
            movers.Add(mover);
            return mover;
        }

        public IBullet CreateTopBullet()
        {
            var mover = new Mover(this) { TimeSpeed = timeSpeed, Scale = scale };

            //initialize, store in our list, and return the bullet
            mover.Init();
            topLevelMovers.Add(mover);
            return mover;
        }

        public double Tier()
        {
            return 0.0;
        }

        public void Clear()
        {
            movers.Clear();
            topLevelMovers.Clear();
        }

        public void PostUpdate()
        {
            // TODO: use godot game loop
            foreach (var t in movers)
            {
                t.PostUpdate();
            }

            foreach (var t in topLevelMovers)
            {
                t.PostUpdate();
            }
        }
    }
}
