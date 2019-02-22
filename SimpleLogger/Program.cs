using Ninject;
using SimpleLogger.Helpers;
using System;

namespace SimpleLogger
{
    internal class Program
    {
        private readonly IIoHelper _ioHelper;
        private readonly ILogHelper _logHelper;

        public Program(IIoHelper ioHelper, ILogHelper logHelper)
        {
            _ioHelper = ioHelper;
            _logHelper = logHelper;
        }

        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new DependenciesModule());
            var program = kernel.Get<Program>();
            program.Run();
        }

        private void Run()
        {
            var dataToBeLoggedFromUser = _ioHelper.GetDataToBeLogged("Please, insert some data to be logged (then press enter):");

            //here I could have a list or collection on targets and enumerate through them
            var loggerFromUser = _ioHelper.GetStringFromUser($"Choose the logger from given below: " +
                                                                           $"{Environment.NewLine}\tFile" +
                                                                           $"{Environment.NewLine}\tRegistry"+
                                                                           $"{Environment.NewLine}\tEventLog");
            var chosenLogger = _logHelper.ChooseLogger(loggerFromUser);

            try
            {
                chosenLogger.Log(dataToBeLoggedFromUser);
            }
            catch(Exception e)
            {
                _ioHelper.PrintMessage($"Error occured: {e.Message}");
                return;
            }
        }
    }
}
