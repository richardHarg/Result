---
OVERVIEW

---

Library is used to provide a way to return complex results from Methods.

---
USAGE

Result or ResultOf<T> should be used as the Method return type, Return where NO data is required and ResultOf<T> when return data of type T is required. This has been nested within a Task<> return type for async Methods.

Both classes contains a status (default success) as well as a collection of validation errors and collection of general errors. Depending on the statis set these collections are populated and give information on the error/s encountered during the Method.

A Number of static Methods can be called on Result/ResultOf to create a return object with the desired status/errors, these are detailed below.

---
CLASSES

---

Both Result and ResultOf expose the below Properties:

ResultStatus Status - Defaults to the Success value of the ResultStatus Enum below.

	public enum ResultStatus
    {
        Success,
        NotFound,
        Invalid,
        Error,
        Db_Deleted,
        Db_Modified,
        Tk_Invalid,
        NoContent
    }

List<ValidationError> ValidationErrors - List of any validation errors assocated with the result. The ValidationError class consists of the below Properties:

        /// <summary>
        /// Id/name of the property/field this validation error relates to
        /// </summary>
        public readonly string Id;
        /// <summary>
        /// Details of the error message associated with this validation error
        /// </summary>
        public readonly string Message;

List<string> Errors - List of any general errors associated with the result.

---

METHODS

---

Method: Success()

Parameters: n/a

Applies To: Result

Details: 

Creates a new Result instance with the status of 'Success'

Example:

	Result ReturnResult()
	{
		// Method work...

		return Result.Success();
	}

---

Method: Success(T value)

Parameters: Instance of Type T

Applies To: ResultOf<T>

Details: 

Creates a new ResultOf<T> instance with the status of 'Success' and sets the value to the provided parameter.

Example:

	ResultOf<MyClass> ReturnResultOf()
	{
		// Method work...

		var returnValue = new MyClass();

		return ResultOf<MyClass>.Success(returnValue);
	}

---

Method: NotFound()

Parameters: n/a

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'NotFound', used when a required resource cannot be located

Example:

	Result DoWorkWhichRequiresUserExists(string userId)
	{
		User user = GetUserById(userId);

		if (user == null)
		{
			return Result.NotFound();
		}

		// Method work...

		return Result.Success();
	}

---














Utility classes to allow for more complex return information from methods.

USAGE
For a method which returns bool use 'Result' class.

e.g. public bool DoSomethingAndReturnResult() == public Result DoSomethingAndReturnResult()

For a method which return an object use 'ResultOf T' where T = the type of object being returned.

e.g. public myClass DoSomethingAndReturnInstanceOfMyClass() == public ResultOf<myClass> DoSomethingAndReturnInstanceOfMyClass()

---------------------------------
   
Both Result and ResultOf can be created using the below static methods:

RESULTOF SPECIFIC:

Method: Success(T Value)
   
ProducesStatus: ResultStatus.Success
   
Parameters: Object of T which is returned along with the result
   
Result: A new instance of ResultOf is returned with the above status, indicates the task this result represents completed OK. The returned value can be accessed 
via the 'Value' property. 

RESULT SPECIFIC:

Method: Success()
   
ProducesStatus: ResultStatus.Success
   
Parameters: n/a
   
Result: A new instance of Result is returned with the above status, indicates the task this result represents completed OK.

GENERAL:

Method: NotFound()
   
ProducesStatus: ResultStatus.NotFound
   
Parameters: n/a
   
Result: A new instance of Result/ResultOf is returned with the above status and no additional errors.

---------------------------------
   
Method: NoContent()
   
ProducesStatus: ResultStatus.NoContent
   
Parameters: n/a
   
Result: A new instance of Result/ResultOf is returned with the above status and no additional errors.

---------------------------------
   
Method: Invalid(List<ValidationError> validationErrors)
   
ProducesStatus: ResultStatus.Invalid
   
Parameters:  A list of validation errors
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 

---------------------------------
   
Method: Invalid(string id, string message)
   
ProducesStatus: ResultStatus.Invalid
   
Parameters:  A key value and message which is parsed into a ValidationError and added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 

---------------------------------
   
Method: Error(params string[] errors)
   
ProducesStatus: ResultStatus.Error
   
Parameters:  An array of error strings which are added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, general errors can be accessed via the 'Errors' property.

---------------------------------
   
Method: Error(string error)
   
ProducesStatus: ResultStatus.Error
   
Parameters:  A single error message which is added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, general errors can be accessed via the 'Errors' property.
   
---------------------------------

TOKEN SPECIFIC:
  
Method: InvalidToken(List<ValidationError> validationErrors)
   
ProducesStatus: ResultStatus.Tk_Invalid
   
Parameters:  A list of validation errors
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 

---------------------------------
   
Method: InvalidToken(string id, string message)
   
ProducesStatus: ResultStatus.Tk_Invalid
   
Parameters:  A key value and message which is parsed into a ValidationError and added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 
  
---------------------------------
  
DATABASE CONCURRENCY ENTITY SPECIFIC:
  
Method: Deleted(string key)
   
ProducesStatus: ResultStatus.Db_Deleted
   
Parameters:  The Key value of the database object which no longer exists which is parsed into a ValidationError and added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 
  
---------------------------------
   
Method: Modified(List<ValidationError> validationErrors)
   
ProducesStatus: ResultStatus.Db_Modified
   
Parameters: A list of validation errors
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property.
 
