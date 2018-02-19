using System;

namespace Livecoin
{
    public class LivecoinApiException : Exception
    {
        public LivecoinApiException()
        {
        }

        public LivecoinApiException(string message)
            : base(message)
        {
        }

        public LivecoinApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}