﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamposTools.InShell
{
    /// <summary>
    /// Default builder for a <see cref="ConsoleService"/>
    /// </summary>
    public sealed class ConsoleServiceBuilder
    {
        ConsoleService _consoleService = new ConsoleService();

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

        public ConsoleService Build() => _consoleService;
    }

    /// <summary>
    /// Generic builder for any type <see cref="T"/> of <see cref="IConsoleService"/>, <see cref="IServiceDefinition"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ConsoleServiceBuilder<T> where T : class, IConsoleService, IServiceDefinition, new()
    {
        T _consoleService = new T();

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

        public IConsoleService Build() => _consoleService;
    }
}