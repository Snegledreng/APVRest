namespace APVRest.Model
{
    public class Plant
    {
        private string _name;
        private int _desiredHumidity;
        private int _waterTankVolume;
        private string _ipAddress;
        private string _pictureUrl;
        private List<Log> _logListe;

        public int UserId;
        public int PlantID;

        

        public List<Log> Logliste
        {
            get => _logListe;
            set => _logListe = value;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value.Length > 19)
                    throw new ArgumentException("Name must be between 2 and 19 characters long (2 and 19 included)");
                _name = value;
            }
        }

        public int DesiredHumidity
        {
            get => _desiredHumidity;
            set
            {
                if (value < 1 || value > 99)
                    throw new ArgumentException("Desiredhumidity must be between 1 and 99");
                _desiredHumidity = value;
            }
        }

        public int WaterTankVolume
        {
            get => _waterTankVolume;
            set
            {
                if (value < 10)
                    throw new ArgumentException("Watertankvolume must be above 10 Ml");
                _waterTankVolume = value;

            }
        }

        public string IPAddress
        {
            get => _ipAddress;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                    throw new ArgumentException("Ipaddress is  incorrect");
                
                _ipAddress = value;

            }
        }

        public string PictureUrl
        {
            get => _pictureUrl;
            set => _pictureUrl = value;
        }

        public Plant(string name, int desiredHumidity, int waterTankVolume, string ipAddress, string pictureUrl, List<Log> logListe, int userId, int plantId)
        {
            _name = name;
            _desiredHumidity = desiredHumidity;
            _waterTankVolume = waterTankVolume;
            _ipAddress = ipAddress;
            _pictureUrl = pictureUrl;
            _logListe = logListe;
            UserId = userId;
            PlantID = plantId;
        }

        public Plant(string name, int desiredHumidity, int waterTankVolume, string ipAddress, string pictureUrl, int userId)
        {
            _name = name;
            _desiredHumidity = desiredHumidity;
            _waterTankVolume = waterTankVolume;
            _ipAddress = ipAddress;
            _pictureUrl = pictureUrl;
            _logListe = new List<Log>();
            UserId = userId;
        }
    }
}
