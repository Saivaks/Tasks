using System;

namespace TaskExtentions
{
    internal static class IntExtentions
    {
        internal static TimeSpan Seconds(this int second)
        {
            if (second < 0 || second > 86400)
                throw new ArgumentException("Exception!! Некорректный аргумент метода!");
            return new TimeSpan(00, 00, second);
        }

        internal static TimeSpan Minutes(this int minutes)
        {
            if (minutes < 0 || minutes > 1440)
                throw new ArgumentException("Exception!! Некорректный аргумент метода!");
            return new TimeSpan(00, minutes, 00);
        }

        internal static TimeSpan Hours(this int hours)
        {
            if (hours < 0)
                throw new ArgumentException("Exception!! Некорректный аргумент метода!");
            return new TimeSpan(hours % 24, 00, 00);
        }
    }
}
