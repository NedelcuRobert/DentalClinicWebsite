using DentalClinicWebsite.Models;
using DentalClinicWebsite.Models.DTOs;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services;
using Moq;
using NUnit.Framework;

namespace DentalClinicWebsite.Tests.Services
{
    [TestFixture]
    public class AppointmentServiceTests
    {
        private Mock<IAppointmentRepository> _appointmentRepositoryMock;
        private AppointmentService _appointmentService;

        [SetUp]
        public void Setup()
        {
            _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            _appointmentService = new AppointmentService(_appointmentRepositoryMock.Object);
        }

        [Test]
        public void GetServices_ReturnsServicesFromRepository()
        {
            int specializationId = 1;
            var expectedServices = new List<Service>
            {
                new Service { ID = 1, Name = "Service 1" },
                new Service { ID = 2, Name = "Service 2" }
            };
            _appointmentRepositoryMock.Setup(r => r.GetServices(specializationId)).Returns(expectedServices);

            var result = _appointmentService.GetServices(specializationId);

            Assert.AreEqual(expectedServices, result);
        }

        [Test]
        public void GetDentists_ReturnsDentistsFromRepository()
        {
            int specializationId = 1;
            var expectedDentists = new List<User>
            {
                new User { Id = "1", FirstName = "John", LastName = "Doe" },
                new User { Id = "2", FirstName = "Jane", LastName = "Smith" }
            };
            _appointmentRepositoryMock.Setup(r => r.GetDentists(specializationId)).Returns(expectedDentists);

            var result = _appointmentService.GetDentists(specializationId);

            Assert.AreEqual(expectedDentists, result);
        }

        [Test]
        public async Task GetAvailableAppointmentsAsync_ReturnsAvailableAppointmentsFromRepository()
        {
            int serviceId = 1;
            string dentistId = "1";
            var expectedAppointments = new List<Appointment>
            {
                    new Appointment { ID = 1, CalendarData = new DateTime(2023, 5, 23).Add(new TimeSpan(9, 0, 0)) },
                    new Appointment { ID = 2, CalendarData = new DateTime(2023, 5, 24).Add(new TimeSpan(14, 30, 0)) }
             };
            _appointmentRepositoryMock.Setup(r => r.GetAvailableAppointmentsAsync(serviceId, dentistId)).ReturnsAsync(expectedAppointments);

            var result = await _appointmentService.GetAvailableAppointmentsAsync(serviceId, dentistId);

            Assert.AreEqual(expectedAppointments, result);
        }

        [Test]
        public async Task CreateAppointmentAsync_CreatesAppointmentInRepository()
        {
            var appointmentDTO = new AppointmentDTO
            {
                UserId = "1",
                DentistId = "2",
                ServiceId = 1,
                Date = new DateTime(2023, 5, 25),
                Time = new TimeSpan(10, 0, 0)
            };
            var expectedAppointment = new Appointment
            {
                UserId = appointmentDTO.UserId,
                DentistId = appointmentDTO.DentistId,
                ServiceId = appointmentDTO.ServiceId,
                CalendarData = appointmentDTO.Date.Date.Add(appointmentDTO.Time)
            };

            _appointmentRepositoryMock.Setup(r => r.CreateAppointmentAsync(It.IsAny<Appointment>())).Returns(Task.CompletedTask);

            await _appointmentService.CreateAppointmentAsync(appointmentDTO);

            _appointmentRepositoryMock.Verify(r => r.CreateAppointmentAsync(It.Is<Appointment>(a =>
                a.UserId == expectedAppointment.UserId &&
                a.DentistId == expectedAppointment.DentistId &&
                a.ServiceId == expectedAppointment.ServiceId &&
                a.CalendarData == expectedAppointment.CalendarData)), Times.Once);
        }

        [Test]
        public void GetSpecializations_ReturnsSpecializationsFromRepository()
        {
            var expectedSpecializations = new List<Specialization>
            {
                new Specialization { ID = 1, Name = "Specialization 1" },
                new Specialization { ID = 2, Name = "Specialization 2" }
            };
            _appointmentRepositoryMock.Setup(r => r.GetSpecializations()).Returns(expectedSpecializations);

            var result = _appointmentService.GetSpecializations();

            Assert.AreEqual(expectedSpecializations, result);
        }

        [Test]
        public void GetAppointmentsById_ReturnsAppointmentsFromRepository()
        {
            string userId = "1";
            var expectedAppointments = new List<Appointment>
            {
                new Appointment { ID = 1, CalendarData = new DateTime(2023, 5, 23).Add(new TimeSpan(9, 0, 0)) },
                new Appointment { ID = 2, CalendarData = new DateTime(2023, 5, 24).Add(new TimeSpan(14, 30, 0)) }
            };

            _appointmentRepositoryMock.Setup(r => r.GetAppointmentsById(userId)).Returns(expectedAppointments);

            var result = _appointmentService.GetAppointmentsById(userId);

            Assert.AreEqual(expectedAppointments, result);
        }
    }
}
