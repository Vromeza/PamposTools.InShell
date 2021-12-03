using System;
using System.Collections.Generic;
using System.Linq;

namespace PamposTools.InShell
{
    /// <inheritdoc cref="IConsoleService"/>
    /// <summary>
    /// Base console service.
    /// Shows the services options, processes input with validation and executes commands based on choice
    /// Can be inherited for any further functionality required
    /// </summary>
    public class ConsoleService : IConsoleService, IServiceDefinition
    {
        public string Name { get; set; }
        public List<CommandDefinition> CommandDefinitions { get; set; } = new List<CommandDefinition>();

        public ConsoleService() {
        }

        public ConsoleService(string name, List<CommandDefinition> commandDefinitions) {
            Name = name;
            CommandDefinitions = commandDefinitions;
        }

        public void Start() {
            bool result = true;
            while (result) {
                try {
                    PrintConsoleOptions();
                    result = ProcessInput(Console.ReadLine());
                }
                catch (Exception ex) {
                    PrintHelper.PrintLine($"Exception occured: {ex}", LogLevel.Critical);
                    PrintHelper.PrintLine($"Resetting...", LogLevel.Warning);
                }
            }
            PrintHelper.PrintLine($"Exiting...", LogLevel.Critical);
            Environment.Exit(0); //exit console app
        }

        public virtual void PrintConsoleOptions() {
            Console.WriteLine();
            PrintHelper.PrintLine($"------ {Name} ------", LogLevel.Information);
            foreach (var def in CommandDefinitions) {
                PrintHelper.PrintLine($" [{def.Id}] {def.Description}", LogLevel.Information);
            }
            PrintHelper.PrintLine($" [EXIT] Exit program", LogLevel.Information);
            PrintHelper.Print($"Please select an option: ");
        }

        public bool ProcessInput(string input) {
            bool isNumeric = int.TryParse(input, out int n);
            if (input.ToUpper() == "EXIT")
                return false;
            while (!isNumeric || !CommandDefinitions.Select(cd => cd.Id).Contains(n)) {
                PrintHelper.Print($"Please enter a valid option: ", LogLevel.Warning);
                return ProcessInput(Console.ReadLine());
            }

            try {
                var definition = GetDefinitionById(n);
                if (ConfirmAction(definition)) {
                    definition.Command.Execute();
                }
            }
            catch (InvalidOperationException) {
                PrintHelper.PrintLine("INTERNAL ERROR: You are not allowed to have more than one definition with the same Id", LogLevel.Critical);
            }

            return true;
        }

        private CommandDefinition GetDefinitionById(int id) {
            return CommandDefinitions.Single(cd => cd.Id == id);
        }

        private static bool ConfirmAction(CommandDefinition definition) {
            string confirmationMessage = !string.IsNullOrEmpty(definition.ConfirmationMessage) ? definition.ConfirmationMessage : "Are you sure you want to execute the above action";
            bool confirm = InputHelper.GetYesOrNo(confirmationMessage);
            if (!confirm) {
                PrintHelper.PrintLine("Aborting...", LogLevel.Error);
            }
            return confirm;
        }
    }
}