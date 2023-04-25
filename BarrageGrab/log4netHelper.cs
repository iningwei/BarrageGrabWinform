using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrageGrab
{
    public class log4netHelper
    {
        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("InfoLog");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">错误日志</param>
        public static void Error(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Error");
            if (log.IsInfoEnabled)
            {
                log.Error(message);
            }
            log = null;
        }
    }
}
