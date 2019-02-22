using SimpleLogger.Loggers;

namespace SimpleLogger.Helpers
{
    public interface ILogHelper
    {
        IBaseLogger ChooseLogger(string logger);
    }

    public class LogHelper : ILogHelper
    {
        private IBaseLogger logger;
        private readonly IIoHelper _ioHelper;

        public LogHelper(IIoHelper ioHelper)
        {
            _ioHelper = ioHelper;
        }

        public IBaseLogger ChooseLogger(string loggerFromUser)
        {
            switch (loggerFromUser)
            {
                case "File":
                    logger = new FileLogger(_ioHelper);
                    break;
                case "Registry":
                    logger = new RegistryLogger();
                    break;
                case "EventLog":
                    logger = new EventLogger();
                    break;
                default:
                    _ioHelper.PrintMessage("Wrong format of logger");
                    break;
            }
            return logger;
        }

    }
}
