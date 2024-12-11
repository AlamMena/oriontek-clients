using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontekClientsServer.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public int Code { get; }

        public DomainException(string message, int code) : base(message) => Code = code;
    }
}
