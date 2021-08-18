using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            CommandDefinitions.Add(new CommandDefinition(5, "Command 5", async () => await Command5()));
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

        private async Task Command5() {
            Thread.Sleep(1000);
        }
    }
}
