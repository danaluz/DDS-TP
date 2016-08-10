using System;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

namespace DDSTP.Proxies
{
    public class EmailProxy : IEmailProxy
    {
        public void SendToAdmin(string subject, string content)
        {
            var result = SendSimpleMessage(subject, content);

            if (result.StatusCode != HttpStatusCode.OK)
                throw new Exception("EmailException (See inner exception)", result.ErrorException);
        }

        /*
         * TODO: remove this comments
         * https://mailgun.com/
         * eci_white@hispavista.com
         * Alt------5
         */

        private IRestResponse SendSimpleMessage(string subject, string content)
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator = new HttpBasicAuthenticator("api", "key-b91bdbfbdd798ed754c2f7b6b8c8ee1d")
            };
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox2f36c1d3e8ea4eeb9529b8f5dee43f16.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "<eci_white@hispavista.com>");
            request.AddParameter("to", "<eci_white@hispavista.com>");
            request.AddParameter("subject", subject);
            request.AddParameter("text", content);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}
