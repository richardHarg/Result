
namespace RLH.Result
{
    public interface IResultOf<T> : IResult
    {
        T Value { get; }
    }
}
