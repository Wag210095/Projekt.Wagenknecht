namespace Project1.Exceptions
{
    public class AddSongsToPlaylistServiceException : Exception
    {
        public AddSongsToPlaylistServiceException() 
            :base()
        { }

        public AddSongsToPlaylistServiceException(string message)
            : base(message)
        { }

        public AddSongsToPlaylistServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
