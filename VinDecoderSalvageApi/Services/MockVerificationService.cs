using VinDecoderSalvageApi.Interface;

namespace VinDecoderSalvageApi.Services
{
    public class MockVerificationService : IVerificationService
    {
        public Task<bool> VerifyPhoneNumber(string phoneNumber)
        {
            // Simulate API response
            return Task.FromResult(true); // or false to simulate failure
        }
    }
}
