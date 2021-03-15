using System;
using System.Collections.Generic;

namespace Notebook
{
    class Notebook
    {
        public static List<Record> recordsList = new List<Record>();
        static void Main(string[] args)
        {
            
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1.Добавить     2.Редактировать      3.Посмотреть все     4.Удалить     5.Краткий просмотр");
                Console.ResetColor();
                int.TryParse(Console.ReadLine(),out int operation);
                switch (operation)
                {
                    case 1:
                        {
                            Console.WriteLine("Фамилия:");
                            string lastName;
                            do
                            {
                                lastName = Console.ReadLine();
                                if (!IsNotEmptyValidation(lastName))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Это обязательно поле.");
                                    Console.ResetColor();
                                }
                            }
                            while (!IsNotEmptyValidation(lastName));

                            Console.WriteLine("Имя:");
                            string firstName;
                            do
                            {
                                firstName = Console.ReadLine();
                                if (!IsNotEmptyValidation(firstName))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Это обязательно поле.");
                                    Console.ResetColor();
                                }
                            }
                            while (!IsNotEmptyValidation(firstName));

                            Console.WriteLine("Отчество:");
                            string middleName = Console.ReadLine();
                            Console.WriteLine("Номер телефона:");
                            string phone;
                            do
                            {
                                phone = Console.ReadLine();
                                if (!IsOnlyDigitsValidation(phone))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Поле должно содержать только цифры");
                                    Console.ResetColor();
                                }
                            }
                            while (!IsOnlyDigitsValidation(phone));


                            Console.WriteLine("Страна:");
                            string country;
                            do
                            {
                                country = Console.ReadLine();
                                if (!IsNotEmptyValidation(country))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Это обязательно поле.");
                                    Console.ResetColor();
                                }
                            }
                            while (!IsNotEmptyValidation(country));

                            Console.WriteLine("Дата рождения:");
                            string birthday = Console.ReadLine();
                            Console.WriteLine("Организация:");
                            string company = Console.ReadLine();
                            Console.WriteLine("Должность:");
                            string position = Console.ReadLine();
                            Console.WriteLine("Прочие заметки:");
                            string comment = Console.ReadLine();
                            Record record = new Record();
                            record.CreateRecord(lastName, firstName, middleName, phone, country, birthday, company, position, comment);
                            recordsList.Add(record);
                            Console.ForegroundColor=ConsoleColor.Green;
                            Console.WriteLine("Запись успешно создана!");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Введите номер записи, которую необходимо обновить:");
                            int id = int.Parse(Console.ReadLine());
                            var record = GetRecordById(id);
                            if (record!=null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("------------------------------------------------");
                                Console.ResetColor();
                                Console.WriteLine(record);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("------------------------------------------------");
                                Console.ResetColor();
                                Console.WriteLine();
                                while (true)
                                {
                                    Console.WriteLine("Выберите поля для редактирования:");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("1.Фамилия  2.Имя  3.Отчество  4.Телефон  5.Страна  6.День рождения  7.Организация  8.Должность  9.Прочие заметки ");
                                    Console.ResetColor();
                                    int.TryParse(Console.ReadLine(),out int option);
                                    switch (option)
                                    {
                                        case 1:
                                            string lastName;
                                            do
                                            {
                                                lastName = Console.ReadLine();
                                                if (!IsNotEmptyValidation(lastName))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Это обязательно поле.");
                                                    Console.ResetColor();
                                                }
                                            }
                                            while (!IsNotEmptyValidation(lastName));
                                            record.LastName = lastName;
                                            break;
                                        case 2:
                                            string firstName;
                                            do
                                            {
                                                firstName = Console.ReadLine();
                                                if (!IsNotEmptyValidation(firstName))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Это обязательно поле.");
                                                    Console.ResetColor();
                                                }
                                            }
                                            while (!IsNotEmptyValidation(firstName));
                                            record.FirstName = firstName;
                                            break;
                                        case 3:
                                            string middleName = Console.ReadLine();
                                            record.MiddleName = middleName;
                                            break;
                                        case 4:
                                            string phone;
                                            do
                                            {
                                                phone = Console.ReadLine();
                                                if (!IsOnlyDigitsValidation(phone))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Поле должно содержать только цифры");
                                                    Console.ResetColor();
                                                }
                                            }
                                            while (!IsOnlyDigitsValidation(phone));
                                            record.Phone = phone;
                                            break;
                                        case 5:
                                            string country;
                                            do
                                            {
                                                country = Console.ReadLine();
                                                if (!IsNotEmptyValidation(country))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Это обязательно поле.");
                                                    Console.ResetColor();
                                                }
                                            }
                                            while (!IsNotEmptyValidation(country));
                                            record.Country = country;
                                            break;
                                        case 6:
                                            string birthday = Console.ReadLine();
                                            record.Birthday = birthday;
                                            break;
                                        case 7:
                                            string company = Console.ReadLine();
                                            record.Company = company;
                                            break;
                                        case 8:
                                            string position = Console.ReadLine();
                                            record.Position = position;
                                            break;
                                        case 9:
                                            string comment = Console.ReadLine();
                                            record.Comment = comment;
                                            break;
                                        default:
                                            Console.WriteLine("Неверная опция. Попробуйте еще раз");
                                            break;
                                    }
                                    Console.WriteLine("Продолжить редактирование? y/n");
                                    string answer = Console.ReadLine();
                                    if (answer == "y")
                                        continue;
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Запись успешно обновлена!");
                                        Console.ResetColor();
                                        Console.WriteLine();
                                        break;
                                    }

                                }
                            }
                            else
                                Console.WriteLine("Нет такой записи.");
                            break;
                        }

                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------Список записей в книжке-----------------");
                            Console.ResetColor();
                            foreach (var item in recordsList)
                            {
                                Console.WriteLine(item);
                                Console.WriteLine();
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.ResetColor();
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("Введите номер записи, которую необходимо удалить:");

                            int id = int.Parse(Console.ReadLine());
                            var record = GetRecordById(id);
                            if (record != null)
                            {
                                recordsList.Remove(record);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Запись успешно удалена!");
                                Console.ResetColor();
                                Console.WriteLine();
                            }
                            else
                                Console.WriteLine("Нет такой записи.");

                            break;
                        }
                    case 5:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------Список записей в книжке-----------------");
                            Console.ResetColor();
                            foreach (var item in recordsList)
                            {
                                Console.WriteLine(item.GetShortInformation());

                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }

                    case 6:
                        Console.WriteLine("Для завершения работы нажмите клавишу T.");
                        break;
                    default:
                        Console.WriteLine("Неверная опция. Попробуйте еще раз");
                        break;
                    
                }

                Console.WriteLine("Продолжить работу? y/n");
                string stop = Console.ReadLine();
                if (stop == "y")
                    continue;
                else
                {
                    break;
                }
            }
            
        }

        private static bool IsNotEmptyValidation(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return false;
            return true;
        }

        private static bool IsOnlyDigitsValidation(string inputString)
        {
            bool isCorrect=true;
            foreach (var item in inputString)
            {
                if (item < '0' || item > '9')
                    isCorrect = false;
                break;
            }
            return isCorrect;
        }


        public static Record GetRecordById(int id)
        {
            foreach (var item in recordsList)
            {
                if (item.ID == id)
                    return item;
            }
            return null;
        }
    }
}
