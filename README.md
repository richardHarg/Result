Utility classes to allow for more complex return information from methods.

USAGE
For a method which returns bool use 'Result' class.

e.g. public bool DoSomethingAndReturnResult() == public Result DoSomethingAndReturnResult()

For a method which return an object use 'ResultOf T' where T = the type of object being returned.

e.g. public myClass DoSomethingAndReturnInstanceOfMyClass() == public ResultOf<myClass> DoSomethingAndReturnInstanceOfMyClass()

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

   
Method: Invalid(List<ValidationError> validationErrors)
   
ProducesStatus: ResultStatus.Invalid
   
Parameters:  A list of validation errors
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 

   
Method: Invalid(string id, string message)
   
ProducesStatus: ResultStatus.Invalid
   
Parameters:  A key value and message which is parsed into a ValidationError and added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 

   
Method: Error(params string[] errors)
   
ProducesStatus: ResultStatus.Error
   
Parameters:  An array of error strings which are added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, general errors can be accessed via the 'Errors' property.

   
Method: Error(string error)
   
ProducesStatus: ResultStatus.Error
   
Parameters:  A single error message which is added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, general errors can be accessed via the 'Errors' property.
   

TOKEN SPECIFIC:
  
Method: InvalidToken(List<ValidationError> validationErrors)
   
ProducesStatus: ResultStatus.Tk_Invalid
   
Parameters:  A list of validation errors
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 

   
Method: InvalidToken(string id, string message)
   
ProducesStatus: ResultStatus.Tk_Invalid
   
Parameters:  A key value and message which is parsed into a ValidationError and added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 
  
  
DATABASE CONCURRENCY ENTITY SPECIFIC:
  
Method: Deleted(string key)
   
ProducesStatus: ResultStatus.Db_Deleted
   
Parameters:  The Key value of the database object which no longer exists which is parsed into a ValidationError and added to the internal collection
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property. 
  
   
Method: Modified(List<ValidationError> validationErrors)
   
ProducesStatus: ResultStatus.Db_Modified
   
Parameters: A list of validation errors
   
Result: A new instance of Result/ResultOf is returned with the above status, validation errors can be accessed via the 'ValidationErrors' property.
 
