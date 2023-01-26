using System;
using System.Collections.Generic;

namespace OOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            string userInput;
            const string CommandAddUser = "add";
            const string CommandOutputAllUsers = "output";
            const string CommandDeleteUser = "delete";
            const string CommandBlockUser = "ban";
            const string CommandUnlockUser = "unlock";
            const string CommandExit = "exit";

            Database.ShowMenu();

            while (isWorking)
            {
                Console.Write("\nВведите команду: ");
                userInput = Console.ReadLine();

                Console.Clear();
                Database.ShowMenu();

                switch (userInput)
                {
                    case CommandAddUser:
                        Database.AddUser();
                        break;
                    case CommandOutputAllUsers:
                        Database.ShowItems();
                        break;
                    case CommandDeleteUser:
                        Database.DeleteUser();
                        break;
                    case CommandBlockUser:
                        Database.BlockUser();
                        break;
                    case CommandUnlockUser:
                        Database.UnlockUser();
                        break;
                    case CommandExit:
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine($"\nВведите {CommandAddUser}, {CommandOutputAllUsers}, {CommandDeleteUser}, " +
                            $"{CommandBlockUser}, {CommandUnlockUser} или {CommandExit}");
                        break;
                }
            }
        }
    }

    class Database
    {
        private static List<Player> DataPlayers = new();

        public static void AddUser()
        {
            Console.WriteLine("\nНомер добавлен.");
            Console.WriteLine("Уровень добавлен.");
            Console.WriteLine("Уровень доступа добавлен.");
            Console.Write("Введите никнейм: ");
            DataPlayers.Add(new Player(nickName:Console.ReadLine()));
        }

        public static void DeleteUser()
        {
            Console.Write("\nВведите номер в списке для удаления пользователя: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int userNumber);

            if (isSuccess)
            {
                if (userNumber < DataPlayers.Count && userNumber >= 0)
                {
                    DataPlayers.RemoveAt(userNumber);
                    Console.WriteLine("Игрок удалён.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Попробуйте ещё раз.");
            }
        }

        public static void BlockUser()
        {
            Console.Write("Введите номер в списке для блокировки пользователя: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int userNumber);

            if (isSuccess)
            {
                if (userNumber >= 0 && userNumber < DataPlayers.Count)
                {
                    DataPlayers[userNumber].BanUser();
                    Console.WriteLine("Игрок заблокирован.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Попробуйте ещё раз.");
            }
        }

        public static void UnlockUser()
        {
            Console.Write("Введите номер в списке для разблокировки пользователя: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int userNumber);

            if (isSuccess)
            {
                if (userNumber >= 0 && userNumber < DataPlayers.Count)
                {
                    DataPlayers[userNumber].UnbanUser();
                    Console.WriteLine("Игрок разблокирован.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Попробуйте ещё раз.");
            }
        }

        public static void ShowItems()
        {
            for (int i = 0; i < DataPlayers.Count; i++)
            {
                Console.Write("\nНомер в списке - " + i + " " + "\nУникальный номер - " + DataPlayers[i].UniqueNumber + "\nУровень - " + DataPlayers[i].PlayerLevel
                  + "\nНикнейм: " + DataPlayers[i].NickName);

                if (DataPlayers[i].IsBanned)
                {
                    Console.WriteLine("\nИгрок свободен.");
                }
                else
                {
                    Console.WriteLine("\nИгрок заблокирован.");
                }
            }
        }

        public static void ShowMenu()
        {
            const string CommandAddUser = "add";
            const string CommandOutputAllUsers = "output";
            const string CommandDeleteUser = "delete";
            const string CommandBlockUser = "ban";
            const string CommandUnlockUser = "unlock";
            const string CommandExit = "exit";

            Console.WriteLine("=============M--------Е---------Н--------Ю==========");
            Console.WriteLine($"||||||||||------{CommandAddUser} - ДОБАВИТЬ ИГРОКА------|||||||||");
            Console.WriteLine($"||||||||||--{CommandOutputAllUsers} - ВЫВЕСТИ ВСЁХ ИГРОКОВ--|||||||||");
            Console.WriteLine($"||||||||||--{CommandBlockUser} - ЗАБЛОКИРОВАТЬ ИГРОКА-----|||||||||");
            Console.WriteLine($"||||||||||--{CommandUnlockUser} - РАЗБЛОКИРОВАТЬ ИГРОКА-|||||||||");
            Console.WriteLine($"||||||||||---- {CommandDeleteUser} - УДАЛИТЬ ИГРОКА-----|||||||||");
            Console.WriteLine($"||||||||||_________{CommandExit}  -  ВЫХОД__________|||||||||");
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

        public void BanUser() 
        {
            IsBanned = false;
        }

        public void UnbanUser()
        {
            IsBanned = true;
        }
    }
}
