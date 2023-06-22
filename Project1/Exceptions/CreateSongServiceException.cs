namespace Project1.Exceptions
{
    public class CreateSongServiceException : Exception
    {
        public CreateSongServiceException() 
            :base()
        { }

        public CreateSongServiceException(string message)
            : base(message)
        { }

        public CreateSongServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
