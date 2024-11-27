namespace APVRest.Model
{
    public class Log
    {
        public int LogID { get; set; }
        public int PlantID { get; set; }
        public DateTime Timestamp { get; set; }
        public int Humidity { get; set; }
        public int RemainingWater { get; set; }

        public Log(int LogID, int PlantID, DateTime Timestamp, int Humidity, int RemainingWater)
        {
            this.LogID = LogID;
            this.PlantID = PlantID;
            this.Timestamp = Timestamp;
            this.Humidity = Humidity;
            this.RemainingWater = RemainingWater;
        }
    }
}
