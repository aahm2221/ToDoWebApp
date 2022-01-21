using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToDo;

namespace ToDoTest
{
    [TestClass]
    public class ToDoRepositoryTest
    {
        private IToDoRepository repository;

        [TestInitialize]
        public void testInit()
        {
            repository = new ToDoRepository(string.Empty);
        }

        [TestMethod]
        public void AddTask_ConnectionStringCausesException_ReturnsNull()
        {

            Task actual = repository.AddTask(string.Empty);

            Assert.AreEqual(null, actual);

        }

        [TestMethod]
        public void DeleteTask_ConnectionStringCausesException_DoesNothing()
        {
            repository.DeleteTask(int.MinValue);
        }

        [TestMethod]
        public void GetTasks_ConnectionStringCausesException_ReturnsNull()
        {

            List<Task> actual = repository.GetTasks();

            Assert.AreEqual(null, actual);

        }

        [TestMethod]
        public void ToggleComplete_ConnectionStringCausesException_ReturnsNull()
        {

            Task actual = repository.ToggleComplete(int.MinValue);

            Assert.AreEqual(null, actual);

        }
    }
}