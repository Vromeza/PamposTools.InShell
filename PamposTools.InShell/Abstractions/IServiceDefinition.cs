using System.Collections.Generic;

namespace PamposTools.InShell
{
    /// <summary>
    /// Interface for a service definition
    /// A service should include a list of <see cref="CommandDefinition"/> and an indicative name
    /// </summary>
    public interface IServiceDefinition
    {
        /// <summary>
        /// Indicative name of the service
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// List of commands this service includes
        /// </summary>
        List<CommandDefinition> CommandDefinitions { get; set; }
    }
}