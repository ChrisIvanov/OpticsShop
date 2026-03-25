namespace OpticsShop.Services.FileIO.Reader
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class Reader
    {
        public static async Task<List<T>> LoadFromFileAsync<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<T>();
            }

            try
            {
                List<T>? items = JsonSerializer.Deserialize<List<T>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return items ?? new List<T>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Invalid JSON in file: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
