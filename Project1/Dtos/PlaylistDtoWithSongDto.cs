namespace Project1.Dtos
{
    public class PlaylistDtoWithSongDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string CreationDate { get; set; } = String.Empty;
        public string UpdateDate { get; set; } = String.Empty;

        public int SongCount { get; set;}
        public List<SongDto> Songs { get; set; }  = new List<SongDto> { };

    }
}
