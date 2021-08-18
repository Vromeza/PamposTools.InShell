using System.Linq;

namespace PamposTools.InShell.Console
{
    public class TestStringValidationCommand : ICommand
    {
        private readonly string[] _validColors = new string[] { "red", "blue", "green", "yellow" }; 

        public void Execute() {
            string color = InputHelper.GetString("What's your favorite color? ", ValidateColor);
            PrintHelper.PrintLine($"Cool! I like {color} too.", LogLevel.Success);
        }

        private bool ValidateColor(string color) {

            if (!_validColors.Any(c => c == color.ToLower())) {
                PrintHelper.PrintLine($"That's not a valid color.", LogLevel.Warning);
                return false;
            }
            return true;
        }
    }
}
