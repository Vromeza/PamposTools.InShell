namespace PamposTools.InShell.Console
{
    public class TestService : ConsoleService
    {
        public TestService() {
            SetupCommandDefinitions();
            Name = "TEST SERVICE";
        }

        private void SetupCommandDefinitions() {
            CommandDefinitions.Add(new CommandDefinition(1, "Command 1", Command1));
            CommandDefinitions.Add(new CommandDefinition(2, "Command 2", Command2));
            CommandDefinitions.Add(new CommandDefinition(3, "Command 3", Command3));
            CommandDefinitions.Add(new CommandDefinition(4, "Command 4", Command4));
            CommandDefinitions.Add(new CommandDefinitionBuilder(5).WithDescription("Command 5").WithCommand(Command5).WithConfirmation().Build());
        }

        private void Command1() {
            PrintHelper.PrintLine("This is command 1");
        }

        private void Command2() {
            PrintHelper.PrintLine("This is command 2", LogLevel.Information);
        }

        private void Command3() {
            PrintHelper.PrintLine("This is command 3", LogLevel.Critical);
        }

        private void Command4() {
            PrintHelper.PrintLine("This is command 4", LogLevel.Warning);
        }

        private void Command5() {
            PrintHelper.PrintLine("This is command 5", LogLevel.Warning);
        }
    }
}