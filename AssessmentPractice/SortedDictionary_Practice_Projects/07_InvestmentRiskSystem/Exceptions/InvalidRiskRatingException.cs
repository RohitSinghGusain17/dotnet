using System;

namespace Exceptions
{
    public class InvalidRiskRatingException : Exception
    {
        public InvalidRiskRatingException(string message) : base(message) { }
    }
}
