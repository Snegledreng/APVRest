namespace APVRest.Model
{
    public class Log
    {
        private int _plantid;
        private DateTime _timestamp;
        private int _humidity;
        private int _remainingWater;


        public int Plantid
        {
            get { return _plantid; }
            set { _plantid = value; }
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = Helpers.DateTimeExpansion.RoundDownToHour(value); }
        }

        public int Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
        }

        public int Remainingwater
        {
            get { return _remainingWater; }
            set { _remainingWater = value; }
        }



        public Log(int plantID, DateTime timestamp, int humidity, int remainingWater)
        {
            Plantid = plantID;
            this._timestamp = timestamp;
            this._humidity = humidity;
            this._remainingWater = remainingWater;
        }
    }
}
