// Compile: >csc /r:MySql.Data.dll RetrieveTempCSharp.cs
// run with file name i.e., RetrieveTempCSharp


using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter city name: ");
        string cityName = Console.ReadLine();

        try
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=abe3a0f4d0b6cebfbe7393b4b4e3aa28&units=metric";
            WebClient client = new WebClient();
            string json = client.DownloadString(url);

            // extract temperature from JSON response
            int index = json.IndexOf("\"temp\":") + 7;
            string tempString = json.Substring(index, 4);
            float temperature = float.Parse(tempString);

            Console.WriteLine("Temperature in " + cityName + " is " + temperature + "°C."); //(Alt + 0176 to get degree symbol)
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}









/*using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string city = "Anakapalle";
        string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=YOUR_API_KEY&units=metric";

        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();

        using (System.IO.Stream stream = response.GetResponseStream())
        using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
        {
            string json = reader.ReadToEnd();
            double temp = Double.Parse(json.Substring(json.IndexOf("\"temp\":") + 7, 4));
            Console.WriteLine("Temperature in " + city + ": " + temp + "°C");
        }

        response.Close();
    }
}


*/



/*using System;
using System.Net.Http;
using System.Text.Json;

namespace RetrieveTemperature
{
class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        string cityName = "Anakapalle"; // replace with the name of the city you want to get the temperature for
        string apiKey = "abe3a0f4d0b6cebfbe7393b4b4e3aa28"; // replace with your own API key from OpenWeatherMap

        string url = "https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(responseBody);

                Console.WriteLine("Current temperature in {cityName}: {weatherData.Main.Temp}°C");
            }
            else
            {
                Console.WriteLine("Failed to get temperature for {cityName}. Status code: {response.StatusCode}");
            }
        }
    }

    class WeatherData
    {
        public MainData Main { get; set; }
    }

    class MainData
    {
        public float Temp { get; set; }
    }
}
}

https://api.openweathermap.org/data/2.5/weather?q=eluru&appid=abe3a0f4d0b6cebfbe7393b4b4e3aa28&units=metric*/
