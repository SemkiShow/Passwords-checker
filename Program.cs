using System;
using System.Collections;
using System.Diagnostics;

namespace Passwords_Checker
{
    class Program
    {
        static string message = "";
        static string currentPassword = "!";
        static string password;
        static Stopwatch watch;
        static bool isHacked = false;
        static string[] symbols = new string[] {
            "A",
            "a",
            "B",
            "b",
            "C",
            "c",
            "D",
            "d",
            "E",
            "e",
            "F",
            "f",
            "G",
            "g",
            "H",
            "h",
            "I",
            "i",
            "J",
            "j",
            "K",
            "k",
            "L",
            "l",
            "M",
            "m",
            "N",
            "n",
            "O",
            "o",
            "P",
            "p",
            "Q",
            "q",
            "R",
            "r",
            "S",
            "s",
            "T",
            "t",
            "U",
            "u",
            "V",
            "v",
            "W",
            "w",
            "X",
            "x",
            "Y",
            "y",
            "Z",
            "z",
            "~",
            "`",
            "!",
            "@",
            "\"",
            "#",
            "№",
            "$",
            ";",
            "%",
            "^",
            ":",
            "&",
            "?",
            "*",
            "(",
            ")",
            "-",
            "_",
            "+",
            "=",
            "/",
            ".",
            ",",
            "\\",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "|",
            "[",
            "]",
            "{",
            "}",
            "'"
        };
        static List<int> interation = new List<int>{0};
        static void PrintMessage()
        {
            // Console.Clear();
            Console.WriteLine(message);
        }
        static void Success()
        {
            watch.Stop();
            isHacked = true;
            Console.Clear();
            Console.WriteLine("Password is hacked! Original password is " + password + ", hacked password is " + currentPassword);
            Console.WriteLine("Hacking this password on your machine takes " + 
            (watch.ElapsedMilliseconds / 1000 / 60 / 60 / 24) + " days " + 
            ((watch.ElapsedMilliseconds / 1000 / 60 / 60) - (watch.ElapsedMilliseconds / 1000 / 60 / 60 / 24 * 24 * 60 * 60 * 1000)) + " hours " + 
            ((watch.ElapsedMilliseconds / 1000 / 60) - (watch.ElapsedMilliseconds / 1000 / 60 / 60 * 60 * 60 * 1000)) + " minutes " + 
            ((watch.ElapsedMilliseconds / 1000) - (watch.ElapsedMilliseconds / 1000 / 60 * 60 * 1000)) + " seconds " + 
            ((watch.ElapsedMilliseconds) - (watch.ElapsedMilliseconds / 1000 * 1000)) + " milliseconds");
            Environment.Exit(1);
        }
        static void Main()
        {
            // while (true)
            // {
                message = "Type in your password:";
                PrintMessage();
                password = Console.ReadLine();
                // int interations = 92 ^ password.Length - 1;
                // int interationsPerPercent = (int)interations / 10;
                watch = new Stopwatch();
                watch.Start();
                Console.WriteLine("Characters count: " + interation.Count);
                while (!isHacked)
                {
                    for (int i = 0; i < symbols.Length; i++)
                    {
                        currentPassword = currentPassword.Remove(currentPassword.Length - 1) + symbols[i];
                        // message = "Currently hacking: " + currentPassword;
                        // PrintMessage();
                        interation[0]++;
                        if (currentPassword == password)
                        {
                            Success();
                        }
                    }
                    for (int x = 0; x < interation.Count; x++)
                    {
                        if (interation[x] > symbols.Length - 1)
                        {
                            interation[x] = 0;
                            if (x > interation.Count - 2)
                            {
                                interation.Add(1);
                                Console.WriteLine("Characters count: " + interation.Count);
                            }
                            else
                            {
                                interation[x + 1]++;
                            }
                        }
                    }
                    // foreach (var item in interation)
                    // {
                    //     Console.Write(item + " ");
                    // }
                    // Console.WriteLine();
                    currentPassword = "";
                    for (int i = interation.Count - 1; i > -1; i--)
                    {
                        currentPassword += symbols[interation[i]];
                    }
                    // Console.ReadLine();
                }
            // }
        }
    }
}
