using System;

namespace HttpClientSample2
{
    class Program
    {
        static void Main(string[] args)
        {
            var ret = ApiClient.GetRaw("https://jsonplaceholder.typicode.com/todos/1",out string error);
            if (ret.IsSuccessStatusCode)
            {
                var str = ret.Content.ReadAsStringAsync().Result;
                Console.WriteLine(str);
            }
            else{
                Console.WriteLine("bad http response");
            }
        }
    }
}
