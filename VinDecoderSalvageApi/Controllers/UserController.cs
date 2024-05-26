using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinDecoderSalvageApi.DatabaseContext;
using VinDecoderSalvageApi.Entities;
using VinDecoderSalvageApi.Interface;
using VinDecoderSalvageApi.Model;
using VinDecoderSalvageApi.Services;

namespace VinDecoderSalvageApi.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : ControllerBase
        {
            private readonly IVerificationService _verificationService;
            //private static List<User> users = new List<User>();
            //private readonly IUserService _userService;
            private readonly IOTPService _otpService;
            private readonly MockOTPService _otpsService;
            private readonly ApplicationDbContext _context;

        //public UserController(ApplicationDbContext context, IVerificationService verificationService, IOTPService otpService, MockOTPService otpsService)
        //    {
        //        _verificationService = verificationService;
        //        //_userService = userService;
        //        _otpService = otpService;
        //        _otpsService = otpsService;
        //        _context = context;
        //}

        public UserController(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        [HttpPost("send-otp")]
        public IActionResult SendOTP([FromBody] SendOtpRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var otp = _otpService.GenerateOtp();
            _otpService.SendOtp(request.PhoneNumber, otp);

            var otpEntity = new OTP
            {
                UserId = user.Id,
                Code = otp
            };
            _context.OTPs.Add(otpEntity);
            _context.SaveChanges();

            return Ok();
        }


        [HttpPost("verify-otp")]
        public IActionResult VerifyOTP([FromBody] VerifyOtpRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var otpEntity = _context.OTPs
                .Include(o => o.User)
                .FirstOrDefault(o => o.User.PhoneNumber == request.PhoneNumber && o.Code == request.Otp);

            if (otpEntity != null)
            {
                _context.OTPs.Remove(otpEntity);
                _context.SaveChanges();
                return Ok(new { Token = "JWT_TOKEN" });
            }

            return BadRequest("Invalid OTP");
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] User user)
        //{
        //    var isVerified = await _verificationService.VerifyPhoneNumber(user.PhoneNumber);
        //    if (isVerified)
        //    {
        //        user.IsVerified = true;
        //        user.Add(user);
        //        return Ok(user);
        //    }
        //    return BadRequest("Phone number verification failed.");
        //}

        //Enable CORS for this specific controller
       [EnableCors]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var isVerified = await _verificationService.VerifyPhoneNumber(user.PhoneNumber);
            if (!isVerified)
            {
                return BadRequest("Phone number verification failed");
            }

            user.IsVerified = true;
            return Ok(user);
        }
    }

    public class SendOtpRequest
    {
        public string PhoneNumber { get; set; }
    }

    public class VerifyOtpRequest
    {
        public string PhoneNumber { get; set; }
        public string Otp { get; set; }
    }
}
