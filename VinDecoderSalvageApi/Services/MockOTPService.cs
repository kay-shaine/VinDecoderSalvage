using VinDecoderSalvageApi.Interface;

namespace VinDecoderSalvageApi.Services
{
    // Services/MockOTPService.cs
    public class MockOTPService : IOTPService
    {
        private static readonly Dictionary<string, string> otpStorage = new();

        public string GenerateOtp()
        {
            // Generate a random 6-digit OTP
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public void SendOtp(string phoneNumber, string otp)
        {
            // Store OTP for the given phone number
            otpStorage[phoneNumber] = otp;
            // Simulate sending OTP (in reality, you would use an SMS API)
            Console.WriteLine($"OTP {otp} sent to {phoneNumber}");
        }

        public bool VerifyOtp(string phoneNumber, string otp)
        {
            return otpStorage.ContainsKey(phoneNumber) && otpStorage[phoneNumber] == otp;
        }
    }
}
