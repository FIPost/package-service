using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PakketService.Controllers;
using PakketService.Database.Converters;
using PakketService.Database.Datamodels;
using PakketService.Database.Datamodels.Dtos;
using PakketService.Services;
using System;
using System.Threading.Tasks;

namespace PakketService.Test
{
    public class Tests
    {
        private Mock<IPackageService> serviceMock;
        private Mock<IDtoConverter<Package, PackageRequest, PackageResponse>> converterMock;

        private Package package;
        private PackageRequest request;

        [SetUp]
        public void Setup()
        {
            // Instantiate mocks:
            serviceMock = new Mock<IPackageService>();
            converterMock = new Mock<IDtoConverter<Package, PackageRequest, PackageResponse>>();

            // Create mock data:
            package = new Package
            {
                Sender = "Coolblue",
                ReceiverId = "1",
                Name = "Test",
                CollectionPointId = new Guid()
            };
            request = new PackageRequest
            {
                Sender = "Coolblue",
                ReceiverId = "1",
                Name = "Test",
                CollectionPointId = new Guid()
            };
        }

        [Test]
        public async Task AddPackageTest()
        {
            // Arrange
            serviceMock.Setup(x => x.AddAsync(package)).Returns(Task.FromResult(package));
            var controller = new PackagesController(serviceMock.Object, converterMock.Object);

            // Act
            var result = await controller.AddPackage(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ActionResult<PackageResponse>>(result);
        }

        [Test]
        public async Task GetPackageByIdTest()
        {
            // Arrange
            serviceMock.Setup(x => x.GetByIdAsync(new Guid())).Returns(Task.FromResult(package));
            var controller = new PackagesController(serviceMock.Object, converterMock.Object);

            // Act
            var result = await controller.GetPackageById(new Guid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ActionResult<PackageResponse>>(result);
        }
    }
}