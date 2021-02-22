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
Once ready, call **Start()**
