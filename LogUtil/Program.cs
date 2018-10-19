using LogUtil.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            LogUtilClass log = new LogUtilClass();

            log.WriteInLog("Example Text");

            string site = "Creating Error";
            object o2 = null;
            try
            {
                int i2 = (int)o2;   // Error  
            }
            catch(Exception e)
            {
                log.WriteError(site, e);
            }

        }
    }
}
