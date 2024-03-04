using System;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

class Program
{
    static void Main()
    {
        // Инициализируем время начала выполнения запросов
        DateTime startTime = DateTime.Now;

        try
        {
            // Выполняем первый запрос к серверу
            string response1 = MakeRequest("http://server1.com/api/data1");
            Console.WriteLine(response1);

            // Выполняем второй запрос к серверу
            string response2 = MakeRequest("http://server2.com/api/data2");
            Console.WriteLine(response2);

            // Выполняем третий запрос к серверу
            string response3 = MakeRequest("http://server3.com/api/data3");
            Console.WriteLine(response3);
        }
        catch (Exception ex)
        {
            // Обработка и вывод ошибки
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        // Определяем и выводим общее время выполнения запросов
        TimeSpan duration = DateTime.Now - startTime;
        Console.WriteLine("Общее время выполнения: " + duration.TotalSeconds + " секунд");
    }

    // Метод для выполнения HTTP-запроса и возврата ответа в виде строки JSON
    static string MakeRequest(string url)
    {
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        using (Stream dataStream = response.GetResponseStream())
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(string));
            string jsonResponse = jsonSerializer.ReadObject(dataStream) as string;
            return jsonResponse;
        }
    }
}


//using System;
//using System.Net.Http;
//using System.Threading.Tasks;

//class Program
//{
//    static async Task Main()
//    {
//        // Инициализируем время начала выполнения запросов
//        DateTime startTime = DateTime.Now;

//        try
//        {
//            // Выполняем все запросы асинхронно и дожидаемся их завершения
//            string response1 = await MakeRequestAsync("http://server1.com/api/data1");
//            Console.WriteLine(response1);

//            string response2 = await MakeRequestAsync("http://server2.com/api/data2");
//            Console.WriteLine(response2);

//            string response3 = await MakeRequestAsync("http://server3.com/api/data3");
//            Console.WriteLine(response3);
//        }
//        catch (Exception ex)
//        {
//            // Обработка и вывод ошибки
//            Console.WriteLine("Ошибка: " + ex.Message);
//        }

//        // Определяем и выводим общее время выполнения запросов
//        TimeSpan duration = DateTime.Now - startTime;
//        Console.WriteLine("Общее время выполнения: " + duration.TotalSeconds + " секунд");
//    }

//    // Метод для выполнения HTTP-запроса асинхронно и возврата ответа в виде строки JSON
//    static async Task<string> MakeRequestAsync(string url)
//    {
//        using (HttpClient client = new HttpClient())
//        {
//            HttpResponseMessage response = await client.GetAsync(url);
//            response.EnsureSuccessStatusCode();
//            string responseBody = await response.Content.ReadAsStringAsync();
//            return responseBody;
//        }
//    }
//}
