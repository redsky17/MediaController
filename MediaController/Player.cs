using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediaController
{
    /// <summary>
    /// Provides a base class that defines functions used for any media player
    /// </summary>
    public interface IPlayer
    {
        // public void InitPlayer();
        Dictionary<int, string> GetTracks();
        List<string> GetArtists();
        List<string> GetPlaylists();
        List<string> GetAlbums();
        Dictionary<int, string> GetPlaylistTracks(string playlist);
        void Play(string trackName);
        void PlayFromPlaylist(int trackID, string playlist);
    }
}
