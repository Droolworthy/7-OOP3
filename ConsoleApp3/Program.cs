using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.AddPlayer();

            Database.ShowInfo();
        }

        class Database
        {
            private static List<Player> DataPlayers = new();

            public static void AddPlayer()
            {
                Console.WriteLine("Номер добавлен.");
                Console.WriteLine("Уровень добавлен.");
                Console.Write("Введите никнейм: ");
                DataPlayers.Add(new Player(nickName: Console.ReadLine()));
            }

            public static void ShowInfo()
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

            public static int IdentificationsLevel;

            public static int IdentificationsNumber;

            public Player(string nickName)
            {
                UniqueNumber = ++IdentificationsNumber;
                PlayerLevel = ++IdentificationsLevel;
                NickName = nickName;
            }
        }
    }
}
