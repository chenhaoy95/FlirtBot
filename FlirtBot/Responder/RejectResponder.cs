using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using java.util;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FlirtBot.Responder
{
    public class RejectResponder
    {

        public string Respond(string message)
        {
            return message;
        }
        public async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);



            Dictionary<string, string> body = new Dictionary<string, string>()
            {
                {"language", "en"},
                {"id", "1" },
                {"text", "i like watermelons and i don't know why i just said that" }

            };
            List<Dictionary<string, string>> body_list = new List<Dictionary<string, string>>()
            {
                body,
            };
            var final_body = new Dictionary<string, List<Dictionary<string, string>>>()
            {
                {"documents",  body_list},
            };
            string json = JsonConvert.SerializeObject(final_body);




            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Resources.Constants.TextAnalyticsSubscriptionKey);

            var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(json);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

            var c = await response.Content.ReadAsStringAsync();
            /*
            dynamic data = JObject.Parse(c);
            var data1 = data.documents;
            var data2 = data1[0];
            var data3 = data2.keyPhrases;
            var data4 = data3[0];
            
            var test = "test"; */

            dynamic data = JObject.Parse(c);
            string documents = data["documents"][0]["keyPhrases"][0];
            Debug.WriteLine("The answer is " + documents);
            //Debug.WriteLine(data.documents[0].keyPhrases[0]);

            /*
            var resDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(c);
            


            var keyPhrasesDict = resDict["documents"];

            var resList = JsonConvert.DeserializeObject<List<string>>(keyPhrasesDict);

            var result = resList[0];
            */
            //Debug.WriteLine(result);

        }

    }
}