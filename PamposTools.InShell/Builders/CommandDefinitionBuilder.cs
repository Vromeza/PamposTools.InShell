using PamposTools.InShell.Enumerations;
using PamposTools.InShell.Exceptions;
using System;

namespace PamposTools.InShell
{
    /// <summary>
    /// Default builder for a <see cref="CommandDefinition"/>
    /// </summary>
    public sealed class CommandDefinitionBuilder
    {
        private readonly CommandDefinition _commandDefinition;
        private string _description;
        private int _id;
        private ICommand _command;
        private Action _action;
        private DefinitionType? _definitionType = null;

        public CommandDefinitionBuilder(int id) {
            _id = id;
        }

        public CommandDefinitionBuilder WithDescription(string description) {
            _description = description;
            return this;
        }

        public CommandDefinitionBuilder WithCommand(ICommand command) {
            _command = command;
            _definitionType = DefinitionType.Command;
            return this;
        }

        public CommandDefinitionBuilder WithCommand(Action action) {
            _action = action;
            _definitionType = DefinitionType.Action;
            return this;
        }

        public CommandDefinitionBuilder WithConfirmation(string confirmationMessage = default) {
            _commandDefinition.RequireConfirmation(confirmationMessage);
            return this;
        }

        public CommandDefinition Build() {
            CommandDefinition commandDefinition;
            if (!_definitionType.HasValue) {
                throw new DefinitionMissingActionException($"The definition is missing an action/command. Please specify one prior to building");
            }
            switch (_definitionType) {
                case DefinitionType.Command: commandDefinition = new CommandDefinition(_id, _description, _command); break;
                case DefinitionType.Action: commandDefinition = new CommandDefinition(_id, _description, _action); break;
            }
            return _commandDefinition;
        }
    }
}