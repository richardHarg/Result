namespace RLH.Result
{
    public class Result<T> : IResult
    {
        private Result(ResultStatus status)
        {
            Status = status;
        }
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



        public static Result<T> Success(T value)
        {
            return new Result<T>(ResultStatus.Success, value);
        }


        public static Result<T> NotFound()
        {
            return new Result<T>(ResultStatus.NotFound);
        }
        public static Result<T> Invalid(List<ValidationError> validationErrors)
        {
            return new Result<T>(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors
            };
        }
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
        public static Result<T> Error(params string[] errors)
        {
            return new Result<T>(ResultStatus.Error)
            {
                Errors = errors
            };
        }


        public object ReturnValue()
        {
            return Value;
        }
    }
}