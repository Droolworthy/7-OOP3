using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new();

            database.ShowItems();
        }
    }

    class Database
    {
        private List<Player> DataPlayers = new();

        public Database()
        {
            DataPlayers.Add(new Player(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Convert.ToInt32(Console.ReadLine())));
        }

        public void ShowItems()
        {
            for (int i = 0; i < DataPlayers.Count; i++)
            {
                Console.Write("Уникальный номер: " + DataPlayers[i].UniqueNumber + "\nУровень: " + DataPlayers[i].PlayerLevel
                 + "\nНикнейм: " + DataPlayers[i].NickName);
            }
        }
    }

    class Player
    {
        public int PlayerLevel { get; private set; }

        public string NickName { get; private set; }

        public int UniqueNumber { get; private set; }
        
        public Player(int individualNumber, string moniker, int gamerLevel) 
        { 
            UniqueNumber = individualNumber;
            PlayerLevel = gamerLevel;
            NickName = moniker;
        }
    }
}
