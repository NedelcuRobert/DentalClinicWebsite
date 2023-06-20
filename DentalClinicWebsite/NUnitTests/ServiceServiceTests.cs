using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services;
using Moq;
using NUnit.Framework;

namespace DentalClinicWebsite.Tests.Services
{
    [TestFixture]
    public class ServiceServiceTests
    {
        private Mock<IServiceRepository> _serviceRepositoryMock;
        private ServiceService _serviceService;

        [SetUp]
        public void Setup()
        {
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _serviceService = new ServiceService(_serviceRepositoryMock.Object);
        }

        [Test]
        public void GetAllServices_ReturnsAllServicesFromRepository()
        {
            var expectedServices = new List<Service>
            {
                new Service { ID = 1, Name = "Service 1" },
                new Service { ID = 2, Name = "Service 2" }
            };
            _serviceRepositoryMock.Setup(r => r.GetAllServices()).Returns(expectedServices);

            var result = _serviceService.GetAllServices();

            Assert.AreEqual(expectedServices, result);
        }

        [Test]
        public void GetServicesBySpecialization_ReturnsServicesBySpecializationFromRepository()
        {
            int specializationId = 1;
            var expectedServices = new List<Service>
            {
                new Service { ID = 1, Name = "Service 1" },
                new Service { ID = 2, Name = "Service 2" }
            };
            _serviceRepositoryMock.Setup(r => r.GetServicesBySpecialization(specializationId)).Returns(expectedServices);

            var result = _serviceService.GetServicesBySpecialization(specializationId);

            Assert.AreEqual(expectedServices, result);
        }

        [Test]
        public void GetServiceById_ReturnsServiceByIdFromRepository()
        {
            int serviceId = 1;
            var expectedService = new Service { ID = serviceId, Name = "Service 1" };
            _serviceRepositoryMock.Setup(r => r.GetServiceById(serviceId)).Returns(expectedService);

            var result = _serviceService.GetServiceById(serviceId);

            Assert.AreEqual(expectedService, result);
        }

        [Test]
        public async Task AddServiceAsync_AddsServiceToRepository()
        {
            var service = new Service { ID = 1, Name = "Service 1" };

            _serviceRepositoryMock.Setup(r => r.AddServiceAsync(It.IsAny<Service>())).Returns(Task.CompletedTask);

            await _serviceService.AddServiceAsync(service);

            _serviceRepositoryMock.Verify(r => r.AddServiceAsync(service), Times.Once);
        }

        [Test]
        public async Task UpdateServiceAsync_UpdatesServiceInRepository()
        {
            var service = new Service { ID = 1, Name = "Updated Service" };

            _serviceRepositoryMock.Setup(r => r.UpdateServiceAsync(It.IsAny<Service>())).Returns(Task.CompletedTask);

            await _serviceService.UpdateServiceAsync(service);

            _serviceRepositoryMock.Verify(r => r.UpdateServiceAsync(service), Times.Once);
        }

        [Test]
        public async Task DeleteServiceAsync_DeletesServiceFromRepository()
        {
            int serviceId = 1;

            _serviceRepositoryMock.Setup(r => r.DeleteServiceAsync(serviceId)).Returns(Task.CompletedTask);

            await _serviceService.DeleteServiceAsync(serviceId);

            _serviceRepositoryMock.Verify(r => r.DeleteServiceAsync(serviceId), Times.Once);
        }
    }
}
