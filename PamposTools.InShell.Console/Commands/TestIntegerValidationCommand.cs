namespace PamposTools.InShell.Console
{
    public class TestIntegerValidationCommand : ICommand
    {
        public void Execute() {
            int age = InputHelper.GetInt("How old are you? ", ValidateAge);
            int ageInDays = age * 365;
            int ageInHours = ageInDays * 24;
            int ageInMinutes = ageInHours * 60;
            long ageInSeconds = (long)ageInMinutes * 60;
            PrintHelper.PrintLine($"You are {ageInDays} days old.", LogLevel.Success);
            PrintHelper.PrintLine($"You are {ageInHours} hours old.", LogLevel.Success);
            PrintHelper.PrintLine($"You are {ageInMinutes} minutes old.", LogLevel.Success);
            PrintHelper.PrintLine($"You are {ageInSeconds} seconds old.", LogLevel.Success);
        }

        private bool ValidateAge(int age) {
            
            if (age < 0) {
                PrintHelper.PrintLine($"Negative age? This can't be right!", LogLevel.Warning);
                return false;
            }
            else if (age < 5) {
                PrintHelper.PrintLine($"Are we dealing with a baby genius here?", LogLevel.Warning);
                return false;
            }
            else if (age > 90 && age <= 120) {
                PrintHelper.PrintLine($"Wow! What's your secret?", LogLevel.Information);
                return true;
            }
            else if (age > 120) {
                PrintHelper.PrintLine($"Hello from the other side!", LogLevel.Warning);
                return false;
            }

            return true;
        }
    }
}
