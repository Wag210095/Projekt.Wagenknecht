namespace Project1.Exceptions
{
    public class SongRepositoryCreateException : Exception
    {

        public SongRepositoryCreateException()
            : base()
        { }

        public SongRepositoryCreateException(string message)
            : base(message)
        { }

        public SongRepositoryCreateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
