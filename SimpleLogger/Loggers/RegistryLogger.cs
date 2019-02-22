using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Loggers
{
    public class RegistryLogger : IBaseLogger
    {
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "Logging_Info_Example";
        const string keyName = userRoot + @"\SOFTWARE\" + subkey;

        public void Log(string message)
        {
            Registry.SetValue(keyName, DateTime.Now.ToString(), message);
        }     
    }
}
