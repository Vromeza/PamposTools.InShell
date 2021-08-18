namespace PamposTools.InShell.Console
{
    public class TestYesNoCommand : ICommand
    {
        public void Execute() {
            bool fly = InputHelper.GetYesOrNo("Would you like to fly?: ");
            if (fly) {
                int days = InputHelper.GetInt("For how many days?: ", 2, 10);
                PrintHelper.PrintLine($"Congratulations. You became a bird for {days} days", LogLevel.Success);
            }
            else
                PrintHelper.PrintLine($"That's too bad. Keep walking...", LogLevel.Warning);
        }
    }
}