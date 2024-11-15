using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManagement.Domain.BusinessModels.Project;
using ProjectManagement.Infrastructure.Repositories.Interface;
using ProjectMangement.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyForge.Application.UnitTests
{
    [TestClass]
    public class ProjectValidatorTests
    {
        private readonly Mock<IProjectStatusRepsitory> _mockProjectStatusRepository = new Mock<IProjectStatusRepsitory>();
        private readonly Mock<ILogger<ProjectValidator>> _mocklogger = new Mock<ILogger<ProjectValidator>>();
        private static ProjectValidator _projectValidator;

        [TestInitialize]
        public void TestInit()
        {
            _projectValidator = new ProjectValidator(_mockProjectStatusRepository.Object, _mocklogger.Object);
        }

        [TestMethod]
        public async Task ProjectValidator_Valid_Test()
        {
            //Arrange
            var request = new Project()
            {
                StatusId = 1
            };

            _mockProjectStatusRepository.Setup(x => x.getProjectStatusesAsync())
                .ReturnsAsync(new List<ProjectStatus>() { new ProjectStatus() { Name = "A", StatusId = 1 } });

            //Act
            var result = await _projectValidator.ValidateAsync(request);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public async Task ProjectValidator_Invalid_ProjectStatus_Test()
        {
            //Arrange
            var expectErrorMessage = "Status id is invalid";

            var request = new Project()
            {
                StatusId = 1
            };

            _mockProjectStatusRepository.Setup(x => x.getProjectStatusesAsync())
                .ReturnsAsync(new List<ProjectStatus>() { new ProjectStatus() });

            //Act
            var result = await _projectValidator.ValidateAsync(request);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(expectErrorMessage, result.Errors[0].ErrorMessage);
        }
    }
}
