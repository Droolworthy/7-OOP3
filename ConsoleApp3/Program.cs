using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Database
    {
        static void Main(string[] args)
        {
            Player players = new Player();

            players.ShowItems();
        }

    }
    class Player
    {
        public Player()
        {
            Console.Write("Введите номер: ");
            Data.Add(new Data(UniqueNumber = Convert.ToInt32(Console.ReadLine())));
            Console.Write("Введите уровень: ");
            Data.Add(new Data(PlayerLevel = Convert.ToInt32(Console.ReadLine())));
            Console.Write("Введите никнейм: ");
            Data.Add(new Data(NickName = Console.ReadLine()));
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

    class Data
    {
        public int PlayerLevel { get; private set; }

        public string NickName { get; private set; }

        public int UniqueNumber { get; private set; }

        public Data(int playerLevel)
        {
            PlayerLevel = playerLevel;
        }

        public Data(string nickName)
        {
            NickName = nickName;
        }
    }
}
