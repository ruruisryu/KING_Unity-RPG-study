using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }

    class Player : Creature
    {
        protected PlayerType type = PlayerType.None;

        protected Player(PlayerType type) : base(CreaterType.Player)
        {
            this.type = type;
        }

        public PlayerType GetPlayerType()
        {
            return type;
        }
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo("Knight", 100, 10);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo("Archer", 75, 12);
        }

    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo("Mage", 50, 15);
        }

    }
}
