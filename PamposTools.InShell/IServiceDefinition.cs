using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamposTools.InShell
{
    public interface IServiceDefinition
    {
        string Name { get; set; }
        List<CommandDefinition> CommandDefinitions { get; set; }
    }
}
