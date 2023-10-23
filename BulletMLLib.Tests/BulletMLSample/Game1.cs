//using FontBuddyLib;
using System.Collections.Generic;
using BulletMLLib.SharedProject;
using Godot;

namespace BulletMLSample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    internal class Game1
    {
        private static MyShip myship;
        private Mover mover;

        private MoverManager _moverManager;

        //GameClock _clock;

        //InputState _inputState;
        //InputWrapper _inputWrapper;

        private float _Rank = 0.0f;

        //private FontBuddy _text = new FontBuddy();

        /// <summary>
        /// A list of all the bulletml samples we have loaded
        /// </summary>
        private List<BulletPattern> _myPatterns = new();

        /// <summary>
        /// The names of all the bulletml patterns that are loaded, stored so we can display what is being fired
        /// </summary>
        private List<string> _patternNames = new();

        /// <summary>
        /// The current Bullet ML pattern to use to shoot bullets
        /// </summary>
        private int _CurrentPattern = 0;

        public Game1()
        {
            myship = new();

            _moverManager = new(myship.Position);

            _moverManager.Difficulty = _Rank;
        }

        protected void Initialize()
        {
            myship.Init();
        }
    }
}
