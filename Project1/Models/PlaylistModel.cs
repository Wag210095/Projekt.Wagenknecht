using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Project1.Models
{
    public class PlaylistModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [AllowNull]
        public String? CreationDate { get; set; }
        [AllowNull]
        public String? UpdateDate { get; set; }

        public List<SongModel> _songs = new();
        public virtual IReadOnlyList<SongModel> Songs => _songs;

        protected PlaylistModel()
        { }
        public PlaylistModel(string name, string creationDate)
        {
            Name = name;
            CreationDate = creationDate;
        }

        public PlaylistModel(int id, string name, string updateDate)
        {
            Name = name;
            UpdateDate = updateDate;
        }
    }
}
