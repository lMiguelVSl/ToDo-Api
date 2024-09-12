using NUnit.Framework;
using Moq;
using ToDo.Api.Controllers.V1;
using ToDo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Models.Requests;
using ToDo.Core.Models.Responses;

namespace ToDo.Api.Tests.Controllers
{
    [TestFixture]
    public class ToDosControllerTests
    {
        private Mock<IToDoService> _mockToDoService;
        private ToDosController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockToDoService = new Mock<IToDoService>();
            _controller = new ToDosController();
        }

        [Test]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            _mockToDoService.Setup(x => x.GetAll()).ReturnsAsync(new List<ToDoResponse>());

            // Act
            var result = await _controller.Get(_mockToDoService.Object);
                
            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task Post_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var todoCreateRequest = new ToDoCreateRequest();
            _mockToDoService.Setup(x => x.Create(todoCreateRequest)).ReturnsAsync(new ToDoResponse());

            // Act
            var result = await _controller.Post(_mockToDoService.Object, todoCreateRequest);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
        
        [Test]
        public async Task Put_ReturnsUpdatedAtActionResult()
        {
            // Arrange
            var todoUpdateRequest = new ToDoRequest();
            var todoResponse = new ToDoResponse
            {
                Id = 1,
                Title = "Test",
                IsDone = false
            };
            _mockToDoService.Setup(x => x.Update(todoUpdateRequest)).ReturnsAsync(todoResponse);

            // Act
            var result = await _controller.Put(_mockToDoService.Object, todoUpdateRequest);

            // Assert
            Assert.That(result, Is.Not.Null);
        }
        
        [Test]
        public async Task Delete_ReturnsDeletedAtActionResult()
        {
            // Arrange
            _mockToDoService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(string.Empty);

            // Act
            var result = await _controller.Delete(_mockToDoService.Object, It.IsAny<int>()) as ObjectResult;

            // Assert
            Assert.That(result, Is.Not.Null);
        }

    }
}