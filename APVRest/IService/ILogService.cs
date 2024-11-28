using APVRest.Model;

namespace APVRest.IService
{
    public interface ILogService
    {
        public void CreateLog(Log log);

        public bool DeleteLog(int plantId, DateTime dateTime);

        public List<Log> GetAllLog(int plantId);

        public Log GetLogById(int plantId, DateTime dateTime);
    }
}
