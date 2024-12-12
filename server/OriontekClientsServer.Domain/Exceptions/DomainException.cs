using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public int ErrorCode { get; set; }
        public DomainException() : base()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public DomainException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
