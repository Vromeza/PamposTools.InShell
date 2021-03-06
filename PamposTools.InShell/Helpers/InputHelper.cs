﻿using System;

namespace PamposTools.InShell
{
    /// <summary>
    /// Helper class for handling input
    /// </summary>
    public static class InputHelper
    {
        /// <summary>
        /// Gets a boolean response from user input
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <returns></returns>
        public static bool GetYesOrNo(string promptMessage) {
            do {
                PrintHelper.Print($"{promptMessage}");

                string response = Console.ReadLine()?.ToLower()?.Trim();

                switch (response) {
                    case "n":
                    case "no":
                        return false;

                    case "y":
                    case "yes":
                        return true;

                    default:
                        PrintHelper.PrintLine($"Invalid response '{response}'. Please answer 'y' or 'n' or CTRL+C to exit.", LogLevel.Warning);
                        break;
                }
            }
            while (true);
        }

        /// <summary>
        /// Gets a string from user input
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <returns></returns>
        public static string GetString(string promptMessage) {
            PrintHelper.Print($"{promptMessage}");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets an integer from user input
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <returns></returns>
        public static int GetInt(string promptMessage) {
            do {
                PrintHelper.Print($"{promptMessage}");
                string resp = Console.ReadLine()?.ToLower()?.Trim();

                if (string.IsNullOrEmpty(resp)) {
                    PrintHelper.PrintLine("Please enter a valid number or press CTRL+C to exit.", LogLevel.Warning);
                    continue;
                }

                if (int.TryParse(resp, out var result)) {
                    return result;
                }

                PrintHelper.PrintLine($"Invalid number '{resp}'. Please enter a valid number or press CTRL+C to exit.", LogLevel.Warning);
            }
            while (true);
        }

        /// <summary>
        /// Gets an integer from user input. Validates minimum and maximum ranges
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetInt(string promptMessage, int min, int max) {
            do {
                int integer = GetInt(promptMessage);

                if (integer < min || integer > max) {
                    PrintHelper.PrintLine($"Please enter a number between {min} and {max} inclusive");
                    continue;
                }
                return integer;
            } while (true);
        }
    }
}