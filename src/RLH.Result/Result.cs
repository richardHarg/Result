namespace RLH.Result
{
    public class Result<T> : IResult
    {
        /// <summary>
        /// Private constructor passing through a status
        /// </summary>
        /// <param name="status">Status to set new Result to</param>
        private Result(ResultStatus status)
        {
            Status = status;
        }
        /// <summary>
        /// Private constructor passing through status and return value
        /// </summary>
        /// <param name="status">Status to set new Result to</param>
        /// <param name="value">Value of T to pass back</param>
        private Result(ResultStatus status,T value)
        {
            Status = status;
            Value = value;
        }


        /// <summary>
        /// Status of the Result
        /// </summary>
        public ResultStatus Status { get; private set; } = ResultStatus.Success;
        /// <summary>
        /// List of ValidationErrors related to this Result
        /// </summary>
        public List<ValidationError> ValidationErrors { get; private set; } = new List<ValidationError>();
        /// <summary>
        /// List of general errors related to this Result
        /// </summary>
        public IEnumerable<string> Errors { get; private set; } = new List<string>();
        /// <summary>
        /// Return value of this Result
        /// </summary>
        public T Value { get; }


        /// <summary>
        /// Creates a new Result of T with a status of 'Success' passing through the return object
        /// </summary>
        /// <param name="value">Object of type T to return</param>
        /// <returns>New Result of T</returns>
        public static Result<T> Success(T value)
        {
            return new Result<T>(ResultStatus.Success, value);
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'NotFound' for when an entity cannot be located
        /// </summary>
        /// <returns>New Result of T</returns>
        public static Result<T> NotFound()
        {
            return new Result<T>(ResultStatus.NotFound);
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'Invalid' passing a list of validation errors
        /// </summary>
        /// <param name="validationErrors">List of validation Errors linked to this request</param>
        /// <returns>New Result of T</returns>
        public static Result<T> Invalid(List<ValidationError> validationErrors)
        {
            return new Result<T>(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors
            };
        }
        /// <summary>
        /// Creates a new Result of T with a status of 'Invalid' passing a single validation error
        /// </summary>
        /// <param name="id">Id of the field/property this validation error relates to</param>
        /// <param name="message">Details of the validation error</param>
        /// <returns>New Result of T</returns>
        public static Result<T> Invalid(string id,string message)
        {
            return new Result<T>(ResultStatus.Invalid)
            {
                ValidationErrors = new List<ValidationError>()
                {
                    new ValidationError(id,message)
                }
            };
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'Error' passing a single error
        /// </summary>
        /// <param name="validationErrors">Error linked to this request</param>
        /// <returns>New Result of T</returns>
        public static Result<T> Error(string error)
        {
            return new Result<T>(ResultStatus.Error)
            {
                Errors = new List<string>()
                {
                    error
                }
            };
        }
        /// <summary>
        /// Creates a new Result of T with a status of 'Error' passing a number of errors
        /// </summary>
        /// <param name="errors">Collection of error strings associated with the Result</param>
        /// <returns>New Result of T</returns>
        public static Result<T> Error(params string[] errors)
        {
            return new Result<T>(ResultStatus.Error)
            {
                Errors = errors
            };
        }


        /// <summary>
        /// Get the returned Value(T) 
        /// </summary>
        /// <returns></returns>
        public object ReturnValue()
        {
            return Value;
        }
    }
}