//Реализовать базу данных игроков и методы для работы с ней.
//У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли он(флаг - bool)..
//Реализовать возможность добавления игрока, бана игрока по уникальный номеру, разбана игрока по уникальный номеру и удаление игрока.
//Создание самой БД не требуется, задание выполняется инструментами, которые вы уже изучили в рамках курса.
//Но нужен класс, который содержит игроков и её можно назвать "База данных".
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

            ShowMenu();

            while (isWorking)
            {
                Console.Write("\nВведите команду: ");
                userInput = Console.ReadLine();

                Console.Clear();
                ShowMenu();

                switch (userInput)
                {
                    case CommandAddUser:
                        database.AddUser();
                        break;

                    case CommandOutputAllUsers:
                        database.ShowInfoUsers();
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

            static void ShowMenu()
            {
                Console.WriteLine("=============M--------Е---------Н--------Ю==========");
                Console.WriteLine($"||||||||||------{CommandAddUser} - ДОБАВИТЬ ИГРОКА------|||||||||");
                Console.WriteLine($"||||||||||--{CommandOutputAllUsers} - ВЫВЕСТИ ВСЁХ ИГРОКОВ--|||||||||");
                Console.WriteLine($"||||||||||--{CommandBlockUser} - ЗАБЛОКИРОВАТЬ ИГРОКА-----|||||||||");
                Console.WriteLine($"||||||||||--{CommandUnlockUser} - РАЗБЛОКИРОВАТЬ ИГРОКА-|||||||||");
                Console.WriteLine($"||||||||||---- {CommandDeleteUser} - УДАЛИТЬ ИГРОКА-----|||||||||");
                Console.WriteLine($"||||||||||_________{CommandExit}  -  ВЫХОД__________|||||||||");
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
            TryGetPlayer("\nВведите номер для удаления пользователя: ", "Игрок удалён.", out Player player);
            _dataPlayers.Remove(player);
        }

        public void BlockUser()
        {
            TryGetPlayer("Введите номер для блокировки пользователя: ", "Игрок заблокирован.", out Player player);
            player.BanUser();
        }

        public void UnlockUser()
        {
            TryGetPlayer("Введите номер для разблокировки пользователя: ", "Игрок разблокирован.", out Player player);
            player.UnbanUser();
        }

        public void ShowInfoUsers()
        {
            for (int i = 0; i < _dataPlayers.Count; i++)
            {
                Console.Write("\nУникальный номер - " + _dataPlayers[i].UniqueNumber + "\nУровень - " + _dataPlayers[i].PlayerLevel
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

        private bool TryGetPlayer(string inputDescription, string DescriptionSuccessInput, out Player player)
        {
            player = null;

            Console.Write(inputDescription);
            string userInput = Console.ReadLine();

            bool isSuccess = int.TryParse(userInput, out int userNumber);

            if (isSuccess)
            {
                for (int i = 0; i < _dataPlayers.Count; i++)
                {
                    if (userNumber == _dataPlayers[i].UniqueNumber)
                    {
                        player = _dataPlayers[i];
                        Console.WriteLine(DescriptionSuccessInput);
                        return true;
                    }
                }
            }

            return false;
        }
    }

    class Player
    {
        private static int _identifications;

        public Player(string nickName)
        {
            UniqueNumber = ++_identifications;
            PlayerLevel = _identifications;
            IsBanned = true;
            NickName = nickName;
        }

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
