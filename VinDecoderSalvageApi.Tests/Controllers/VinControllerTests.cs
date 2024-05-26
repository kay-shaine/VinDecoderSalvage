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
    public class VinControllerTests
    {
        [Fact]
        public async Task DecodeVin_ReturnsOk_WithVinData()
        {
            // Arrange
            var mockVinDecoderService = new Mock<IVinDecoderService>();
            var vinData = new VinData
            {
                Vin = "1HGCM82633A123456",
                Make = "Honda",
                Model = "Accord",
                Year = "2005",
                SalvageStatus = "No"
            };
            mockVinDecoderService.Setup(service => service.DecodeVinAsync(It.IsAny<string>()))
                                 .ReturnsAsync(vinData);

            var controller = new VinController(mockVinDecoderService.Object);
            // Act
            var result = await controller.DecodeVin("1HGCM82633A123456") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var returnedVinData = result.Value as VinData;
            Assert.Equal(vinData.Vin, returnedVinData.Vin);
            Assert.Equal(vinData.Make, returnedVinData.Make);
            Assert.Equal(vinData.Model, returnedVinData.Model);
            Assert.Equal(vinData.Year, returnedVinData.Year);
            Assert.Equal(vinData.SalvageStatus, returnedVinData.SalvageStatus);
        }

        [Fact]
        public async Task DecodeVin_ReturnsNotFound_WhenVinDataIsNull()
        {
            // Arrange
            var mockVinDecoderService = new Mock<IVinDecoderService>();
            mockVinDecoderService.Setup(service => service.DecodeVinAsync(It.IsAny<string>()))
                                 .ReturnsAsync((VinData)null);

            var controller = new VinController(mockVinDecoderService.Object);

            // Act
            var result = await controller.DecodeVin("1HGCM82633A123456");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
