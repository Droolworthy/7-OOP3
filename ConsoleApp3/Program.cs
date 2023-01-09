using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Database database = new();

                Database.AddPlayer();

                database.ShowItems();                   
            }
        }
        class Database
        {
            private static List<Player> DataPlayers = new();

            public static Player AddPlayer()
            {           
                Console.Write("Введите номер: ");
                int individualNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите уровень: ");
                int gamerLevel = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите никнейм: ");
                string moniker = Console.ReadLine();

                DataPlayers.Add(new Player(individualNumber, gamerLevel, moniker));

                return new Player(individualNumber, gamerLevel, moniker);               
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

            public Player(int individualNumber, int gamerLevel, string moniker)
            {
                UniqueNumber = individualNumber;
                PlayerLevel = gamerLevel;
                NickName = moniker;
            }
        }
    }
}
