using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class LogUtil
    {
        ///TODO: Add log to entity validation errors.
        ///TODO: Configure log4net
        public static void Log(string Message, Exception ex = null)
        {
            if (ex == null)
                log4net.LogManager.GetLogger("root").Info(Message);
            else
            {
                log4net.LogManager.GetLogger("root").Error(Message, ex);

                if (ex.InnerException != null)
                {
                    Log(Message + " InnerException ", ex.InnerException);
                }
            }
        }
    }
}
