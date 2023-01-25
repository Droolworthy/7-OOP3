using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            string userInput;
            const string CommandAddPlayer = "add";
            const string CommandOutputAllPlayers = "output";
            const string CommandDeletePlayer = "delete";
            const string CommandExit = "exit";

            Database.ShowMenu();

            while (isWorking)
            {
                Console.Write("\nВведите команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddPlayer:
                        Database.AddPlayer();
                        break;
                    case CommandOutputAllPlayers:
                        Database.ShowItems();
                        break;
                    case CommandDeletePlayer:
                        Database.DeleteUniqueNumber();
                        break;
                    case CommandExit:
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine($"\nВведите {CommandAddPlayer}, {CommandOutputAllPlayers}, {CommandDeletePlayer} или {CommandExit}");
                        break;
                }
            }
        }
    }

    class Database
    {
        private static List<Player> DataPlayers = new();

        public static void ShowMenu()
        {
            const string CommandAddPlayer = "add";
            const string CommandOutputAllPlayers = "output";
            const string CommandDeletePlayer = "delete";
            const string CommandExit = "exit";

            Console.WriteLine("==========M--------Е---------Н--------Ю============");
            Console.WriteLine($"|||||||||||-----{CommandAddPlayer} - ДОБАВИТЬ ДОСЬЕ---||||||||||||");
            Console.WriteLine($"|||||||||||-{CommandOutputAllPlayers} - ВЫВЕСТИ ВСЁ ДОСЬЕ-||||||||||||");
            Console.WriteLine($"|||||||||||--- {CommandDeletePlayer} - УДАЛИТЬ ДОСЬЕ--||||||||||||");
            Console.WriteLine($"|||||||||||________{CommandExit} - ВЫХОД________||||||||||||");
        }

        public static void AddPlayer()
        {
            Console.WriteLine("\nНомер добавлен.");
            Console.WriteLine("Уровень добавлен.");
            Console.WriteLine("Уровень доступа добавлен.");
            Console.Write("Введите никнейм: ");
            DataPlayers.Add(new Player(nickName:Console.ReadLine()));
        }

        public static void DeleteUniqueNumber()
        {
            Console.Write("\nВведите номер игрока для удаления: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int playerNumber);

            if (isSuccess)
            {
                if (playerNumber < DataPlayers.Count && playerNumber >= 0)
                {
                    DataPlayers.RemoveAt(playerNumber);
                    Console.WriteLine("Игрок удалён!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Попробуйте ещё раз");
            }
        }

        public static void ShowItems()
        {
            for (int i = 0; i < DataPlayers.Count; i++)
            {
                Console.Write("\nНомер в списке: " + i + " " + "\nУникальный номер: " + DataPlayers[i].UniqueNumber + "\nУровень: " + DataPlayers[i].PlayerLevel
                  + "\nНикнейм: " + DataPlayers[i].NickName);

                if (DataPlayers[i].IsBanned)
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
            IsBanned = true;
            NickName = nickName;
        }

        private static int Identifications;

        public int UniqueNumber { get; private set; }

        public int PlayerLevel { get; private set; }

        public string NickName { get; private set; }

        public bool IsBanned { get; private set; }
    }
}
