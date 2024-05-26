using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinDecoderSalvageApi.Interface;

namespace VinDecoderSalvageApi.Tests.Services
{
    public class VerificationServiceTests
    {
        [Fact]
        public async Task VerifyPhoneNumber_ReturnsTrue_WhenVerificationIsSuccessful()
        {
            // Arrange
            var mockService = new Mock<IVerificationService>();
            mockService.Setup(service => service.VerifyPhoneNumber(It.IsAny<string>()))
                       .ReturnsAsync(true);

            // Act
            var result = await mockService.Object.VerifyPhoneNumber("1234567890");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task VerifyPhoneNumber_ReturnsFalse_WhenVerificationFails()
        {
            // Arrange
            var mockService = new Mock<IVerificationService>();
            mockService.Setup(service => service.VerifyPhoneNumber(It.IsAny<string>()))
                       .ReturnsAsync(false);

            // Act
            var result = await mockService.Object.VerifyPhoneNumber("1234567890");

            // Assert
            Assert.False(result);
        }
    }
}
