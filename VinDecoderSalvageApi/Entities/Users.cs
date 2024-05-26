namespace VinDecoderSalvageApi.Entities
{
    // Models/User.cs
    public class Users
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        // Other user properties
    }

    // Models/OTP.cs
    public class OTP
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; }
        // Other OTP properties

        public Users User { get; set; }
    }

}
