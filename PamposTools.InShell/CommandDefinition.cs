using System;

namespace PamposTools.InShell
{
    /// <summary>
    /// The command definition
    /// Defines an Id, Description and an <see cref="ICommand"/> object
    /// </summary>
    public sealed class CommandDefinition
    {
        private CommandDefinition(int id, string description) {
            Id = id;
            Description = description;
        }

        /// <summary>
        /// Command with <see cref="ICommand"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="command"></param>
        public CommandDefinition(int id, string description, ICommand command)
            : this(id, description) {
            Command = command;
        }

        /// <summary>
        /// Command with <see cref="Action"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="command"></param>
        public CommandDefinition(int id, string description, Action command)
            : this(id, description) {
            Command = new ActionCommand(command);
        }

        /// <summary>
        /// The id of the command
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Command description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The command
        /// </summary>
        public ICommand Command { get; private set; }
    }
}