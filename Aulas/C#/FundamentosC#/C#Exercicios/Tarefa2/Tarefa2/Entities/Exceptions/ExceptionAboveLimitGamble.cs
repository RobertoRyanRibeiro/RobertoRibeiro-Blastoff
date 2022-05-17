using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa2.Entities.Exceptions
{
    public class ExceptionAboveLimitGamble : Exception
    {
        public ExceptionAboveLimitGamble(string message) : base(message)
        {
        }
        public ExceptionAboveLimitGamble(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
