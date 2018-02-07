using System;
using System.Diagnostics;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.BusinessLogic
{
    [DebuggerDisplay("Status: {Status}")]
    public class BusinessResult
    {
        public bool Status { get; set; }
        public int RecordsAffected { get; set; }
        public string Message { get; set; }
        public Object OperationID { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string ExceptionInnerMessage { get; set; }
        public string ExceptionInnerStackTrace { get; set; }

        public static BusinessResult CreateFromException(string message, Exception ex)
        {
            BusinessResult opStatus = new BusinessResult
                                       {
                                           Status = false,
                                           Message = message,
                                           OperationID = null
                                       };

            if (ex != null)
            {
                opStatus.ExceptionMessage = ex.Message;
                opStatus.ExceptionStackTrace = ex.StackTrace;
                opStatus.ExceptionInnerMessage = (ex.InnerException == null) ? null : ex.InnerException.Message;
                opStatus.ExceptionInnerStackTrace = (ex.InnerException == null) ? null : ex.InnerException.StackTrace;
            }
            return opStatus;
        }
    }
}
