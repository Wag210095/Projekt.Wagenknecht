namespace Project1.Exceptions
{
    public class PlaylistRepositoryCreateException : Exception
    {

        public PlaylistRepositoryCreateException()
            : base()
        { }

        public PlaylistRepositoryCreateException(string message)
            : base(message)
        { }

        public PlaylistRepositoryCreateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
