namespace PamposTools.InShell.Console
{
    internal class Program
    {
        private static void Main(string[] args) {
            //RunService1();
            RunService2();
        }

        private static void RunService1() {
            var service = new ConsoleServiceBuilder()
                .WithName("TESTER SERVICE")
                .WithDefinitions(
                new CommandDefinition(1, "some description", new TestStringCommand()),
                new CommandDefinition(2, "Test some description", () => { System.Console.WriteLine("Writing from action"); })
                )
                .WithDefinition(3, "some other description", () => { System.Console.WriteLine("Writing from another action"); })
                .WithDefinition(4, "Fly or not?", new TestYesNoCommand())
                .WithDefinition(5, "Keep printing", KeepPrinting)
                .WithDefinition(6, "Test Integer Validation", new TestIntegerValidationCommand())
                .WithDefinition(7, "Test String Validation", new TestStringValidationCommand())
                .WithDefinition(8, "Test Decimal Validation", new TestDecimalValidationCommand())
                .WithDefinition(9, "Test DateTime Validation", new TestDateTimeValidationCommand())
                .Build();

            service.Start();
        }

        private static void KeepPrinting() {
            for (int i = 0; i < 10; i++)
                PrintHelper.PrintLine("Keep printing");
        }

        private static void RunService2() {
            TestService testService = new TestService();
            testService.Start();
        }
    }
}