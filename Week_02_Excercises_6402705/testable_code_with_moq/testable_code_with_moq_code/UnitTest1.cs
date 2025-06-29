using System;
using Moq;
using NUnit.Framework;

namespace StudentApp.Tests
{
    // Step 1: Define the dependency interface
    public interface IStudentRepository
    {
        int GetStudentCount();
    }

    // Step 2: Implement the class that uses the interface
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public string GetStatus()
        {
            int count = _repository.GetStudentCount();
            return count > 0 ? "Students exist" : "No students";
        }
    }

    // Step 3: NUnit test class using Moq
    [TestFixture]
    public class StudentServiceTests
    {
        [Test]
        public void GetStatus_ShouldReturnExist_WhenStudentCountIsGreaterThanZero()
        {
            // Arrange
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(repo => repo.GetStudentCount()).Returns(3);
            var service = new StudentService(mockRepo.Object);

            // Act
            var result = service.GetStatus();

            // Assert
            Assert.That(result, Is.EqualTo("Students exist"));
        }

        [Test]
        public void GetStatus_ShouldReturnNoStudents_WhenStudentCountIsZero()
        {
            // Arrange
            var mockRepo = new Mock<IStudentRepository>();
            mockRepo.Setup(repo => repo.GetStudentCount()).Returns(0);
            var service = new StudentService(mockRepo.Object);

            // Act
            var result = service.GetStatus();

            // Assert
            Assert.That(result, Is.EqualTo("No students"));
        }
    }
}
