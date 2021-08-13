using System;

namespace PamposTools.InShell
{
    /// <summary>
    /// Helper class to handle console outputs
    /// </summary>
    public static partial class PrintHelper
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
            switch (logLevel) {
                case LogLevel.Plain: return ConsoleColor.White;
                case LogLevel.Information: return ConsoleColor.Cyan;
                case LogLevel.Warning: return ConsoleColor.Yellow;
                case LogLevel.Error: return ConsoleColor.Red;
                case LogLevel.Critical: return ConsoleColor.DarkRed;
                case LogLevel.Success: return ConsoleColor.Green;
                default: return ConsoleColor.Gray;
            }
        }
    }
}