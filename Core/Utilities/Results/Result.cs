using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result:IResult 
    {
        public Result(bool success, string messege) :this(success)
        {
            Messege = messege;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Messege { get; }
    }
}
