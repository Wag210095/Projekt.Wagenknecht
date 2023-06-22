namespace Project1.Exceptions
{
    public class SongRepositoryDeleteException : Exception
    {

        public SongRepositoryDeleteException()
            : base()
        { }

        public SongRepositoryDeleteException(string message)
            : base(message)
        { }

        public SongRepositoryDeleteException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
