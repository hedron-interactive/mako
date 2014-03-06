namespace Mako
{
    using System.Collections.Generic;

    /// <summary>
    /// List of composition error codes and messages well known to the core
    /// platform.
    /// </summary>
    public sealed class CompositionErrorCode
    {
        public const int Unknown = 0;
        public const int TrappedBlockException = 1;
        public const int TrappedAsyncException = 2;
        public const int TrappedTransformException = 3;

        public static readonly IReadOnlyList<string> ErrorMessages = new string[]
        {
            "Unknown, an unknown error has occured",
            "TrappedBlockException, a block's apply method was invoked; this method threw an exception",
            "TrappedAsyncException, a block supplied a task to the sequence controller's async forward method; this task threw an exception",
            "TrappedTransformException, a block's input transformation method was invoked; this method threw an exception",
        };

        public static string GetErrorDescription(int errorCode)
        {
            if (errorCode >= 0 && errorCode < ErrorMessages.Count)
            {
                return ErrorMessages[errorCode];
            }

            return null;
        }
    }
}