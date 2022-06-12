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
RESULT/RESULTOF

---

Both Result and ResultOf expose the below Properties:

        /// <summary>
        /// Status of the Result
        /// </summary>
        public ResultStatus Status { get; protected set; }; // Default to 'ResultStatus.Success'
        /// <summary>
        /// List of ValidationErrors related to this Result
        /// </summary>
        public List<ValidationError> ValidationErrors { get; protected set; };
        /// <summary>
        /// List of general errors related to this Result
        /// </summary>
        public IEnumerable<string> Errors { get; protected set; };

---
RESULTSTATUS ENUM

---

Holds values which represent the status of the returned Result/ResultOf class.

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

---
VALIDATIONERROR

---

Holds details of a validation error related to a specific value (Id).

     /// <summary>
     /// Id/name of the property/field this validation error relates to
     /// </summary>
     public readonly string Id;
     /// <summary>
     /// Details of the error message associated with this validation error
     /// </summary>
     public readonly string Message;
       

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

Method: Invalid(IEnumerable<ValidationError> validationErrors)

Parameters: Collection of validationErrors associated with the result

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'Invalid'. Details can be accessed via the 'ValidationErrors' property of the returned result.

Example:

	Result DoWorkWhichRequiresValidation(string email,string age)
	{
        var validationErrors = new List<ValidationError>();

        if (EmailInUse(email) == true)
        {
            validationErrors.Add(new ValidationError("email","The email provided is already in use."));
        }
        if (age < 18)
        {
            validationErrors.Add(new ValidationError("age","You must be over 18 to use this service."));
        }
		
        if (validationErrors.Any() == true)
        {
            return Result.Invalid(validationErrors)
        }

		// Method work...

		return Result.Success();
	}

---

Method: Invalid(string id,string message)

Parameters: Details of a single validation error associated with the Result

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'Invalid'. Details can be accessed via the 'ValidationErrors' property of the returned result.

Example:

	Result DoWorkWhichRequiresValidation(string email)
	{
        if (EmailInUse(email) == true)
        {
            return Result.Invalid("email","The email provided is already in use.");
        }
        
		// Method work...

		return Result.Success();
	}

---

Method: InvalidToken(IEnumerable<ValidationError> validationErrors)

Parameters: Collection of validationErrors associated with the result

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'Tk_Invalid'. Details can be accessed via the 'ValidationErrors' property of the returned result. This should be used when specific action is required when a token is invalid as opposed to any general validation error.

Example:

	Result DoWorkWhichRequiresValidToken(string token)
	{
        var validationErrors = new List<ValidationError>();

        if (TokenIsCurrent(token)== false)
        {
            validationErrors.Add(new ValidationError("token","Out of date token."));
        }
        if (TokenAudienceValid(token) == false)
        {
            validationErrors.Add(new ValidationError("token","Invalid token audience"));
        }
		
        if (validationErrors.Any() == true)
        {
            return Result.InvalidToken(validationErrors)
        }

		// Method work...

		return Result.Success();
	}

---

Method: InvalidToken(string id,string message)

Parameters: Details of a single validation error associated with the Result

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'Tk_Invalid'. Details can be accessed via the 'ValidationErrors' property of the returned result. This should be used when specific action is required when a token is invalid as opposed to any general validation error.

Example:

	Result DoWorkWhichRequiresValidToken(string token)
	{
        if (TokenIsCurrent(token)== false)
        {
            return Result.InvalidToken("token","Out of date token.");
        }
       
		// Method work...

		return Result.Success();
	}

---

Method: Error(string error)

Parameters: Details of a single error associated with the Result

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'Error'. Details can be accessed via the 'Errors' property of the returned result.

Example:

	Result DoWorkWhichCouldError()
	{
        if (SomeConditionWhichCouldFail == false)
        {
            return Result.Error("Details of a general error go here");
        }
       
		// Method work...

		return Result.Success();
	}

---

Method: Error(IEnumerable<string> errors)

Parameters: Collection of general errors associated with this Result

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'Error'. Details can be accessed via the 'Errors' property of the returned result.

Example:

	Result DoWorkWhichCouldError()
	{
        var errors = new List<string>();

        if (SomeConditionWhichCouldFail() == false)
        {
            errors.Add("Details of a general error go here");
        }
       
        if (AnotherPossibleError() == false)
        {
            errors.Add("Details of another general error go here");
        }

        if (errors.Any() == true)
        {
           return Result.Error(errors);
        }


		// Method work...

		return Result.Success();
	}

---

Method: Deleted(string key)

Parameters: The primary key value of the database object which has been deleted

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'Db_Deleted'. Details can be accessed via the 'Errors' property of the returned result. This is used when managing database concurrency operations.

Example:

	Result DoWorkWithDatabase(MyClass value)
	{
        try
        {
            SomeDatabaseOperation(value);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            var databaseEntry = exceptionEntry.GetDatabaseValues();

            // If there is no Db entry then the entity was deleted
            if (databaseEntry == null)
            {
                return Result.Deleted(value.Id);
            }
        }

		// Method work...

		return Result.Success();
	}

---

Method: Modified(IEnumerable<ValidationError> validationErrors)

Parameters: Collection of Validation errors associated with this result

Applies To: Result/ResultOf

Details: 

Creates a new Result instance with the status of 'Db_Modified'. Details can be accessed via the 'ValidationErrors' property of the returned result. This is used when managing database concurrency operations where a db entity has been updated.

Example:

	Result DoWorkWithDatabase(MyClass entity)
	{
        try
        {
            SomeDatabaseOperation(value);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            var databaseEntry = exceptionEntry.GetDatabaseValues();

            // If there is no Db entry then the entity was deleted
            if (databaseEntry == null)
            {
                return Result.Deleted(value.Id);
            }
            else
            {
                // Get the current values from the Database
                var databaseValues = (User)databaseEntry.ToObject();

                var updateResult = new List<ValidationError>();

                if (databaseValues.Email != entity.Email)
                {
                    updateResult.Add(new ValidationError("Email", $"Field 'Email' updated by 3rd party. Current value '{databaseValues.Email}'"));
                }
                
                if (databaseValues.PasswordHash != entity.PasswordHash)
                {
                    updateResult.Add(new ValidationError("PasswordHash", $"Field 'PasswordHash' updated by 3rd party."));
                }

                return Result.Modified(updateResult);
            }

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
 
