
namespace RLH.Results
{
    public interface IResultOf<T> : IResult
    {
        T Value { get; }
    }
}
