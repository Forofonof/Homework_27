using System;

internal class Program
{
    static void Main(string[] args)
    {
        string[] fullName = { };
        string[] position = { };
        bool isDatabaseActive = true;

        Console.WriteLine("База данных к вашим услугам, что желаете сделать?\n");

        while (isDatabaseActive)
        {
            Console.WriteLine("1 - Добавить досье.");
            Console.WriteLine("2 - Вывести все досье.");
            Console.WriteLine("3 - Удалить досье.");
            Console.WriteLine("4 - Поиск сотрудника по Фамилии.");
            Console.WriteLine("5 - Завершить работу программы.");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    InputAddingInfo(ref fullName, ref position);
                    break;
                case "2":
                    InfoOutput(fullName, position);
                    break;
                case "3":
                    InputInfoDelete(ref fullName, ref position);
                    break;
                case "4":
                    InputSearchInfo(fullName, position);
                    break;
                case "5":
                    DoExit(ref isDatabaseActive);
                    break;
                default:
                    Console.WriteLine("Ошибка! Неизвестная команда.");
                    break;
            }
        }
    }

    static string[] InfoAdd(string[] info, string newInfo)
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

    static void InputAddingInfo(ref string[] fullName, ref string[] position)
    {
        Console.Clear();
        Console.WriteLine("Введите Ф.И.О сотрудника: ");

        string newFullName = Console.ReadLine();
        fullName = InfoAdd(fullName, newFullName);

        Console.WriteLine("Введите должность сотрудника: ");

        string newPosition = Console.ReadLine();
        position = InfoAdd(position, newPosition);

        Console.WriteLine("Успешно! Досье добавлено. Нажмите любую кнопку, чтобы продолжить.");
        Console.ReadKey();
        Console.Clear();
    }

    static void InfoOutput(string[] fullName, string[] position)
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

    static string[] InfoDelite(string[] info, int indexNumbers)
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

    static void InputInfoDelete(ref string[] fullName, ref string[] position)
    {
        Console.Clear();
        Console.WriteLine("Укажите номер досье, которое хотите удалить.");

        int indexNumbers = Convert.ToInt16(Console.ReadLine()) - 1;
        fullName = InfoDelite(fullName, indexNumbers);
        position = InfoDelite(position, indexNumbers);

        Console.WriteLine("Успешно! Досье удаленно. Нажмите любую кнопку, чтобы продолжить.");
        Console.ReadKey();
        Console.Clear();
    }

    static void SearchInfo(string[] fullName, string[] position, string searchInfo)
    {
        int indexNumbers = 0;
        bool wasFound = false;

        for (int i = 0; i < fullName.Length; i++)
        {
            string[] tempArray = fullName[i].Split(' ');
            indexNumbers++;

            if (tempArray[i].ToLower() == searchInfo)
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
            Console.WriteLine($"{searchInfo}. Cотрудник отсутствует в базе данных.");
        }
    }

    static void InputSearchInfo(string[] fullName, string[] position)
    {
        Console.Clear();
        Console.WriteLine("Введите Фамилию сотрудника, досье которого хотите найти.");

        string searchInfo = Console.ReadLine();
        SearchInfo(fullName, position, searchInfo);

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