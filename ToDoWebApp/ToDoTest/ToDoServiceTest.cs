using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using ToDo;
using ToDo.Service;

namespace ToDoTest
{
    [TestClass]
    public class ToDoServiceTest
    {
        private IToDoRepository toDoRepository;
        private IToDoService toDoService;

        [TestInitialize]
        public void testInit()
        {
            toDoRepository = Mock.Create<IToDoRepository>();
            toDoService = new ToDoService(toDoRepository);
        }

        [TestCleanup]
        public void testCleanup()
        {
            toDoRepository = null;
        }

        [TestMethod]
        public void AddTask_CallsRepository_ReturnsAddedTask()
        {

            Mock.Arrange(() => toDoRepository.AddTask(Arg.IsAny<string>())).Returns((string description) => 
                new ToDo.Task
                {
                    Description = description
                }) ;

            var actual = toDoService.AddTask("description");


            Assert.AreEqual("description", actual.Description);
        }

        [TestMethod]
        public void DeleteTask_CallsRepository()
        {
            Mock.Arrange(() => toDoRepository.DeleteTask(Arg.IsAny<int>())).OccursOnce();

            toDoService.DeleteTask(1);

            Mock.Assert(() => toDoRepository.DeleteTask(Arg.IsAny<int>()), Occurs.Once());
        }

        [TestMethod]
        public void GetTasks_CallsRepository_ReturnsTasks()
        {
            Mock.Arrange(() => toDoRepository.GetTasks()).Returns(new List<ToDo.Task>());

            var actual = toDoService.GetTasks();

            CollectionAssert.AreEqual(new List<ToDo.Task>(), actual);
        }

        [TestMethod]
        public void ToggleComplete_CallsReposiory_ReturnsTask()
        {
            Mock.Arrange(() => toDoRepository.ToggleComplete(Arg.IsAny<int>())).Returns((int id) =>
                new ToDo.Task
                {
                    Id = id
                });

            ToDo.Task actual = toDoService.ToggleComplete(1);

            Assert.AreEqual(1, actual.Id);
        }
    }
}
