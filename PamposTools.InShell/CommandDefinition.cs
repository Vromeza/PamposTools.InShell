using System;
using System.Collections.Generic;
using System.Text;

namespace PamposTools.InShell
{
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
            :this(id, description) {
            Command = command;
        }

        /// <summary>
        /// Command with <see cref="Action"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="command"></param>
        public CommandDefinition(int id, string description, Action command)
            :this(id, description){
            Command = new ActionCommand(command);
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public ICommand Command { get; private set; }
    }
}
