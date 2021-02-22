using System;
using System.Collections.Generic;
using System.Text;

namespace PamposTools.InShell
{
    public static class InputHelper
    {
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
                        Console.WriteLine($"Invalid response '{response}'. Please answer 'y' or 'n' or CTRL+C to exit.");
                        break;
                }
            }
            while (true);
        }
    }
}
