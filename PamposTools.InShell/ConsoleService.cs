using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamposTools.InShell
{
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
                CommandDefinitions.Single(cd => cd.Id == n).Command.Execute();
            }
            catch (InvalidOperationException ex) {
                PrintHelper.PrintLine("INTERNAL ERROR: You are not allowed to have more than one definition with the same Id", LogLevel.Critical);
            }
            
            return true;
        }
    }
}
