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
            for (int i = 4; i < 14; i++)
            {
                await GetResponse(i);
            }
           

        }

        static async Task GetResponse(int postNumber)
        {
            var response = await _jsonPHClient.GetAsync(@"https://jsonplaceholder.typicode.com/posts/"+postNumber);  
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Post>(content);
            await File.AppendAllTextAsync(filePath, result + "\r\n");
        }


    }
}
