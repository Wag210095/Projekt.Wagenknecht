namespace Project1.Exceptions
{
    public class CreatePlaylistServiceException : Exception
    {
        public CreatePlaylistServiceException() 
            :base()
        { }

        public CreatePlaylistServiceException(string message)
            : base(message)
        { }

        public CreatePlaylistServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
