namespace VinDecoderSalvageApi.Interface
{
    public interface IVerificationService
    {
        Task<bool> VerifyPhoneNumber(string phoneNumber);
    }
}
