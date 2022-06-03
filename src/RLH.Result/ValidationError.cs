
namespace RLH.Result
{
    public sealed class ValidationError
    {
        public readonly string Id;
        public readonly string Message;

        public ValidationError(string id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
