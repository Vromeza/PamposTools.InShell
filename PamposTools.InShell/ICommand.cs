namespace PamposTools.InShell
{
    /// <summary>
    /// Command interface
    /// TODO[CH]: Add an async version
    /// </summary>
    public interface ICommand : ICommandBase
    {
        void Execute();
    }
}