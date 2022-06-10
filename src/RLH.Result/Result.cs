using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLH.Result
{
    public class Result : IResult
    {
        /// <summary>
        /// Private constructor passing through a status
        /// </summary>
        /// <param name="status">Status to set new Result to</param>
        protected Result(ResultStatus status)
        {
            Status = status;
        }



        /// <summary>
        /// Status of the Result
        /// </summary>
        public ResultStatus Status { get; protected set; } = ResultStatus.Success;
        /// <summary>
        /// List of ValidationErrors related to this Result
        /// </summary>
        public List<ValidationError> ValidationErrors { get; protected set; } = new List<ValidationError>();
        /// <summary>
        /// List of general errors related to this Result
        /// </summary>
        public IEnumerable<string> Errors { get; protected set; } = new List<string>();


        /// <summary>
        /// Creates a new Result of T with a status of 'Success' passing through the return object
        /// </summary>
        /// <param name="value">Object of type T to return</param>
        /// <returns>New Result of T</returns>
        public static Result Success()
        {
            return new Result(ResultStatus.Success);
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'NotFound' for when an entity cannot be located
        /// </summary>
        /// <returns>New Result of T</returns>
        public static Result NotFound()
        {
            return new Result(ResultStatus.NotFound);
        }

        /// <summary>
        /// Creates a new Result of T with a status of 'Invalid' passing a list of validation errors
        /// </summary>
        /// <param name="validationErrors">List of validation Errors linked to this request</param>
        /// <returns>New Result of T</returns>
        public static Result Invalid(List<ValidationError> validationErrors)
        {
            return new Result(ResultStatus.Invalid)
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
        public static Result Invalid(string id, string message)
        {
            return new Result(ResultStatus.Invalid)
            {
                ValidationErrors = new List<ValidationError>()
                {
                    new ValidationError(id,message)
                }
            };
        }

        public static Result InvalidToken(List<ValidationError> validationErrors)
        {
            return new Result(ResultStatus.Tk_Invalid)
            {
                ValidationErrors = validationErrors
            };
        }

        public static Result InvalidToken(string id, string message)
        {
            return new Result(ResultStatus.Tk_Invalid)
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
        public static Result Error(string error)
        {
            return new Result(ResultStatus.Error)
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
        public static Result Error(params string[] errors)
        {
            return new Result(ResultStatus.Error)
            {
                Errors = errors
            };
        }

        public static Result Deleted(string key)
        {
            return new Result(ResultStatus.Db_Deleted)
            {
                ValidationErrors = new List<ValidationError>() { new ValidationError(key, $"Entity with Id '{key}' has been deleted from the backing store") }
            };
        }

        public static Result Modified(List<ValidationError> validationErrors)
        {
            return new Result(ResultStatus.Db_Modified)
            {
                ValidationErrors = validationErrors
            };
        }
    }
}
