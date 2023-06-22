namespace Project1.Exceptions
{
    public class DeletePlaylistServiceException : Exception
    {
        public DeletePlaylistServiceException() 
            :base()
        { }

        public DeletePlaylistServiceException(string message)
            : base(message)
        { }

        public DeletePlaylistServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
