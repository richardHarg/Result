using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLH.Results
{
    public interface IResult
    {
        ResultStatus Status { get; }
        List<ValidationError> ValidationErrors { get; }
        List<string> Errors { get; }
    }
}
