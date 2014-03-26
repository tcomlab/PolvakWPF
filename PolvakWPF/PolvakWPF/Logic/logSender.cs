using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Json;


namespace PolvakWPF.Logic
{
    public class Message
    {
        public DateTime TimeStamp { set; get; }
        public String MessageText { set; get; }
    }

    public static class LogSender
    {
        private static List<Message> _messageStack = new List<Message>();

        static LogSender()
        {
            
        }

        public static void AddMessage(string message)
        {
            _messageStack.Add(new Message() { MessageText = message, TimeStamp = DateTime.Now });
        }

        public static void SendToServer()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.203:8888/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsJsonAsync("data", _messageStack);
                if (response.Result.IsSuccessStatusCode)
                {
                    var cont = response.Result.Content;
                }
                Console.Write(response.Result.StatusCode);
            }
        }

        private static void json_test()
        {
            string json = "";
            var bc = new HttpClient();
            var response = bc.GetAsync(@"http://192.168.0.10/control/data.json");
            if (response.Result.IsSuccessStatusCode)
            {
                var responseContent = response.Result.Content;
                json = responseContent.ReadAsStringAsync().Result;
            }

            //var spot = JsonParser.Deserialize<Dog>(json);

        }
    }
}
