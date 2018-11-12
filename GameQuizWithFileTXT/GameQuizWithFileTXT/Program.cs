using System;
using System.IO;
using System.Threading;

namespace GameQuizWithFileTXT
{
    class Program
    {
        static void Main(string[] args)
        {
            int correct = 0;
            int milisecond = 300;
            using (StreamReader sr = new StreamReader(@"c:/temp/file.txt"))
            {
                while (!sr.EndOfStream)
                {
                    Console.Clear();
                    for (int i = 0; i < 5; i++)
                    {
                        string line = sr.ReadLine();
                        if (i > 0)
                        {
                            if (line.Substring(0, 1) == "#") correct = i;
                            Console.WriteLine("{0}: {1}", i, line);
                            Thread.Sleep(milisecond);
                        }
                        else
                        {
                            Console.WriteLine(line);
                        }
                    }

                    for (; ; )
                    {
                        Console.Write("Select Answer: ");
                        ConsoleKeyInfo cki = Console.ReadKey();
                        if (cki.KeyChar.ToString() == correct.ToString())
                        {
                            Console.WriteLine(" - Correct!");
                            Console.WriteLine("Press any key for next question...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" - Try again!");
                        }
                    }
                }
            }
        }
    }
}
