using System;

namespace NewsPortal.Data.Results
{
    public class DataWriteResult
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }

        public static DataWriteResult SuccessResult()
        {
            return new DataWriteResult { Success = true };
        }

        public static DataWriteResult FailureResult(Exception exception)
        {
            return new DataWriteResult { Success = false, Exception = exception };
        }
    }
}
