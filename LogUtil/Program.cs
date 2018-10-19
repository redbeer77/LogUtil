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
        }
    }
}
