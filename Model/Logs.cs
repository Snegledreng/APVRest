namespace APVRest.Model
{
    public class Logs
    {
        public int LogID { get; set; }
        public int PlantID { get; set; }
        public DateTime Timestamp { get; set; }
        public int Humidity { get; set; }
        public int RemainingWater { get; set; }

    }
}
