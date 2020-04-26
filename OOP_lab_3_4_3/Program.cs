using System;
using System.IO;

namespace OOP_lab_3_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fromFile = new StreamReader("input.txt");

            string str = fromFile.ReadLine();

            string tempStr;

            while (!string.IsNullOrWhiteSpace(tempStr = fromFile.ReadLine()))
            {
                str += tempStr;
            }

            fromFile.Close();

            StreamWriter toFile = File.CreateText("output.txt");

            bool write = false;

            foreach (char c in str)
            {
                if (write)
                {
                    toFile.Write(c);
                }

                if (c == ':')
                {
                    write = true;
                }
            }

            string[] sentences = str.Split(".", StringSplitOptions.RemoveEmptyEntries);

            int counter = 0;

            foreach (string sentence in sentences)
            {
                string[] words = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int k = 0;

                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        ++k;
                    }
                }

                if (k % 2 != 0)
                {
                    ++counter;
                }
            }

            toFile.WriteLine();
            toFile.WriteLine();

            toFile.WriteLine("Kількість речень, що мiстять непарну кiлькiсть слiв: {0}", counter);

            toFile.Close();
        }
    }
}
