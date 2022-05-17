using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefa2.Entities.Exceptions
{
    public class ExceptionPlayGame : Exception
    {
        public ExceptionPlayGame(string message) : base(message)
        {
        }
        public ExceptionPlayGame(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
