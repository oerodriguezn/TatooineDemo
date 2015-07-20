using log4net;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Logger
    {
        private readonly ILog _logger;

        public Logger(ILog ConcreteLogger)
        {
            _logger = ConcreteLogger;
        }
        ///TODO: Add log to entity validation errors.
        ///TODO: Configure log4net
        public void Log(string Message, Exception ex = null)
        {
            if (ex == null)
                _logger.Info(Message);
            else
            {
                _logger.Error(Message, ex);

                if (ex.InnerException != null)
                {
                    Log(Message + " InnerException ", ex.InnerException);
                }
            }
        }
    }
    public class LogUtil
    {
        public static void Log(string Message, Exception ex = null)
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILog>(new InjectionFactory(factory => log4net.LogManager.GetLogger("root")));
            var log = unityContainer.Resolve<Logger>();
            log.Log(Message, ex);
        }
    }
}
