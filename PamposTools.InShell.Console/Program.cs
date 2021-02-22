using System;

namespace PamposTools.InShell.Console
{
    class Program
    {
        static void Main(string[] args) {
            var service = new ConsoleServiceBuilder()
                .WithName("TESTER SERVICE")
                .WithDefinitions(
                new CommandDefinition(2, "some description", new TestCommand()),
                new CommandDefinition(3, "Test some description", () => { System.Console.WriteLine("Writing from action"); })
                )
                .Build();

            var service2 = new ConsoleService();

            //service.Start();
            service2.Start();
        }
    }
}
