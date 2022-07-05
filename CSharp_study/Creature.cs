using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    public enum CreaterType
    {
        None = 0,
        Player = 1,
        Monster =2
    }

    class Creature
    {
        protected CreaterType type = CreaterType.None;
        protected int hp;
        protected int attack;
        protected string name;

        protected Creature(CreaterType type)
        {
            this.type = type;
        }

        public void SetInfo(string name, int hp, int attack)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }

        public int GetHp() { return hp; }
        public int GetAttack() { return attack; }
        public string GetName() { return name; }

        public bool IsDead() { return hp <= 0; }
        public void Ondamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }
    }
}
