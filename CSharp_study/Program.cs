using System;

namespace TextRPG2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.SetGameMode(GameMode.Lobby);

            while (true)
            {
                game.Process();
            }    
        }
    }
}
