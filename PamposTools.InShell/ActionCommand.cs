using System;

namespace PamposTools.InShell
{
    /// <summary>
    /// Command which encapsulates an <see cref="Action"/>. See <see cref="ICommand"/>
    /// </summary>
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