namespace APVRest.Model
{
    public class Plant
    {
        public int PlantID { get; set; }
        public string Name { get; set; }
        public int DesiredHumidity { get; set; }
        public int WaterTankVolume { get; set; }
        public string IPAddress { get; set; }
        public int UserId { get; set; }
        public string PictureUrl { get; set; }
        public List<Log> LogListe { get; set; }

        public Plant(int PlantID, string Name, int DesiredHumidity, int WaterTankVolume, string IPAddress, int UserId, string PictureUrl)
        {
            this.PlantID = PlantID;
            this.Name = Name;
            this.DesiredHumidity = DesiredHumidity;
            this.WaterTankVolume = WaterTankVolume;
            this.IPAddress = IPAddress;
            this.UserId = UserId;
            this.PictureUrl = PictureUrl;
        }
    }
}
