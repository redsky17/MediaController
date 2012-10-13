using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTunesLib;

namespace MediaController
{
    class iTunesPlayer : IPlayer
    {
        delegate void Router(object arg);
        iTunesAppClass iTunes;

        public Dictionary<int, string> GetTracks()
        {
            Dictionary<int, string> tracks = new Dictionary<int, string>();

            var curPlaylist = iTunes.LibraryPlaylist;
            IITTrackCollection playlistTracks = curPlaylist.Tracks;

            foreach (IITTrack track in playlistTracks)
            {
                tracks.Add(track.trackID, track.Name);
            }

            return tracks;
        }

        public List<string> GetArtists()
        {
            throw new NotImplementedException();
        }

        public List<string> GetPlaylists()
        {
#if DEBUG
            Console.WriteLine("Getting library playlists.");
#endif
            List<string> playlists = new List<string>();

            var libraryPlaylists = iTunes.LibrarySource.Playlists;

            foreach (IITPlaylist pList in libraryPlaylists)
            {
                playlists.Add(pList.Name);
            }

            return playlists;
        }

        public List<string> GetAlbums()
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> GetPlaylistTracks(string playlist)
        {
#if DEBUG
            Console.WriteLine("Getting tracks on playlist " + playlist);
#endif
            Dictionary<int, string> tracks = new Dictionary<int, string>();

            var curPlaylist = iTunes.LibrarySource.Playlists.get_ItemByName(playlist);
            IITTrackCollection playlistTracks = curPlaylist.Tracks;

            foreach (IITTrack track in playlistTracks)
            {
                tracks.Add(track.trackID, track.Name);
            }

            return tracks;
        }

        public iTunesPlayer()
        {
#if DEBUG
            Console.WriteLine("Registering iTunes...");
#endif
            iTunes = new iTunesAppClass();
            this.RegisterEvents();
#if DEBUG
            Console.WriteLine("Done registering");
#endif
        }

        private void RegisterEvents()
        {
            iTunes.OnPlayerPlayEvent += iTunes_OnPlayerPlayEvent;
        }

        void iTunes_OnPlayerPlayEvent(object iTrack)
        {
            var track = iTrack as IITTrack;
            this.WriteTrackToConsole(track);
        }


        public void Play(string trackName)
        {
            var curPlaylist = iTunes.LibraryPlaylist;
            IITTrackCollection playlistTracks = curPlaylist.Tracks;

            IITTrack track = playlistTracks.get_ItemByName(trackName);

            this.WriteTrackToConsole(track);
            track.Play();
        }


        public void PlayFromPlaylist(int trackID, string playlist)
        {
            var curPlaylist = iTunes.LibrarySource.Playlists.get_ItemByName(playlist);
            IITTrackCollection playlistTracks = curPlaylist.Tracks;
            IITTrack track = playlistTracks[trackID];

            this.WriteTrackToConsole(track);
            track.Play();
        }

        private void WriteTrackToConsole(IITTrack track)
        {
            Console.WriteLine(string.Format("Playing: {0} by {1} on {2}", track.Name, track.Artist, track.Album));
        }
    }
}
