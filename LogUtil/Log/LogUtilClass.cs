using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;

namespace LogUtil.Log
{
    public class LogUtilClass
    {
        private string logName;
        private string logRoute;
        private string path;
        private DateTime init = DateTime.Now;
        NameValueCollection config;
        private bool totalTime;
       
        //endlog is called on destruction
        ~LogUtilClass(){
            this.EndLog();
        }

        public LogUtilClass(bool totalTime=true)
        {
            //obtains route to appconfig
            config = ConfigurationManager.GetSection("Rutes") as NameValueCollection;
            if (config != null) {logRoute = config["Log"].ToString();}

            //obtains log filename to appconfig
            config = ConfigurationManager.GetSection("Names") as NameValueCollection;
            if (config != null){logName = config["Log"].ToString();}

            //Log path
            path = logRoute + logName;

            //if no exist create them
            FileStream fs = File.OpenWrite(path);
            
            //close file
            fs.Close();

            this.totalTime = totalTime;

            //write first Log line
            this.InitLog();
        }
        //basic print message
        private void PrintMessage(string text)
        {
            if (File.ReadAllText(path).Length > 0)
            {
                File.AppendAllText(path, Environment.NewLine + text, Encoding.UTF8);
            }
            else
            {
                File.AppendAllText(path, text, Encoding.UTF8);
            }
        }
        //First log line
        private void InitLog()
        {
            this.PrintMessage("Init " + init.ToString());
        }
        //Last line, endlog is called on destruction
        private void EndLog()
        {
            if(this.totalTime)
            this.WriteInLog("Total: " + (DateTime.Now - init).ToString());

            this.PrintMessage("End " + DateTime.Now.ToString());
        }
        public void WriteInLog(string text)
        {
            PrintMessage(String.Format("\t{0}", text));
        }
        public void WriteError(string site , string exception)
        {
            this.WriteInLog( "Error in " + site + ": " + String.Format("\t{0}", exception));
        }
    }
}
