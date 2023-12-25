using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;
using Google.Apis.Calendar;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;

namespace CalendarBot.Oauth
{
    public static class OauthClass
    {
        
        public static UserCredential GetAcces()
        {
            string ClientId= "856294623295-ug9i2lf7n9ipf3urj82supq8jqmokve6.apps.googleusercontent.com";
            string ClientSecret= "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";
            string[] scopes = {
                               "https://www.googleapis.com/auth/calendar" };

            UserCredential credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret,
                }, scopes, "user", CancellationToken.None).Result;
            if (credentials.Token.IsExpired(SystemClock.Default))
            {
                credentials.RefreshTokenAsync(CancellationToken.None).Wait();
            }

            return credentials;
        }
    }
}
