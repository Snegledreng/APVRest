using APVRest.Model;
using System.Collections.Generic;

namespace APVRest.IService
{
    public interface IPlantService
    {
        public void CreatePlant(Plants creatingPlant);

        public void DeletePlant(int plantId);

        public void UpdatePlant(Plants updatePlant, int plantId);

        public List<Plants> GetAllPlants(int userId);

        public Plants GetPlantById();

    }
}
