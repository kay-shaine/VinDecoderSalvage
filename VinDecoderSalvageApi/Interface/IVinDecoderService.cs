using VinDecoderSalvageApi.Model;

namespace VinDecoderSalvageApi.Interface
{
    public interface IVinDecoderService
    {
        Task<VinData> DecodeVinAsync(string vin);
    }
}
