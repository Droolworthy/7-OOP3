using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Database
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            player.ShowItems();
        }
    }

    class Player
    {
        private List<Player> Data = new();

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

        public Player()
        {
            Console.Write("Введите номер: ");
            Data.Add(new Player(UniqueNumber = Convert.ToInt32(Console.ReadLine())));
            Console.Write("Введите уровень: ");
            Data.Add(new Player(PlayerLevel = Convert.ToInt32(Console.ReadLine())));
            Console.Write("Введите никнейм: ");
            Data.Add(new Player(NickName = Console.ReadLine()));
        }

        public void ShowItems()
        {
            for (int i = 1; i < Data.Count; i++)
            {
                Console.Write("Уникальный номер: " + Data[i].UniqueNumber + "Уровень: " + Data[i].PlayerLevel
                + "Никнейм: " + Data[i].NickName);
            }
        }
    }
}
