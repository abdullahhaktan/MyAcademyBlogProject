using Blogy.Business.Services.HuggingFaceService;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blogy.Business.Services.HuggingFaceService
{
    public class HuggingFaceService : IHuggingFaceService
    {
        private readonly string _huggingFaceApiKey = "XXXXXXXXXXXXXX";
        private readonly HttpClient _httpClient;

        private const string TranslateModel = "Helsinki-NLP/opus-mt-tr-en";
        private const string ToxicityModel = "unitary/toxic-bert";

        public HuggingFaceService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_huggingFaceApiKey}");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Blogy/1.0");
        }

        private async Task<string?> SendRequest(string model, object payload)
        {
            string url = $"https://router.huggingface.co/hf-inference/models/{model}";
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            for (int attempt = 1; attempt <= 3; attempt++)
            {
                try
                {
                    var response = await _httpClient.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    // Model load ediliyor olabilir
                    if (responseString.Contains("currently loading") || responseString.Contains("loading"))
                    {
                        Console.WriteLine($"Model yükleniyor, tekrar denenecek... ({attempt}/3)");
                        await Task.Delay(2000);
                        continue;
                    }

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"HuggingFace Hata: {response.StatusCode} - {responseString}");
                        return null;
                    }

                    return responseString;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"HuggingFace Exception: {ex.Message} (Attempt {attempt}/3)");
                    await Task.Delay(1000);
                }
            }

            return null;
        }

        // -------------------------------------------------------------
        // 1) Metin Çevirisi (TR → EN)
        // -------------------------------------------------------------
        public async Task<string?> TranslateTextToEnglish(string text)
        {
            var req = new { inputs = text };
            var json = await SendRequest(TranslateModel, req);

            if (string.IsNullOrWhiteSpace(json) || !json.TrimStart().StartsWith("["))
                return null;

            try
            {
                using var doc = JsonDocument.Parse(json);
                return doc.RootElement[0].GetProperty("translation_text").GetString();
            }
            catch
            {
                Console.WriteLine("Translate JSON parse edilemedi.");
                return null;
            }
        }

        public async Task<double?> GetToxicStore(string text)
        {
            var req = new { inputs = text };
            var json = await SendRequest(ToxicityModel, req);

            if (string.IsNullOrWhiteSpace(json) || !json.TrimStart().StartsWith("["))
                return null;

            try
            {
                using var doc = JsonDocument.Parse(json);

                foreach (var item in doc.RootElement[0].EnumerateArray())
                {
                    string label = item.GetProperty("label").GetString() ?? "";
                    double score = item.GetProperty("score").GetDouble();

                    if (label.Contains("toxic") || label.Contains("insult") || label.Contains("obscene"))
                        return score;
                }

                return 0;
            }
            catch
            {
                Console.WriteLine("Toxicity JSON parse edilemedi.");
                return null;
            }
        }

        public async Task<bool> IsCommentToxic(string text)
        {
            var score = await GetToxicStore(text);
            if (score == null)
                return false;

            return score >= 0.5;
        }

        public async Task<string?> ProcessComment(string text)
        {
            if (await IsCommentToxic(text))
                return null;

            return await TranslateTextToEnglish(text);
        }
    }
}
