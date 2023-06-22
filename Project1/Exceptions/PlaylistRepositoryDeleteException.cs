namespace Project1.Exceptions
{
    public class PlaylistRepositoryDeleteException : Exception
    {

        public PlaylistRepositoryDeleteException()
            : base()
        { }

        public PlaylistRepositoryDeleteException(string message)
            : base(message)
        { }

        public PlaylistRepositoryDeleteException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
