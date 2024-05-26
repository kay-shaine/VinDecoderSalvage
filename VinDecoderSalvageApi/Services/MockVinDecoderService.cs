using VinDecoderSalvageApi.Interface;
using VinDecoderSalvageApi.Model;

namespace VinDecoderSalvageApi.Services
{
    public class MockVinDecoderService : IVinDecoderService
    {
        public Task<VinData> DecodeVinAsync(string vin)
        {
            // Simulate API response
            var vinData = new VinData
            {
                Vin = vin,
                Make = "MockMake",
                Model = "MockModel",
                Year = "2023",
                SalvageStatus = "No"
            };
            return Task.FromResult(vinData);
        }
    }
}
