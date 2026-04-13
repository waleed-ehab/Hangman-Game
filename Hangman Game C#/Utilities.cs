using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Game_C_
{
    public static class Utilities
    {
        public static int GetRandomNumber(int start, int end)
        {
            Random rnd = new Random();
            return rnd.Next(start, end);
        }

        public static char ToLower(char ch)
        {
            return (ch >= 'A' && ch <= 'Z' ? Convert.ToChar((int)ch + 32) : ch);
        }
    }
}
