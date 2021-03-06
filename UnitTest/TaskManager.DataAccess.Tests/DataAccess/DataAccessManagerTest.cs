﻿using System;
using System.Net;
using NUnit.Framework;
using Task.API.Controllers;
using Task.API;

namespace TaskManager.DataAccess.Tests.DataAccess
{
    [TestFixture]
    public class DataAccessManagerTest
    {
        [Test]
        public void AddTaskTestMethod()
        {
            var data = new Task()
            {
                Parent_ID =1,
                Task1 = "second task sub",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddMonths(2),
                Priority = 2
            };
            Assert.NotNull(DataAccessManager.AddTask(data));
        }
    }
}
