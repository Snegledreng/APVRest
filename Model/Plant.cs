namespace APVRest.Model
{
    public class Plant
    {
        private string _name;
        private int _desiredHumidity;
        private int _waterTankVolume;
        private string _ipAddress;
        private string _pictureUrl;

        public int UserId;
        public List<Log> LogListe;
        public int PlantID;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int DesiredHumidity
        {
            get => _desiredHumidity;
            set => _desiredHumidity = value;
        }

        public int WaterTankVolume
        {
            get => _waterTankVolume;
            set => _waterTankVolume = value;
        }

        public string IPAddress
        {
            get => _ipAddress;
            set => _ipAddress = value;
        }

        public string PictureUrl
        {
            get => _pictureUrl;
            set => _pictureUrl = value;
        }

        public Plant(int plantId, string name, int desiredHumidity, int waterTankVolume, string ipAddress, int userId, string pictureUrl)
        {
            this.PlantID = plantId;
            this.Name = name;
            this.DesiredHumidity = desiredHumidity;
            this.WaterTankVolume = waterTankVolume;
            this.IPAddress = ipAddress;
            this.UserId = userId;
            this.PictureUrl = pictureUrl;
        }
    }
}
