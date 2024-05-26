using Newtonsoft.Json.Linq;
using VinDecoderSalvageApi.Interface;

namespace VinDecoderSalvageApi.Services
{
    public class TelesignVerificationService : IVerificationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TelesignVerificationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<bool> VerifyPhoneNumber(string phoneNumber)
        {
            var apiKey = _configuration["Telesign:ApiKey"];
            var url = $"https://rest-ww.telesign.com/v1/verify/sms?phone_number={phoneNumber}&api_key={apiKey}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(content);
                return json["status"]["code"].ToString() == "290";
            }
            return false;
        }
    }
}
