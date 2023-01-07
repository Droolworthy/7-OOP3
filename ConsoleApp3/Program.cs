using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string enterNumber = "Уникальный номер: ";
            string enterLevel = "Введите уровень: ";
            string enterNickName = "Введите никнейм: ";

            Console.Write(enterNumber);
            int individualNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write(enterNickName);
            string moniker = Console.ReadLine();
            Console.Write(enterLevel);
            int gamerLevel = Convert.ToInt32(Console.ReadLine());

            Database database = new(individualNumber, moniker, gamerLevel);

            database.ShowItems();
        }
    }

    class Database
    {
        private List<Player> DataPlayers = new();

        public Database(int individualNumber, string moniker, int gamerLevel)
        {
           DataPlayers.Add(new Player(individualNumber, moniker, gamerLevel)); 
        }

        public void ShowItems()
        {
            for (int i = 0; i < DataPlayers.Count; i++)
            {
                Console.Write("\nУникальный номер: " + DataPlayers[i].UniqueNumber + "\nУровень: " + DataPlayers[i].PlayerLevel
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
            NickName = moniker;
            PlayerLevel = gamerLevel;                    
        }
    }
}
