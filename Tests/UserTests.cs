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

        [TestInitialize]
        public void Start()
        {
            uService = new UserService();
        }

        public void Setup()
        {
            Helpers.NukeTable.NukeSpecificTable<User>();
        }

        [TestMethod()]
        public void GetUserByIdTestExisting()
        {
            Setup();

            uService.CreateUser(new User(1, "UName", "Email@", "Password", "Roskilde"));
            int id = Helpers.GetFirstobjectIDDB.ID();
            Assert.IsNotNull(uService.GetUserById(id));
        }


        [TestMethod()]
        public void GetUserByIdTestInexisting()
        {
            Setup();
            Assert.IsNull(uService.GetUserById(1));
        }

        [TestMethod()]
        public void CreateUserTestAcceptable()
        {
            Setup();
            uService.CreateUser(new User(1, "UName", "Email@","Password", "Roskilde"));
            int id = Helpers.GetFirstobjectIDDB.ID();
            Assert.IsNotNull(uService.GetUserById(id));
        }

        [TestMethod()]
        [DataRow("l", "Emai@l", "Password", "Roskilde")]
        [DataRow("qwertyuqwertyqwertyqwertyu", "Ema@il", "Password", "Roskilde")]
        [DataRow("qwerty", "Email", "Password", "Roskilde")]
        [DataRow("qwerty", "Email@@", "l", "Roskilde")]
        [DataRow("qwerty", "Email@@", "qwertyuqwertyuqwertyqwerty", "Roskilde")]
        [DataRow("qwerty", "Email@@", "Password", "")]

        [ExpectedException(typeof(ArgumentException))]
        public void CreateUserTestUnacceptable( string UName, string Email, string Password, string City)
        {
            Setup();
            uService.CreateUser(new User(UName, Email, Password, City));
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUserTestExistingUser()
        {
            Setup();
            uService.CreateUser(new User(1, "UName", "Email@", "Password", "Roskilde"));
            int id = Helpers.GetFirstobjectIDDB.ID();
            uService.DeleteUser(id);
            Assert.IsNull(uService.GetUserById(id));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DeleteUserTestInexistingUser()
        {
            Setup();
            uService.DeleteUser(1);
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUserTestExistingUser()
        {
            Setup();
            uService.CreateUser(new User(1, "UName", "Email@", "Password", "Roskilde"));
            int id = Helpers.GetFirstobjectIDDB.ID();
            uService.UpdateUser(new User(2, "UName", "Email@", "Password", "Roskilde"), id);
            id = Helpers.GetFirstobjectIDDB.ID();
            Assert.IsNotNull(uService.GetUserById(id));
        }



        [TestMethod()]
        public void LoginUserTestAcceptable()
        {
            Setup();
            uService.CreateUser(new User(1, "UName", "Email@", "Password", "Roskilde"));
            Assert.IsNotNull(uService.LogIn("UName", "Password"));
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]

        public void LoginUserTestUnacceptable()
        {
            Setup();
            uService.LogIn("UName", "r");
            Assert.Fail();
        }




    }
}