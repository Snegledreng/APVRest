using Microsoft.VisualStudio.TestTools.UnitTesting;
using APVRest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APVRest.Model;

namespace APVRest.Tests
{
    [TestClass()]
    public class UserTests
    {
        public UserService uService { get; set; }

        public void Setup()
        {
            uService = new UserService();
            Helpers.NukeTable.NukeSpecificTable<User>();
        }

        [TestMethod()]
        public void GetUserByIdTestExisting()
        {
            Setup();
            uService.CreateUser(new User(1, "UName", "Email", "Password", "Roskilde"));
            Assert.IsNotNull(uService.GetUserById(1));
        }


        [TestMethod()]
        public void GetUserByIdTestInexisting()
        {
            Setup();
            Assert.IsNotNull(uService.GetUserById(1));
        }

        [TestMethod()]
        public void CreateUserTestAcceptable()
        {
            Setup();
            uService.CreateUser(new User(1, "UName", "Email","Password", "Roskilde"));
            Assert.IsNotNull(uService.GetUserById(1));
        }

        //[TestMethod()]
        //[DataRow()]
        //[ExpectedException(typeof(ArgumentException))]
        //public void CreateUserTestUnacceptable(int UID, string UName, string Email, string Password, string City)
        //{
        //    Setup();
        //    uService.CreateUser(new User(UID, UName, Email, Password, City));
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void DeleteUserTestExistingUser()
        {
            Setup();
            uService.CreateUser(new User(1, "UName", "Email", "Password", "Roskilde"));
            uService.DeleteUser(1);
            Assert.IsNull(uService.GetUserById(1));
        }

        //[TestMethod()]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void DeleteUserTestInexistingUser()
        //{
        //    Setup();
        //    uService.DeleteUser(1);
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void UpdateUserTestExistingUser()
        {
            Setup();
            uService.CreateUser(new User(1, "UName", "Email", "Password", "Roskilde"));
            uService.UpdateUser(new User(2, "UName", "Email", "Password", "Roskilde"), 1);
            Assert.IsNotNull(uService.GetUserById(2));
        }

        public void UpdateUserTestInexistingUser()
        {
            Setup();
            uService.UpdateUser(new User(2, "UName", "Email", "Password", "Roskilde"), 12);
            Assert.IsNull(uService.GetUserById(2));
        }

        //[TestMethod()]
        //public void GetHttpTest()
        //{
        //    throw new NotImplementedException();
        //}


        //[TestMethod()]
        //public void LogInTest()
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod()]
        //public void LogOutTest()
        //{
        //    throw new NotImplementedException();
        //}

    }
}