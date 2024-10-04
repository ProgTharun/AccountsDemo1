using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsDemo1.Model
{
    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message) { }

    }

    public class MinimumBalanceException : Exception
    {
        public MinimumBalanceException(string message) : base(message) { }
    }

    public class MustBePositiveException : Exception
    {
        public MustBePositiveException(string message) : base(message) { }
    }
}

