using System;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n) 
        {
            int fact = 1;

            for (int i = 1; i <= n; i++)
                fact = fact * i;

            return fact;
        }

        public static string FormatSeparators(params string[] items)
        { 
            StringBuilder b  = new StringBuilder();

            for (int i = 0; i < items.Length; i++)
            {
                if (i == items.Length - 2)
                {
                    b.Append($"{items[i]} and {items[i + 1]}");
                    return b.ToString();
                }
                else
                    b.Append($"{items[i]}, ");
            }

            return b.ToString();
        }
    }
}