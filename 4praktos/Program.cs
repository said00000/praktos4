using System;

namespace DailyPlanner
{
    class Program
    {
        static string[] notes = { "Заметка 1", "Заметка 2", "Заметка 3", "Заметка 4" };
        static DateTime currentDate = DateTime.Now;
        static int currentIndex = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Ежедневник");
            DisplayMenu();

            while (true)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        ShowPreviousNote();
                        break;
                    case ConsoleKey.RightArrow:
                        ShowNextNote();
                        break;
                    case ConsoleKey.Enter:
                        ShowNoteDetails();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Меню");
            Console.WriteLine("-----");

            for (int i = 0; i < notes.Length; i++)
            {
                string note = notes[i];

                if (i == currentIndex)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }

                Console.WriteLine(note);
            }
        }

        static void ShowPreviousNote()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            DisplayMenu();
        }

        static void ShowNextNote()
        {
            if (currentIndex < notes.Length - 1)
            {
                currentIndex++;
            }
            DisplayMenu();
        }

        static void ShowNoteDetails()
        {
            Console.Clear();
            Console.WriteLine("Подробности");
            Console.WriteLine("-----------");

            string note = notes[currentIndex];
            Console.WriteLine("Заметка: " + note);
            Console.WriteLine("Дата: " + currentDate.ToString("dd.MM.yyyy"));
            Console.WriteLine("Когда должна быть выполнена: <указанная дата>");
            Console.WriteLine();

            Console.WriteLine("Нажмите любую клавишу для возврата к меню...");
            Console.ReadKey(true);

            DisplayMenu();
        }
    }
}
