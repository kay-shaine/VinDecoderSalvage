using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinDecoderSalvageApi.Controllers;
using VinDecoderSalvageApi.Interface;
using VinDecoderSalvageApi.Model;

namespace VinDecoderSalvageApi.Tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Register_ReturnsOk_WhenVerificationIsSuccessful()
        {
            // Arrange
            var mockVerificationService = new Mock<IVerificationService>();
            mockVerificationService.Setup(service => service.VerifyPhoneNumber(It.IsAny<string>()))
                                   .ReturnsAsync(true);

            var controller = new UserController(mockVerificationService.Object);
            var user = new User { Name = "Kehinde Enigbokan", PhoneNumber = "08168301935" };

            // Act
            var result = await controller.Register(user) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var registeredUser = result.Value as User;
            Assert.Equal(user.Name, registeredUser.Name);
            Assert.True(registeredUser.IsVerified);
        }

        [Fact]
        public async Task Register_ReturnsBadRequest_WhenVerificationFails()
        {
            // Arrange
            var mockVerificationService = new Mock<IVerificationService>();
            mockVerificationService.Setup(service => service.VerifyPhoneNumber(It.IsAny<string>()))
                                   .ReturnsAsync(false);

            var controller = new UserController(mockVerificationService.Object);
            var user = new User { Name = "Kehinde Enigbokan", PhoneNumber = "08168301935" };

            // Act
            var result = await controller.Register(user);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

