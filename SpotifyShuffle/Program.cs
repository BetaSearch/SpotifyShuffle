using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace SpotifyShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            Session session = new Session();


            string userInput = "";
            do
            {
                Console.WriteLine("Enter a command");
                userInput = Console.ReadLine();

                if (userInput == "play")
                {
                    SearchItem item = Session.api.SearchItems("roadhouse+blues", SearchType.Album | SearchType.Playlist);
                    Console.WriteLine(item.Albums.Total); //How many results are there in total? NOTE: item.Tracks = item.Artists 
                }


            } while (userInput != "q");

        }
    }
}

