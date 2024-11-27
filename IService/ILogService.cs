using APVRest.Model;

namespace APVRest.IService
{
    public interface ILogService
    {
        public void CreateLog(Logs creatingLog, int plantId);

        public void DeleteLog(int logsId, int plantId);

        public void UpdateLog(Plants updateLogs, int logsId);

        public List<Logs> GetAllLog(int plantId);

        public Logs GetLogById();
    }
}
