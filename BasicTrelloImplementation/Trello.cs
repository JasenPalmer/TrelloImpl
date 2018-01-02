using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BasicTrelloImplementation
{
    public class Trello
    {

        static HttpClient client = new HttpClient();

        private static string ApiKey = "9d3650d4ae55443c1d6463162016e691";

        public static Uri BaseUrl = new Uri("https://api.trello.com/1/");

        public static List<Models.Board> Boards { get; private set; }
        public static List<Models.Card> Cards { get; private set; }

        public static string Token { get; set; }

        public static bool CommentAdded { get; private set; }

        public static async Task LoadBoards()
        {
            Boards = new List<Models.Board>();
            if (String.IsNullOrEmpty(Token))
            {
                Console.Error.WriteLine("Token has not been set");
                return;
            }

            HttpResponseMessage response = await client.GetAsync(BaseUrl + "members/me?boards=all&fields=id,name,desc,descData,closed&key=" + ApiKey + "&token=" + Token);
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                //format json string
                int start = json.IndexOf("\"boards\":");
                start += 9;
                int newLength = json.Length - start-1;
                json = json.Substring(start,newLength);

                //convert json into list of model.Board objects
                Boards = JsonConvert.DeserializeObject<List<Models.Board>>(json);
            }else
            {
                Console.Error.WriteLine("Failed to load boards");
            }
        }

        public static async Task LoadCards(string boardId)
        {
            Cards = new List<Models.Card>();
            if (String.IsNullOrEmpty(Token))
            {
                Console.Error.WriteLine("Token has not been set");
                return;
            }
            if(String.IsNullOrEmpty(boardId))
            {
                Console.Error.WriteLine("boardId was not provided - cards cannot be loaded");
                return;
            }
            HttpResponseMessage response = await client.GetAsync(BaseUrl + "boards/" + boardId + "?cards=all&fields=id,name&key=" + ApiKey + "&token=" + Token);
            if(response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();

                //format json string
                int start = json.IndexOf("\"cards\":");
                start += 8;
                int newLength = json.Length - start - 1;
                json = json.Substring(start, newLength);

                Cards = JsonConvert.DeserializeObject<List<Models.Card>>(json);
            } else
            {
                Console.Error.WriteLine("Failed to get cards for board");
            }
        }

        public static async Task AddComment(string id, string comment)
        {
            CommentAdded = false;
            if(comment == null)
            {
                Console.Error.WriteLine("Comment cannot be null value");
                return;
            }
            if(String.IsNullOrEmpty(id))
            {
                Console.Error.WriteLine("Id has not been set - must be set when adding comment");
                return;
            }
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("text", comment)
            });

            HttpResponseMessage response = await client.PostAsync(BaseUrl + "cards/" + id + "/actions/comments?key=" + ApiKey + "&token=" + Token + "&text=" + comment, content);
            if(response.IsSuccessStatusCode)
            {
                string resultContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
                CommentAdded = true;
            }else
            {
                Console.Error.WriteLine("Failed to post comment");
            }
        }

    }
}
