namespace RLH.Results
{
    public class ResultOf<T> : Result, IResultOf<T>
    {
        /// <summary>
        /// Private constructor passing through a status
        /// </summary>
        /// <param name="status">Status to set new Result to</param>
        private ResultOf(ResultStatus status) : base(status)
        {

        }
        /// <summary>
        /// Private constructor passing through status and return value
        /// </summary>
        /// <param name="status">Status to set new Result to</param>
        /// <param name="value">Value of T to pass back</param>
        private ResultOf(ResultStatus status,T value) : base(status)
        {
            Value = value;
        }

        /// <summary>
        /// Return value of this Result
        /// </summary>
        public T Value { get; }


        /// <summary>
        /// Creates a new Result of T with a status of 'Success' passing through the return object
        /// </summary>
        /// <param name="value">Object of type T to return</param>
        /// <returns>New Result of T</returns>
        public static ResultOf<T> Success(T value)
        {
            return new ResultOf<T>(ResultStatus.Success, value);
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'NotFound' for when an entity cannot be located
        /// </summary>
        /// <returns>New Result of T</returns>
        public static new ResultOf<T> NotFound()
        {
            return new ResultOf<T>(ResultStatus.NotFound);
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'Invalid' passing a list of validation errors
        /// </summary>
        /// <param name="validationErrors">List of validation Errors linked to this request</param>
        /// <returns>New Result of T</returns>
        public static new ResultOf<T> Invalid(IEnumerable<ValidationError> validationErrors)
        {
            return new ResultOf<T>(ResultStatus.Invalid)
            {
                ValidationErrors = validationErrors.ToList()
            };
        }
        /// <summary>
        /// Creates a new Result of T with a status of 'Invalid' passing a single validation error
        /// </summary>
        /// <param name="id">Id of the field/property this validation error relates to</param>
        /// <param name="message">Details of the validation error</param>
        /// <returns>New Result of T</returns>
        public static new ResultOf<T> Invalid(string id,string message)
        {
            return new ResultOf<T>(ResultStatus.Invalid)
            {
                ValidationErrors = new List<ValidationError>()
                {
                    new ValidationError(id,message)
                }
            };
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'TK_Invalid' passing a collection of validation error
        /// </summary>
        /// <param name="validationErrors">Collection of validation errors related to token validation</param>
        /// <returns>New Result of T</returns>
        public static new ResultOf<T> InvalidToken(IEnumerable<ValidationError> validationErrors)
        {
            return new ResultOf<T>(ResultStatus.Tk_Invalid)
            {
                ValidationErrors = validationErrors.ToList()
            };
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'TK_Invalid' passing a collection of validation error
        /// </summary>
        /// <param name="id">Id of the field/property this validation error relates to</param>
        /// <param name="message">Details of the validation error</param>
        /// <returns>New Result of T</returns>
        public static new ResultOf<T> InvalidToken(string id, string message)
        {
            return new ResultOf<T>(ResultStatus.Tk_Invalid)
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
        public static new ResultOf<T> Error(string error)
        {
            return new ResultOf<T>(ResultStatus.Error)
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
        public static new ResultOf<T> Error(IEnumerable<string> errors)
        {
            return new ResultOf<T>(ResultStatus.Error)
            {
                Errors = errors.ToList()
            };
        }

     
        public static new ResultOf<T> Deleted(string key)
        {
            return new ResultOf<T>(ResultStatus.Db_Deleted)
            {
                ValidationErrors = new List<ValidationError>() { new ValidationError(key, $"Entity with Id '{key}' has been deleted from the backing store")  }
            };
        }

        public static new ResultOf<T> Modified(IEnumerable<ValidationError> validationErrors)
        {
            return new ResultOf<T>(ResultStatus.Db_Modified)
            {
                ValidationErrors = validationErrors.ToList()
            };
        }

        public static new ResultOf<T> NoContent()
        {
            return new ResultOf<T>(ResultStatus.NoContent);
        }


        public static new ResultOf<T> AuthLocked(string error)
        {
            return new ResultOf<T>(ResultStatus.Auth_Locked)
            {
                Errors = new List<string>()
                {
                    error
                }
            };
        }

        public static new ResultOf<T> AuthUnverified(string error)
        {
            return new ResultOf<T>(ResultStatus.Auth_Unverified)
            {
                Errors = new List<string>()
                {
                    error
                }
            };
        }

        public static new ResultOf<T> AuthTwoFactorFailed(string error)
        {
            return new ResultOf<T>(ResultStatus.Auth_TwoFactor)
            {
                Errors = new List<string>()
                {
                    error
                }
            };
        }

        public static new ResultOf<T> AuthPasswordFailed(string error)
        {
            return new ResultOf<T>(ResultStatus.Auth_Password)
            {
                Errors = new List<string>()
                {
                    error
                }
            };
        }

        /// <summary>
        /// Allows the details of one ResultOf instance to be copied and returned into another
        /// of a different type. Status,Errors and ValidationErrors are copied.
        /// </summary>
        /// <typeparam name="Y"></typeparam>
        /// <param name="resultToCopy"></param>
        /// <returns></returns>
        public static ResultOf<T> FromResult(IResult resultToCopy)
        {
            return new ResultOf<T>(resultToCopy.Status)
            {
                Errors = resultToCopy.Errors,
                ValidationErrors = resultToCopy.ValidationErrors
            };
        }

       
    }
}