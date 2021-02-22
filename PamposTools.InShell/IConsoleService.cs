namespace PamposTools.InShell
{
    /// <summary>
    /// Interface for a console service
    /// </summary>
    public interface IConsoleService
    {
        /// <summary>
        /// Starts the service
        /// </summary>
        void Start();

        /// <summary>
        /// Should print out the various commands to console
        /// </summary>
        void PrintConsoleOptions();

        /// <summary>
        /// Processes the user's input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool ProcessInput(string input);
    }
}