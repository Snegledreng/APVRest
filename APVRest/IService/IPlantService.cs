using APVRest.Model;
using System.Collections.Generic;

namespace APVRest.IService
{
    public interface IPlantService
    {
        public void CreatePlant(Plant creatingPlant);

        public bool DeletePlant(int plantId);

        public void UpdatePlant(Plant updatePlant, int plantId);

        public List<Plant> GetAllPlants(int userId);

        public Plant GetPlantById(int plantId);

    }
}
