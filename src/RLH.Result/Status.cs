using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLH.Results
{
    /// <summary>
    /// Details of various states a Result instance can be returned in
    /// </summary>
    public enum ResultStatus
    {
        Success,
        NotFound,
        Invalid,
        Error,
        Db_Deleted,
        Db_Modified,
        Tk_Invalid,
        NoContent,
        Auth_Locked,
        Auth_Unverified,
        Auth_TwoFactor,
        Auth_Password
    }
}
