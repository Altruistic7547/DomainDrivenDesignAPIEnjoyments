using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManagement.Domain.BusinessModels.Project;
using ProjectManagement.Infrastructure.Repositories.Interface;
using ProjectMangement.Application.DataObjects;
using ProjectMangement.Application.Projects.Commands;
using ProjectMangement.Application.Services.Interface;
using ProjectMangement.Application.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace PolyForge.Application.UnitTests
{
    [TestClass]
    public class ProjectServiceTests
    {
        private readonly Mock<IProjectRepository> _mockProjectRepository = new Mock<IProjectRepository>();
        private readonly Mock<IProjectStatusRepsitory> _mockProjectStatusRepository = new Mock<IProjectStatusRepsitory>();
        private readonly Mock<IValidator<Project>> _mockProjectValidator = new Mock<IValidator<Project>>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<ProjectDataService>> _mocklogger = new Mock<ILogger<ProjectDataService>>();
        private static IProjectDataService _projectDataService;




        [TestInitialize]
        public void TestInit()
        {
            _projectDataService = new ProjectDataService(_mockProjectRepository.Object, _mockMapper.Object
                , _mockProjectStatusRepository.Object, _mockProjectValidator.Object, _mocklogger.Object);
        }

        [TestMethod]
        public async Task GetAllProjects_Valid_Test()
        {
            //Arrange
            _mockProjectRepository.Setup(x => x.GetProjectsAsync()).ReturnsAsync(new List<Project> { new Project() });
            _mockMapper.Setup(x => x.Map<IEnumerable<GetProjectData>>(It.IsAny<IEnumerable<Project>>()))
                .Returns(new List<GetProjectData>() { new GetProjectData() }.AsEnumerable());

            //Act
            var result = await _projectDataService.GetAllProjects();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());

        }

        [TestMethod]
        public void GetAllProjects_Invalid_Exception_Test()
        {
            //Arrange
            var expectErrorMessage = "Service could not get entity";
            _mockProjectRepository.Setup(x => x.GetProjectsAsync()).Throws(new Exception());

            //Act
            var result = Should.Throw<Exception>(async () => await _projectDataService.GetAllProjects());

            //Assert
            result.Message.ShouldBe(expectErrorMessage);
        }

        [TestMethod]
        public async Task GetProjectById_Valid_Test()
        {
            //Arrange
            _mockProjectRepository.Setup(x => x.GetProjectById(It.IsAny<int>())).ReturnsAsync(new Project() { Budget = 1 });
            _mockMapper.Setup(x => x.Map<GetProjectData>(It.IsAny<Project>()))
                .Returns(new GetProjectData() { Budget = 1 });

            //Act
            var result = await _projectDataService.GetProjectById(It.IsAny<int>());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Budget);
        }

        [TestMethod]
        public void GetProjectById_Invalid_Exception_Test()
        {
            //Arrange
            var expectErrorMessage = "Service could not get entity";
            _mockProjectRepository.Setup(x => x.GetProjectById(It.IsAny<int>())).Throws(new Exception());

            //Act
            var result = Should.Throw<Exception>(async () => await _projectDataService.GetProjectById(It.IsAny<int>()));

            //Assert
            result.Message.ShouldBe(expectErrorMessage);
        }

        [TestMethod]
        public async Task CreateProject_Valid_Test()
        {
            //Arrange
            _mockMapper.Setup(x => x.Map<Project>(It.IsAny<AddProjectRequest>()))
                .Returns(new Project() { Budget = 1 });

            _mockProjectValidator.Setup(x => x.ValidateAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            _mockProjectRepository.Setup(x => x.CreateProjectAsync(It.IsAny<Project>()))
                .ReturnsAsync(new Project() { Budget = 1 });

            //Act
            var result = await _projectDataService.CreateProject(It.IsAny<AddProjectRequest>());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CreateProject_Invalid_Validation_Error_Test()
        {
            //Arrange
            var expectErrorMessage = "Status is invalid";
            _mockMapper.Setup(x => x.Map<Project>(It.IsAny<AddProjectRequest>()))
                .Returns(new Project() { Budget = 1 });

            _mockProjectValidator.Setup(x => x.ValidateAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult() { Errors = new List<ValidationFailure>() { new ValidationFailure() { ErrorMessage = expectErrorMessage } } });

            //Act
            var result = Should.Throw<ValidationException>(async () => await _projectDataService.CreateProject(It.IsAny<AddProjectRequest>()));

            //Assert
            result.Errors.Count().ShouldBe(1);
        }

        [TestMethod]
        public void CreateProject_Invalid_Exception_Test()
        {
            //Arrange
            var expectErrorMessage = "Service could not create entity";
            _mockMapper.Setup(x => x.Map<Project>(It.IsAny<AddProjectRequest>()))
                .Returns(new Project() { Budget = 1 });

            _mockProjectValidator.Setup(x => x.ValidateAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            _mockProjectRepository.Setup(x => x.CreateProjectAsync(It.IsAny<Project>()))
                .Throws(new Exception());

            //Act
            var result = Should.Throw<Exception>(async () => await _projectDataService.CreateProject(It.IsAny<AddProjectRequest>()));

            //Assert
            result.Message.ShouldBe(expectErrorMessage);
        }

        [TestMethod]
        public async Task UpdateProjectStatus_Valid_Test()
        {
            //Arrange
            var request = new UpdateProjectStatusRequest() { NewStatusId = 1, ProjectId = 2 };
            _mockProjectValidator.Setup(x => x.ValidateAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            _mockProjectRepository.Setup(x => x.GetProjectById(It.IsAny<int>()))
                .ReturnsAsync(new Project() { Budget = 1 });

            _mockProjectRepository.Setup(x => x.UpdateProjectAsync(It.IsAny<Project>()))
                .ReturnsAsync(true);

            //Act
            var result = await _projectDataService.UpdateProjectStatus(request);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void UpdateProjectStatus_Invalid_Validation_Error_Test()
        {
            //Arrange
            var expectErrorMessage = "Status is invalid";

            _mockProjectRepository.Setup(x => x.GetProjectById(It.IsAny<int>()))
                .ReturnsAsync(new Project() { Budget = 1 });

            _mockProjectRepository.Setup(x => x.UpdateProjectAsync(It.IsAny<Project>()))
                .ReturnsAsync(true);

            _mockProjectValidator.Setup(x => x.ValidateAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult() { Errors = new List<ValidationFailure>() { new ValidationFailure() { ErrorMessage = expectErrorMessage } } });

            //Act
            var result = Should.Throw<ValidationException>(async () => await _projectDataService.CreateProject(It.IsAny<AddProjectRequest>()));

            //Assert
            result.Errors.Count().ShouldBe(1);
        }

        [TestMethod]
        public void UpdateProjectStatus_Invalid_Exception_Test()
        {
            //Arrange
            var expectErrorMessage = "Service could not create entity";
            _mockProjectRepository.Setup(x => x.GetProjectById(It.IsAny<int>()))
                .ReturnsAsync(new Project() { Budget = 1 });

            _mockProjectValidator.Setup(x => x.ValidateAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());

            _mockProjectRepository.Setup(x => x.UpdateProjectAsync(It.IsAny<Project>()))
                .Throws(new Exception());

            //Act
            var result = Should.Throw<Exception>(async () => await _projectDataService.CreateProject(It.IsAny<AddProjectRequest>()));

            //Assert
            result.Message.ShouldBe(expectErrorMessage);
        }

        [TestMethod]
        public async Task RemoveProject_Valid_Test()
        {
            //Arrange
            _mockProjectRepository.Setup(x => x.GetProjectById(It.IsAny<int>())).ReturnsAsync(new Project() { Budget = 1 });

            _mockProjectRepository.Setup(x => x.DeleteProjectAsync(It.IsAny<int>())).ReturnsAsync(true);

            _mockMapper.Setup(x => x.Map<GetProjectData>(It.IsAny<Project>()))
                .Returns(new GetProjectData() { Budget = 1 });

            //Act
            var result = await _projectDataService.RemoveProject(It.IsAny<int>());

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void RemoveProject_Invalid_Exception_Test()
        {
            //Arrange
            var expectErrorMessage = "Service could not delete entity";
            _mockProjectRepository.Setup(x => x.GetProjectById(It.IsAny<int>())).Throws(new Exception());

            //Act
            var result = Should.Throw<Exception>(async () => await _projectDataService.RemoveProject(It.IsAny<int>()));

            //Assert
            result.Message.ShouldBe(expectErrorMessage);
        }
    }
}
