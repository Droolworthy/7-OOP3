using System;
using System.Collections.Generic;

namespace OOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddUser = "add";
            const string CommandOutputAllUsers = "output";
            const string CommandDeleteUser = "delete";
            const string CommandBlockUser = "ban";
            const string CommandUnlockUser = "unlock";
            const string CommandExit = "exit";

            Database database = new Database();
            bool isWorking = true;
            string userInput;

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
                        database.AddUser();
                        break;

                    case CommandOutputAllUsers:
                        database.ShowItems();
                        break;

                    case CommandDeleteUser:
                        database.DeleteUser();
                        break;

                    case CommandBlockUser:
                        database.BlockUser();
                        break;

                    case CommandUnlockUser:
                        database.UnlockUser();
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
        private List<Player> _dataPlayers = new();

        public void AddUser()
        {
            Console.WriteLine("\nНомер добавлен.");
            Console.WriteLine("Уровень добавлен.");
            Console.WriteLine("Уровень доступа добавлен.");
            Console.Write("Введите никнейм: ");
            _dataPlayers.Add(new Player(nickName: Console.ReadLine()));
        }

        public void DeleteUser()
        {
            Console.Write("\nВведите номер в списке для удаления пользователя: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int userNumber);

            if (isSuccess)
            {
                if (userNumber < _dataPlayers.Count && userNumber >= 0)
                {
                    _dataPlayers.RemoveAt(userNumber);
                    Console.WriteLine("Игрок удалён.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Попробуйте ещё раз.");
            }
        }

        public void BlockUser()
        {
            Console.Write("Введите номер в списке для блокировки пользователя: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int userNumber);

            if (isSuccess)
            {
                if (userNumber < _dataPlayers.Count)
                {
                    _dataPlayers[userNumber].BanUser();
                    Console.WriteLine("Игрок заблокирован.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Попробуйте ещё раз.");
            }
        }

        public void UnlockUser()
        {
            Console.Write("Введите номер в списке для разблокировки пользователя: ");
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int userNumber);

            if (isSuccess)
            {
                if (userNumber >= 0 && userNumber < _dataPlayers.Count)
                {
                    _dataPlayers[userNumber].UnbanUser();
                    Console.WriteLine("Игрок разблокирован.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Попробуйте ещё раз.");
            }
        }

        public void ShowItems()
        {
            for (int i = 0; i < _dataPlayers.Count; i++)
            {
                Console.Write("\nНомер в списке - " + i + " " + "\nУникальный номер - " + _dataPlayers[i].UniqueNumber + "\nУровень - " + _dataPlayers[i].PlayerLevel
                  + "\nНикнейм: " + _dataPlayers[i].NickName);

                if (_dataPlayers[i].IsBanned)
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
