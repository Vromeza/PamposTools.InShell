using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamposTools.InShell
{
    public class ConsoleServiceBuilder
    {
        IConsoleService _consoleService = new ConsoleService();

        public ConsoleServiceBuilder WithName(string name) {
            _consoleService.Name = name;
            return this;
        }

        public ConsoleServiceBuilder WithDefinitions(List<CommandDefinition> commandDefinitions) {
            if (_consoleService.CommandDefinitions == null)
                _consoleService.CommandDefinitions = commandDefinitions;
            else
                _consoleService.CommandDefinitions.AddRange(commandDefinitions);
            return this;
        }

        public ConsoleServiceBuilder WithDefinitions(params CommandDefinition[] commandDefinitions) {
            if (_consoleService.CommandDefinitions == null)
                _consoleService.CommandDefinitions = commandDefinitions.ToList();
            else
                _consoleService.CommandDefinitions.AddRange(commandDefinitions);
            return this;
        }

        public IConsoleService Build() => _consoleService;
    }
}
