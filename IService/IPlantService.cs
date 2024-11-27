using APVRest.Model;
using System.Collections.Generic;

namespace APVRest.IService
{
    public interface IPlantService
    {
        public void CreatePlant(Plants CreatingPlant);

        public void DeletePlant(int PlantId);

        public void UpdatePlant(Plants UpdatePlant, int PlantId);

        public List<Plants> GetAllPlants(int UserId);

        public Plants GetPlantById();

    }
}
