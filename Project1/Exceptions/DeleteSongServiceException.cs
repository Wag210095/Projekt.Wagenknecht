namespace Project1.Exceptions
{
    public class DeleteSongServiceException : Exception
    {
        public DeleteSongServiceException() 
            :base()
        { }

        public DeleteSongServiceException(string message)
            : base(message)
        { }

        public DeleteSongServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
