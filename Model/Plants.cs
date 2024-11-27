namespace APVRest.Model
{
    public class Plants
    {
        public int PlantID { get; set; }
        public string Name { get; set; }
        public int DesiredHumidity { get; set; }
        public int WaterTankVolume { get; set; }
        public string IPAddress { get; set; }
        public int UserId { get; set; }
        public string PicturUrl { get; set; }
        public List<Logs> LogListe { get; set; }

        public Plants(int PlantID, string Name, int DesiredHumidity, int WaterTankVolume, string IPAddress, int UserId, string PicturUrl)
        {
            this.PlantID = PlantID;
            this.Name = Name;
            this.DesiredHumidity = DesiredHumidity;
            this.WaterTankVolume = WaterTankVolume;
            this.IPAddress = IPAddress;
            this.UserId = UserId;
            this.PicturUrl = PicturUrl;
        }
    }
}
