using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                bool isWorking = true;
                string userInput;
                const string CommandAddDossier = "add";
                const string CommandOutputAllDossiers = "out";
                const string CommandExit = "exit";

                while (isWorking)
                {
                    Console.Write("\nВведите команду: ");
                    userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case CommandAddDossier:
                            Database.AddPlayer();
                            break;
                        case CommandOutputAllDossiers:
                            Database.ShowItems();
                            break;
                        case CommandExit:
                            isWorking = false;
                            break;
                    }
                }
            }
        }

        class Database
        {
            private static List<Player> DataPlayers = new();

            public static void AddPlayer()
            {
                Console.WriteLine("Введите стринг: ");
                DataPlayers.Add(new Player(nickName: Console.ReadLine()));                         
            }

            public static void ShowItems()
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

            

            public Player(int individualNumber = 1, int playerLevel = 1, string nickName = null)
            {
                UniqueNumber = individualNumber;
                PlayerLevel = playerLevel;
                NickName = nickName;
            }
        }
    }
}
