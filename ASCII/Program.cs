using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            int L = 4;
            int H = 5;


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("welcome to ASCII art !");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("type any sentence: (for Exit type 'break')");
            Console.ResetColor();
            string T = Console.ReadLine().ToLower();
            if (T == "break")
            {
                break;
            }
            var T2 = T.ToCharArray(); // char of word
            string _space = String.Concat(Enumerable.Repeat("≋≋≋≋≋≋", T2.Count() + 1));
            Console.WriteLine("\n");

            string ROW = "";

            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Letters/" + "Letters.txt";


            Console.ForegroundColor = ConsoleColor.Blue;

            using (var sr = new StreamReader(path))
            {
                Console.WriteLine(_space);


                var data = GetData(sr);

                foreach (var line in data)
                {
                    ROW = line + "\n";
                    foreach (var n in T2)
                    {
                        var RowChar = ROW.ToCharArray();
                        var wordNum = ((byte)n) - 96;
                        var write = RowChar.Skip(wordNum * L - L).Take(L).ToArray();

                        string lastW = new string(write);

                        if (wordNum > 0 && wordNum < 27)
                        {
                            Console.Write(lastW);
                        }
                        else
                        {
                            string emptyLW = new string(RowChar.Skip(27 * L - L).Take(L).ToArray());
                            Console.Write(emptyLW);
                        }
                    }
                    Console.Write("\n");
                }
                Console.WriteLine(_space);
            }

        }
    }







    public static IEnumerable<string> GetData(StreamReader sr)
    {
        string line = null;
        while ((line = sr.ReadLine()) != null)
        {
            yield return line;
        }
    }

}