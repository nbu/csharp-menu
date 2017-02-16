using System;

namespace CSharp.Console.Menu
{
    public class InvalidMenuOptionValueException : Exception
    {
        public InvalidMenuOptionValueException(string message) : base(message)
        {
        }
    }
}