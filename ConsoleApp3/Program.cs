using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string enterNumber = "Уникальный номер: ";
            string enterLevel = "\nУровень: ";
            string enterNickName = "\nНикнейм: ";

            Console.Write(enterNumber);
            int individualNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write(enterNickName);
            string moniker = Console.ReadLine();           
            Console.Write(enterLevel);
            int gamerLevel = Convert.ToInt32(Console.ReadLine());

            Database database = new(enterNumber, individualNumber, enterNickName, moniker, enterLevel, gamerLevel);

            database.ShowItems();
        }
    }

    class Database
    {
        private List<Player> DataPlayers = new();

        public Database(string enterNumber, int individualNumber, string enterNickName, string moniker, string enterLevel, int gamerLevel)
        {
           DataPlayers.Add(new Player(enterNumber, Convert.ToInt32(Console.ReadLine()), enterNickName, moniker, enterLevel, gamerLevel)); 
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
        public string EnterNumber;

        public string EnterLevel;

        public string EnterNickName;

        public int PlayerLevel { get; private set; }

        public string NickName { get; private set; }

        public int UniqueNumber { get; private set; }

        public Player(string enterNumber, int individualNumber, string enterNickName, string moniker, string enterLevel, int gamerLevel)
        {
            EnterNumber = enterNumber;
            EnterNickName = enterNickName;
            EnterLevel = enterLevel;
            EnterNumber = enterNumber;
            UniqueNumber = individualNumber;
            PlayerLevel = gamerLevel;
            NickName = moniker;            
        }
    }
}
