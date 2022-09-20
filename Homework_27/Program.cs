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

        string[] fullName = { };
        string[] position = { };
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
                    CreateDossier(ref fullName, ref position);
                    break;
                case AllDossiers:
                    OutputAllDossiers(fullName, position);
                    break;
                case DeletingDossier:
                    DeletingDossierByUser(ref fullName, ref position);
                    break;
                case SearchDossier:
                    SearchDossierByUser(fullName, position);
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

    static string[] DeletingDossier(string[] dossierInfo, int indexNumbers)
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

            if (tempArray[i] == searchDossier)
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