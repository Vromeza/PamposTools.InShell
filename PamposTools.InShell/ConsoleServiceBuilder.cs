using System;
using System.Collections.Generic;

namespace PamposTools.InShell
{
    /// <summary>
    /// Default builder for a <see cref="ConsoleService"/>
    /// </summary>
    public sealed class ConsoleServiceBuilder
    {
        private ConsoleService _consoleService = new ConsoleService();

        public ConsoleServiceBuilder WithName(string name) {
            _consoleService.Name = name;
            return this;
        }

        public ConsoleServiceBuilder WithDefinitions(List<CommandDefinition> commandDefinitions) {
            _consoleService.CommandDefinitions.AddRange(commandDefinitions);
            return this;
        }

        public ConsoleServiceBuilder WithDefinitions(params CommandDefinition[] commandDefinitions) {
            _consoleService.CommandDefinitions.AddRange(commandDefinitions);
            return this;
        }

        public ConsoleServiceBuilder WithDefinition(int id, string description, ICommand command) {
            _consoleService.CommandDefinitions.Add(new CommandDefinition(id, description, command));
            return this;
        }

        public ConsoleServiceBuilder WithDefinition(int id, string description, Action action) {
            _consoleService.CommandDefinitions.Add(new CommandDefinition(id, description, action));
            return this;
        }

        public ConsoleService Build() => _consoleService;
    }

    /// <summary>
    /// Generic builder for any type <see cref="T"/> of <see cref="IConsoleService"/>, <see cref="IServiceDefinition"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ConsoleServiceBuilder<T> where T : class, IConsoleService, IServiceDefinition, new()
    {
        private T _consoleService = new T();

        public ConsoleServiceBuilder<T> WithName(string name) {
            _consoleService.Name = name;
            return this;
        }

        public ConsoleServiceBuilder<T> WithDefinitions(List<CommandDefinition> commandDefinitions) {
            _consoleService.CommandDefinitions.AddRange(commandDefinitions);
            return this;
        }

        public ConsoleServiceBuilder<T> WithDefinitions(params CommandDefinition[] commandDefinitions) {
            _consoleService.CommandDefinitions.AddRange(commandDefinitions);
            return this;
        }

        public ConsoleServiceBuilder<T> WithDefinition(int id, string description, ICommand command) {
            _consoleService.CommandDefinitions.Add(new CommandDefinition(id, description, command));
            return this;
        }

        public ConsoleServiceBuilder<T> WithDefinition(int id, string description, Action action) {
            _consoleService.CommandDefinitions.Add(new CommandDefinition(id, description, action));
            return this;
        }

        public IConsoleService Build() => _consoleService;
    }
}