using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace lesson1
{
    class Program
    {
        static readonly HttpClient _jsonPHClient = new HttpClient();
        static readonly string filePath = "posts.txt";

        static async Task Main(string[] args)
        {
            var GetResponseTasks = new List<Task<string>>();
            for (int i = 4; i < 14; i++)
            {
                GetResponseTasks.Add(GetResponse(i));
            }
            var postTaskStrings = await Task.WhenAll<string>(GetResponseTasks);

            for(int i = 0; i<10; i++)
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<Post>(postTaskStrings[i], options);
                await File.AppendAllTextAsync(filePath, result + "\r\n");
            }

        }

        static async Task<string> GetResponse(int postNumber)
        {
            HttpResponseMessage response;
            int exceptionTimeout = 5000;

            while (true)
            {
                try
                {
                    response = await _jsonPHClient.GetAsync(@"https://jsonplaceholder.typicode.com/posts/" + postNumber);
                    break;
                }
                catch
                {
                    await Task.Delay(exceptionTimeout);
                }
            }
              
            return await response.Content.ReadAsStringAsync();
        }


    }
}
