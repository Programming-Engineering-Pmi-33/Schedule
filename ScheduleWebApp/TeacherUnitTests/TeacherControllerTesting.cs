using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Moq;
using ScheduleWebApp;
using ScheduleWebApp.BLL;
using ScheduleWebApp.Controllers;
using ScheduleWebApp.Models;
using System.Collections;
using System.Collections.Generic;

namespace TeacherUnitTests
{
    [TestClass]
    public class TeacherControllerTesting
    {
        [TestMethod]
        public void ProfileNotNull()
        {
            var contextMock = new dfkg9ojh16b4rdContext();
            var service = new TeacherService(contextMock);
            TeacherController controller = new TeacherController(contextMock);
            var teacher = service.GetTeacher(1);
            ActionResult result = controller.Profile(teacher) as ActionResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ProfileEdit()
        {
            var contextMock = new dfkg9ojh16b4rdContext();
            var service = new TeacherService(contextMock);
            TeacherController controller = new TeacherController(contextMock);
            var teacher = service.GetTeacher(1);
            var before = teacher;
            teacher.Name = "Oleh";
            service.Edit(teacher);
            ViewResult result = controller.Show() as ViewResult;
            var after = result.Model;
            Assert.AreNotEqual(before, after);
        }

        [TestMethod]
        public void ProfileViewPassed()
        {
            var contextMock = new dfkg9ojh16b4rdContext();
            var service = new TeacherService(contextMock);
            TeacherController controller = new TeacherController(contextMock);
            var result = controller.Profile(service.GetTeacher(1)) as ViewResult;
            Assert.AreEqual(result.ViewName, "Show");
        }
        [TestMethod]
        public void ProfileViewFaild()
        {
            var contextMock = new dfkg9ojh16b4rdContext();
            var service = new TeacherService(contextMock);
            TeacherController controller = new TeacherController(contextMock);
            var result = controller.Profile() as ViewResult;
            Assert.AreNotEqual(result.ViewName, "Show");
        }

        [TestMethod]
        public void TeacherServicePassed()
        {
            var contextMock = new dfkg9ojh16b4rdContext();
            var service = new TeacherService(contextMock);
            var result=service.GetTeacher(18);

            Assert.AreEqual(result.Name, "Sophia");
        }
        [TestMethod]
        public void TeacherServiceFaild()
        {
            var contextMock = new dfkg9ojh16b4rdContext();
            var service = new TeacherService(contextMock);
            TeacherController controller = new TeacherController(contextMock);
            var newTeacher=new TeacherModel
            {
                Id=19,
                Name="Olha",
                Surname= "Danyliuk",
                Position="Student",
                Password="Qwerty12345"
            };
            service.Teacher = newTeacher;
            ViewResult result = controller.Profile(newTeacher) as ViewResult;
            Assert.IsTrue(result.ViewData.Values.Contains( "User not exist"));
        }
    }
}
