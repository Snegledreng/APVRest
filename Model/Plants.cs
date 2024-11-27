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

        public Plants()
        {
            
        }
    }
}
