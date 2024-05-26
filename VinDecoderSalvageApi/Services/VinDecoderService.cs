using Newtonsoft.Json.Linq;
using VinDecoderSalvageApi.Interface;
using VinDecoderSalvageApi.Model;

namespace VinDecoderSalvageApi.Services
{
    public class VinDecoderService : IVinDecoderService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public VinDecoderService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<VinData> DecodeVinAsync(string vin)
        {
            var apiKey = _configuration["VinFreeCheck:ApiKey"];
            var url = $"https://api.vinfreecheck.com/decode?vin={vin}&key={apiKey}";

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(content);

                return new VinData
                {
                    Vin = vin,
                    Make = json["make"].ToString(),
                    Model = json["model"].ToString(),
                    Year = json["year"].ToString(),
                    SalvageStatus = json["salvage"].ToString()
                };
            }
            return null;
        }
    }
}
