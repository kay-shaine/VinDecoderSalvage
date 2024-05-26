namespace VinDecoderSalvageApi.Interface
{
    // Services/IOTPService.cs
    public interface IOTPService
    {
        string GenerateOtp();
        void SendOtp(string phoneNumber, string otp);
    }
}
