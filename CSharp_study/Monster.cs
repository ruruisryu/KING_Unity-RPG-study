using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Orc = 2,
        Skeleton = 3
    }

    class Monster : Creature
    {
        protected MonsterType type = MonsterType.None;

        protected Monster(MonsterType type) :base(CreaterType.Monster)
        {
            this.type = type;
        }

        public MonsterType GetMonsterType()
        {
            return type;
        }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            SetInfo("Slime", 15, 2);
        }
    }

    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc)
        {
            SetInfo("Orc", 30, 5);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Skeleton)
        {
            SetInfo("Skeleton", 20, 7);
        }
    }
}
