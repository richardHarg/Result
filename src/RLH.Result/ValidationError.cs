
namespace RLH.Result
{
    public sealed class ValidationError
    {
        /// <summary>
        /// Id/name of the property/field this validation error relates to
        /// </summary>
        public readonly string Id;
        /// <summary>
        /// Details of the error message associated with this validation error
        /// </summary>
        public readonly string Message;

        /// <summary>
        /// Create a new ValidationError, passing through the Id and message
        /// </summary>
        /// <param name="id">Id/name of the property/field this validation error relates to</param>
        /// <param name="message">Details of the error message associated with this validation error</param>
        public ValidationError(string id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
