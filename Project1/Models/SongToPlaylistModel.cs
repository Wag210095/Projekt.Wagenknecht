using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class SongToPlaylistModel
    {

        [Key]
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }


        protected SongToPlaylistModel()
        {}

        public  SongToPlaylistModel(int playlistId, int songId)
        {
            PlaylistId = playlistId;
            SongId = songId;
        }
    }
}
