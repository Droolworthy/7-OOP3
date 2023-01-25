using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.AddPlayer();

            Database.ShowItems();
        }

        class Database
        {
            private static List<Player> DataPlayers = new();

            public static void AddPlayer()
            {
                Console.WriteLine("Номер добавлен.");
                Console.WriteLine("Уровень добавлен.");
                Console.WriteLine("Флаг добавлен.");
                Console.Write("Введите никнейм: ");
                DataPlayers.Add(new Player(nickName: Console.ReadLine()));
            }

            public static void ShowItems()
            {
                for (int i = 0; i < DataPlayers.Count; i++)
                {
                    Console.Write("\nУникальный номер: " + DataPlayers[i].UniqueNumber + "\nУровень: " + DataPlayers[i].PlayerLevel
                      + "\nНикнейм: " + DataPlayers[i].NickName);

                    if (DataPlayers[i].Flag)
                    {
                        Console.WriteLine("\nИгрок не забанен");
                    }
                    else
                    {
                        Console.WriteLine("Игрок забанен");
                    }
                }
            }
        }

        class Player
        {
            public Player(string nickName)
            {
                UniqueNumber = ++Identifications;
                PlayerLevel = Identifications;
                NickName = nickName;
                Flag = true;  
            }

            private static int Identifications;

            public int UniqueNumber { get; private set; }

            public int PlayerLevel { get; private set; }

            public string NickName { get; private set; }

            public bool Flag { get; private set; }
        }
    }
}
