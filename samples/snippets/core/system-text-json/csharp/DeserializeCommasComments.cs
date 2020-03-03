﻿using System;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class DeserializeCommasComments
    {
        public static void Run()
        {
            string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureC"": 25, // Fahrenheit 77
  ""Summary"": ""Hot"", /* Zharko */
}";
            Console.WriteLine($"JSON input:\n{jsonString}\n");

            // <SnippetDeserialize>
            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            };
            var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString, options);
            // </SnippetDeserialize>
            weatherForecast.DisplayPropertyValues();
        }
    }
}