using System;

namespace PamposTools.InShell.Console
{
    public class TestGuidValidationCommand : ICommand
    {
        public void Execute()
        {
            Guid guid = InputHelper.GetGuid("Give me a GUID: ");
            PrintHelper.PrintLine($"{guid}? Good answer!", LogLevel.Success);

            guid = InputHelper.GetGuid("Give me another GUID : ", (newGuid) =>
            {
                if (guid == newGuid)
                {
                    PrintHelper.PrintLine("You've given me the same GUID.");
                    return false;
                }
                return true;
            });
            PrintHelper.PrintLine($"Your GUID is: {guid}.", LogLevel.Success);
        }
    }
}
