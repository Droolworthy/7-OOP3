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
            Console.Write("Введите номер: ");
            DataPlayers.Add(new Player(Convert.ToInt32(Console.ReadLine())));
            Console.Write("Введите уровень: ");
            DataPlayers.Add(new Player(Convert.ToInt32(Console.ReadLine())));
            Console.Write("Введите никнейм: ");
            DataPlayers.Add(new Player(Console.ReadLine()));
        }

        public void ShowItems()
        {
            //for (int i = 1; i < DataPlayers.Count; i++)
            //{
            //    Console.Write("Уникальный номер: " + DataPlayers[i].UniqueNumber + "Уровень: " + DataPlayers[i].PlayerLevel
            //    + "Никнейм: " + DataPlayers[i].NickName);
            //}

            foreach ( Player player in DataPlayers)
            {
                Console.WriteLine("Уникальный номер: " + player.UniqueNumber + "Уровень: " + player.PlayerLevel + "Никнейм: " + player.NickName);
            }
        }
    }

    class Player
    {
        public int PlayerLevel { get; private set; }

        public string NickName { get; private set; }

        public int UniqueNumber { get; private set; }  

        public Player(int playerLevel)
        {
            PlayerLevel = playerLevel;   
        }

        public Player(string nickName)
        {
            NickName = nickName;
        }
    }
}
