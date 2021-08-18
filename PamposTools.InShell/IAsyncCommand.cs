using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamposTools.InShell
{
    public interface IAsyncCommand : ICommandBase
    {
        Task Execute();
    }
}
