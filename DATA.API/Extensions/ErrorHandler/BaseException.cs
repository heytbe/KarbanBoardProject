namespace Data.API.Extensions.ErrorHandler
{
    public sealed class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
        }
    }
}
