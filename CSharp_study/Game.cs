using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    public enum GameMode
    {
        None = 0,
        Lobby = 1,
        Town = 2,
        Field = 3
    }

    class Game
    {
        private GameMode mode = GameMode.None;
        private Player player = null;
        private Monster monster = null;
        Random rand = new Random();

        public void SetGameMode(GameMode mode)
        {
            this.mode = mode;
        }

        public void Process()
        {
            switch(mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택해주세요.");
            Console.WriteLine("[1]. 전사");
            Console.WriteLine("[2]. 궁수");
            Console.WriteLine("[3]. 법사");

            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
            }

            Console.WriteLine($"{player.GetName()}를 선택하셨습니다.");
        }

        private void ProcessTown()
        {
            Console.WriteLine("[[마을]]");
            Console.WriteLine("[1]. 필드로 가기.");
            Console.WriteLine("[2]. 로비로 돌아가기");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("[[필드]]");
            Console.WriteLine("[1]. 몬스터와 싸우기");
            Console.WriteLine("[2]. 일정 확률로 마을로 돌아가기");

            CreateRandMonster();

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    break;
            }
        }

        private void CreateRandMonster()
        {
            int value = rand.Next(0, 3);

            switch (value)
            {
                case 0:
                    monster = new Slime();
                    break;
                case 1:
                    monster = new Orc();
                    break;
                case 2:
                    monster = new Skeleton();
                    break;
            }

            Console.WriteLine($"{monster.GetName()}가 나타났습니다!");
        }

        private void ProcessFight()
        {
            while(true)
            {
                int damage = player.GetAttack();
                monster.Ondamaged(damage);
                if (monster.IsDead())
                {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은체력: {player.GetHp()}");
                    break;
                }

                damage = monster.GetAttack();
                player.Ondamaged(damage);
                if (player.IsDead())
                {
                    Console.WriteLine("패배했습니다..");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }

        private void TryEscape()
        {
            int randValue = rand.Next(0, 100);
            if (randValue < 33)
            {
                Console.WriteLine("도망쳤습니다!");
                mode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("도망칠 수 없습니다!");
                ProcessFight();
            }
        }
    }
}
