using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace SpotifyShuffle
{

    public class Session
    {
        private string _clientId { get; set; }
        private string _secretId { get; set; }
        public static SpotifyWebAPI api { get; set; }

        public Session()
        {
            _clientId = "331d6d1fc4994d70b74b98e2142527fb";
            _secretId = "5c315164a2d444cd98a8da8b4aa7b000"; //evil dangerous way

            authorize(_clientId, _secretId);

            //ImplicitGrantAuth auth =
            //new ImplicitGrantAuth(_clientId, "http://google.com", "http://google.com", Scope.UserReadPrivate);
            //auth.AuthReceived += (sender, payload) =>
            //{
            //    auth.Stop(); // `sender` is also the auth instance
            //    api = new SpotifyWebAPI() { TokenType = payload.TokenType, AccessToken = payload.AccessToken };
            //    // Do requests with API client
            //};
            //auth.Start(); // Starts an internal HTTP Server
            //auth.OpenBrowser();
        }

        async void authorize(string clientId, string secretId)
        {
            CredentialsAuth auth = new CredentialsAuth(_clientId, _secretId);
            Token token = await auth.GetToken();
            api = new SpotifyWebAPI() { TokenType = token.TokenType, AccessToken = token.AccessToken };
        }

         ~Session()
        {

        }
    }
}
