using System;

namespace PamposTools.InShell.Exceptions
{
    internal class DefinitionMissingActionException : Exception
    {
        public DefinitionMissingActionException(string message) : base(message) {
        }
    }
}