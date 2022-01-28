using System;

namespace AsyncAwait
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}