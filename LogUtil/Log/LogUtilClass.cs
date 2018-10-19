using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;

namespace LogUtil.Log
{
    public class LogUtilClass
    {
        private string nombreLog;
        private string rutaLog;
        private string path;
        private DateTime init = DateTime.Now;
        private DateTime end = DateTime.Now;

        ~LogUtilClass()
        {
            this.EndLog();
        }

        public LogUtilClass()
        {
            NameValueCollection config = ConfigurationManager.GetSection("Rutes") as NameValueCollection;
            if (config != null)
            {
                rutaLog = config["Log"].ToString();
            }
            config = ConfigurationManager.GetSection("Names") as NameValueCollection;
            if (config != null)
            {
                nombreLog = config["Log"].ToString();
            }

            path = rutaLog + nombreLog;

            FileStream fs = File.OpenWrite(rutaLog + nombreLog);
            fs.Close();
            this.InitLog();
        }

        private void PrintMessage(string texto)
        {
            if (File.ReadAllText(path).Length > 0)
            {
                File.AppendAllText(path, Environment.NewLine + texto, Encoding.UTF8);
            }
            else
            {
                File.AppendAllText(path, texto, Encoding.UTF8);
            }
        }
        private void InitLog()
        {
            this.PrintMessage("Init " + DateTime.Now.ToString());
        }
        private void EndLog()
        {
            this.WriteInLog("Total: " + (end - init).ToString());
            this.PrintMessage("End " + DateTime.Now.ToString());
        }

        public void WriteInLog(string text)
        {

            PrintMessage(String.Format("\t{0}", text));
        }

    }
}
