namespace CustomerAPI.Models
//{
//    public enum ErrorType
//    {
//        INVALID_REQUEST = 400,
//        INTERNAL_ERROR = 500,
//        NOT_FOUND = 404
//    }

//    /// <summary>
//    /// Represents an error
//    /// </summary>
//    public class Error
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        public int Code { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string Description { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public ErrorType Type { get; set; }

//        public Error(ErrorType type, string description)
//        {
//            Type = type;
//            Code = (int)type;
//            Description = description;
//        }
//    }

//    public class NotFoundError : Error
//    {
//        public NotFoundError(string code, string description) : base(ErrorType.NOT_FOUND, description)
//        {
//        }
//    }

//    public class InvalidRequestError : Error
//    {
//        public InvalidRequestError(string description) : base(ErrorType.NOT_FOUND, description)
//        {
//        }
//    }

//    public class InternalError : Error
//    {
//        public InternalError(string description) : base(ErrorType.NOT_FOUND, description)
//        {
//        }
//    }
//}
{
    public class ErrorResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        { }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        { }
    }

    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message) : base(message)
        { }
    }

    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string message) : base(message)
        { }
    }
}