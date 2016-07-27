using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using java.util;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;

namespace FlirtBot.Responder
{
    public class RejectResponder
    {

        public string Respond(string message)
        {
            return message;
        }
        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{" + Resources.Constants.TextAnalyticsSubscriptionKey + "}");

            var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("<application/json>");
                response = await client.PostAsync(uri, content);
            }

        }

    }
}