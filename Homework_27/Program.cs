using System;

internal class Program
{
    static void Main(string[] args)
    {
        const string СreateDossier = "1";
        const string AllDossiers = "2";
        const string DeletingDossier = "3";
        const string SearchDossier = "4";
        const string Exit = "5";

        string[] fullNames = { };
        string[] positions = { };
        bool isDatabaseActive = true;

        Console.WriteLine("База данных к вашим услугам, что желаете сделать?\n");

        while (isDatabaseActive)
        {
            Console.WriteLine($"{СreateDossier} - Добавить досье.");
            Console.WriteLine($"{AllDossiers} - Вывести все досье.");
            Console.WriteLine($"{DeletingDossier} - Удалить досье.");
            Console.WriteLine($"{SearchDossier} - Поиск сотрудника по Фамилии.");
            Console.WriteLine($"{Exit} - Завершить работу программы.");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case СreateDossier:
                    CreateDossier(ref fullNames, ref positions);
                    break;
                case AllDossiers:
                    OutputAllDossiers(fullNames, positions);
                    break;
                case DeletingDossier:
                    DeletеDossierByUser(ref fullNames, ref positions);
                    break;
                case SearchDossier:
                    SearchDossierByUser(fullNames, positions);
                    break;
                case Exit:
                    Console.Clear();
                    Console.WriteLine("Работа программы завершена.");

                    isDatabaseActive = false;
                    break;
                default:
                    Console.WriteLine("Ошибка! Неизвестная команда.");
                    break;
            }
        }
    }

    static string[] AddDossier(string[] dossierInfo, string newDossierInfo)
    {
        string[] tempArray = new string[dossierInfo.Length + 1];

        for (int i = 0; i < dossierInfo.Length; i++)
        {
            tempArray[i] = dossierInfo[i];
        }

        dossierInfo = tempArray;
        dossierInfo[dossierInfo.Length - 1] = newDossierInfo;
        return dossierInfo;
    }

    static void CreateDossier(ref string[] fullName, ref string[] position)
    {
        Console.Clear();
        Console.WriteLine("Введите Ф.И.О сотрудника: ");

        string newFullNames = Console.ReadLine();
        fullName = AddDossier(fullName, newFullNames);

        Console.WriteLine("Введите должность сотрудника: ");

        string newPositions = Console.ReadLine();
        position = AddDossier(position, newPositions);

        Console.WriteLine("Успешно! Досье добавлено. Нажмите любую кнопку, чтобы продолжить.");
        Console.ReadKey();
        Console.Clear();
    }

    static void OutputAllDossiers(string[] fullNames, string[] positions)
    {
        Console.Clear();

        int personNumbers = 0;

        for (int i = 0; i < fullNames.Length; i++)
        {
            personNumbers++;
            Console.WriteLine($"№: {personNumbers}. Ф.И.О: {fullNames[i]}. Должность: {positions[i]}.");
        }

        Console.ReadKey();
        Console.Clear();
    }

    static string[] DeletеDossier(string[] dossierInfo, int indexNumbers)
    {
        string[] tempArray = new string[dossierInfo.Length - 1];

        for (int i = 0; i < indexNumbers; i++)
        {
            tempArray[i] = dossierInfo[i];
        }

        for (int i = indexNumbers; i < tempArray.Length; i++)
        {
            tempArray[i] = dossierInfo[i + 1];
        }

        dossierInfo = tempArray;
        return dossierInfo;
    }

    static void DeletеDossierByUser(ref string[] fullName, ref string[] position)
    {
        Console.Clear();
        Console.WriteLine("Укажите номер досье, которое хотите удалить.");

        int indexNumbers = Convert.ToInt16(Console.ReadLine()) - 1;
        fullName = DeletеDossier(fullName, indexNumbers);
        position = DeletеDossier(position, indexNumbers);

        Console.WriteLine("Успешно! Досье удаленно. Нажмите любую кнопку, чтобы продолжить.");
        Console.ReadKey();
        Console.Clear();
    }

    static void SearchDossier(string[] fullNames, string[] positions, string searchDossier)
    {
        int indexNumbers = 0;
        bool wasFound = false;

        for (int i = 0; i < fullNames.Length; i++)
        {
            string[] tempArray = fullNames[i].Split(' ');
            indexNumbers++;

            if (tempArray[i] == searchDossier)
            {
                string foundFullName = fullNames[i];
                string foundPosition = positions[i];

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

    static void SearchDossierByUser(string[] fullName, string[] position)
    {
        Console.Clear();
        Console.WriteLine("Введите Фамилию сотрудника, досье которого хотите найти.");

        string searchDossier = Console.ReadLine();
        SearchDossier(fullName, position, searchDossier);

        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить.");
        Console.ReadKey();
        Console.Clear();
    }
}