using NUnit.Framework;
using Moq;
using AutoMapper;
using ToDo.Services.Services;
using ToDo.Infrastructure.Repositories.Interfaces;
using ToDo.Core.Models.Requests;
using ToDo.Core.Models.Responses;
using ToDoModel = ToDo.Core.Entities.ToDo;

namespace ToDo.Services.Tests.Services
{
    [TestFixture]
    public class ToDoServiceTests
    {
        private Mock<IToDoRepository> _mockToDoRepository;
        private Mock<IMapper> _mockMapper;
        private ToDoService _service;

        [SetUp]
        public void SetUp()
        {
            _mockToDoRepository = new Mock<IToDoRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new ToDoService(_mockToDoRepository.Object, _mockMapper.Object);
        }

        [Test]
        public async Task Create_ReturnsToDoResponse()
        {
            // Arrange
            var toDoCreateRequest = new ToDoCreateRequest();
            var toDoModel = new ToDoModel();
            var toDoResponse = new ToDoResponse();
            _mockMapper.Setup(m => m.Map<ToDoModel>(toDoCreateRequest)).Returns(toDoModel);
            _mockToDoRepository.Setup(r => r.AddAsync(toDoModel)).ReturnsAsync(toDoModel);
            _mockMapper.Setup(m => m.Map<ToDoResponse>(toDoModel)).Returns(toDoResponse);

            // Act
            var result = await _service.Create(toDoCreateRequest);

            // Assert
            Assert.That(toDoResponse, Is.EqualTo(result));
        }

        [Test]
        public async Task GetAll_ReturnsToDoResponseList()
        {
            // Arrange
            var toDoModelList = new List<ToDoModel> { new ToDoModel() };
            var toDoResponseList = new List<ToDoResponse> { new ToDoResponse() };
            _mockToDoRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(toDoModelList);
            _mockMapper.Setup(m => m.Map<List<ToDoResponse>>(toDoModelList)).Returns(toDoResponseList);
        
            // Act
            var result = await _service.GetAll();
        
            // Assert
            Assert.That(toDoResponseList, Is.EqualTo(result));
        }
        
        [Test]
        public async Task Update_ReturnsUpdatedToDoResponse()
        {
            // Arrange
            var toDoRequest = new ToDoRequest { Id = 1 };
            var toDoModel = new ToDoModel { Id = 1 };
            var toDoResponse = new ToDoResponse { Id = 1 };
            _mockToDoRepository.Setup(r => r.GetById(toDoRequest.Id)).ReturnsAsync(toDoModel);
            _mockToDoRepository.Setup(r => r.UpdateAsync(It.IsAny<ToDoModel>())).ReturnsAsync(toDoModel);
            _mockMapper.Setup(m => m.Map<ToDoResponse>(toDoModel)).Returns(toDoResponse);
        
            // Act
            var result = await _service.Update(toDoRequest);
        
            // Assert
            Assert.That(toDoResponse, Is.EqualTo(result));
        }
        
        [Test]
        public async Task Delete_ReturnsSuccessMessage()
        {
            // Arrange
            var taskId = 1;
            var toDoModel = new ToDoModel { Id = taskId };
            _mockToDoRepository.Setup(r => r.GetById(taskId)).ReturnsAsync(toDoModel);
            _mockToDoRepository.Setup(r => r.DeleteAsync(toDoModel)).ReturnsAsync(1);
        
            // Act
            var result = await _service.Delete(taskId);
        
            // Assert
            Assert.That($"Delete Success: 1", Is.EqualTo(result));
        }
    }
}