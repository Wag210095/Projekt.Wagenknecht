namespace Project1.Dtos
{
    public class SelectableSongDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ReleaseYear { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public bool Selected { get; set;} = false;

    }
}
