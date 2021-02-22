using System;

namespace PamposTools.InShell
{
    /// <summary>
    /// Helper class to handle console outputs
    /// </summary>
    public static class PrintHelper
    {
        /// <summary>
        /// Prints to console in new line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public static void PrintLine(string message, LogLevel level = LogLevel.Plain) {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = GetColor(level);
            Console.WriteLine(message);
            Console.ForegroundColor = consoleColor;
        }

        /// <summary>
        /// Prints to console
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public static void Print(string message, LogLevel level = LogLevel.Plain) {
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = GetColor(level);
            Console.Write(message);
            Console.ForegroundColor = consoleColor;
        }

        /// <summary>
        /// Retrieves the <see cref="ConsoleColor"/> of the console text based on <see cref="LogLevel"/>
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
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