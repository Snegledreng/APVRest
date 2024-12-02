using APVRest.Model;
using APVRest.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APVRest.Tests
{
    [TestClass()]
    public class LogTests
    {
        public PlantService plantService { get; set; }

        public UserService uService { get; set; }

        public LogService logService { get; set; }

        public int PlantId { get; set; }

        [TestInitialize]
        public void Start()
        {
            plantService = new PlantService();

            Helpers.NukeTable.NukeSpecificTable<User>();

            uService = new UserService();

            uService.CreateUser(new User("UName", "Email@", "Password", "Roskilde"));

            int userId = Helpers.GetFirstobjectIDDB.ID();

            plantService.CreatePlant(new Plant("Sunflower", 30, 1000, "192.234.46.55", "www.billede.dk",userId));

            PlantId = plantService.GetAllPlants(userId).First().PlantID;

            logService = new LogService();

        }

        public void Setup()
        {
            Helpers.NukeTable.NukeSpecificTable<Log>();
        }

        [TestMethod()]
        public void GetLogByIdTestExisting()
        {
            Setup();           
            logService.CreateLog(new Log(PlantId, new DateTime(10/ 12/02/2024) , 20, 200));
            Assert.IsNotNull(logService.GetLogById(PlantId, new DateTime(10 / 12 / 02 / 2024)));
        }


        [TestMethod()]
        public void GetLogByIdTestInexisting()
        {
            Setup();
            Assert.IsNull(logService.GetLogById(1, DateTime.Now));
        }

        [TestMethod()]
        public void CreateLOgTestAcceptable()
        {
            Setup(); 
            logService.CreateLog(new Log(PlantId, new DateTime(10 / 12 / 02 / 2024), 20, 200));
            Assert.IsNotNull(logService.GetLogById(PlantId, new DateTime(10 / 12 / 02 / 2024)));
        }


        [TestMethod()]
        public void GetAllLogTest()
        {
            Setup();
            int numberbefore = logService.GetAllLog(PlantId).Count();
            logService.CreateLog(new Log(PlantId, new DateTime(10 / 12 / 02 / 2024), 20, 200));
            Assert.AreEqual(numberbefore + 1, logService.GetAllLog(PlantId).Count());
        }

        [TestMethod()]
        public void DeleteLogTestExistingPlant()
        {
            Setup();
            logService.CreateLog(new Log(PlantId, new DateTime(10 / 12 / 02 / 2024), 20, 200));
            logService.DeleteLog(PlantId, new DateTime(10 / 12 / 02 / 2024));
            Assert.IsNull(logService.GetLogById(PlantId, new DateTime(10 / 12 / 02 / 2024)));
        }

        [TestMethod()]

        [ExpectedException(typeof(ArgumentException))]

        public void DeleteLogTestInexistingPlant()
        {
            Setup();
            logService.DeleteLog(PlantId, new DateTime(10 / 12 / 02 / 2024));
            Assert.Fail();
        }


    }
}