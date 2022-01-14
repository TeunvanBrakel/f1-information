using f1_information_backend;
using f1_information_backend.Controllers;
using f1_information_backend.Database;
using f1_information_backend.Models;
using f1_information_backend.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackendTests
{
    [TestClass]
    public class UserServiceTest
    {


        [TestMethod]
        public async Task Test_If_Create_User_Creates_A_New_User()
        {
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<f1_information_backend.Database.DbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            var username = "test";
            var password = "test123";
            var email = "t@gmail.com";
            User user = new User();
            user.UserName = username;
            user.PassWord = password;
            user.Email = email;

            var service = new f1_information_backend.Services.UserService(mockContext.Object);
            service.AddUser(user);

            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
