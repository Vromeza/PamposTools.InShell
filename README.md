# PamposTools.InShell

InShell is a library for interactive console applications. Includes common input/output helpers and is based on the Command Pattern for quickly creating tasks/actions to be executed from a console application.
I've made this for my own personal use but i thought I'd publicize, maybe it'll help some folks.


# Usage

    internal class Program
    {
        private static void Main(string[] args) {
            var service = new ConsoleServiceBuilder()
                .WithName("TESTER SERVICE")
                .WithDefinitions(
                new CommandDefinition(1, "some description", new TestCommand()),
                new CommandDefinition(2, "Test some description", () => { System.Console.WriteLine("Writing from action"); })
                )
                .WithDefinition(3, "some other description", () => { System.Console.WriteLine("Writing from another action"); })
                .WithDefinition(4, "Fly or not?", new Test2Command())
                .Build();

            service.Start();
        }
    }

Use the **ConsoleServiceBuilder** to build your service with **CommandDefinitions**
You can implement your custom **Commands** and add them to a definition.

Or you can implement your own **ConsoleService** like so:

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
	}

Once ready, call **Start()**
