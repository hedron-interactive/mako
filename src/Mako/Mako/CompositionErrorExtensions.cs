namespace Mako
{
    using System;

    public static class CompositionErrorExtensions
    {
        public static CompositionError AsError(this Exception exception, int code)
        {
            return CompositionError.Create(code, exception);
        }

        public static CompositionError AsError(this Exception exception, int code, string description)
        {
            return CompositionError.Create(code, exception, description);
        }
    }
}