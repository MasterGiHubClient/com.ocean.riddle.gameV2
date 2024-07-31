using System;
using System.Linq;

namespace Core
{
    public static class TextFormatter
    {
        public static string FormatScore(int score)
        {
            if (score > 999999999)
                return ">1B";
            if (score > 999999)
                return $"{score / 1000000},{score / 100000 % 10}M";
            if (score > 999)
                return $"{score / 1000},{score / 100 % 10:D1}K";

            return $"{score}";
        }

        public static string FormatTime(int time)
        {
            return $"{time / 60:D2}:{time % 60:D2}";
        }
    }
}