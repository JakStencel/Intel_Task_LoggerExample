using SimpleLogger.Helpers;
using System;
using System.IO;

namespace SimpleLogger.Loggers
{
    public class FileLogger : IBaseLogger
    {
        private readonly IIoHelper _ioHelper;

        public FileLogger(IIoHelper ioHelper)
        {
            _ioHelper = ioHelper;
        }

        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(GetFilePath()))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }

        public string GetFilePath()
        {
            var filePath = _ioHelper.GetStringFromUser("Enter the path of the file ( to save in working directory leave it empty ): ");

            while (!Directory.Exists(filePath))
            {
                if (String.IsNullOrEmpty(filePath))
                {
                    filePath = Directory.GetCurrentDirectory();
                    continue;
                }

                filePath = _ioHelper.GetStringFromUser($"Wrong path, insert the path again: {Environment.NewLine}");
            }
            //format of the date is used on purpose - that the file name to be more readable
            return Path.Combine(filePath, $"Log_From_{DateTime.Now.ToString("M_dd_yyyy_H_mm_ss_tt")}.txt");
        }
    }
}
