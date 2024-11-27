using APVRest.Model;

namespace APVRest.IService
{
    public interface ILogService
    {
        public void CreateLog(Logs CreatingLog, int PlantId);

        public void DeleteLog(int logsId, int PlantId);

        public void UpdateLog(Plants UpdateLogs, int LogsId);

        public List<Logs> GetAllLog(int plantId);

        public Logs GetLogById();
    }
}
