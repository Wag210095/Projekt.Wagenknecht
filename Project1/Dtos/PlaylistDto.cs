namespace Project1.Dtos
{
    public record PlaylistDto
        (
            int Id,
            string Name,
            String? CreationDate,
            String? UpdateDate
        )
    {

        public IEnumerable<SongDto> Songs { get; init; } = new List<SongDto>();
        public int SongsCount => Songs.Count();

    }
}