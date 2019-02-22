using Ninject.Modules;
using SimpleLogger.Helpers;

namespace SimpleLogger
{
    public class DependenciesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IIoHelper>().To<IoHelper>();
            Bind<ILogHelper>().To<LogHelper>();
        }
    }
}
