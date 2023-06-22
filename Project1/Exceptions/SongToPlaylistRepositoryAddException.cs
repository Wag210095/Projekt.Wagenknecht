namespace Project1.Exceptions
{
    public class SongToPlaylistRepositoryAddException : Exception
    {
        public SongToPlaylistRepositoryAddException()
            : base()
        { }

        public SongToPlaylistRepositoryAddException(string message)
            : base(message)
        { }

        public SongToPlaylistRepositoryAddException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
