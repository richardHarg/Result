
namespace RLH.Result
{
    public interface IResult
    {
        ResultStatus Status { get; }
        List<ValidationError> ValidationErrors { get; }
        IEnumerable<string> Errors { get; }
        Object ReturnValue();
    }
}
