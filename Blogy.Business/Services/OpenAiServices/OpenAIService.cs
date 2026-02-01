using System.Text;
using System.Text.Json;

namespace Blogy.Business.Services.OpenAIService
{
    public class OpenAIService : IOpenAIService
    {
        private readonly string _apiKey = "XXXXXXX"; // Buraya kendi OpenAI API key’inizi girin
        private readonly HttpClient _httpClient;

        public OpenAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        private async Task<string?> SendChatRequestAsync(string prompt, string model = "gpt-3.5-turbo", int maxTokens = 600)
        {
            var requestBody = new
            {
                model = "gpt-4",
                messages = new object[]
                {
            new { role = "system", content = "sen bir makale oluşturucususun" },
            new { role = "user", content = $"Bana 1000 sayfalık bir makale hazırla anahtar kelimeler işte prompt: {prompt}." }
                },
                max_tokens = maxTokens,
                temperature = 0.7
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"OpenAI API hatası: {(int)response.StatusCode} - {responseString}");
                return null;
            }

            using var doc = JsonDocument.Parse(responseString);
            var message = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return message;
        }

        public async Task<string?> GenerateArticleAsync(string shortDescription, List<string> keywords)
        {
            string prompt = $"{shortDescription}\nAnahtar kelimeler: {string.Join(", ", keywords)}\nMakale uzunluğu yaklaşık 1000 karakter.";
            return await SendChatRequestAsync(prompt, maxTokens: 600);
        }

        public async Task<string> ContactResponse(string request)
        {
            var requestBody = new
            {
                model = "gpt-4.1-mini", // daha hızlı ve ucuz, dil görevlerinde çok iyi
                messages = new object[]
                {
            new
            {
                role = "system",
                content =
                "Sen bir blog sitesinin 'Bize Yazın' bölümüne gelen mesajlara otomatik yanıt üreten asistansın. " +
                "Kullanıcı soruyu hangi dilde yazarsa, sen de aynı dilde yanıt üretmelisin. " +
                "Kibar, profesyonel ve yardımsever bir ton kullan."
            },
            new
            {
                role = "user",
                content = request
            }
                },
                max_tokens = 400,
                temperature = 0.4
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"OpenAI API hatası: {(int)response.StatusCode} - {responseString}");
                return "Sistemsel bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
            }

            using var doc = JsonDocument.Parse(responseString);
            var message = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return message;
        }

    }
}
