using System.Runtime.Serialization;

namespace Project.Exceptions
{
    [Serializable]
    internal class StudentIdNotExistException : Exception
    {
        public StudentIdNotExistException()
        {
        }

        public StudentIdNotExistException(string? message) : base(message)
        {
        }

        public StudentIdNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StudentIdNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}