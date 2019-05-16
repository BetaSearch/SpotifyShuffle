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

            //simpleAuthorize(_clientId, _secretId);


            AuthorizationCodeAuth auth =
                new AuthorizationCodeAuth(_clientId, _secretId, "https://www.google.com", "https://www.google.com",
                    Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative);
            auth.AuthReceived += (sender, payload) =>
            {

                auth.Stop();
                Token token = auth.ExchangeCode(payload.Code);
                api = new SpotifyWebAPI() { TokenType = token.TokenType, AccessToken = token.AccessToken };

            };
            auth.Start(); // Starts an internal HTTP Server
            auth.OpenBrowser();
        }




        async void simpleAuthorize(string clientId, string secretId)
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
