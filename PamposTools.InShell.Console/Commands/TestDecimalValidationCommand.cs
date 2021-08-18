using System;

namespace PamposTools.InShell.Console
{
    public class TestDecimalValidationCommand : ICommand
    {
        public void Execute() {
            decimal number = InputHelper.GetDecimal("Give me a decimal: ");
            PrintHelper.PrintLine($"{number}? Good answer!", LogLevel.Success);

            number = InputHelper.GetDecimal("Give me a decimal between 0 and 1: ", 0m, 1m);
            PrintHelper.PrintLine($"Your number is: {number}.", LogLevel.Success);

            number = InputHelper.GetDecimal("What is the value of pi in 6 decimal places?: ", IsDecimalEqualToPiInSixDecimalPlaces);
            PrintHelper.PrintLine($"That's right! PI is {number}.", LogLevel.Success);
        }

        private bool IsDecimalEqualToPiInSixDecimalPlaces(decimal d) {

            if (d != TruncateDecimal(d, 6)) {
                PrintHelper.PrintLine($"6 decimal places please....", LogLevel.Warning);
                return false;
            }

            if (d != TruncateDecimal((decimal)Math.PI, 6)) {
                PrintHelper.PrintLine($"That's not it! Try again.", LogLevel.Warning);
                return false;
            }

            return true;
        }

        private static decimal TruncateDecimal(decimal d, int precision) {
            double number = (double)d;
            double multiplier = Math.Pow(10, precision);
            return (decimal)(Math.Truncate(number * multiplier) / multiplier);
        }
    }
}
