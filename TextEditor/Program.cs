using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("File path?");
            string path = Console.ReadLine();

            using (StreamReader sr = File.OpenText(path))
            {
                Console.Clear();
                string text = sr.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine();
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Enter your text (ESC to exit)");
            Console.WriteLine("-----------------------");
            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Path to save file?");
            string path = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(text);
            }

            Console.WriteLine($"File {path} saved successfully!");
            Console.ReadLine();
            Menu();
        }
    }
}
