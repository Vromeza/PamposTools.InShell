using System;
using System.Collections.Generic;
using System.Text;

namespace PamposTools.InShell
{
    public static class PrintHelper
    {
        public static void PrintLine(string message, LogLevel level = LogLevel.Plain) {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = GetColor(level);
            Console.WriteLine(message);
            Console.ForegroundColor = consoleColor;
        }
        public static void Print(string message, LogLevel level = LogLevel.Plain) {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = GetColor(level);
            Console.Write(message);
            Console.ForegroundColor = consoleColor;
        }

        private static ConsoleColor GetColor(LogLevel logLevel) {
            return logLevel switch
            {
                LogLevel.Plain => ConsoleColor.White,
                LogLevel.Information => ConsoleColor.Cyan,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Critical => ConsoleColor.DarkRed,
                LogLevel.Success => ConsoleColor.Green,
                _ => ConsoleColor.Gray,
            };
        }
    }
}
