namespace PamposTools.InShell.Console
{
    /// <summary>
    /// Concrete class for a command
    /// </summary>
    public class TestCommand : ICommand
    {
        public void Execute() {
            string testInput = InputHelper.GetString("Enter some random string:");

            PrintHelper.PrintLine($"Showing random string: {testInput}", LogLevel.Success);
        }
    }
}