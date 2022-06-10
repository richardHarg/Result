using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLH.Result
{
    public interface IResult
    {
        ResultStatus Status { get; }
        List<ValidationError> ValidationErrors { get; }
        IEnumerable<string> Errors { get; }
    }
}
