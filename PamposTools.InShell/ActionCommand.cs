using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamposTools.InShell
{
    public class ActionCommand : ICommand
    {
        private Action _action;
        public ActionCommand(Action action) {
            _action = action;
        }
        public void Execute() {
            _action();
        }
    }
}
