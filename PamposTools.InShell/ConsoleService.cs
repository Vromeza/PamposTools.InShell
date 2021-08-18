using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PamposTools.InShell
{
    /// <inheritdoc cref="IConsoleService"/>
    /// <summary>
    /// Base console service.
    /// Shows the services options, processes input with validation and executes commands based on choice
    /// Can be inherited for any further functionality required
    /// </summary>
    public class ConsoleService : IConsoleService, IServiceDefinition
    {
        private const string EXECUTE_METHOD_NAME = "Execute";
        public string Name { get; set; }
        public List<CommandDefinition> CommandDefinitions { get; set; } = new List<CommandDefinition>();

        public ConsoleService() {
        }

        public ConsoleService(string name, List<CommandDefinition> commandDefinitions) {
            Name = name;
            CommandDefinitions = commandDefinitions;
        }

        public void Start() {
            bool result = true;
            while (result) {
                try {
                    PrintConsoleOptions();
                    result = ProcessInput(Console.ReadLine());
                }
                catch (Exception ex) {
                    PrintHelper.PrintLine($"Exception occured: {ex}", LogLevel.Critical);
                    PrintHelper.PrintLine($"Resetting...", LogLevel.Warning);
                }
            }
            PrintHelper.PrintLine($"Exiting...", LogLevel.Critical);
            Environment.Exit(0); //exit console app
        }

        public virtual void PrintConsoleOptions() {
            Console.WriteLine();
            PrintHelper.PrintLine($"------ {Name} ------", LogLevel.Information);
            foreach (var def in CommandDefinitions) {
                PrintHelper.PrintLine($" [{def.Id}] {def.Description}", LogLevel.Information);
            }
            PrintHelper.PrintLine($" [EXIT] Exit program", LogLevel.Information);
            PrintHelper.Print($"Please select an option: ");
        }

        public bool ProcessInput(string input) {
            bool isNumeric = int.TryParse(input, out int n);
            if (input.ToUpper() == "EXIT")
                return false;
            while (!isNumeric || !CommandDefinitions.Select(cd => cd.Id).Contains(n)) {
                PrintHelper.Print($"Please enter a valid option: ", LogLevel.Warning);
                return ProcessInput(Console.ReadLine());
            }

            try {
                ICommandBase command = CommandDefinitions.Single(cd => cd.Id == n).Command;
                InvokeCommandExecution(command).GetAwaiter().GetResult();
            }
            catch (InvalidOperationException) {
                PrintHelper.PrintLine("INTERNAL ERROR: You are not allowed to have more than one definition with the same Id", LogLevel.Critical);
            }

            return true;
        }

        private async Task InvokeAsyncExecution(MethodInfo methodInfo, dynamic instance) {
            if (methodInfo.ReturnType.IsGenericType) {
                _ = (object)await(dynamic)methodInfo.Invoke(instance, null);
            }
            else {
                await(Task)methodInfo.Invoke(instance, null);
            }
        }

        private void InvokeSyncExecution(MethodInfo methodInfo, dynamic instance) {
            if (methodInfo.ReturnType == typeof(void)) {
                methodInfo.Invoke(instance, null);
            }
            else {
                _ = methodInfo.Invoke(instance, null);
            }
        }

        private async Task InvokeCommandExecution(ICommandBase commandBase) {
            var type = commandBase.GetType();
            var methodInfo = GetExecutionMethodInfo(type);
            var instance = Activator.CreateInstance(type);
            if (IsExecutionAwaitable(methodInfo)) {
                await InvokeAsyncExecution(methodInfo, instance);
            }
            else {
                InvokeSyncExecution(methodInfo, instance);
            }
        }

        private MethodInfo GetExecutionMethodInfo(Type classType) {
            return classType.GetMethod(EXECUTE_METHOD_NAME);
        }

        private bool IsExecutionAwaitable(MethodInfo methodInfo) {
            return methodInfo.ReturnType.GetMethod(nameof(Task.GetAwaiter)) != null;
        }
    }
}