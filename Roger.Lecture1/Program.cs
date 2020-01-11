/*
 * Name: Rogerio
 */
using static System.Console;
using System;

namespace Roger.Lecture1
{
    class Program
    {
        private readonly string[] errors = {
            "No", "Nope", "Really?", "Dude..pls", "OMG, it's just Math", "Go back home", "..."
        };

        private int attempts = 0;

        public void InitApp()
        {
            try
            {
                int[] values;
                string answer = "";

                do
                {
                    values = GenerateRandomNumbers();
                    ReadUserInput(ref answer, values);

                    Clear();
                    if (!Calculate(values[0], values[1], Convert.ToInt32(answer)))
                    {
                        WriteLine(errors[attempts]);
                        CountAttempts(ref attempts);
                    }
                    else
                        break;

                } while (true);
            }
            catch (Exception)
            {
                WriteLine("I see that you wanna crash my app...");
                ReadKey();
            }
        }

        private void ReadUserInput(ref string answer, int[] values)
        {
            WriteLine(String.Format("What is the answer for: {0} + {1}?", values[0], values[1]));
            answer = ReadLine().Trim();
        }

        private void CountAttempts(ref int attempts)
        {
            if (attempts < errors.Length - 1)
                attempts++;
            else
                attempts = 0;
        }

        private Boolean Calculate(int a, int b, int result)
        {
            return result == a + b;
        }

        private int[] GenerateRandomNumbers()
        {
            Random random = new Random();
            return new int[] { random.Next(20), random.Next(20) };
        }

        static void Main(string[] args)
        {
            new Program().InitApp();
            new Program().Calculate(1, 2, 3);
        }

    }
}
