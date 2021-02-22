namespace PamposTools.InShell.Console
{
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
}