using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Smart_Asset
{
    public class AiMethods
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string apiKey = "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"; // Replace with your actual API key
        private const string apiUrl = "https://api.openai.com/v1/chat/completions";

        /// <summary>
        /// Sends a request to the OpenAI API with retry logic.
        /// </summary>
        /// <param name="model">Model name (e.g., gpt-4).</param>
        /// <param name="systemMessage">System message to provide context.</param>
        /// <param name="userPrompt">User input for the AI.</param>
        /// <param name="maxTokens">Maximum tokens for the response.</param>
        /// <param name="maxRetries">Maximum number of retry attempts.</param>
        /// <returns>AI response as a string.</returns>
        public static async Task<string> GetChatResponseWithRetryAsync(string model, string systemMessage, string userPrompt, int maxTokens, int maxRetries = 5)
        {
            var requestBody = new
            {
                model = model,
                messages = new[]
                {
            new { role = "system", content = systemMessage },
            new { role = "user", content = userPrompt }
        },
                max_tokens = maxTokens
            };

            string jsonPayload = JsonConvert.SerializeObject(requestBody);
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                    {
                        Headers = { { "Authorization", $"Bearer {apiKey}" } },
                        Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
                    };

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    {
                        // Log rate limiting and prepare for retry
                        Console.WriteLine("Rate limit hit. Retrying...");
                        throw new HttpRequestException("Rate limit hit. Retry required.");
                    }

                    response.EnsureSuccessStatusCode(); // Throws an exception if status code is not 2xx

                    // Parse response content
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    if (apiResponse?.choices != null && apiResponse.choices.Count > 0)
                    {
                        return apiResponse.choices[0].message.content.ToString();
                    }

                    throw new Exception("Unexpected response format.");
                }
                catch (HttpRequestException ex)
                {
                    retryCount++;
                    if (retryCount >= maxRetries)
                        throw new Exception($"Request failed after {maxRetries} retries: {ex.Message}");

                    int delay = (int)Math.Pow(2, retryCount) * 1000; // Exponential backoff
                    Console.WriteLine($"Retrying in {delay / 1000} seconds due to: {ex.Message}");
                    await Task.Delay(delay);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error during request: {ex.Message}");
                }
            }

            throw new Exception("Max retries exceeded.");
        }
    }
}