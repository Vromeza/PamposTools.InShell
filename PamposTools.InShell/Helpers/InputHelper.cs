using System;
using System.Globalization;

namespace PamposTools.InShell
{
    /// <summary>
    /// Helper class for handling input
    /// </summary>
    public static partial class InputHelper
    {
        const string DEFAULT_DATE_FORMAT = "yyyyMMdd";

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
        /// Gets a string from user input. Validates using the provided validation method.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="validationMethod"></param>
        /// <returns></returns>
        public static string GetString(string promptMessage, Func<string, bool> validationMethod) {
            string input;
            do {
                input = GetString(promptMessage);

            } while (!validationMethod(input));

            return input;
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
        /// Gets an integer from user input. Validates value is within the scpecified range.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetInt(string promptMessage, int min, int max) {
            do {
                int integer = GetInt(promptMessage);

                if (integer < min || integer > max) {
                    PrintHelper.PrintLine($"Please enter a number between {min} and {max} inclusive", LogLevel.Warning);
                    continue;
                }
                return integer;
            } while (true);
        }

        /// <summary>
        /// Gets an integer from user input. Validates using the provided validation method.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="validationMethod"></param>
        /// <returns></returns>
        public static int GetInt(string promptMessage, Func<int, bool> validationMethod) {
            int integer;
            do {
                integer = GetInt(promptMessage);

            } while (!validationMethod(integer));

            return integer;
        }

        /// <summary>
        /// Gets a decimal from user input.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string promptMessage) {
            do {
                PrintHelper.Print($"{promptMessage}");
                string resp = Console.ReadLine()?.ToLower()?.Trim();

                if (string.IsNullOrEmpty(resp)) {
                    PrintHelper.PrintLine("Please enter a valid number or press CTRL+C to exit.", LogLevel.Warning);
                    continue;
                }

                if (decimal.TryParse(resp, out var result)) {
                    return result;
                }

                PrintHelper.PrintLine($"Invalid number '{resp}'. Please enter a valid number or press CTRL+C to exit.", LogLevel.Warning);
            }
            while (true);
        }

        /// <summary>
        /// Gets an decimal from user input. Validates value is within the scpecified range.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string promptMessage, decimal min, decimal max) {
            do {
                decimal number = GetDecimal(promptMessage);

                if (number < min || number > max) {
                    PrintHelper.PrintLine($"Please enter a number between {min} and {max} inclusive", LogLevel.Warning);
                    continue;
                }
                return number;
            } while (true);
        }

        /// <summary>
        /// Gets an decimal from user input. Validates using the provided validation method.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="validationMethod"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string promptMessage, Func<decimal, bool> validationMethod) {
            decimal number;
            do {
                number = GetDecimal(promptMessage);

            } while (!validationMethod(number));

            return number;
        }

        /// <summary>
        /// Gets a date/time from user input in one of the specified formats.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string promptMessage) {
            return GetDateTime(promptMessage, DEFAULT_DATE_FORMAT);
        }

        /// <summary>
        /// Gets a date/time from user input in one of the specified formats.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="dateFormats"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string promptMessage, params string[] dateFormats) {
            do {
                PrintHelper.Print($"{promptMessage} [Format(s): {string.Join(", ", dateFormats)}]: ");
                string resp = Console.ReadLine()?.ToLower()?.Trim();

                if (string.IsNullOrEmpty(resp)) {
                    PrintHelper.PrintLine("Please enter a valid date/time or press CTRL+C to exit.", LogLevel.Warning);
                    continue;
                }

                if (DateTime.TryParseExact(resp, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)) {
                    return result;
                }

                PrintHelper.PrintLine($"Invalid date/time '{resp}'. Please enter a valid date/time or press CTRL+C to exit.", LogLevel.Warning);
            }
            while (true);
        }

        /// <summary>
        /// Gets an date/time from user input. Validates value is within the scpecified range.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="format"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string promptMessage, DateTime min, DateTime max) {
            return GetDateTime(promptMessage, min, max, DEFAULT_DATE_FORMAT);
        }

        /// <summary>
        /// Gets an date/time from user input. Validates value is within the scpecified range.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="formats"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string promptMessage, DateTime min, DateTime max, params string[] dateFormats) {
            do {
                DateTime dateTime = GetDateTime(promptMessage, dateFormats);

                if (dateTime < min || dateTime > max) {
                    PrintHelper.PrintLine($"Please enter a date/time between {min.ToString(dateFormats?[0], CultureInfo.InvariantCulture)} and {max.ToString(dateFormats?[0], CultureInfo.InvariantCulture)} inclusive", LogLevel.Warning);
                    continue;
                }
                return dateTime;
            } while (true);
        }

        /// <summary>
        /// Gets an date/time from user input. Validates using the provided validation method.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="format"></param>
        /// <param name="validationMethod"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string promptMessage, Func<DateTime, bool> validationMethod) {
            return GetDateTime(promptMessage, validationMethod, DEFAULT_DATE_FORMAT);
        }

        /// <summary>
        /// Gets an date/time from user input. Validates using the provided validation method.
        /// </summary>
        /// <param name="promptMessage"></param>
        /// <param name="formats"></param>
        /// <param name="validationMethod"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string promptMessage, Func<DateTime, bool> validationMethod, params string[] dateFormats) {
            DateTime dateTime;
            do {
                dateTime = GetDateTime(promptMessage, dateFormats);

            } while (!validationMethod(dateTime));

            return dateTime;
        }
    }
}