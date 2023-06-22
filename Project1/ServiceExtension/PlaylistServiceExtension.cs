using Project1.Interfaces;

namespace Project1.ServiceExtension
{
    public static class PlaylistServiceExtension
    {

        public static IReadOnlyPlaylistService UseFilterContainsName(this IReadOnlyPlaylistService service, string filter)
        {
            // Filterlogik
            if (!string.IsNullOrEmpty(filter))
            {
                service.Playlists = service
                    .Playlists
                    .Where(p => p.Name.ToLower().Contains(filter.ToLower()));
            }
            return service;
        }
    }
}
