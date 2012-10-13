using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaController
{
    class Program
    {
        static void Main(string[] args)
        {
            iTunesPlayer iPlayer = new iTunesPlayer();

            List<string> playlists = iPlayer.GetPlaylists();

            Dictionary<int, string> tracks = iPlayer.GetTracks();

            //foreach (string str in playlists)
            //{
            //    foreach (KeyValuePair<int, string> track in iPlayer.GetPlaylistTracks(str))
            //    {
            //        Console.WriteLine(string.Join(", ", track.Key, track.Value));
            //    }
            //}


            int trackToPlayID = 0;

            do
            {
                try
                {
                    Console.Write("Enter the number of the track you'd like to play, (-1 to quit): ");
                    trackToPlayID = Int32.Parse(Console.ReadLine());
                    iPlayer.Play(tracks[trackToPlayID]);
                }
                catch (Exception ex) { }
            }
            while (trackToPlayID != -1);

            iPlayer.PlayFromPlaylist(15569, "Music");
        }
    }
}
