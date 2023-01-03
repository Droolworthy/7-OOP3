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
            DataPlayers.Add(new Player("Введите номер: ", Convert.ToInt32(Console.ReadLine()), "Введите уровень: ",
                Console.ReadLine(), "Введите никнейм: ", Convert.ToInt32(Console.ReadLine())));
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
        public string EnterLevel { get; private set; }

        public string EnterNickName { get; private set; }

        public int PlayerLevel { get; private set; }

        public string NickName { get; private set; }        

        public string EnterNumber { get; private set; }

        public int UniqueNumber { get; private set; }

        public Player(string enterNumber, int individualNumber, string enterLevel, string moniker, string enterNickName, int gamerLevel)
        {
            EnterNumber = enterNumber;
            UniqueNumber = individualNumber;
            EnterLevel = enterLevel;
            PlayerLevel = gamerLevel;
            EnterNickName = enterNickName;
            NickName = moniker;
        }
    }
}
