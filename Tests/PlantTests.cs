using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APVRest.Model;
using APVRest.Service;
using Microsoft.Identity.Client;

namespace APVRest.Tests
{
    [TestClass()]
    public class PlantTests
    {
        public PlantService plantService { get; set; }

        public UserService uService { get; set; }

        public int userId { get; set; }

        [TestInitialize]
        public void Start()
        {
            plantService = new PlantService();

            Helpers.NukeTable.NukeSpecificTable<User>();

            uService = new UserService();

            uService.CreateUser(new User("UName", "Email@", "Password", "Roskilde"));

            userId = Helpers.GetFirstobjectIDDB.ID();
        }

        public void Setup()
        {
            Helpers.NukeTable.NukeSpecificTable<Plant>();
        }

        [TestMethod()]
        public void GetPlantByIdTestExisting()
        {
            Setup();

            plantService.CreatePlant(new Plant("Sunflower", 30, 1000, "192.234.46.55", "www.billede.dk",userId)); 

            int plantId = plantService.GetAllPlants(userId).First().PlantID;

            Assert.IsNotNull(plantService.GetPlantById(plantId));
        }


        [TestMethod()]
        public void GetPlantByIdTestInexisting()
        {
            Setup();
            Assert.IsNull(plantService.GetPlantById(1));
        }

        [TestMethod()]
        public void CreateUserTestAcceptable()
        {
            Setup();
            plantService.CreatePlant(new Plant("Sunflower", 30, 1000, "192.234.46.55", "www.billede.dk", userId));

            Assert.IsNull(plantService.GetPlantById(1));
        }

        [TestMethod()]
        [DataRow("n", 30, 1000, "192.234.46.55", "www.billede.dk")]
        [DataRow("qwertyqwertyqwertyqw", 30, 1000, "192.234.46.55", "www.billede.dk")]
        [DataRow("Sunflower", -1, 1000, "192.234.46.55", "www.billede.dk")]
        [DataRow("Sunflower", 101, 1000, "192.234.46.55", "www.billede.dk")]
        [DataRow("Sunflower", 30, 9, "192.234.46.55", "www.billede.dk")]
        [DataRow("Sunflower", 30, 1000, "", "www.billede.dk")]



        [ExpectedException(typeof(ArgumentException))]

        public void CreateUserTestUnacceptable(string name, int desiredHumidity, int waterTankVolume, string ipAdress,
            string pictureUrl)
        {
            Setup();
            plantService.CreatePlant(new Plant(name, desiredHumidity, waterTankVolume, ipAdress, pictureUrl, userId));
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllPlantsTest()
        {
            Setup();
            int numberbefore = plantService.GetAllPlants(userId).Count();

            plantService.CreatePlant(new Plant("Sunflower", 30, 1000, "192.234.46.55", "www.billede.dk", userId));

            
            Assert.AreEqual(numberbefore + 1, plantService.GetAllPlants(userId).Count());
        }
        
    [TestMethod()]
        public void DeletePlantTestExistingPlant()
        {
            Setup();
            plantService.CreatePlant(new Plant("Sunflower", 30, 1000, "192.234.46.55", "www.billede.dk", userId));

            int plantId = plantService.GetAllPlants(userId).First().PlantID;
            
            plantService.DeletePlant(plantId);
            
            Assert.IsNull(plantService.GetPlantById(plantId));
        }

        [TestMethod()]
        
        [ExpectedException(typeof(Exception))]
        
        public void DeletePlantTestInexistingPlant()
        {
            Setup();
            plantService.DeletePlant(1);
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdatePlantTestExistingPlant()
        {
            Setup();
            
            plantService.CreatePlant(new Plant("Sunflower", 30, 1000, "192.234.46.55", "www.billede.dk", userId));
            
            int plantId = plantService.GetAllPlants(userId).First().PlantID;
            
            plantService.UpdatePlant(new Plant("Tomato", 30, 1000, "192.234.46.55", "www.billede.dk", userId),plantId);
            
            Assert.AreEqual(plantService.GetPlantById(plantId).Name,"Tomato");
        }

        public void UpdatePlantTestInexistingPlant()
        {
            Setup();
            
            plantService.UpdatePlant(new Plant("Tomato", 30, 1000, "192.234.46.55","www.billede.dk", userId),2);
            
            Assert.IsNull(plantService.GetPlantById(2));
        }
    }
}