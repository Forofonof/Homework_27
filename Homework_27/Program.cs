using System;

internal class Program
{
    static void Main(string[] args)
    {
        const string createDossier = "1";
        const string outputAllDossiers = "2";
        const string deletingDossier = "3";
        const string searchDossier = "4";
        const string doExit = "5";

        string[] fullName = { };
        string[] position = { };
        bool isDatabaseActive = true;

        Console.WriteLine("База данных к вашим услугам, что желаете сделать?\n");

        while (isDatabaseActive)
        {
            Console.WriteLine($"{createDossier} - Добавить досье.");
            Console.WriteLine($"{outputAllDossiers} - Вывести все досье.");
            Console.WriteLine($"{deletingDossier} - Удалить досье.");
            Console.WriteLine($"{searchDossier} - Поиск сотрудника по Фамилии.");
            Console.WriteLine($"{doExit} - Завершить работу программы.");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case createDossier:
                    CreateDossier(ref fullName, ref position);
                    break;
                case outputAllDossiers:
                    OutputAllDossiers(fullName, position);
                    break;
                case deletingDossier:
                    DeletingDossierByUser(ref fullName, ref position);
                    break;
                case searchDossier:
                    InputSearchDossier(fullName, position);
                    break;
                case doExit:
                    DoExit(ref isDatabaseActive);
                    break;
                default:
                    Console.WriteLine("Ошибка! Неизвестная команда.");
                    break;
            }
        }
    }

    static string[] AddDossier(string[] info, string newInfo)
    {
        string[] tempArray = new string[info.Length + 1];

        for (int i = 0; i < info.Length; i++)
        {
            tempArray[i] = info[i];
        }

        info = tempArray;
        info[info.Length - 1] = newInfo;
        return info;
    }

    static void CreateDossier(ref string[] fullName, ref string[] position)
    {
        Console.Clear();
        Console.WriteLine("Введите Ф.И.О сотрудника: ");

        string newFullName = Console.ReadLine();
        fullName = AddDossier(fullName, newFullName);

        Console.WriteLine("Введите должность сотрудника: ");

        string newPosition = Console.ReadLine();
        position = AddDossier(position, newPosition);

        Console.WriteLine("Успешно! Досье добавлено. Нажмите любую кнопку, чтобы продолжить.");
        Console.ReadKey();
        Console.Clear();
    }

    static void OutputAllDossiers(string[] fullName, string[] position)
    {
        Console.Clear();

        int personNumbers = 0;

        for (int i = 0; i < fullName.Length; i++)
        {
            personNumbers++;
            Console.WriteLine($"№: {personNumbers}. Ф.И.О: {fullName[i]}. Должность: {position[i]}.");
        }

        Console.ReadKey();
        Console.Clear();
    }

    static string[] DeletingDossier(string[] info, int indexNumbers)
    {
        string[] tempArray = new string[info.Length - 1];

        for (int i = 0; i < indexNumbers; i++)
        {
            tempArray[i] = info[i];
        }

        for (int i = indexNumbers; i < tempArray.Length; i++)
        {
            tempArray[i] = info[i + 1];
        }

        info = tempArray;
        return info;
    }

    static void DeletingDossierByUser(ref string[] fullName, ref string[] position)
    {
        Console.Clear();
        Console.WriteLine("Укажите номер досье, которое хотите удалить.");

        int indexNumbers = Convert.ToInt16(Console.ReadLine()) - 1;
        fullName = DeletingDossier(fullName, indexNumbers);
        position = DeletingDossier(position, indexNumbers);

        Console.WriteLine("Успешно! Досье удаленно. Нажмите любую кнопку, чтобы продолжить.");
        Console.ReadKey();
        Console.Clear();
    }

    static void SearchDossier(string[] fullName, string[] position, string searchDossier)
    {
        int indexNumbers = 0;
        bool wasFound = false;

        for (int i = 0; i < fullName.Length; i++)
        {
            string[] tempArray = fullName[i].Split(' ');
            indexNumbers++;

            if (tempArray[i].ToLower() == searchDossier)
            {
                string foundFullName = fullName[i];
                string foundPosition = position[i];

                Console.WriteLine("Доступна следующая информация:");
                Console.WriteLine($"Сотрудник: {foundFullName}. Находится в базе данных под номером: {indexNumbers}. Занимает должность: {foundPosition}.");

                wasFound = true;
            }
        }

        if (wasFound == false)
        {
            Console.WriteLine($"{searchDossier}. Cотрудник отсутствует в базе данных.");
        }
    }

    static void InputSearchDossier(string[] fullName, string[] position)
    {
        Console.Clear();
        Console.WriteLine("Введите Фамилию сотрудника, досье которого хотите найти.");

        string searchDossier = Console.ReadLine();
        SearchDossier(fullName, position, searchDossier);

        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить.");
        Console.ReadKey();
        Console.Clear();
    }

    static void DoExit(ref bool isDatabaseActive)
    {
        Console.Clear();
        Console.WriteLine("Работа программы завершена.");
        Console.ReadKey();

        isDatabaseActive = false;
    }
}