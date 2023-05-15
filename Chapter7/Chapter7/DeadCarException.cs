using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7
{
    public class DeadCarException : ApplicationException
    {
        //readonly 
        public string _Message { get; private set; } = string.Empty;
        public DateTime TimeStamp { get; set; }
        public string CauseError { get; set; }

        public Exception InnerException { get; set; }
        public DeadCarException() { }
        public DeadCarException(string message, string cause, DateTime timestamp) { 
            this._Message = message;
            this.TimeStamp = timestamp;
            this.CauseError = cause;
        }
        public DeadCarException(string message, string cause, DateTime timestamp, Exception e)
            : this (message, cause, timestamp)
        {
            this.InnerException = e;
        }


        public override string Message => $"Car Error Message => {this._Message + this.CauseError + this.TimeStamp.ToString()}";
    }
}
